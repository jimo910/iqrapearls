using System;
using System.Collections.Generic;
using System.Text;
using IqraPearls.Model;
using IqraPearls.DataDbContext;
using IqraPearls.StaticMethods;
using System.Linq;

namespace IqraPearls.Data
{
    public class LoginSeller
    {


     /*   public  bool isPasswordVerified(string providedPassword, string hashedPassword, string GeneratedSalt){

               string newHashPassword= staticMethodsClass.HashPassword(providedPassword, GeneratedSalt);
               return newHashPassword == hashedPassword;

        }*/

        public Sellers Login(string emailaddress, string password)
        {
            Sellers user = new Sellers();
            Sellers  Seller = new Sellers();

             var dbContext = new IqraDbContext();
            
               // user = dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
               Seller = dbContext.Sellerss.FirstOrDefault(a => a.EmailAddress ==emailaddress);
               if(Seller != null){
               staticMethodsClass staticClass = new staticMethodsClass();
              string newHashPassword= staticClass.HashPassword(password, Seller.GeneratedSalt);
               if  (newHashPassword == Seller.Password){

                    user= Seller;
               }

               }
             /* if(isPasswordVerified(password, customer.Password, customer.GeneratedSalt)){
                user = customer;
               }*/
              
            return user;
        }


    }
}
