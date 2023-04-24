using Models;
using MyProject.Data;

namespace Controllers{

    public class GarageController{

        public static void Create(Garage garage){
            using (var context = new Context()){
                context.Garages.Add(garage);
                context.SaveChanges();
            }
        }

        public static List<Garage> Read()
        {
            using (var context = new Context())
            {
                return context.Garages.ToList();
            }
        }

        public static Garage ReadById(int id)
        {
            using (var context = new Context())
            {
                var garage = context.Garages.Find(id);
                if (garage == null)
                {
                    throw new ArgumentException("Garagem não encontrada");
                }
                else
                {
                    return (Garage) garage;
                }
            }
        }

        public static void Update(Garage garage)
        {
            using (var context = new Context())
            {
                context.Garages.Update(garage);
                context.SaveChanges();
            }
        }

        public static void Delete(Garage garage)
        {
            using (var context = new Context())
            {
                context.Garages.Remove(garage);
                context.SaveChanges();
            }
        }

    }
}