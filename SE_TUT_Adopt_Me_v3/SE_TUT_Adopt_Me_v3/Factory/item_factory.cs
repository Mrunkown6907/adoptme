using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class item_factory
    {
        public static item CreateItem(string itemId, string shopId, string itemName, int inventory, DateTime expirationDate, int price, string itemImagePath)
        {
            return new item
            {
                item_id = itemId,
                shop_id = shopId,
                item_name = itemName,
                inventory = inventory,
                expiration_date = expirationDate,
                price = price,
                item_image_path = itemImagePath
            };
        }
    }
}