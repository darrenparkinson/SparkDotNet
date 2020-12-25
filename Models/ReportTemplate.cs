using System;

namespace SparkDotNet {
    public class ReportTemplate
    {
        /// <summary>
        /// unique identifier representing a report
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the template
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The service to which the report belongs
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Maximum date range for reports belonging to this template
        /// </summary>
        public int MaxDays { get; set; }

        /// <summary>
        /// Generated reports belong to which field
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Validation Rules Collection
        /// </summary>
        public ReportTemplateValidation[] Validations { get; set; }
    }
}