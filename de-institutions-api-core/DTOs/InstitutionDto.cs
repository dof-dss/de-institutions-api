using System;

namespace de_institutions_api_core.DTOs
{
    public class InstitutionDto
    {
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Management { get; set; }
        public string InstitutionType { get; set; }
        public string Status { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}