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
using IqraPearls.StaticMethods;

 namespace IqraPearls.Data{

    public class  ReturnRequest{

        private List <ReturnRequestProductQuantityDto> returnProductQuantity;
        private List <ProductRequestRelationship> ListProductId ; 

        public boolEnum.boolEnums PostReturnRequest( ReturnRequestDto newReturnRequestDto){

            var context = new IqraDbContext();
            var OrderNumberExist = context.Orders.FirstOrDefault(a => a.OrderNumber == newReturnRequestDto.OrderNumber);
            if(OrderNumberExist == null){
                return boolEnum.boolEnums.NULL;
            } else if(OrderNumberExist.CustomerId != newReturnRequestDto.CustomerId){
                return boolEnum.boolEnums.NAN;
            }else if(newReturnRequestDto.ReasonForReturn == null && newReturnRequestDto.ProductIdQuantity == null){
                return  boolEnum.boolEnums.EMPTY;
            }else{


               returnProductQuantity =newReturnRequestDto.ProductIdQuantity;
               foreach( var returnRequest in returnProductQuantity){

                  int productId =staticMethodsClass.returnProductId(newReturnRequestDto.OrderNumber, returnRequest.ProductIdonOrder);
                   ListProductId.Add (new ProductRequestRelationship{ProductId =productId});
                    SellerReturnRequestModel  sellerreturnModel = new SellerReturnRequestModel{
                        OrderNumber = newReturnRequestDto.OrderNumber,
                        CustomerId = newReturnRequestDto.CustomerId,
                        ReasonForReturn = newReturnRequestDto.ReasonForReturn,
                        ProductIdToReturn =  productId,
                        QuantityToReturn = returnRequest.Quantity,
                        TimeReturnRequested = DateTime.Now,
                        isRequestAccepted =  false,
                        ReasonForAcceptanceOrDenial =   null,
                        ProductIdonOrder = returnRequest.ProductIdonOrder,
                        SellersId = staticMethodsClass.returnSellersId(newReturnRequestDto.OrderNumber, returnRequest.ProductIdonOrder)
                    };
                    context.SellerReturnRequestTable.Add(sellerreturnModel);
                    
               }

               ReturnRequestModel returnRequestModel = new ReturnRequestModel{
                OrderNumber = newReturnRequestDto.OrderNumber,
                CustomerId = newReturnRequestDto.CustomerId,
                ReasonForReturn = newReturnRequestDto.ReasonForReturn,
                PRRelations = ListProductId,
                TimeReturnRequested = DateTime.Now,
                ReturnChoice = newReturnRequestDto.ReturnChoice,
                ReturnStatus = ReturnStatus.ReturnStatusEnums.Pending
               };

               context.ReturnRequestTable.Add(returnRequestModel);
               context.SaveChanges();
            
                return boolEnum.boolEnums.TRUE;
            }
                

        }


        public bool DeleteReturnRequest(Guid OrderNumber){

            var context = new IqraDbContext ();
            var SellerReturnRequest = context.SellerReturnRequestTable;
           var checkOrderNumber = context.ReturnRequestTable.FirstOrDefault(a => a.OrderNumber == OrderNumber);
           if(checkOrderNumber != null){

                checkOrderNumber.ReturnStatus = ReturnStatus.ReturnStatusEnums.Deleted;
                // Send Notifications to Seller Request Deleted.
               // context.SellerReturnRequestTable.RemoveAll(a=> a.OrderNumber == OrderNumber);
               var sellerReturnRequestToDelete =  SellerReturnRequest.Where(a=>  a.OrderNumber == OrderNumber).ToList();
               if(sellerReturnRequestToDelete.Count >0){
                SellerReturnRequest.RemoveRange(sellerReturnRequestToDelete);
               }
                return true;
           }

        return false;

        }
        public IEnumerable<ReturnRequestDto> GetCustomerReturnRequest(int CustomerId){

            var context = new IqraDbContext();
            var GetCustomerReq = context.ReturnRequestTable.Where(a => a.CustomerId == CustomerId).ToList();
            List<ReturnRequestDto> ListReturnRequestDto =  new List<ReturnRequestDto>() ;
            foreach (var GetCustomerRequest in GetCustomerReq){

              ReturnRequestDto  returnRequest = new ReturnRequestDto {
                OrderNumber = GetCustomerRequest.OrderNumber,
                ReasonForReturn = GetCustomerRequest.ReasonForReturn,
                ReturnChoice = GetCustomerRequest.ReturnChoice,
                ProductIdQuantity = staticMethodsClass.returnProductQuantity(GetCustomerRequest.OrderNumber)
            };
                ListReturnRequestDto.Add(returnRequest);
                
        }
        return ListReturnRequestDto;

    }

 }

 }