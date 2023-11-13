using System ;
using IqraPearls.Enums;

namespace IqraPearls.Dtos{
 
    public  record ReturnRequestDto {
    
        public Guid OrderNumber { get; set;}
        public int Quantity { get; set;}
        public string ReasonForReturn{ get; set;}
        public int ProductIdToReturn { get; set; }  
        public ReturnChoice.ReturnChoiceEnums ReturnChoice {get; set;}
}

}