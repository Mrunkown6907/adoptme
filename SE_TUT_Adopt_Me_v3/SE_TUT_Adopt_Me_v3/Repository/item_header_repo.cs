using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class item_header_repo
    {
        static DatabaseEntities db = new DatabaseEntities();

        public void AddItemHeader(item_header ItemHeader)
        {
            db.item_header.Add(ItemHeader);
            db.SaveChanges();
        }

        public void UpdateItemHeader(item_header itemHeader)
        {
            var existingItemHeader = db.item_header.Find(itemHeader.item_header_id);
            if (existingItemHeader != null)
            {
                db.Entry(existingItemHeader).CurrentValues.SetValues(itemHeader);
                db.SaveChanges();
            }
        }

        public void DeleteItemHeader(int itemHeaderId)
        {
            var itemHeader = db.item_header.Find(itemHeaderId);
            if (itemHeader != null)
            {
                db.item_header.Remove(itemHeader);
                db.SaveChanges();
            }
        }

        public item_header GetItemHeaderById(int itemHeaderId)
        {
            return db.item_header.Find(itemHeaderId);
        }

        public List<item_header> GetAllItemHeaders()
        {
            return db.item_header.ToList();
        }
    }
}