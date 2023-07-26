using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace consoleApp{

    public class product{

        public string name;
        public string category;
        public double price;
        public string size;
        public string description;
       public  int productID;
        static  int productId;

    public product(string names, double price, string categorys, string sizes, string descriptions){
            this.name=names;
            this.price=price;
            this.category=categorys;
            this.size=sizes;
            this.description=descriptions;
            
            productId= productId+1;
            productID=productId;
    }
        
    }


   


    
    
}