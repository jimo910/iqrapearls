using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IqraPearls.FieldValidators;
using IqraPearls.Dtos;
using IqraPearls.Model;
using IqraPearls.DataDbContext;

 namespace IqraPearls.Data{

    public class  UpdateCustomers {


        public delegate void UserValidationDel();
       CustomerUpdateDto  _userregDto = new CustomerUpdateDto() ;
        string invalidMessage = "";
        bool Success =false;

          IFieldValidator UserRegValidator = new UserRegistrationValidator();
   //       UserRegValidator.InitialiseValidatorDelegates();
      //  FieldValidatorDel ValidatorDeld = null;
      //  ValidatorDeld =  UserRegistrationValidator.ValidatorDel;
            // func to get data.(done)
            // to validate the data(done)
            // to register User
            // send message back to the controller.

        private  UserValidationDel _userValidDel = null;
   
        public  UserValidationDel  userValidDel
        {
            get 
            {
                if (_userValidDel == null)
                   _userValidDel = new UserValidationDel(UserValidation);

                return _userValidDel;
            }
        }
    


     public void getUsersData(CustomerUpdateDto userData){
            _userregDto = userData;
        }

        private void UserValidation(){
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.EmailAddress,  _userregDto.EmailAddress, out invalidMessage);}else{return;}
        //   if(invalidMessage ==""){UserRegValidator.ValidField(0, "jimomubarak@gmail.com", out invalidMessage);}else{return;}
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.FirstName, _userregDto.FirstName, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.LastName, _userregDto.LastName, out invalidMessage);}else{return;}           
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.PhoneNumber, _userregDto.PhoneNumber, out invalidMessage);}else{return;} 
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Address, _userregDto.Address, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.AddressCity, _userregDto.AddressCity, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.PostCode, _userregDto.PostCode, out invalidMessage);}else{return;}
             
        }


        

     public bool is_success(){
        if(invalidMessage==""){
           return true;
           }
           else{
            return false;
           }
        }


     public string ErrorMessageInfo(){
       
       return invalidMessage;
    }



    }

 }

 