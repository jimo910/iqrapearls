

using System;
using System.IO;
using System.Collections.Generic;
using IqraPearls.DataDbContext;
using System.Security.Cryptography;
using System.Text;
using IqraPearls.Dtos;

namespace IqraPearls.StaticMethods{

public  class staticMethodsClass{

    public static bool DeleteImage (string imagePath){
         // Check if the file exists
        if (File.Exists(imagePath))
        {
            try
            {
                // Delete the file
                File.Delete(imagePath);
                return true;
               
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
       
            return false;
    }

      public  string HashPassword(string password, string salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
            return Convert.ToBase64String(hash);
        }
    }

    public static int returnProductId( Guid OrderNumber, int ProductIdonOrder){

        int ProductId= 1013725;
        var context = new IqraDbContext();
        var OrderExist = context.Orders.FirstOrDefault (a => a.OrderNumber == OrderNumber);
        if(OrderExist != null){
            if( OrderExist.ListofProductOrdered.Count > ProductIdonOrder -1){
            ProductId = OrderExist.ListofProductOrdered[ProductIdonOrder].ProductId;
            }
        }

        return ProductId;
    }

    public static int returnSellersId( Guid OrderNumber, int ProductIdonOrder){

        int SellersId=  1013725;
        var context = new IqraDbContext();
        var OrderExist = context.Orders.FirstOrDefault (a => a.OrderNumber == OrderNumber);
        if(OrderExist != null){
            if(OrderExist.ListOfSellers.Count > ProductIdonOrder-1){
            SellersId = OrderExist.ListOfSellers[ProductIdonOrder].SellersId;
            }
        }

        return SellersId;
    }

    public static  List<ReturnRequestProductQuantityDto> returnProductQuantity (Guid OrderNumber){
        List<ReturnRequestProductQuantityDto> toreturn = new List<ReturnRequestProductQuantityDto>();
        var context = new IqraDbContext();
        var SellerReturnRequest = context.SellerReturnRequestTable;
        var SellerReturn = SellerReturnRequest.Where(e=> e.OrderNumber == OrderNumber).ToList();
        
        if(SellerReturn != null){
        foreach( var Sellerreturn in SellerReturn){
            ReturnRequestProductQuantityDto newReturnRequestDto = new ReturnRequestProductQuantityDto{
                Quantity = Sellerreturn.QuantityToReturn,
                ProductIdonOrder =  Sellerreturn.ProductIdToReturn
            };

            toreturn.Add(newReturnRequestDto);
            }
        }
    
        return toreturn;
    }

}

}