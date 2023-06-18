using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class cus_repo
    {
        static DatabaseEntities db = new DatabaseEntities();

        public static void AddCustomer(int phoneNum, string email, string address, string nama, string pass)
        {
            cus_factory.CreateCustomer(phoneNum, email, address, nama, pass);
        }

        public static void UpdateCustomer(string customer_id, int Phone_num, string Email, string Address, string Nama, string Pass)
        {
            var NewCustomer = db.customers.Find(customer_id);
            if (NewCustomer != null)
            {
                NewCustomer.phone_num = Phone_num;
                NewCustomer.email = Email;
                NewCustomer.address = Address;
                NewCustomer.nama = Nama;
                NewCustomer.pass = Pass;
                db.SaveChanges();
            }
        }

        public void AddSaldoToCustomer(string customerId, int saldoToAdd)
        {
            var customer = db.customers.Find(customerId);
            if (customer != null)
            {
                customer.saldo += saldoToAdd;
                db.SaveChanges();
            }
        }

        public void ReduceSaldoFromCustomer(string customerId, int saldoToReduce)
        {
            var customer = db.customers.Find(customerId);
            if (customer != null)
            {
                if (customer.saldo >= saldoToReduce)
                {
                    customer.saldo -= saldoToReduce;
                    db.SaveChanges();
                }
                else
                {
                    // Handle insufficient saldo case
                    throw new InvalidOperationException("Insufficient saldo.");
                }
            }
        }

        public void DeleteCustomer(string customerId)
        {
            var customer = db.customers.Find(customerId);
            if (customer != null)
            {
                db.customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public static customer GetCustomerById(string customerId)
        {
            return db.customers.FirstOrDefault(c => c.customer_id == customerId);
        }

        public static customer GetByName(string name)
        {
            return db.customers.FirstOrDefault(c => c.nama == name);
        }

        public static customer GetByEmail(string email)
        {
            return db.customers.FirstOrDefault(c => c.email == email);
        }

        public static customer GetByPhoneNumber(int phoneNumber)
        {
            return db.customers.FirstOrDefault(c => c.phone_num == phoneNumber);
        }
        public static customer GetByPass(string pass)
        {
            return db.customers.FirstOrDefault(c => c.pass == pass);
        }

        public static List<customer> GetAllCustomers()
        {
            return db.customers.ToList();
        }
    }
}