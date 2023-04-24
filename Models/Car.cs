using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Car{
        [Column("IdCar")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
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
        public decimal Price { get; set; }


        
        public Car(string Brand, string Model, int Year, string Color, string LicensePlate, string Type, decimal Price){
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