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


[HttpGet("IqraPearls/GetCustomer")]
  public Customers Customer( string emailaddress, string providedPassword){
        LoginUser logUser = new LoginUser();
        Customers CUST = new Customers();
        CUST = logUser.Login(emailaddress, providedPassword);
        return CUST;
}



[HttpGet("IqraPearls/GetSeller")]
  public Sellers Seller( string emailaddress, string providedPassword){
        LoginSeller logseller = new LoginSeller();
        Sellers SELLER = new Sellers();
        SELLER = logseller.Login(emailaddress, providedPassword);
        return SELLER;
}


}


}