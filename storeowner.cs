using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace consoleApp{

   public  class storeowner{

        public string storename;
        public string storeowner_description;
        public int storeId;
        static int staticStoreID;
        public List<store_product> StoreProduct = new List<store_product>();
        public storeowner(string storename, string storeowner_description){

            this.storename=storename;
            this.storeowner_description=storeowner_description;
            this.storeId= staticStoreID+1;
            staticStoreID = staticStoreID +1;

        }
        public void stock_product(){
             string name;
             string category;
             double price;
             string size;
             string description;
             int  how_many;
            name =Console.ReadLine();
            category =Console.ReadLine();
            size =Console.ReadLine();
            description =Console.ReadLine();
            price =Convert.ToDouble(Console.ReadLine());
            how_many = Convert.ToInt32(Console.ReadLine());
          store_product newe = new store_product(name, price,category,size, description,how_many);
           StoreProduct.Add(newe);
            
        }

        public void stock_existing_product(int ProductIDs){
                    var productisp = from prodcs  in StoreProduct
                                     where prodcs.productID==ProductIDs
                                     select prodcs;
                    store_product prods = productisp.First();
                    Console.WriteLine("how many more products is to be stocked");
                    int heead = Convert.ToInt32(Console.ReadLine());
                    prods.how_many= prods.how_many+heead;

        }

        public void list_all_product_available(){
            foreach (store_product ISP in StoreProduct){
                    Console.WriteLine($"{ISP.name}\t{ISP.price}\t{ISP.productID} \t {ISP.how_many}");
            }
        }


        public int check_product(int productISD,  int no_of){
                int return_value=0;
          var product_exist = from productS in  StoreProduct 
                                where productS.productID == productISD    
                                orderby productS.category
                                select productS;
            if(product_exist.Count() !=0){                   
            foreach (var Vproduct in product_exist){
                    if(Vproduct.how_many >=no_of){
                          //  Console.WriteLine("Congratulations it available");
                          //  print_reciept(Vproduct, Customername, no_of);
                          Vproduct.how_many = Vproduct.how_many-no_of;
                            return_value= 1;
                    }
            }
            Console.WriteLine($"oouch  we have less of it available");
            }
            else{
                Console.WriteLine("SORRY FOR THE INCOVINIENCE, THE PRODUCT IS OUT OF STOCK");
                return_value=0;
            }              
            return return_value;
        }

        public store_product GetProduct(int productId){

            var product_exist = from productS in  StoreProduct 
                                where productS.productID == productId    
                                orderby productS.category
                                select productS;

            store_product productSW = product_exist.First();    
            return productSW; 
        }

        public void print_reciept(product ProductSold, string Customername,  int no_of){
                Console.WriteLine($"{this.storename}");
                Console.WriteLine($" This is to certify that {Customername} purchase  {no_of} {ProductSold.name}  of unit price{ProductSold.price}, to make a totalPrice of{no_of* ProductSold.price} ");
                Console.WriteLine("THANKS FOR YOUR PATRONAGE");
        }

    public class store_product :product{
           
       public store_product(string names, double price, string categorys, string sizes, string descriptions, int how_man):base(names, price, categorys,sizes,descriptions){

            this.how_many = how_man;
        }
        
        public int how_many;

    }   
        
    }
}