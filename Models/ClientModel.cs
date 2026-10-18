namespace BVK_Advocates_Law_Firm.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string SurName { get; set; } = string.Empty;
        public string FirstName { get; set; }= string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AltPhoneNumber { get; set; } = string.Empty;
        public string WhatsAppPhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? Country { get; set; }//Default India
        public string? State { get; set; }
        public string? District { get; set; }
        public string? Mandal { get; set; }
        public string? Village { get; set; }
        public string? ZipCode { get; set; }
        
        public string? Jurisdiction { get; set; }
    }
}
