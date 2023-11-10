

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

    public class  ProductReview{


      public  void  AddProductReview(ProductReviewDto prodReviewDto){

        var context = new IqraDbContext();
        var ProductReviewExist=  context.Reviews.FirstOrDefault(a => a.ProductId==prodReviewDto.ProductId && a.CustomerId== prodReviewDto.CustomerId);
        var productPreviewExist = context.PReviews.FirstOrDefault(a => a.ProductId==prodReviewDto.ProductId );
        if (ProductReviewExist == null){

            Review review = new Review{
            ProductId = prodReviewDto.ProductId,
            ReviewValue = prodReviewDto.ReviewValue,
            };
            context.Reviews.Add(review);
            context.SaveChanges();

        }else{

            ProductReviewExist.ReviewValue= prodReviewDto.ReviewValue;
            context.SaveChanges();
      
        }
   

      }

     public  double  getReview(int productid){
        
        
        var context = new IqraDbContext();
        var ProductReviewExist=  context.Reviews.FirstOrDefault(a => a.ProductId== productid ); 
           if (ProductReviewExist == null){
                return (double)0;

           }else{

                return (double)ProductReviewExist.ReviewValue; //ProductReviewExist.NoOfReveiws;

           }

        
      }
   
   
    }

 }