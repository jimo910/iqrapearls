

using System;
using System.IO;
using System.Collections.Generic;
using IqraPearls.DataDbContext;
using System.Security.Cryptography;
using System.Text;

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

      public  string HashPassword(string password, string salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
            return Convert.ToBase64String(hash);
        }
    }

}

}