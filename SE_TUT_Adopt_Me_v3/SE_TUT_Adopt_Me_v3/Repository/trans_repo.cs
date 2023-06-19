using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class trans_repo
    {
        static DatabaseEntities2 db = new DatabaseEntities2();

        public void AddTransaction(string customerId, string shopId, int tempSaldo)
        {
            trans_factory.CreateTransaction( customerId, shopId, tempSaldo);
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