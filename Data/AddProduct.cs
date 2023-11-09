
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

    public class  AddProduct{


        public delegate void UserValidationDel();
        AddProductDto _userregDto = new AddProductDto() ;
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
                   _userValidDel = new UserValidationDel(ProductValidation);

                return _userValidDel;
            }
        }
    

 

     public void getProductData(AddProductDto userData){
            _userregDto = userData;
        }
        
        private void ProductValidation(){
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Required,  _userregDto.ProductName, out invalidMessage);}else{return;}
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Required, _userregDto.ProductDescription, out invalidMessage);}else{return;}
          if(invalidMessage ==""){UserRegValidator.ValidatorDel((int)FieldConstants.UserRegistrationField.Required, _userregDto.Category, out invalidMessage);}else{return;}
        }

        public bool AddProductFunc(AddProductDto  _ProdDBregDto){

            if(invalidMessage ==""){
                
             var context = new IqraDbContext();
             var SellerExist = context.Sellerss.FirstOrDefault(a => a.Id == _ProdDBregDto.SellersId ); 
             if(SellerExist != null){
              Product prod = new Product{
                ProductName = _ProdDBregDto.ProductName,
                ProductDescription = _ProdDBregDto.ProductDescription,
                Category = _ProdDBregDto.Category,
                SellersId = _ProdDBregDto.SellersId,
                Price = _ProdDBregDto.Price,
               // Reviews = 0
              };
                context.Products.Add(prod);
                context.SaveChanges();
                  return true;
            }
          
            }
               return false;
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