

using System;
using System.IO;
using System.Collections.Generic;
using IqraPearls.DataDbContext;

namespace IqraPearls.StaticMethods{

public  class staticMethodsClass{

    public static bool DeleteImage (string imagePath){
         // Check if the file exists
        if (File.Exists(imagePath))
        {
            try
            {
                // Delete the file
                File.Delete(imagePath);
                return true;
               
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
       
            return false;
    }
}

}