using SE_TUT_Adopt_Me_v3.Model;
using SE_TUT_Adopt_Me_v3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Handler
{
    public class shop_handler
    {
        public void AddShop(int shopPhoneNumber, string shopAddress, string shopName, string shopPass, string confirmedPass, int shopSaldo, int rating)
        {
            // Check if shop name is unique
            if (!IsShopNameUnique(shopName))
            {
                throw new InvalidOperationException("Shop name must be unique.");
            }

            // Check if password and confirmed password match
            if (shopPass != confirmedPass)
            {
                throw new InvalidOperationException("Password and confirmed password do not match.");
            }

            shop_repo.AddShop(shopPhoneNumber, shopAddress, shopName, shopPass, shopSaldo, rating);
        }

        public void UpdateShop(string shopId, int shopPhoneNumber, string shopAddress, string shopName, string shopPass, string confirmedPass)
        {
            // Check if shop name is unique excluding the current shop
            if (!IsShopNameUnique(shopName, shopId))
            {
                throw new InvalidOperationException("Shop name must be unique.");
            }

            // Check if password and confirmed password match
            if (shopPass != confirmedPass)
            {
                throw new InvalidOperationException("Password and confirmed password do not match.");
            }

            shop_repo.UpdateShop(shopId, shopPhoneNumber, shopAddress, shopName, shopPass);
        }

        public void AddSaldoToShop(string shopId, int saldoToAdd)
        {
            shop_repo.AddSaldoToShop(shopId, saldoToAdd);
        }

        public void ReduceSaldoFromShop(string shopId, int saldoToReduce)
        {
            shop_repo.ReduceSaldoFromShop(shopId, saldoToReduce);
        }

        public void DeleteShop(string shopId)
        {
            shop_repo.DeleteShop(shopId);
        }

        public shop GetShopById(string shopId)
        {
            return shop_repo.GetShopById(shopId);
        }

        public List<shop> GetAllShops()
        {
            return shop_repo.GetAllShops();
        }

        private bool IsShopNameUnique(string shopName, string excludeShopId = null)
        {
            List<shop> allShops = shop_repo.GetAllShops();

            if (excludeShopId != null)
            {
                // Exclude the shop being updated from the check
                allShops = allShops.Where(shop => shop.shop_id != excludeShopId).ToList();
            }

            return !allShops.Any(shop => shop.shop_name == shopName);
        }
    }
}