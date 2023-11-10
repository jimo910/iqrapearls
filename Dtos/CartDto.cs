
using System ;
namespace IqraPearls.Dtos{
 
    public  record   CartDto {

        public int ProductId{get; set;}
        public int CustomerId{get ; set;}
        public int Quantity{get; set;} 
}

}