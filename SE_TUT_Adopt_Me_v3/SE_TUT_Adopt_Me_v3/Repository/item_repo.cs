using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class item_repo
    {
        static DatabaseEntities2 db = new DatabaseEntities2();

        public static void AddItem(string shopId, string itemName, int inventory, DateTime expirationDate, int price, string itemImagePath)
        {
            item_factory.CreateItem( shopId, itemName, inventory, expirationDate, price, itemImagePath);
            db.SaveChanges();
        }

        public static void UpdateItem(string itemId, string shopId, string itemName, int inventory, DateTime expirationDate, int price, string itemImagePath)
        {
            var existingItem = db.items.Find(itemId);
            if (existingItem != null)
            {
                existingItem.shop_id = shopId;
                existingItem.item_name = itemName;
                existingItem.inventory = inventory;
                existingItem.expiration_date = expirationDate;
                existingItem.price = price;
                existingItem.item_image_path = itemImagePath;

                db.SaveChanges();
            }
        }


        public static void DeleteItem(string itemId)
        {
            var item = db.items.Find(itemId);
            if (item != null)
            {
                db.items.Remove(item);
                db.SaveChanges();
            }
        }

        public static item GetItemById(string itemId)
        {
            return db.items.Find(itemId);
        }

        public static List<item> GetAllItems()
        {
            return db.items.ToList();
        }
    }
}