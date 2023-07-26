using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace consoleApp{

 public class Customers{

    public string name;
    public int customerId;
    static int custID;
    public Customers(string names){

         this.name = names;
        customerId = custID+1;
        custID = custID+1;
    }
    private List<storeowner.store_product> hello = new List<storeowner.store_product>();
    public void pay_for_item(){
      double  total_money_paid=0;
      Console.WriteLine("GO FOR CHECKOUT");
      Console.WriteLine($"{hello.Count} product is  been checked out");
      foreach ( storeowner.store_product items in hello){
         Console.WriteLine($"{items.how_many} {items.name} is bought at {items.price} unit price");
         total_money_paid = total_money_paid + (items.how_many*items.price);
      }
      
         Console.WriteLine($"the total money expense is {total_money_paid}");
         hello = new List<storeowner.store_product>();
    }
    public void pick_item(){
      int storeId;
      int ProductID;
      int no_of;
      Console.WriteLine("What is the storeID");
      storeId = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("What is the ProductID");
      ProductID = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("How many of the product are you purchasing");
      no_of = Convert.ToInt32(Console.ReadLine());
      int transaction_successful = Program.market.confirm_transaction(storeId, ProductID, no_of);
      if(transaction_successful ==1){
            storeowner.store_product hells = Program.market.process_transaction(storeId, ProductID);
            this.hello.Add(hells);   
      }

    }
    public void print_all_product_carted(){

      foreach(storeowner.store_product hi in hello){
            Console.WriteLine($"{hi.name}\t {hi.price}\t {hi.productID}");
      }
    }


   /* public void return_an_item(){

    }*/


 }

}