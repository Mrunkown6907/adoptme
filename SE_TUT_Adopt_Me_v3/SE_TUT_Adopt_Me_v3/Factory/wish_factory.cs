using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class wish_factory
    {
        public static wishlist CreateWishlist(string customerId, string petId, string itemId)
        {
            return new wishlist
            {
                customer_id = customerId,
                pet_id = petId,
                item_id = itemId
            };
        }
    }
}