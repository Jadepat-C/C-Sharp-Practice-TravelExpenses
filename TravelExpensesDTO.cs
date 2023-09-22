using System.Globalization;
using System.Reflection;

namespace TravelEx
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for travel expenses.
    /// </summary>
    public class TravelExpensesDTO
    {
        // Used column
        // Generate id field for PK
        /// <summary>
        /// Gets or sets the ID of the travel expense.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the reference number of the travel expense.
        /// </summary>
        public string? ref_number { get; set; } = "";

        /// <summary>
        /// Gets or sets the title (English) of the travel expense.
        /// </summary>
        public string? title_en { get; set; } = "";

        /// <summary>
        /// Gets or sets the purpose (English) of the travel expense.
        /// </summary>
        public string? purpose_en { get; set; } = "";

        /// <summary>
        /// Gets or sets the start date of the travel expense.
        /// </summary>
        public string? start_date { get; set; }

        /// <summary>
        /// Gets or sets the end date of the travel expense.
        /// </summary>
        public string? end_date { get; set; }

        /// <summary>
        /// Gets or sets the airfare cost of the travel expense.
        /// </summary>
        public double? airfare { get; set; }

        /// <summary>
        /// Gets or sets the other transport cost of the travel expense.
        /// </summary>
        public double? other_transport { get; set; }

        /// <summary>
        /// Gets or sets the meals cost of the travel expense.
        /// </summary>
        public double? meals { get; set; }

        /// <summary>
        /// Gets or sets the other expenses cost of the travel expense.
        /// </summary>
        public double? other_expenses { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the travel expense.
        /// </summary>
        public double? total { get; set; }

        // Unused Column
        /// <summary>
        /// Gets or sets the name of the travel expense.
        /// </summary>
        public string? name { get; set; }
        
        /// <summary>
        /// Gets or sets the disclosure group of the travel expense.
        /// </summary>
        public string? disclosure_group { get; set; }

        /// <summary>
        /// Gets or sets the title (France) of the travel expense.
        /// </summary>
        public string? title_fr { get; set; }

        /// <summary>
        /// Gets or sets the purpose (France) of the travel expense.
        /// </summary>
        public string? purpose_fr { get; set; }

        /// <summary>
        /// Gets or sets the destination (English) of the travel expense.
        /// </summary>
        public string? destination_en { get; set; }

        /// <summary>
        /// Gets or sets the destination (France) of the travel expense.
        /// </summary>
        public string? destination_fr { get; set; }

        /// <summary>
        /// Gets or sets the lodging of the travel expense.
        /// </summary>
        public double? lodging { get; set; }

        /// <summary>
        /// Gets or sets the additional comments (English) of the travel expense.
        /// </summary>
        public string? additional_comments_en { get; set; }

        /// <summary>
        /// Gets or sets the additional comments (France) of the travel expense.
        /// </summary>
        public string? additional_comments_fr { get; set; }

        /// <summary>
        /// Gets or sets the owner organization of the travel expense.
        /// </summary>
        public string? owner_org { get; set; }

        /// <summary>
        /// Gets or sets the owner organization title of the travel expense.
        /// </summary>
        public string? owner_org_title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDTO"/> class.
        /// </summary>
        public TravelExpensesDTO() { }
    }
}
