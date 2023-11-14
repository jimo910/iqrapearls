using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using IqraPearls.Dtos;

namespace IqraPearls.Model{
 
    public  class  SellerReturnRequestModel {
        public int Id{get; set;} 
        public Guid OrderNumber { get; set;}
        public int CustomerId{get; set;}
        public string ReasonForReturn{ get; set;}
        public string ReasonForAcceptanceOrDenial{get; set;}
        public int ProductIdToReturn { get; set; }  
        public int ProductIdonOrder {get; set;}
        public int QuantityToReturn {get; set;}
        public   bool isRequestAccepted {get; set;}
        public DateTime TimeReturnRequested {get; set;}
        public int SellersId {get; set;}
        public Sellers Seller{get; set;}
       
}

}