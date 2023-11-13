
using System ;
namespace IqraPearls.Dtos{
 
    public  record   OrderDto {

        public Guid OrderNumber{get; set;}
        public int CustomerId{get ; set;}
        public int ProductId{get; set;}
        public int Quantity{get; set;} 
        public bool isPaid{get; set;}
}

}