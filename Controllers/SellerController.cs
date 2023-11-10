
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
public class SellerController : ControllerBase
{

    private readonly IWebHostEnvironment  _webHostEnvironment;

   public SellerController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


[HttpGet("IqraPearls/GetSellers")]
public IEnumerable<Sellers> GetSellers(){
    var context = new IqraDbContext();
    var SellerList = context.Sellerss;
    var SellersLists  = SellerList.ToList();
    return SellersLists;  

}


[HttpPost("IqraPearls/RegisterSeller")]
public IActionResult RegisterSeller( [FromBody] SellerRegistrationDto sellerDto)
{
 
    RegisterSeller registerseller = new RegisterSeller();

   registerseller.getSellerData(sellerDto);
   registerseller.userValidDel();
    if( registerseller.is_success()){     
    // Check if an image was uploaded


    registerseller.registerSellerFunc(sellerDto);
    
     return Ok("User Registered successfully.");

}else{

    return BadRequest(registerseller.ErrorMessageInfo());
}

}


[HttpPost("IqraPearls/UploadSellerImage")]
public async Task<IActionResult> UploadSellerImage( int userId, IFormFile imageFile)
{
   
    // Check if an image was uploaded
    if (imageFile != null && imageFile.Length > 0)
    {
        // Generate a unique file name for the image (e.g., using a GUID)
        var uniqueFileName = userId.ToString() + "_" + imageFile.FileName;

        // Specify the folder where you want to save the image
        var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads/SellerProfilePic");

        // Create the folder if it doesn't exist
        Directory.CreateDirectory(uploadFolder);

        // Combine the folder path and file name to get the full path to the saved image
        var filePath = Path.Combine(uploadFolder, uniqueFileName);

        // Save the uploaded image to the specified path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

   string ImageUrl = "uploads/SellerProfilePic/" + uniqueFileName ;
    var context = new IqraDbContext();
     var  SellerExist=  context.Sellerss.FirstOrDefault(a => a.Id ==userId); 
       if (SellerExist!= null) {

          SellerExist.ImageUrl = ImageUrl;
          context.SaveChanges();
            return Ok("Image uploaded successfully.");

        }else{

               return BadRequest("NO seller Id "); 
        }
  
      
    }

    return BadRequest("No image uploaded.");
}


 [HttpDelete("IqraPearl/DeleteSeller")]
    public IActionResult DeleteSeller (int userId)
    {
         var context = new IqraDbContext();
         var  SellerExist=  context.Sellerss.FirstOrDefault(a => a.Id ==userId); 
        if (SellerExist == null)
        {
            return NotFound(); // Return a 404 Not Found if the item doesn't exist.
        }

        context.Remove(SellerExist);
        staticMethodsClass.DeleteImage(SellerExist.ImageUrl);
        context.SaveChanges();
        return NoContent(); // Return a 204 No Content on successful deletion.
    }
}

}
