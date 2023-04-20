using Models;
using MyProject.Data;

namespace Controllers
{
    public class CarController
    {
       public void Create(Car car){
            using (var context = new CarContext()){
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public static List<Car> Read()
        {
            using (var context = new CarContext())
            {
                return context.Cars.ToList();
            }
        }

        public static Car ReadById(int id)
        {
            using (var context = new CarContext())
            {
                var car = context.Cars.Find(id);
                if (car == null)
                {
                    throw new ArgumentException("Carro não encontrado");
                }
                else
                {
                    return car;
                }
            }
        }



        public static void Update(Car car)
        {
            using (var context = new CarContext())
            {
                context.Cars.Update(car);
                context.SaveChanges();
            }
        }

        public static void Delete(Car car)
        {
            using (var context = new CarContext())
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }
    }
}
