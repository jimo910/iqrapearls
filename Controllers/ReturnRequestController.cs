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
using IqraPearls.Enums;

namespace IqraPearls.Controllers{



[ApiController]
[Route("[controller]")]
public class ReturnRequestcontroller : ControllerBase
{


[HttpGet("IqraPearls/GetCustomerReturnRequest")]
public IEnumerable<ReturnRequestDto> GetCustomerReturnRequest(int CustomerId){

   ReturnRequest RetReq = new ReturnRequest();
   IEnumerable<ReturnRequestDto>  ListRetReq =RetReq.GetCustomerReturnRequest(CustomerId);
  return ListRetReq;

}


[HttpPost("IqraPearls/PostReturnReques")]
public IActionResult PostReturnRequest( [FromBody] ReturnRequestDto newReturnRequestDto)
{

   ReturnRequest RetReq = new ReturnRequest();
   boolEnum.boolEnums result = RetReq.PostReturnRequest(newReturnRequestDto);
   if(result == boolEnum.boolEnums.NULL){
         return BadRequest("OrderNumber Doesnot Exist");
   }else if(result == boolEnum.boolEnums.NAN){

        return BadRequest("Customer does not Exist");
   }else if(result == boolEnum.boolEnums.EMPTY){
    return BadRequest("Reason For return can not be Empty");
   }else{
    return Ok("Return Requested Posted");
   }
}



 [HttpDelete("IqraPearls/DeleteReturnRequest")]
    public IActionResult DeleteReturnRequest(Guid OrderNumber)
    {

          /* bool isDelete = OrderProduct.CancelOrder(OrderNumber);
           if(isDelete){
            return NoContent();
           }
           return NotFound();*/
        ReturnRequest RetReq = new ReturnRequest();
        bool isDelete  = RetReq.DeleteReturnRequest(OrderNumber);
        if(isDelete){
            return NoContent();
           }
           return NotFound();
    }


}


}