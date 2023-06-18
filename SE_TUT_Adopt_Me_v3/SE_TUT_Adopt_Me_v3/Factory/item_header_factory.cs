using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class item_header_factory
    {
        public static item_header CreateItemHeader(int itemHeaderId, string cartId, string itemId, int quantity)
        {
            return new item_header
            {
                item_header_id = itemHeaderId,
                cart_id = cartId,
                item_id = itemId,
                quantity = quantity
            };
        }
    }
}