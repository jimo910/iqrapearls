using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using IqraPearls.Dtos;

namespace IqraPearls.Model{

        public class Customers{
        
           public int Id{get; set;}
           public string FirstName{get; set;}
           public string LastName{get; set;}
           public string  EmailAddress{get; set;}
           public string Password{get; set;}
           public string GeneratedSalt{get; set;}
           public string PhoneNumber{get; set;}
           public string Address { get; set; }
           public string ImageUrl{get; set;}
           public string AddressCity{ get; set; }
           public string PostCode{ get; set; }
           public List<Wishlist> ListOfWishlistProduct {get; set;}
           public List<Cart> ListOfCartProduct{get; set;}
           public List<ReturnRequestDto> ListofProductToReturned {get; set;}
           public List<OrderDto> ListofProductOrdered{get; set;} 

        }
}