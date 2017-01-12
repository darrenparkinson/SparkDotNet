﻿using System.Collections.Generic;
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

namespace SparkDotNet
{
    public partial class Spark
    {
        private string accessToken { get; set; }
        private static string baseURL = "https://api.ciscospark.com";

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
            T returnItem = (T)System.Activator.CreateInstance(typeof(T));
            var jsonBody = JsonConvert.SerializeObject(bodyParams);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                returnItem = DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                //TODO: Throw Exception or error if we get one.
                //throw new System.Exception($"Received Status Code: {response.StatusCode.ToString()}");

            }
            return returnItem;

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
            T returnItem = (T)System.Activator.CreateInstance(typeof(T));
            var jsonBody = JsonConvert.SerializeObject(bodyParams);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                returnItem = DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {

            }
            return returnItem;
        }
        private async Task<T> GetItemAsync<T>(string path)
        {
            T returnItem = (T)System.Activator.CreateInstance(typeof(T));
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                returnItem = DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                //TODO: Throw Exception or error if we get one.
                //throw new System.Exception($"Received Status Code: {response.StatusCode.ToString()}");

            }
            return returnItem;
        }

        private async Task<List<T>> GetItemsAsync<T>(string path)
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                JObject requestResult = JObject.Parse(await response.Content.ReadAsStringAsync());
                List<JToken> results = requestResult["items"].Children().ToList();
                foreach (JToken result in results)
                {
                    T item = DeserializeObject<T>(result.ToString());
                    items.Add(item);
                }
            }
            else
            {
                //TODO: Throw Exception or error if we get one.
                //throw new System.Exception($"Received Status Code: {response.StatusCode.ToString()}");

            }

            return items;
        }

        public async Task<PaginationResult<T>> GetItemsWithLinksAsync<T>(string path)
        {
            PaginationResult<T> paginationResult = new PaginationResult<T>();
            List<T> items = new List<T>();
            Links links = new Links();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
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
                    if (link != null && !"".Equals(link)) {
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
            }
            else
            {
                //TODO: Throw Exception or error if we get one.
                //throw new System.Exception($"Received Status Code: {response.StatusCode.ToString()}");

            }

            //return new Tuple<List<T>, Links>(items, links);
            return paginationResult;
        }

        #endregion

    }
}
