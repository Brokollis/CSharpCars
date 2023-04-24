using Models;
using MyProject.Data;

namespace Controllers{

    public class SalesBalanceController{

        public static void Create(SalesBalance salesBalance){
            using (var context = new Context()){
                context.SalesBalances.Add(salesBalance);
                context.SaveChanges();
            }
        }

        public static List<SalesBalance> Read()
        {
            using (var context = new Context())
            {
                return context.SalesBalances.ToList();
            }
        }

        public static SalesBalance ReadById(int id)
        {
            using (var context = new Context())
            {
                var salesBalance = context.SalesBalances.Find(id);
                if (salesBalance == null)
                {
                    throw new ArgumentException("Carro não encontrado");
                }
                else
                {
                    return (SalesBalance) salesBalance;
                }
            }
        }

        public static void Update(SalesBalance salesBalance)
        {
            using (var context = new Context())
            {
                context.SalesBalances.Update(salesBalance);
                context.SaveChanges();
            }
        }

        public static void Delete(SalesBalance salesBalance)
        {
            using (var context = new Context())
            {
                context.SalesBalances.Remove(salesBalance);
                context.SaveChanges();
            }
        }
    }
}