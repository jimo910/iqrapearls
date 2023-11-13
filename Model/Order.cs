using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{

        public class Order{

          public int Id{get; set;}
          public Guid OrderNumber{get; set;}
          public  List<Sellers> ListOfSellers {get; set;}
          public List<Cart> ListofProductOrdered{get; set;}
          public  bool isPaid{get; set;}
          public int CustomerId{get; set;}
          public Customers customer{get; set;}
        }

}