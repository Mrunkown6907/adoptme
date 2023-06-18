using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class cus_factory
    {
        public static customer CreateCustomer(int phoneNum, string email, string address, string nama, string pass)
        {
            return new customer
            {
                customer_id = customerId,
                phone_num = phoneNum,
                email = email,
                address = address,
                nama = nama,
                pass = pass,
                saldo = 0
            };
        }
    }
}