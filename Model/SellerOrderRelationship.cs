
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{


    public class SellerOrderRelationship{

        public Guid OrderNumber {get; set;}
        public int OrderId{get; set;}
        public Order Orders {get; set;}

        public int SellersId {get; set;}
        public  Sellers Sellers {get; set;}
    

    }

}