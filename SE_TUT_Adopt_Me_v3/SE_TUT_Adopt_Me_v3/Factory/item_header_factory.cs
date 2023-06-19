using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class item_header_factory
    {
        public static item_header CreateItemHeader(string cartId, string itemId, int quantity)
        {
            return new item_header
            {
                item_header_id = GenerateUniqueId(),
                cart_id = cartId,
                item_id = itemId,
                quantity = quantity
            };
        }

        static string GenerateUniqueId()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 1000); // Generate a random 3-digit number
            string uniqueId = "ITH" + randomNumber.ToString();
            return uniqueId;
        }
    }
}