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
public class LoginController : ControllerBase
{

    private readonly IWebHostEnvironment  _webHostEnvironment;

   public LoginController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


[HttpGet("IqraPearls/GetProduct")]
  public Customers Customer( string emailaddress, string providedPassword){
        LoginUser logUser = new LoginUser();
        Customers CUST = new Customers();
        CUST = logUser.Login(emailaddress, providedPassword);
        return CUST;
}




}


}