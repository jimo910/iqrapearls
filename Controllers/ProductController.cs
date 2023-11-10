using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IO;
using IqraPearls.FieldValidators;
using IqraPearls.Dtos;
using IqraPearls.Model;
using IqraPearls.DataDbContext;
using IqraPearls.Data;
using Microsoft.AspNetCore.Hosting;
using IqraPearls.StaticMethods;

namespace IqraPearls.Controllers{



[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly IWebHostEnvironment  _webHostEnvironment;

   public ProductController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


[HttpGet("IqraPearls/GetProduct")]
public IEnumerable<Product> GetProduct(){

    var context = new IqraDbContext();
    var ProductList = context.Products;
    var ProductsLists  = ProductList.ToList();
    return ProductsLists;  

}
 

[HttpPost("IqraPearls/UploadProductImage")]
public async Task<IActionResult> UploadProductImage( int SellerId, int ProductID, int picsNo ,  IFormFile imageFile)
{
   
    // Check if an image was uploaded
    if (imageFile != null && imageFile.Length > 0)
    {
        // Generate a unique file name for the image (e.g., using a GUID)
        var uniqueFileName = SellerId.ToString() + "_"+ picsNo.ToString()+ "_"+ imageFile.FileName;
        var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, $"uploads/Product/{SellerId}/{ProductID}");
        Directory.CreateDirectory(uploadFolder);
        var filePath = Path.Combine(uploadFolder, uniqueFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

   string ImageUrls = $"/uploads/Product/{SellerId}/{ProductID}" + uniqueFileName ;
    var context = new IqraDbContext();
     var  ProductExist=  context.Products.FirstOrDefault(a => a.Id ==ProductID); 
       if (ProductExist!= null) {

        ProductImage prdImg = new ProductImage{
                ImageUrl = ImageUrls,
                ProductId = ProductID 

        };
          ProductExist.ImageUrlList[picsNo] = prdImg;
          context.SaveChanges();

        }
  
        return Ok("Image uploaded successfully.");
    }

    return BadRequest("No image uploaded.");
}


[HttpPost("IqraPearls/AddProduct")]
public IActionResult AddProduct ( [FromBody]  AddProductDto   addProductDto)
{
            AddProduct addproduct = new AddProduct();

   addproduct.getProductData(addProductDto);
   addproduct.userValidDel();
    if( addproduct.is_success()){     
   
bool isaddProd = addproduct.AddProductFunc(addProductDto);
    if(!(isaddProd)){
        return BadRequest("Sellers Id is empty");
    }
    
     return Ok($"Product addded to Sellers {addProductDto.SellersId} successfully.");

}else{

    return BadRequest(addproduct.ErrorMessageInfo());
}

}


[HttpPut("IqraPearls/UpdateProductImage")]
public async Task<IActionResult> UpdateProductImage( int SellerId, int ProductID, int picsNo ,   int ProductImageId, IFormFile imageFile)
{
   
    // Check if an image was uploaded
    if (imageFile != null && imageFile.Length > 0)
    {
        // Generate a unique file name for the image (e.g., using a GUID)
        var uniqueFileName = SellerId.ToString() + "_"+ picsNo.ToString()+ "_"+ imageFile.FileName;
        var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, $"uploads/Product/{SellerId}/{ProductID}");
        Directory.CreateDirectory(uploadFolder);
        var filePath = Path.Combine(uploadFolder, uniqueFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

   string ImageUrls = $"/uploads/Product/{SellerId}/{ProductID}" + uniqueFileName ;
   string imageToDelete= null;
    var context = new IqraDbContext();
     var  ProductExist=  context.Products.FirstOrDefault(a => a.Id ==ProductID); 
     var  ProductImageExist=  context.ProductImages.FirstOrDefault(a => a.Id ==ProductImageId); 
       if (ProductExist!= null && ProductImageExist !=null) {
            imageToDelete = ProductImageExist.ImageUrl;
            ProductImageExist.ImageUrl = ImageUrls;
            context.SaveChanges();

        }

           staticMethodsClass.DeleteImage(imageToDelete);
  
        return Ok("Image updated  successfully.");
    }

    return BadRequest("No image uploaded.");
}


 [HttpDelete("IqraPearl/DeleteProduct")]
    public IActionResult ProductDelete(int ProductId)
    {
         var context = new IqraDbContext();
         var  ProductExist=  context.Products.FirstOrDefault(a => a.Id ==ProductId); 
        if (ProductExist == null)
        {
            return NotFound(); // Return a 404 Not Found if the item doesn't exist.
        }

        context.Remove(ProductExist);
        context.SaveChanges();
        return NoContent(); // Return a 204 No Content on successful deletion.
    }

    /*********************************** END OF CRUD PRODUCT **************************************************/


        [HttpGet("IqraPearls/GetProductReviews")]
        public double GetProductReview(int productId){

        ProductReview GetProductReview  =new ProductReview();
       double productReviews =  GetProductReview.getReview(productId);
       return productReviews;
} 

 [HttpPost("IqraPearls/AddProductReview")]
public IActionResult AddProductReview ( [FromBody]  ProductReviewDto  productreviewdto)
{
         ProductReview  addproductReview = new ProductReview();
         addproductReview.AddProductReview(productreviewdto);
         return Ok("Reviews Successfully sent.");


}


[HttpDelete("IqraPearl/DeleteProductReviews")]
    public IActionResult DeleteProductReviews(int productId, int customerId)
    {
         var context = new IqraDbContext();
         var  prodReviewExist=  context.Reviews.FirstOrDefault(a => a.ProductId ==productId && a.CustomerId == customerId); 
        if (prodReviewExist == null)
        {
            return NotFound(); // Return a 404 Not Found if the item doesn't exist.
        }

        context.Remove(prodReviewExist);
        context.SaveChanges();
        return NoContent(); // Return a 204 No Content on successful deletion.
    }

/************************************************** End of CRUD PRODUCT REVIEWS *****************************************************/

/****************************************************** BEGINNING OF CRUD FOR PRODUCT COMMENT *************************************/

[HttpGet("IqraPearls/GetProductComment")]
public IEnumerable<Comment> GetProductComment(int ProductId){

     if(ProductId != null){
     ProductComment prodcomment = new ProductComment();
     return (prodcomment.getProductComment(ProductId));
     }
    return  null;
}

[HttpPost("IqraPearls/PostProductComment")]
public IActionResult AddProductComment ( [FromBody]   commentDto  addProductCommentDto)
{
   
      ProductComment prodcomment = new ProductComment();
      boolEnum.boolEnums isDone = prodcomment.AddProductComment(addProductCommentDto);

    if(isDone == boolEnum.boolEnums.TRUE){

        return Ok("Comment Added");

    }else if(isDone == boolEnum.boolEnums.FALSE){
        return BadRequest("Comment cannot be empty");

    }else{
        return NotFound();
    }

}

[HttpPut("IqraPearls/UpdateProductComment")]
public ActionResult UpdateProductComment (int CommentId, [FromBody] commentDto newComment){

    ProductComment newProdComment = new ProductComment();
  bool isUpdated =  newProdComment.UpdateProductIdComment(CommentId, newComment);
  if(isUpdated){
    return Ok("Comment Updated");

  }else{
    return BadRequest("Error Updating Comment.");
  }
}

[HttpDelete("IqraPearl/DeleteProductComment")]
    public IActionResult DeleteProductComment(int CommentId, int customerId)
    {
         var context = new IqraDbContext();
         var  prodCommentExist=  context.Comments.FirstOrDefault(a => a.Id == CommentId && a.CustomerId == customerId); 
        if (prodCommentExist == null)
        {
            return NotFound(); // Return a 404 Not Found if the item doesn't exist.
        }

        context.Remove(prodCommentExist);
        context.SaveChanges();
        return NoContent(); // Return a 204 No Content on successful deletion.
    }



}

}
