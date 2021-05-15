using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string reportBase = "/v1/reports";

        /// <summary>
        /// Lists all reports. Use query parameters to filter the response. The parameters are optional.
        /// However, 'from' and 'to' parameters should be provided together.
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// </summary>
        /// <param name="reportId">List reports by ID.</param>
        /// <param name="service">List reports which use this service.</param>
        /// <param name="templateId">List reports with this report template ID.</param>
        /// <param name="from">List reports that were created on or after this date.</param>
        /// <param name="to">List reports that were created before this date.</param>
        /// <returns>List of Report  objects.</returns>
        public async Task<List<Report>> GetReportsAsync(string reportId = null, string service = null,
                                                        string templateId = null, DateTime? from = null,
                                                        DateTime? to = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (reportId != null) queryParams.Add("reportId", reportId);
            if (service != null) queryParams.Add("service", service);
            if (templateId != null) queryParams.Add("templateId", templateId);
            if (from != null) queryParams.Add("from", ((DateTime)from).ToString("yyyy-MM-dd"));
            if (to != null) queryParams.Add("to", ((DateTime)from).ToString("yyyy-MM-dd"));
            var path = getURL(reportBase, queryParams);
            return await GetItemsAsync<Report>(path);
        }

        /// <summary>
        /// Shows details for a report, by report ID.
        /// Specify the report ID in the reportId parameter in the URI.
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// </summary>
        /// <param name="reportId">The unique identifier for the report.</param>
        /// <returns>The report object</returns>
        public async Task<Report> GetReportAsync(string reportId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{reportBase}/{reportId}", queryParams);
            return await GetItemAsync<Report>(path);
        }

        /// <summary>
        /// Create a new report.
        /// For each templateId, there are a set of validation rules that need to be followed.
        /// For example, for templates belonging to Webex, the user needs to provide siteUrl.
        /// These validation rules can be retrieved via the Report Templates API.
        /// The 'templateId' parameter is a number.
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// </summary>
        /// <param name="templateId">Unique ID representing valid report templates</param>
        /// <param name="startDate">Data in the report will be from this date onwards</param>
        /// <param name="endDate">Data in the report will be till this date</param>
        /// <param name="siteList">Sites belonging to user's organization. This attribute is needed for site-based templates</param>
        /// <returns>A report object</returns>
        public async Task<Report> CreateReportAsync(int templateId, DateTime? startDate = null, DateTime? endDate = null, string siteList = null)
        {
            var bodyParams = new Dictionary<string, object>();
            bodyParams.Add("templateId", templateId);
            if (startDate != null) bodyParams.Add("startDate", ((DateTime)startDate).ToString("yyyy-MM-dd"));
            if (endDate != null) bodyParams.Add("endDate", ((DateTime)endDate).ToString("yyyy-MM-dd"));
            if (siteList != null) bodyParams.Add("siteList", siteList);

            return await PostItemAsync<Report>($"{reportBase}", bodyParams);
        }

        /// <summary>
        /// Remove a report from the system.
        /// Specify the report ID in the reportId parameter in the URI
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// </summary>
        /// <param name="reportId">The unique identifier for the report</param>
        /// <returns>true if Report was deleted, false otherwise</returns>
        public async Task<bool> DeleteReportAsync(string reportId)
        {
            return await DeleteItemAsync($"{reportBase}/{reportId}");
        }

        /// <summary>
        /// Remove a report from the system.
        /// Specify the report ID in the reportId parameter in the URI
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// </summary>
        /// <param name="report">The report object to be deleted</param>
        /// <returns>true if Report was deleted, false otherwise</returns>
        public async Task<bool> DeleteReportAsync(Report report)
        {
            return await DeleteReportAsync(report.Id);
        }

        /// <summary>
        /// Downloads a report
        /// </summary>
        /// <param name="reportUrl">The URL of the report</param>
        /// <returns>The CSV Report</returns>
        public async Task<string> DownloadReport(string reportUrl)
        {
            HttpResponseMessage response = await client.GetAsync(reportUrl);

            await CheckForErrorResponse(response);

            return await response.Content.ReadAsStringAsync();
        }
   }

}