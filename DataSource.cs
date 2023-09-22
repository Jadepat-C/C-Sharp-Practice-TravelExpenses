using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Reflection.PortableExecutable;
using CsvHelper.Configuration;
using System;
using System.IO;
using System.Xml.Serialization;

namespace TravelEx
{
    /// <summary>
    /// Represents a data source for travel expenses using Singleton Pattern.
    /// </summary>
    public class DataSource
    {
        private string filePath = @".\dataset\travelq.csv";
        private List<TravelExpensesDTO> expensesDataset;

        // Private static instance of the class
        private static DataSource instance;

        /// <summary>
        /// Private constructor to prevent external instantiation
        /// </summary>
        private DataSource()
        {
            ImportDataset();
        }

        /// <summary>
        /// Gets the single instance of the DataSource class.
        /// </summary>
        /// <returns>The DataSource instance.</returns>
        public static DataSource GetInstance()
        {
            if (instance == null)
            {
                instance = new DataSource();
            }
            return instance;
        }
        /// <summary>
        /// Private method importing CSV file into List
        /// </summary>
        private void ImportDataset()
        {
            if (expensesDataset == null)
            {
                // Read the CSV file and map it to the TravelExpensesDTO class
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {

                    csv.Context.RegisterClassMap<CsvRecordMap>();
                    var records = csv.GetRecords<TravelExpensesDTO>().ToList();

                    // Declare variables before go into the loop to optimize program
                    // Used Column
                    int id = 0;
                    string refNeumberValue;
                    string? titleValue;
                    string? purposeValue;
                    DateTime? startDateValue;
                    DateTime? endDateValue;
                    double? airfareValue;
                    double? otherTransportValue;
                    double? mealsValue;
                    double? otherExpensesValue;
                    double? totalValue;

                    //Unused Column
                    string? name;
                    string? disclosureGroup;
                    string? titleFr;
                    string? purposeFr;
                    string? destinationEn;
                    string? destinationFr;
                    double? lodging;
                    string? addtitionalCommentEn;
                    string? addtitionalCommentFr;
                    string? ownerOrg;
                    string? ownerOrgTitle;

                    expensesDataset = new List<TravelExpensesDTO>();

                    // Access the data and save it into variables
                    foreach (var record in records)
                    {
                        id++;
                        record.id = id;
                        refNeumberValue = record.ref_number;
                        disclosureGroup = record.disclosure_group; // Unused
                        titleValue = record.title_en;
                        titleFr = record.title_fr; // Unused
                        name = record.name; // Unused
                        purposeValue = record.purpose_en;
                        purposeFr = record.purpose_fr; // Unused
                                                       // Try to pharse string to datetime
                        if (DateTime.TryParseExact(record.start_date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startResult))
                        {
                            startDateValue = startResult;
                        }
                        else
                        {
                            startDateValue = null;
                        }
                        if (DateTime.TryParseExact(record.end_date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endResult))
                        {
                            endDateValue = endResult;
                        }
                        else
                        {
                            endDateValue = null;
                        }
                        destinationEn = record.destination_en; // Unused
                        destinationFr = record.destination_fr; // Unused
                        airfareValue = record.airfare;
                        otherTransportValue = record.other_transport;
                        lodging = record.lodging; // Unused
                        mealsValue = record.meals;
                        otherExpensesValue = record.other_expenses;
                        totalValue = record.total;

                        // Import unused columns
                        addtitionalCommentEn = record.additional_comments_en;
                        addtitionalCommentFr = record.additional_comments_fr;
                        ownerOrg = record.owner_org;
                        ownerOrgTitle = record.owner_org_title;

                        expensesDataset.Add(record);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the travel expenses dataset.
        /// </summary>
        /// <returns>The list of travel expenses.</returns>
        public List<TravelExpensesDTO> GetDataset()
        {
            return expensesDataset;
        }

        /// <summary>
        /// Commits changes to the travel expenses dataset.
        /// </summary>
        /// <param name="dataset">The updated dataset.</param>
        public void Commit(List<TravelExpensesDTO> dataset)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(dataset);
            }
        }
    }
}
