using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace consoleApp {


public class Program{

    static void Main(string[] args)
        {
            Console.WriteLine("main FUNCTION ENETERED");
                        market Bodija  = new market ();
            Bodija.surf_through_market();

        }
public class market {

    public  static List<storeowner> seller = new List<storeowner>();
    public static  List <Customers> buyers = new List<Customers>();
    public static int confirm_transaction(int StoreId, int ProductID, int no_of){

          storeowner returnStore;
      //  StoreId= Convert.ToInt32 (Console.ReadLine());
        var storeShop = from stores in seller
                        where stores.storeId==StoreId
                        select stores;
        returnStore= storeShop.First();            

        int return_value = returnStore.check_product(ProductID, no_of);

        return return_value;

    }

    public static storeowner.store_product process_transaction( int StoreId, int producId ){

              storeowner returnStore;
       // StoreId= Convert.ToInt32 (Console.ReadLine());
        var storeShop = from stores in seller
                        where stores.storeId==StoreId
                        select stores;

        returnStore= storeShop.First();
         var storeProds = from hell in returnStore.StoreProduct
                           where hell.productID==producId
                           select hell;
         
        storeowner.store_product  hells = storeProds.First();

        return hells;
                        
    }
    public void create_a_new_seller(){
        Console.WriteLine("What is the STORE Name");
        string sellerStore = Console.ReadLine();
        Console.WriteLine("What is the store  Description");
        string sellerDescription = Console.ReadLine();
        storeowner Store_Owner = new storeowner (sellerStore, sellerDescription);
        int x = seller.Count();
        Console.WriteLine($"the list has {x}");
        seller.Add(Store_Owner);
        Console.WriteLine($"the list has { seller.Count()}");
        Console.WriteLine($"Seller {sellerStore} has a unique ID of {Store_Owner.storeId} ");
    }

    public void create_a_new_buyer(){
        Console.WriteLine("What is the customer's Name");
        string customer = Console.ReadLine();
        
             Customers cust = new Customers(customer);
       buyers.Add(cust);
        Console.WriteLine($" Customer {customer} has a unique ID of {cust.customerId} ");

    }

    public void print_all_product_available (){
        Console.WriteLine("print all product available entered");
            Console.WriteLine(seller.Count);
            foreach (storeowner StoreProd  in seller){
             Console.WriteLine($"*****************************************BEGIN STORE : {StoreProd.storename}({StoreProd.storeId})*******************************************");
                        foreach (product  storesp in StoreProd.StoreProduct ){

                                Console.WriteLine($"{storesp.name}\t {storesp.productID}\t{storesp.price}\t {storesp.category}");
                        }
             Console.WriteLine("***************************************END STORE******************************************/n");
            }    


    }

    public storeowner access_store_as_owner(){
        Console.WriteLine("access stored as owner entered");
        int StoreId;
        storeowner returnStore;
        StoreId= Convert.ToInt32 (Console.ReadLine());
        var storeShop = from stores in seller
                        where stores.storeId==StoreId
                        select stores;

        returnStore= storeShop.First();
        Console.WriteLine($" the store name is {returnStore.storename} and the description is {returnStore.storeowner_description}");
         return returnStore;
    }


    public Customers access_market_as_customers()
    {
        Console.WriteLine("access stored as  customer entered");
        Customers Returncust;
        int customer_access_ID;
        customer_access_ID = Convert.ToInt32(Console.ReadLine());
        var customerShops = from customer_buy in buyers
                            where customer_buy.customerId==customer_access_ID
                            select customer_buy;
        Returncust = customerShops.First();
      return Returncust;

    }


public void surf_through_as_owner(storeowner hello){
    Int32 cases = 1;
    while (cases!=0){

            switch (cases){
               case 1:
                    hello.list_all_product_available();
                     Console.WriteLine("case 1");
                     cases = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                        hello.stock_product();
                         Console.WriteLine("case 2");
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;
                case 3: 

                        int prodId;
                        prodId = Convert.ToInt32(Console.ReadLine());
                        hello.stock_existing_product(prodId);
                        Console.WriteLine("case 3");
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;
            }
    }

}


public void surf_through_as_customer(Customers cust){

 Int32 cases = 1;
    while (cases!=0){

            switch (cases){
               case 1:
                  //  hello.list_all_product_available();
                  this.print_all_product_available();
                     Console.WriteLine("case 1");
                     cases = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                     
                         Console.WriteLine("case 2");
                         cust.print_all_product_carted();
                         cases = Convert.ToInt32(Console.ReadLine());
                         break;
                case 3: 

                       // int prodId;
                       // prodId = Convert.ToInt32(Console.ReadLine());
                       Console.WriteLine("case 3");
                        cust.pick_item();
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;
                case 4:

                        Console.WriteLine("case 4");
                        cust.pay_for_item();
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;

            }
    }

}


  public void surf_through_market(){

               // mainmenu  login as customer, login as storeonwer, create a store, create  a customeraccount, list all product and their owner.
               //toolbar on customer: list all product_available in market,  list all product the customers_has_carted, checkout the product and pay, buy a product,back
              // toolbar on seller : stock new product; check_product_remaining on it store, stock_existing_product, back,
            Console.WriteLine("SURF INTO ENTERED");
            Int32 cases=4;
    while (cases!=-1){

            switch(cases)
            {

             case 1:
                        Console.WriteLine("case 1");
                        storeowner hello=  this.access_store_as_owner();
                        this.surf_through_as_owner(hello);
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;
            case 2: 
                         Console.WriteLine("case 2");
                      //  storeowner hello=  this.access_store_as_owner();
                      Customers helo = this.access_market_as_customers();
                        //this.surf_through_as_owner(hello);
                        this.surf_through_as_customer(helo);
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;


            case 3:

                      this.create_a_new_seller();
                     Console.WriteLine("case 3");
                        cases = Convert.ToInt32(Console.ReadLine());
                        break; 

            case 4: 
                         this.create_a_new_buyer();
                         Console.WriteLine("case 4");
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;  
            case 0: 
                        Console.WriteLine("case 0");
                       this.print_all_product_available();
                        cases = Convert.ToInt32(Console.ReadLine());
                        break;  
              
            }


    }


   }

}

}
}
