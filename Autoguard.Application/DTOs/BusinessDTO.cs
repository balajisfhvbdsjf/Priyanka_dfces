namespace Autoguard.Application.DTOs
{
    public class BusinessDto
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string RegNumber { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessContactNumber { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public string GeoLocation { get; set; }
        public long TaxNumber { get; set; }
        public string CipcFilePath { get; set; }
        public string PsiraDocumentationFilePath { get; set; }
        public string PayeNumber { get; set; }
        public string VatNumber { get; set; }
        public string OperationalCountry { get; set; }
        public string BusinessLogoImagePath { get; set; }
        public string NumberOfPeople { get; set; }
    }
}
