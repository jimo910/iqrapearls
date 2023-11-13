using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{

        public class Cart{

          public int Id{get; set;}
          public int ProductId{get; set;}
          public int CustomerId {get; set;}
          public Customers Customer{get; set;}
          public int Quantity {get; set;}
          
        }

}