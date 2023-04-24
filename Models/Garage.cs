using System.ComponentModel.DataAnnotations.Schema;

namespace Models{

    public class Garage{
            
        [Column("IdGarage")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int Id { get; set; }

        [Column("NameGarage")]
        public string Name { get; set; }

        [Column("AddressGarage")]
        public string Address { get; set; }

        public Garage(string Name, string Address){
            this.Name = Name;
            this.Address = Address;
        }

    }
}