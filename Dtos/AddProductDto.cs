
using System ;
namespace IqraPearls.Dtos{
 
    public  record    AddProductDto {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double  Price { get; set; }
        public string Category{ get; set; }
        public int SellersId { get; set; }  
}

}