
using System ;
namespace IqraPearls.Dtos{
 
    public record UserDBRegistrationDto {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Address{ get; set;}
        public string AddressCity { get; set; }
        public string PostCode { get; set;}
     
}

}