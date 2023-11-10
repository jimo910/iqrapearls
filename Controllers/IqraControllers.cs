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
public class IqraPearlsController : ControllerBase
{

    private readonly IWebHostEnvironment  _webHostEnvironment;

   public IqraPearlsController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


[HttpGet("IqraPearls/GetCustomer")]
public IEnumerable<Customers> GetCustomer(){

    var context = new IqraDbContext();
    var CustomersList = context.Customerss;
    var CustomersLists  = CustomersList.ToList();
    return CustomersLists;  

}



[HttpPost("IqraPearls/RegisterCustomer")]
public IActionResult RegisterCustomer( [FromBody] UserRegistrationDto userdto)
{
 
    RegisterUser registerUser = new RegisterUser();

    registerUser.getUsersData(userdto);
    registerUser.userValidDel();
    if( registerUser.is_success()){     
    // Check if an image was uploaded

    UserDBRegistrationDto userDBdto  = new UserDBRegistrationDto{
     EmailAddress = userdto.EmailAddress,
     FirstName = userdto.FirstName,
     LastName = userdto.LastName,
     Password = userdto.Password,
     PhoneNumber = userdto.PhoneNumber,
     Address = userdto.Address,
     AddressCity = userdto.AddressCity,
     PostCode = userdto.PostCode,
   //  ImageUrl = "/uploads/UserProfilePic/" + uniqueFileName 
    };

    registerUser.registerUserFunc(userDBdto);
    
     return Ok("User Registered successfully.");

}else{

    return BadRequest(registerUser.ErrorMessageInfo());
}

}



[HttpPost("IqraPearls/UploadCustomerImage")]
public async Task<IActionResult> UploadCustomerImage( int userId, IFormFile imageFile)
{


          
    // Check if an image was uploaded
    if (imageFile != null && imageFile.Length > 0)
    {
        // Generate a unique file name for the image (e.g., using a GUID)
        var uniqueFileName = userId.ToString() + "_" + imageFile.FileName;

        // Specify the folder where you want to save the image
        var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads/UserProfilePic");

        // Create the folder if it doesn't exist
        Directory.CreateDirectory(uploadFolder);

        // Combine the folder path and file name to get the full path to the saved image
        var filePath = Path.Combine(uploadFolder, uniqueFileName);

        // Save the uploaded image to the specified path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

   string ImageUrl = "uploads/UserProfilePic/" + uniqueFileName ;
    var context = new IqraDbContext();
     var  userExist=  context.Customerss.FirstOrDefault(a => a.Id ==userId); 
       if (userExist != null) {

          userExist.ImageUrl = ImageUrl;
          context.SaveChanges();

        }
  
        return Ok("Image uploaded successfully.");
    }

    return BadRequest("No image uploaded.");
}


[HttpPut("IqraPearls/UpdateCustomer")]
public ActionResult UpdateCustomer(int Ids, [FromBody] CustomerUpdateDto newUser){

           var context = new  IqraDbContext();
            var CustomerExist =  context.Customerss.FirstOrDefault(a => a.Id == Ids); 
              if (CustomerExist != null)
                { 
                      UpdateCustomers updateCustomers = new UpdateCustomers();
                     updateCustomers.getUsersData(newUser);
                    updateCustomers.userValidDel();
                 if(updateCustomers.is_success()){                
                    CustomerExist.EmailAddress = newUser.EmailAddress;
                    CustomerExist.FirstName = newUser.FirstName;
                     CustomerExist.LastName = newUser.LastName;
                     CustomerExist.PhoneNumber = newUser.PhoneNumber;
                    CustomerExist.Address = newUser.Address;
                    CustomerExist.AddressCity = newUser.AddressCity;
                    CustomerExist.PostCode = newUser.PostCode;
                      context.SaveChanges();
                   return Ok("Update Done Successful");
                   }else{
                      return BadRequest(updateCustomers.ErrorMessageInfo());
                   }

                }else{

                    return NotFound();
                }

           

}

    [HttpDelete("IqraPearls/DeleteCustomer")]
    public IActionResult DeleteCustomer(int userId)
    {
         var context = new IqraDbContext();
         var  CustomerExist=  context.Customerss.FirstOrDefault(a => a.Id ==userId); 
        if (CustomerExist == null)
        {
            return NotFound(); // Return a 404 Not Found if the item doesn't exist.
        }
        staticMethodsClass.DeleteImage(CustomerExist.ImageUrl);
        context.Remove(CustomerExist);
        context.SaveChanges();
        return NoContent(); // Return a 204 No Content on successful deletion.
    }









}

}