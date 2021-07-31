namespace de_institutions_api_core.Entities
{
    public class Address : BaseEntity<int>
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}