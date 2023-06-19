using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class shop_factory
    {
        public static shop CreateShop(int shopPhoneNumber, string shopAddress, string shopName, string shopPass, int shopSaldo, int rating)
        {
            return new shop
            {
                shop_id = GenerateUniqueId(),
                shop_phone_number = shopPhoneNumber,
                shop_address = shopAddress,
                shop_name = shopName,
                shop_pass = shopPass,
                shop_saldo = shopSaldo,
                rating = rating
            };
        }

        static string GenerateUniqueId()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 1000); // Generate a random 3-digit number
            string uniqueId = "SH" + randomNumber.ToString();
            return uniqueId;
        }
    }
}