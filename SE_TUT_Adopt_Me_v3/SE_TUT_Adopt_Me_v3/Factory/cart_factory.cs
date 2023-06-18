using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class cart_factory
    {
        public static cart CreateCart(string cartId, string customerId)
        {
            return new cart
            {
                cart_id = cartId,
                customer_id = customerId
            };
        }
    }
}