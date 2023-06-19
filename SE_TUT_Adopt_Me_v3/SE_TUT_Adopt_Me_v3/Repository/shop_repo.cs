using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class shop_repo
    {
        static DatabaseEntities2 db = new DatabaseEntities2();

        public static void AddShop(int shopPhoneNumber, string shopAddress, string shopName, string shopPass, int shopSaldo, int rating)
        {
            shop_factory.CreateShop(shopPhoneNumber, shopAddress, shopName, shopPass, shopSaldo, rating);
            db.SaveChanges();
        }

        public static void UpdateShop(string shop_id, int shop_phone_number, string shop_address, string shop_name, string shop_pass)
        {
            var NewShop = db.shops.Find(shop_id);
            if (NewShop != null)
            {
                NewShop.shop_phone_number = shop_phone_number;
                NewShop.shop_address = shop_address;
                NewShop.shop_name = shop_name;
                NewShop.shop_pass = shop_pass;
                db.SaveChanges();
            }
        }

        public static void AddSaldoToShop(string shopId, int saldoToAdd)
        {
            var Sshop = db.shops.Find(shopId);
            if (Sshop != null)
            {
                Sshop.shop_saldo += saldoToAdd;
                db.SaveChanges();
            }
        }

        public static void ReduceSaldoFromShop(string shopId, int saldoToReduce)
        {
            var Sshop = db.shops.Find(shopId);
            if (Sshop != null)
            {
                if (Sshop.shop_saldo >= saldoToReduce)
                {
                    Sshop.shop_saldo -= saldoToReduce;
                    db.SaveChanges();
                }
                else
                {
                    // Handle insufficient saldo case
                    throw new InvalidOperationException("Insufficient saldo.");
                }
            }
        }

        public static void DeleteShop(string shopId)
        {
            var shop = db.shops.Find(shopId);
            if (shop != null)
            {
                db.shops.Remove(shop);
                db.SaveChanges();
            }
        }

        public static shop GetShopById(string shopId)
        {
            return db.shops.Find(shopId);
        }

        public static List<shop> GetAllShops()
        {
            return db.shops.ToList();
        }
    }
}