using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class shop_factory
    {
        public static shop CreateShop(string shopId, int shopPhoneNumber, string shopAddress, string shopName, string shopPass, int shopSaldo, int rating)
        {
            return new shop
            {
                shop_id = shopId,
                shop_phone_number = shopPhoneNumber,
                shop_address = shopAddress,
                shop_name = shopName,
                shop_pass = shopPass,
                shop_saldo = shopSaldo,
                rating = rating
            };
        }
    }
}