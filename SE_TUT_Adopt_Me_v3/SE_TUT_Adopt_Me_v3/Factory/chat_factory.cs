using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class chat_factory
    {
        public static chat CreateChat(string chatId, string shopId, string customerId)
        {
            return new chat
            {
                chat_id = chatId,
                shop_id = shopId,
                customer_id = customerId
            };
        }
    }
}