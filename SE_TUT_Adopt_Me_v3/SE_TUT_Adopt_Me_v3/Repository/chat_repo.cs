using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class chat_repo
    {
        static DatabaseEntities1 db = new DatabaseEntities1();

        public void AddChat(string shopId, string customerId)
        {
            chat_factory.CreateChat( shopId, customerId);
            db.SaveChanges();
        }

        public void UpdateChat(chat Chat)
        {
            var existingChat = db.chats.Find(Chat.chat_id);
            if (existingChat != null)
            {
                db.Entry(existingChat).CurrentValues.SetValues(Chat);
                db.SaveChanges();
            }
        }

        public void DeleteChat(string chatId)
        {
            var chat = db.chats.Find(chatId);
            if (chat != null)
            {
                db.chats.Remove(chat);
                db.SaveChanges();
            }
        }

        public chat GetChatById(string chatId)
        {
            return db.chats.Find(chatId);
        }

        public List<chat> GetAllChats()
        {
            return db.chats.ToList();
        }
    }
}