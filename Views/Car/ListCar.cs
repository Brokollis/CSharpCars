using Models;
using Controllers;

namespace Views{
    
    public enum Option { Edit, Delete }

    public class ListCar : Form
    {
        ListView listCar;

         private void AddToListView(Models.Car car)
        {
            string[] row = { 
                car.Id.ToString(), 
                car.Brand, 
                car.Model, 
                car.Year.ToString(), 
                car.Color, 
                car.LicensePlate, 
                car.Type, 
                car.Price.ToString() 
            };
            ListViewItem item = new ListViewItem(row);
            listCar.Items.Add(item);
        }

        public void RefreshList()
        {
            listCar.Items.Clear();

            List<Models.Car> cars = Controllers.CarController.Read();


            foreach (Models.Car car in cars)
            {
                AddToListView(car);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var registerCar = new Views.RegisterCar();
            registerCar.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = GetSelectedCar(Option.Edit);
                RefreshList();
                var modifyCarView = new Views.ModifyCar(car);
                if (modifyCarView.ShowDialog() == DialogResult.OK)
                {
                    // Atualizar a lista após modificar o carro
                    RefreshList();
                    MessageBox.Show("Carro modificado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = GetSelectedCar(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse carro?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.CarController.Delete(car);
                    RefreshList();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public Car GetSelectedCar(Option option)
        {
            if (listCar.SelectedItems.Count > 0)
            {
                int selectedCarId = int.Parse(listCar.SelectedItems[0].Text);
                return Controllers.CarController.ReadById(selectedCarId);
            }
            else
            {
                throw new Exception($"Por gentileza, selecione um carro para {(option == Option.Edit ? "editar" : "deletar")}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public ListCar()
        {
            this.Icon = new Icon("Assets/iconCar.ico", 52,52);


            this.Text = "Carros";
            this.Size = new Size(720, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            listCar = new ListView();
            listCar.Size = new Size(605, 180);
            listCar.Location = new Point(50, 50);
            listCar.GridLines = true;
            listCar.MultiSelect = true;
            listCar.View = View.Details;
            listCar.Columns.Add("Id");
            listCar.Columns.Add("Marca");
            listCar.Columns.Add("Modelo");
            listCar.Columns.Add("Ano");
            listCar.Columns.Add("Cor");
            listCar.Columns.Add("Placa");
            listCar.Columns.Add("Tipo");
            listCar.Columns.Add("Preço");
            listCar.Columns[0].Width = 30;
            listCar.Columns[1].Width = 80;
            listCar.Columns[2].Width = 100;
            listCar.Columns[3].Width = 50;
            listCar.Columns[4].Width = 80;
            listCar.Columns[5].Width = 100;
            listCar.Columns[6].Width = 70;
            listCar.Columns[7].Width = 70;
            listCar.FullRowSelect = true; // permite selecionar a linha inteira ao clicar
            this.Controls.Add(listCar);

            RefreshList();

            Button btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(50, 270);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Size = new Size(100, 30);
            btnEdit.Location = new Point(170, 270);
            btnEdit.Click += new EventHandler(btnUpdate_Click);
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Deletar";
            btnDelete.Size = new Size(100, 30);
            btnDelete.Location = new Point(290, 270);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.Controls.Add(btnDelete);

            Button btnClose = new Button();
            btnClose.Text = "Fechar";
            btnClose.Size = new Size(100, 30);
            btnClose.Location = new Point(550, 270);
            btnClose.Click += new EventHandler(btnClose_Click);
            this.Controls.Add(btnClose);
        }
       


    }
}