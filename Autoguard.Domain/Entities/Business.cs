using System;

namespace Autoguard.Domain.Entities
{
    public class Business
    {
        public int BusinessId { get; set; } // Primary Key
        public string BusinessName { get; set; } // business_name
        public string RegNumber { get; set; } // Format "xxx/xxxxxx/xx"
        public string BusinessEmail { get; set; } // Valid email format
        public string BusinessContactNumber { get; set; } // Format "(xx) xxx xxxx"
        public string Suburb { get; set; } // suburb
        public string City { get; set; } // city
        public string Province { get; set; } // province
        public int PostalCode { get; set; } // Between "0001" and "9999"
        public string GeoLocation { get; set; } //Current location
        public long TaxNumber { get; set; } // 10 numeric digits
        public string CipcFilePath { get; set; } // cipc_file_path
        public string PsiraDocumentationFilePath { get; set; } // Upload from local
        public string PayeNumber { get; set; } // Starts with 7, 10 digits
        public string VatNumber { get; set; } // Starts with 4, 10 digits
        public string OperationalCountry { get; set; } // operational_country
        public string BusinessLogoImagePath { get; set; } // Image upload
        public string NumberOfPeople { get; set; } // number_of_people
    }
}
