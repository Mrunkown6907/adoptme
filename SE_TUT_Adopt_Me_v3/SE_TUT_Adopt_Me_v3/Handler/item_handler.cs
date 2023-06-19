using SE_TUT_Adopt_Me_v3.Model;
using SE_TUT_Adopt_Me_v3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Handler
{
    public class item_handler
    {
        public void AddItem(string shopId, string itemName, int inventory, DateTime expirationDate, int price, string itemImagePath)
        {
            // Check if the required fields are filled
            if (string.IsNullOrEmpty(shopId) || string.IsNullOrEmpty(itemName) || inventory <= 0 || price <= 0 || string.IsNullOrEmpty(itemImagePath))
            {
                throw new InvalidOperationException("Required fields must be filled.");
            }

            item_repo.AddItem(shopId, itemName, inventory, expirationDate, price, itemImagePath);
        }

        public void UpdateItem(string itemId, string shopId, string itemName, int inventory, DateTime expirationDate, int price, string itemImagePath)
        {
            // Check if the required fields are filled
            if (string.IsNullOrEmpty(shopId) || string.IsNullOrEmpty(itemName) || inventory <= 0 || price <= 0 || string.IsNullOrEmpty(itemImagePath))
            {
                throw new InvalidOperationException("Required fields must be filled.");
            }

            item_repo.UpdateItem(itemId, shopId, itemName, inventory, expirationDate, price, itemImagePath);
        }

        public void DeleteItem(string itemId)
        {
            item_repo.DeleteItem(itemId);
        }

        public item GetItemById(string itemId)
        {
            return item_repo.GetItemById(itemId);
        }

        public List<item> GetAllItems()
        {
            return item_repo.GetAllItems();
        }

    }
}