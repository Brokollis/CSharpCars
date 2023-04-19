using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Car{
        [Column("IdCar")]        
        public int Id { get; set; }

        [Column("BrandCar")]
        public string Brand { get; set; }

        [Column("ModelCar")]
        public string Model { get; set; }

        [Column("YearCar")]
        public int Year { get; set; }

        [Column("ColorCar")]
        public string Color { get; set; }

        [Column("LicensePlateCar")]
        public string LicensePlate { get; set; }

        [Column("TypeCar")]
        public string Type { get; set; }

        [Column("PriceCar")]
        public float Price { get; set; }


        
        public Car(int Id, string Brand, string Model, int Year, string Color, string LicensePlate, string Type, float Price){
            this.Id = Id;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.Color = Color;
            this.LicensePlate = LicensePlate;
            this.Type = Type;
            this.Price = Price;
        }
    }

}