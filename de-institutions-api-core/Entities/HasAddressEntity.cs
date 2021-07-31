namespace de_institutions_api_core.Entities
{
    public class HasAddressEntity : BaseEntity<int>
    {
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}