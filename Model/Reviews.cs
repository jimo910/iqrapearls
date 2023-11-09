using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{


        public class Review{
            public int Id{get; set;}
            public int ReviewValue {get; set;}
            public int ProductId {get; set;}
            public int CustomerId{get; set;}
            public Product product {get; set;}
        }

}