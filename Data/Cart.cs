
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

    public class Cartd{


            public bool AddProductToCart(CartDto newCartDto)
            {

                
                  var context = new IqraDbContext();
                  var CartContext = context.Carts;
        if((context.Customerss.FirstOrDefault(a => a.Id == newCartDto.CustomerId)) != null){
                  Cart newCart = new Cart {
                        ProductId = newCartDto.ProductId,
                        CustomerId = newCartDto.CustomerId,
                        Quantity = newCartDto.Quantity
                  };
                  CartContext.Add(newCart);
                  context.SaveChanges();
        return true;

            }
        return false;
            }


            public bool RemoveProductFromCart( int CartProductId){

                var context = new IqraDbContext();
                var CartContext = context.Carts;
                var CartTBRemoved = CartContext.FirstOrDefault(a => a.Id ==CartProductId);
                if(CartTBRemoved != null){
                         context.Remove(CartTBRemoved);
                         context.SaveChanges();
                        return true;
                }
              
        return false;
    }

    public bool UpdateProductCartQuantity (int CartProductId, int Quantity){
               var context = new IqraDbContext();
                var CartContext = context.Carts;
                var CartTBUpdated = CartContext.FirstOrDefault(a => a.Id ==CartProductId);
                if(CartTBUpdated != null){
                        
                        CartTBUpdated.Quantity = Quantity;
                        context.SaveChanges();
                        return true;
                }
              
        return false;
    }

            


            }



    }


 
 
 
 