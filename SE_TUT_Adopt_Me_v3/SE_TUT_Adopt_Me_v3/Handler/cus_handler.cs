using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using SE_TUT_Adopt_Me_v3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Handler
{
    public class cus_handler
    {

        public bool IsEmailTaken(string email)
        {
            return cus_repo.GetByEmail(email) != null;
        }

        public bool IsPhoneNumberTaken(int phoneNumber)
        {
            return cus_repo.GetByPhoneNumber(phoneNumber) != null;
        }

        public bool IsDuplicateUser(string customerId, string email, int phoneNumber)
        {
            return IsEmailTaken(email) || IsPhoneNumberTaken(phoneNumber);
        }

        public bool IsValidPassword(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        public bool SaveUser(customer Customer)
        {
            var existingCustomer = cus_repo.GetCustomerById(Customer.customer_id);
            if (IsDuplicateUser(Customer.customer_id, Customer.email, Customer.phone_num) &&
                (existingCustomer == null || existingCustomer.email != Customer.email || existingCustomer.phone_num != Customer.phone_num))
            {
                return false; // Another user already exists with the given email or phone number
            }

            cus_repo.UpdateCustomer(Customer.customer_id,Customer.phone_num, Customer.email, Customer.address, Customer.nama, Customer.pass);
            return true;
        }

        public bool CreateUser(string customerId, int phoneNumber, string email, string address, string name, string password, string confirmPassword, int saldo)
        {
            if (IsDuplicateUser(customerId, email, phoneNumber))
            {
                return false; // User already exists with the given username, email, or phone number
            }

            if (!IsValidPassword(password, confirmPassword))
            {
                return false; // Password and confirm password do not match
            }

            var Customer = cus_factory.CreateCustomer(phoneNumber, email, address, name, password);
            cus_repo.AddCustomer(phoneNumber, email, address, name, password);
            return true;
        }
    }
}