using Models;
using MyProject.Data;

namespace Controllers
{
    public class CarController
    {
       public static void Create(Car car){

            CarValidation.ValidateYear(car);
            if(!CarValidation.IsCarInputEmpty(car)){
                using (var context = new Context()){
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
                MessageBox.Show("Carro foi registrado com sucesso!");
            }else{
                MessageBox.Show("Preencha todos os campos!");
                return;
            }
        }

        public static List<Car> Read()
        {
            using (var context = new Context())
            {
                return context.Cars.ToList();
            }
        }

        public static Car ReadById(int id)
        {
            using (var context = new Context())
            {
                var car = context.Cars.Find(id);
                if (car == null)
                {
                    throw new ArgumentException("Carro não encontrado");
                }
                else
                {
                    return (Car) car;
                }
            }
        }



        public static void Update(Car car)
        {
            using (var context = new Context())
            {
                context.Cars.Update(car);
                context.SaveChanges();
            }
        }

        public static void Delete(Car car)
        {
            using (var context = new Context())
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }
    }
}
