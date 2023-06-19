using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class wish_repo
    {
        static DatabaseEntities2 db = new DatabaseEntities2();

        public void AddWishlist(string customerId, string petId, string itemId)
        {
            wish_factory.CreateWishlist(customerId, petId, itemId);
            db.SaveChanges();
        }

        public void UpdateWishlist(wishlist Wishlist)
        {
            var existingWishlist = db.wishlists.Find(Wishlist.customer_id);
            if (existingWishlist != null)
            {
                db.Entry(existingWishlist).CurrentValues.SetValues(Wishlist);
                db.SaveChanges();
            }
        }

        public void DeleteWishlist(string cartId)
        {
            var wishlist = db.wishlists.Find(cartId);
            if (wishlist != null)
            {
                db.wishlists.Remove(wishlist);
                db.SaveChanges();
            }
        }

        public wishlist GetWishlistById(string cartId)
        {
            return db.wishlists.Find(cartId);
        }

        public List<wishlist> GetAllWishlists()
        {
            return db.wishlists.ToList();
        }
    }
}