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
public class OrderController : ControllerBase
{


[HttpGet("IqraPearls/GetCustomerOrder")]
public Order GetCustomerOrder(Guid OrderNumber){

    Order getOrder =  new Order();
    getOrder = OrderProduct.getOrder(OrderNumber);
    return getOrder;

}


[HttpPost("IqraPearls/PostCustomerOrder")]
public IActionResult PostCustomerOrder(int CustomerId)
{

    OrderProduct _orderProduct = new OrderProduct(CustomerId);
    Guid OrderNumber = _orderProduct.TakeOrder();
    return Ok($"YOur OrderNumber is {OrderNumber}");

}



 [HttpDelete("IqraPearls/CancelCustomer")]
    public IActionResult CancelCustomerOrder(Guid OrderNumber)
    {

           bool isDelete = OrderProduct.CancelOrder(OrderNumber);
           if(isDelete){
            return NoContent();
           }
           return NotFound();
    }


}


}