using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class trans_repo
    {
        static DatabaseEntities db = new DatabaseEntities();

        public void AddTransaction(transaction Transaction)
        {
            db.transactions.Add(Transaction);
            db.SaveChanges();
        }

        public void UpdateTransaction(transaction Transaction)
        {
            var existingTransaction = db.transactions.Find(Transaction.trans_id);
            if (existingTransaction != null)
            {
                db.Entry(existingTransaction).CurrentValues.SetValues(Transaction);
                db.SaveChanges();
            }
        }

        public void DeleteTransaction(int transId)
        {
            var transaction = db.transactions.Find(transId);
            if (transaction != null)
            {
                db.transactions.Remove(transaction);
                db.SaveChanges();
            }
        }

        public transaction GetTransactionById(int transId)
        {
            return db.transactions.Find(transId);
        }

        public List<transaction> GetAllTransactions()
        {
            return db.transactions.ToList();
        }
    }
}