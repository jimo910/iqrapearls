using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IqraPearls.Model{

        public class Product{
           public int Id{get; set;}
           public string ProductName{get; set;}
           public string ProductDescription{get; set;}
           public double  Price{get; set;}
           public string  Category{get; set;}
           public List<ProductImage> ImageUrlList { get; set; } 
           public ICollection<ProductRequestRelationship> PRRelations{get; set;}
           public int SellersId{get; set;}
           public Sellers sellers { get; set;}
           public Review review {get; set;}
        }

}