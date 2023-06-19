using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class chat_factory
    {
        public static chat CreateChat(string shopId, string customerId)
        {
            return new chat
            {
                chat_id = GenerateUniqueId(),
                shop_id = shopId,
                customer_id = customerId
            };
        }

        static string GenerateUniqueId()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 1000); // Generate a random 3-digit number
            string uniqueId = "CH" + randomNumber.ToString();
            return uniqueId;
        }
    }
}