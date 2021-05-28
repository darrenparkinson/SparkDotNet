
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string reportTemplateBase = "/v1/report/templates";

        /// <summary>
        /// List all the available report templates that can be generated.
        /// CSV reports for Teams services are only supported for organizations based in the North American region.
        /// Organizations based in a different region will return blank CSV files for any Teams reports.
        /// <returns>List of Report Template objects.</returns>
        public async Task<List<ReportTemplate>> GetReportTemplatesAsync()
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL(reportTemplateBase, queryParams);
            return await GetItemsAsync<ReportTemplate>(path);
        }
   }

}