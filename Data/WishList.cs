
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

    public class WishList{


            public static bool AddProductToWishList(WishlistDto newWishlistDto)
            {
                  var context = new IqraDbContext();
                  var WishlistContext = context.Wishlists;
                 if((context.Customerss.FirstOrDefault(a => a.Id == newWishlistDto.CustomerId)) != null){
                  Wishlist newWishlist = new Wishlist {
                        ProductId = newWishlistDto.ProductId,
                        CustomerId = newWishlistDto.CustomerId
                  };
                  WishlistContext.Add(newWishlist);
                  context.SaveChanges();
        return true;
            }
        return false;
            }


            public static bool RemoveProductFromWishlist( int wishlistProductId){

                var context = new IqraDbContext();
                var WishlistContext = context.Wishlists;
                var WishlistTBRemoved = WishlistContext.FirstOrDefault(a => a.Id ==wishlistProductId);
                if(WishlistTBRemoved != null){
                         context.Remove(WishlistTBRemoved );
                        return true;
                }
              
                return false;
            }

    public static  void MoveProductToCart(int wishlistProductId){

       var context = new IqraDbContext();
       var ProductTBMove = context.Wishlists.FirstOrDefault(a => a.Id ==  wishlistProductId);
    if(ProductTBMove  != null){
       Cart newCart =new Cart{

            ProductId = ProductTBMove.ProductId,
            CustomerId = ProductTBMove.CustomerId,
            Quantity = 1
       };
       var CartContext = context.Carts;
       CartContext.Add(newCart);

       context.Remove(ProductTBMove);


    }

}

  public static  void MoveAllProductToCart(int CustomerId){

       var context = new IqraDbContext();
     var CustomerwishlistList = context.Wishlists.Select (e => new Wishlist {
             Id = e.Id   
     }).Where(e => e.CustomerId == CustomerId);

     foreach (var custwishlist in CustomerwishlistList){

                MoveProductToCart(custwishlist.Id);

     }

}



    }
    
    }