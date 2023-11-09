
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{


        public class ProductImage
        {
          public int Id { get; set; }
          public string ImageUrl { get; set; }
          public int ProductId { get; set; } // Foreign key to relate to Product
          public Product Product { get; set; } // Navigation property to access the related Product
        }

}