using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IqraPearls.FieldValidators;
using IqraPearls.Dtos;
using IqraPearls.Model;
using IqraPearls.DataDbContext;
using IqraPearls.Enums;
 namespace IqraPearls.Data{

    public class  ProductComment{


        public boolEnum.boolEnums AddProductComment(commentDto commentdto )
        {
            
            var context = new IqraDbContext();
            var CustomerExist = context.Customerss.FirstOrDefault(a => a.Id == commentdto.CustomerId);
             if(CustomerExist != null){
            if(commentdto.ProductComment !=null){
            Comment newComment = new Comment {
                 ProductComment = commentdto.ProductComment,
                 ProductId = commentdto.ProductId,
                 CustomerId = commentdto.CustomerId,
                 ParentCommentId = commentdto.ParentCommentId
            };
            context.Comments.Add(newComment);
            context.SaveChanges();
            return  boolEnum.boolEnums.TRUE;
            }
            
            else{
                return boolEnum.boolEnums.FALSE;
            }
            }
          
        return boolEnum.boolEnums.NAN;
        }

        public IEnumerable <Comment> getProductComment(int ProductId){

            var context = new IqraDbContext();
            var productComment = context.Comments;                
             var ProductIdCommentList = productComment.Select(e=> new Comment {
                ProductComment = e.ProductComment,
                ProductId = e.ProductId,
                CustomerId = e.CustomerId,
                ParentCommentId = e.ParentCommentId
             }).Where (e=>e.ProductId == ProductId).ToList();

        return ProductIdCommentList;
            
        }

        public bool UpdateProductIdComment(int commentId, commentDto newCommentDto){

          var context = new IqraDbContext();
          var productComment = context.Comments; 
          var  prodCommentExist=  context.Comments.FirstOrDefault(a => a.Id ==commentId && a.CustomerId == newCommentDto.CustomerId);
          if( prodCommentExist != null){
            prodCommentExist.ProductComment= newCommentDto.ProductComment;
            context.SaveChanges(); 
            return true;
          } 

        return false;
        }


    


    }

 }