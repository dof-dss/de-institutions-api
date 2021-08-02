namespace de_institutions_api_core.DTOs
{
    public class AddressDto
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public override string ToString()
        {
            return $"{Address1} {Address2} {Address3} {TownCity} {PostCode}";
        }
    }
}