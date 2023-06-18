using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class wish_repo
    {
        static DatabaseEntities db = new DatabaseEntities();

        public void AddWishlist(wishlist Wishlist)
        {
            db.wishlists.Add(Wishlist);
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