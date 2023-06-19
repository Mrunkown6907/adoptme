using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class trans_factory
    {
        public static transaction CreateTransaction(string customerId, string shopId, int tempSaldo)
        {
            return new transaction
            {
                trans_id = GenerateUniqueId(),
                customer_id = customerId,
                shop_id = shopId,
                temp_saldo = tempSaldo
            };
        }
        private static int counter = 0;
        static int GenerateUniqueId()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            int id = (int)((timestamp << 8) | (counter++ % 256));
            return id;
        }
    }
}