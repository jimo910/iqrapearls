
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{


    public class ProductRequestRelationship{

   
        public int ProductId {get; set;}
        public Product Products {get; set;}

        public int ReturnRequestModelId {get; set;}
        public ReturnRequestModel _ReturnRequest{get; set;}
    

    }

}