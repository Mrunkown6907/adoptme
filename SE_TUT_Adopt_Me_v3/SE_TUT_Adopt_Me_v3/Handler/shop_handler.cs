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
        public void AddShop(shop Shop)
        {
            // Check if the shop name already exists
            if (IsShopNameTaken(Shop.shop_name))
            {
                throw new ArgumentException("Shop name already exists.");
            }

            // Add the new shop to the repository
            shop_repo.AddShop(Shop);
        }

        public void UpdateShop(string shopId, int shopPhoneNumber, string shopAddress, string shopName, string shopPass)
        {
            // Check if the shop name already exists (excluding the shop being updated)
            if (IsShopNameTaken(shopName, shopId))
            {
                throw new ArgumentException("Shop name already exists.");
            }

            // Update the shop details in the repository
            shop_repo.UpdateShop(shopId, shopPhoneNumber, shopAddress, shopName, shopPass);
        }

        public void AddItemToShop(string shopId, item Item)
        {
            shop targetShop = GetShopById(shopId);
            if (targetShop == null)
            {
                throw new ArgumentException("Shop not found.");
            }

            // Add the new item to the shop's items collection
            targetShop.items.Add(Item);
            shop_repo.SaveChanges();
        }

        public void AddPetToShop(string shopId, pet Pet)
        {
            shop targetShop = GetShopById(shopId);
            if (targetShop == null)
            {
                throw new ArgumentException("Shop not found.");
            }

            // Add the new pet to the shop's pets collection
            targetShop.pets.Add(Pet);
            shop_repo.SaveChanges();
        }

        public List<shop> GetAllShops()
        {
            return shop_repo.GetAllShops();
        }

        public shop GetShopById(string shopId)
        {
            return shop_repo.GetShopById(shopId);
        }

        private bool IsShopNameTaken(string shopName, string excludedShopId = null)
        {
            List<shop> allShops = GetAllShops();

            // Check if any shop has the same name (excluding the shop being updated)
            return allShops.Any(shop => shop.shop_name.Equals(shopName, StringComparison.OrdinalIgnoreCase) && shop.shop_id != excludedShopId);
        }
    }

}
}