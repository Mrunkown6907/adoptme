using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class trans_factory
    {
        public static transaction CreateTransaction(int transId, string customerId, string shopId, int tempSaldo)
        {
            return new transaction
            {
                trans_id = transId,
                customer_id = customerId,
                shop_id = shopId,
                temp_saldo = tempSaldo
            };
        }
    }
}