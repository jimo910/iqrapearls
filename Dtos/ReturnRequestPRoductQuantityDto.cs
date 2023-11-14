using System ;
using IqraPearls.Enums;

namespace IqraPearls.Dtos{
 
    public  record ReturnRequestProductQuantityDto {
    
        public int Quantity { get; set;}
        public  int ProductIdonOrder { get; set;}  
     
    }

}