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

    public class  OrderProduct{

        public int _customerId ;
        private  Guid  _orderNumber;
        public List<Cart> CustomerCart = new List<Cart>();
     //   public List<SellerOrderRelationship> ListOfSellers = new List<SellerOrderRelationship>();

        public OrderProduct(int CustomerId){
                _customerId = CustomerId;
                _orderNumber = Guid.NewGuid();
        }

        public void  getCustomerCart(){

                var context=  new IqraDbContext();
              var  CustomerExist = context.Customerss.FirstOrDefault(a => a.Id ==_customerId);
                if(CustomerExist != null && CustomerExist.ListOfCartProduct != null)
                CustomerCart = CustomerExist.ListOfCartProduct;
                CustomerExist.ListOfCartProduct = null;
        }

       // public int GetSellersId()

        public Guid TakeOrder(){
                getCustomerCart();
                var context = new IqraDbContext();
                foreach(var cartedProduct in CustomerCart){

                    OrderDto _orderDto = new OrderDto{
                        OrderNumber = _orderNumber,
                        CustomerId =  _customerId,
                        ProductId = cartedProduct.ProductId,
                        Quantity = cartedProduct.Quantity,
                        isPaid = false
                    };
                   
                    Product prods =context.Products.FirstOrDefault( a=> a.Id == cartedProduct.ProductId);
                    Sellers seller =  context.Sellerss.FirstOrDefault(a => a.Id== prods.SellersId);
                     SellerOrderRelationship sellerOrderRelations = new SellerOrderRelationship{OrderNumber =_orderNumber, Sellers = seller, SellersId = prods.SellersId };
                   // ListOfSellers.Add(SellerOrderRelationship);
                   // seller.productCartedFromStore.Add(sellerOrderRelations);
                    context.SellerOrderTable.Add(sellerOrderRelations);
                    context.SaveChanges();
                }

            Order order = new Order{
                OrderNumber = _orderNumber,
               // ListOfSellers = this.ListOfSellers,
                ListofProductOrdered = CustomerCart,
                isPaid = false,
                CustomerId = _customerId
            };
            context.Orders.Add(order);
            context.SaveChanges();

        return this._orderNumber;
        }

       
       public static  Order getOrder(Guid OrderNumber){

                var context = new IqraDbContext();
                Order Getorder = context.Orders.FirstOrDefault( a => a.OrderNumber ==OrderNumber);
                    return Getorder;              

       }

       public static bool CancelOrder (Guid OrderNumber){

            var context = new IqraDbContext();
            var SellerOrderrelations = context.SellerOrderTable;
            var OrderTable = context.Orders;
            var sellerOrderToDelete =  SellerOrderrelations.Where(a=>  a.OrderNumber == OrderNumber).ToList();
            var OrderExist = OrderTable.FirstOrDefault( a=> a.OrderNumber== OrderNumber);
            

            if(sellerOrderToDelete.Count >0 && OrderExist != null){
                SellerOrderrelations.RemoveRange(sellerOrderToDelete);  
                OrderTable.Remove(OrderExist);
                return true;
       }

        return false;
    }

    }

 }