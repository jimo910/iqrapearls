
using System ;
namespace IqraPearls.Dtos{
 
    public record CustomerUpdateDto {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address{ get; set;}
        public string AddressCity { get; set; }
        public string PostCode { get; set;}
     
}

}