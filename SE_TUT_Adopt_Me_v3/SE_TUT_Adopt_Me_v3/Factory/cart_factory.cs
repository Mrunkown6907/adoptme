using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class cart_factory
    {
        public static cart CreateCart(string customerId)
        {
            return new cart
            {
                cart_id = GenerateUniqueId(),
                customer_id = customerId
            };
        }

        static string GenerateUniqueId()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 1000); // Generate a random 3-digit number
            string uniqueId = "CART" + randomNumber.ToString();
            return uniqueId;
        }
    }

}