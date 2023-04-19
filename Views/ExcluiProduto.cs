
namespace Views
{
    public class ExcluiProduto :Form{

        public void DeleteCar(){

            this.Text = "Excluir Produto";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblId = new Label();
            lblId.Text = "ID";
            lblId.Location = new Point(10, 10);
            lblId.Size = new Size(50, 20);

            TextBox txtId = new TextBox();
            txtId.Location = new Point(80, 10);
            txtId.Size = new Size(150, 20);


           Button btnExcluir = new Button();
            btnExcluir.Text = "Excluir";
            btnExcluir.Location = new Point(10, 40);
            btnExcluir.Size = new Size(100, 20);
            btnExcluir.Click += (sender, e) => {
                int carId = int.Parse(txtId.Text);
                Models.Car carToDelete = Controllers.CarController.ReadById(carId);
                Controllers.CarController.Delete(carToDelete);
                MessageBox.Show("Produto excluído com sucesso!");
                this.Close();
            };

        }





        
    }
}