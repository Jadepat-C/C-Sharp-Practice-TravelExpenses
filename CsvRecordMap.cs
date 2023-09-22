using CsvHelper.Configuration;

namespace TravelEx
{
    /// <summary>
    /// Represents a map for CSV header
    /// </summary>
    public class CsvRecordMap : ClassMap<TravelExpensesDTO>
    {
        /// <summary>
        /// A constructor maping each header into the index
        /// </summary>
        public CsvRecordMap()
        {
            Map(m => m.id).Index(0).Name("id");
            Map(m => m.ref_number).Index(1).Name("ref_number");
            Map(m => m.disclosure_group).Index(2).Name("disclosure_group");
            Map(m => m.title_en).Index(3).Name("title_en");
            Map(m => m.title_fr).Index(4).Name("title_fr");
            Map(m => m.name).Index(5).Name("name");
            Map(m => m.purpose_en).Index(6).Name("purpose_en");
            Map(m => m.purpose_fr).Index(7).Name("purpose_fr");
            Map(m => m.start_date).Index(8).Name("start_date");
            Map(m => m.end_date).Index(9).Name("end_date");
            Map(m => m.destination_en).Index(10).Name("destination_en");
            Map(m => m.destination_fr).Index(11).Name("destination_fr");
            Map(m => m.airfare).Index(12).Name("airfare");
            Map(m => m.other_transport).Index(13).Name("other_transport");
            Map(m => m.lodging).Index(14).Name("lodging");
            Map(m => m.meals).Index(15).Name("meals");
            Map(m => m.other_expenses).Index(16).Name("other_expenses");
            Map(m => m.total).Index(17).Name("total");
            Map(m => m.additional_comments_en).Index(18).Name("additional_comments_en");
            Map(m => m.additional_comments_fr).Index(19).Name("additional_comments_fr");
            Map(m => m.owner_org).Index(20).Name("owner_org");
            Map(m => m.owner_org_title).Index(21).Name("owner_org_title");
        }
    }
}
