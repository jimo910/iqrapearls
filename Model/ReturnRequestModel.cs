using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using IqraPearls.Dtos;
using IqraPearls.Enums;

namespace IqraPearls.Model{
 
    public  class  ReturnRequestModel {
    
        public int Id{get; set;}
        public Guid OrderNumber { get; set;}
        public int CustomerId{get; set;}
        public int Quantity { get; set;}
        public string ReasonForReturn{ get; set;}
        public ICollection<ProductRequestRelationship> PRRelations{get; set;}
        public DateTime TimeReturnRequested {get; set;}
        public ReturnStatus.ReturnStatusEnums ReturnStatus {get; set;}
        public ReturnChoice.ReturnChoiceEnums ReturnChoice {get; set;}
}

}