using System ;
using System.Collections.Generic;
using IqraPearls.Enums;

namespace IqraPearls.Dtos{
 
    public  record ReturnRequestDto {
    
        public Guid OrderNumber { get; set;}
        public List<ReturnRequestProductQuantityDto> ProductIdQuantity{get; set;}
        public string ReasonForReturn{ get; set;}
        public int CustomerId  {get; set;}
        public ReturnChoice.ReturnChoiceEnums ReturnChoice {get; set;}

}

}