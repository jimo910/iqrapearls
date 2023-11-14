using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using IqraPearls.Dtos;

namespace IqraPearls.Model{

        public class Sellers{

           public int  Id{get; set;}
           public string StoreName{get; set;}
           public string StoreDescription{get; set;}
           public string  EmailAddress{get; set;}
           public string Password{get; set;}
           public string GeneratedSalt{get; set;}
           public string PhoneNumber{get; set;}
           public string Address { get; set; }
           public string ImageUrl{get; set;}
           public string AddressCity{ get; set; }
           public string PostCode{ get; set; }
           public List <Product> Tosell {get; set;}
           public List <OrderDto> productCarted{get; set;}
           public List < SellerReturnRequestModel> ReturnRequest {get; set;}

        }
}