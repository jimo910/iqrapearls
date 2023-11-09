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

    public class  RegisterSeller {


        public delegate void UserValidationDel();
        SellerRegistrationDto _userregDto = new SellerRegistrationDto() ;
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
                   _userValidDel = new UserValidationDel(SellerValidation);

                return _userValidDel;
            }
        }
    

     static string GenerateSalt()
    {
        byte[] salt = new byte[16]; // 16 bytes = 128 bits
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    // Hash the password with the salt
    static string HashPassword(string password, string salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
            return Convert.ToBase64String(hash);
        }
    }

     public void getSellerData(SellerRegistrationDto userData){
            _userregDto = userData;
        }
        
        private void SellerValidation(){
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.EmailAddress,  _userregDto.EmailAddress, out invalidMessage);}else{return;}
        //   if(invalidMessage ==""){UserRegValidator.ValidField(0, "jimomubarak@gmail.com", out invalidMessage);}else{return;}
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.FirstName, _userregDto.StoreName, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.LastName, _userregDto.StoreDescription, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Password,  _userregDto.Password, out invalidMessage);}else{return;}
          // if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.PasswordCompare, _userregDto.PasswordCompare, out invalidMessage);}else{return;}            
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.PhoneNumber, _userregDto.PhoneNumber, out invalidMessage);}else{return;} 
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Address, _userregDto.Address, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.AddressCity, _userregDto.AddressCity, out invalidMessage);}else{return;}
           if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.PostCode, _userregDto.PostCode, out invalidMessage);}else{return;}
             
        }

        public void  registerSellerFunc(SellerRegistrationDto  _userDBregDto){

            if(invalidMessage ==""){
                
                var Context = new IqraDbContext();

                string salt = GenerateSalt();
                string hashedPassword = HashPassword(_userDBregDto.Password, salt);

               Sellers sellers = new Sellers{
                    EmailAddress = _userDBregDto.EmailAddress,
                    StoreName = _userDBregDto.StoreName,
                    StoreDescription = _userDBregDto.StoreDescription,
                    Password = hashedPassword,
                    Address =_userDBregDto.Address,
                    AddressCity = _userDBregDto.AddressCity,
                    PostCode= _userDBregDto.PostCode,
                    GeneratedSalt = salt,
                    ImageUrl = "default_link",
                    PhoneNumber = _userDBregDto .PhoneNumber
                };

                Context.Sellerss.Add(sellers);
                Context.SaveChanges();
            }

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