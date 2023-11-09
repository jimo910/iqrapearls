
using System ;
namespace IqraPearls.Dtos{
 
    public record SellerRegistrationDto {
        public string EmailAddress { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Address{ get; set;}
        public string AddressCity { get; set; }
        public string PostCode { get; set;}
     
}

}