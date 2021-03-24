using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using static System.Net.WebUtility;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace SparkDotNet
{
    public partial class Spark
    {
        private string accessToken { get; set; }
        private static string baseURL = "https://webexapis.com";

        private HttpClient client = new HttpClient();

        public Spark(string accessToken)
        {
            this.accessToken = accessToken;
            client.BaseAddress = new System.Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
        }

        #region Private Helper Methods

        private async Task<bool> DeleteItemAsync(string path)
        {
            HttpResponseMessage response = await client.DeleteAsync(path);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<T> PostItemAsync<T>(string path, Dictionary<string, object> bodyParams)
        {
            HttpContent content;

            if (bodyParams.ContainsKey("files") && IsLocalPath(bodyParams["files"]))
            {
                MultipartFormDataContent multiPartContent = new MultipartFormDataContent("----SparkDotNetBoundary");
                string[] filelist = (string[])bodyParams["files"];
                bodyParams.Remove("files");
                foreach (KeyValuePair<string, object> kv in bodyParams)
                {
                    StringContent stringContent = new StringContent((string)kv.Value);
                    multiPartContent.Add(stringContent, kv.Key);
                }
                foreach (string file in filelist)
                {
                    FileInfo fi = new FileInfo(file);
                    string fileName = fi.Name;
                    byte[] fileContents = File.ReadAllBytes(fi.FullName);
                    ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
                    byteArrayContent.Headers.Add("Content-Type", MimeTypes.GetMimeType(fileName));
                    multiPartContent.Add(byteArrayContent, "files", fileName);
                }
                content = multiPartContent;
            }
            else
            {
                string jsonBody = "";
                if (bodyParams.ContainsKey("attachments"))
                {
                    var attachments = JObject.Parse((string)bodyParams["attachments"]);
                    bodyParams.Remove("attachments");
                    var jsonParams = JsonConvert.SerializeObject(bodyParams);
                    var json = JObject.Parse(jsonParams);
                    json["attachments"] = attachments;
                    jsonBody = JsonConvert.SerializeObject(json);
                }
                else
                {
                    jsonBody = JsonConvert.SerializeObject(bodyParams);
                }
                content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await client.PostAsync(path, content);
            await CheckForErrorResponse(response);

            return DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private string getURL(string path, Dictionary<string, string> dict)
        {
            UriBuilder uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Path = path;
            string queryString = "";
            if (dict.Count > 0)
            {
                foreach (KeyValuePair<string, string> kv in dict)
                {
                    queryString += UrlEncode(kv.Key);
                    queryString += "=";
                    queryString += UrlEncode(kv.Value);
                    queryString += "&";
                }
            }
            uriBuilder.Query = queryString;
            return uriBuilder.Uri.PathAndQuery;
        }

        private async Task<T> UpdateItemAsync<T>(string path, Dictionary<string, object> bodyParams)
        {
            var jsonBody = JsonConvert.SerializeObject(bodyParams);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(path, content);
            await CheckForErrorResponse(response);

            return DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private async Task<T> GetItemAsync<T>(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            await CheckForErrorResponse(response);

            return DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private async Task<List<T>> GetItemsAsync<T>(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            await CheckForErrorResponse(response);

            List<T> items = new List<T>();
            JObject requestResult = JObject.Parse(await response.Content.ReadAsStringAsync());
            List<JToken> results = requestResult["items"].Children().ToList();
            foreach (JToken result in results)
            {
                T item = DeserializeObject<T>(result.ToString());
                items.Add(item);
            }
            return items;
        }

        private static bool IsLocalPath(object files)
        {
            string[] filelist = (string[])files;
            var p = filelist[0];
            try
            {
                return new System.Uri(p).IsFile;
            }
            catch (Exception)
            {
                return true; // assume it's a local file if we can't create a URI out of it...
            }
        }
        #endregion

        public async Task<PaginationResult<T>> GetItemsWithLinksAsync<T>(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            await CheckForErrorResponse(response);

            PaginationResult<T> paginationResult = new PaginationResult<T>();
            List<T> items = new List<T>();
            Links links = new Links();
            JObject requestResult = JObject.Parse(await response.Content.ReadAsStringAsync());
            List<JToken> results = requestResult["items"].Children().ToList();
            foreach (JToken result in results)
            {
                T item = DeserializeObject<T>(result.ToString());
                items.Add(item);
            }
            if (response.Headers.Contains("Link"))
            {
                var link = response.Headers.GetValues("Link").FirstOrDefault();
                if (link != null && !"".Equals(link))
                {
                    // borrowed regex from spark-java-sdk https://github.com/ciscospark/spark-java-sdk/blob/master/src/main/java/com/ciscospark/LinkedResponse.java
                    Regex r = new Regex("\\s*<(\\S+)>\\s*;\\s*rel=\"(\\S+)\",?", RegexOptions.Compiled);
                    MatchCollection regmatch = r.Matches(link);
                    foreach (Match item in regmatch)
                    {
                        var linktype = item.Groups[2].ToString().ToLower();
                        Uri linkUrl = new Uri(item.Groups[1].ToString());

                        switch (linktype)
                        {
                            case "next":
                                links.Next = linkUrl.PathAndQuery;
                                break;
                            case "prev":
                                links.Prev = linkUrl.PathAndQuery;
                                break;
                            case "first":
                                links.First = linkUrl.PathAndQuery;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            paginationResult.Items = items;
            paginationResult.Links = links;

            return paginationResult;
        }

        private async Task CheckForErrorResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            SparkErrorContent errorContent = DeserializeObject<SparkErrorContent>(await response.Content.ReadAsStringAsync());
            string errorMessage = errorContent?.Message ?? response.ReasonPhrase;
            throw new SparkException((int)response.StatusCode, errorMessage, errorContent, response.Headers);
        }
    }
}
