using Models;
using Views;

namespace Controllers{

    public static class CarValidation{
        public static bool IsCarInputEmpty(Models.Car car){
            
            if(car.Brand == null || car.Model == null || car.Year == 0 || car.Color == null || car.Type == null || car.LicensePlate == null || car.Year == 0){

               return true;
            }
            return false;
        }
        // public static bool IsCarInputEmpty(Models.Car car){
        //     return (car.Brand != null && car.Model != null && car.Year != 0 && car.Color != null && car.Type != null && car.LicensePlate != null && car.Price != 0);
        // }

        // public static bool ValidateLicensePlate(Models.Car car){
        //     Car existingCar = CarController.Read().FirstOrDefault(c => c.LicensePlate == Views.RegisterCar.mskLicensePlate.Text);
        //     return existingCar == null;
        // }

        public static void ValidateYear(Models.Car car){
            if(car.Year < 1950 || car.Year > DateTime.Now.Year){
                throw new ArgumentException("Ano inválido.");
            }
        }
    }
}