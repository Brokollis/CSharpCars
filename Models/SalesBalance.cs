using System.ComponentModel.DataAnnotations.Schema;

namespace Models{

    public class SalesBalance{

        [Column("IdSalesBalance")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public int Id { get; set; }

        [Column("CarId")]
        public int CarId {get; set;}
        public Car Car {get; set;}

        [Column("GarageId")]
        public int GarageId {get; set;}
        public Garage Garage {get; set;}

        [Column("AmountSalesBalance")]
        public decimal Amount { get; set; }


        public SalesBalance(int CarId, int GarageId, decimal Amount){
            this.CarId = CarId;
            this.GarageId = GarageId;
            this.Amount = Amount;
        }
        
    }
}