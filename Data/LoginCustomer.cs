using System;
using System.Collections.Generic;
using System.Text;
using IqraPearls.Model;
using IqraPearls.DataDbContext;
using IqraPearls.StaticMethods;
using System.Linq;

namespace IqraPearls.Data
{
    public class LoginUser
    {


     /*   public  bool isPasswordVerified(string providedPassword, string hashedPassword, string GeneratedSalt){

               string newHashPassword= staticMethodsClass.HashPassword(providedPassword, GeneratedSalt);
               return newHashPassword == hashedPassword;

        }*/

        public Customers Login(string emailaddress, string password)
        {
            Customers user = new Customers();
            Customers customer = new Customers();

             var dbContext = new IqraDbContext();
            
               // user = dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
               customer = dbContext.Customerss.FirstOrDefault(a => a.EmailAddress ==emailaddress);
               if(customer != null){
               staticMethodsClass staticClass = new staticMethodsClass();
              string newHashPassword= staticClass.HashPassword(password, customer.GeneratedSalt);
               if  (newHashPassword == customer.Password){

                    user= customer;
               }

               }
             /* if(isPasswordVerified(password, customer.Password, customer.GeneratedSalt)){
                user = customer;
               }*/
              
            return user;
        }


    }
}
