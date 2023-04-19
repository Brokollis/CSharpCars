namespace Views{
    public class Produto : Form
    {
        ListView list;

        public Produto()
        {
            this.Text = "Produto";
            this.Size = new Size(680, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(575, 180);
            list.Location = new Point(50, 50);
            list.View = View.Details;
            list.Columns.Add("Id");
            list.Columns.Add("Brand");
            list.Columns.Add("Model");
            list.Columns.Add("Year");
            list.Columns.Add("Color");
            list.Columns.Add("License Plate");
            list.Columns.Add("Type");
            list.Columns.Add("Price");
            list.Columns[0].Width = 0;
            list.Columns[1].Width = 100;
            list.Columns[2].Width = 100;
            list.Columns[3].Width = 50;
            list.Columns[4].Width = 80;
            list.Columns[5].Width = 100;
            list.Columns[6].Width = 70;
            list.Columns[7].Width = 70;
            list.FullRowSelect = true; // permite selecionar a linha inteira ao clicar
            list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            this.Controls.Add(list);

            


            RefreshList(); 

            Button btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(50, 270);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button();
            btnEdit.Text = "Edit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.Location = new Point(170, 270);
            // btnEdit.Click += new EventHandler(btnEdit_Click);
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.Location = new Point(290, 270);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.Controls.Add(btnDelete);

            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Size = new Size(100, 30);
            btnClose.Location = new Point(410, 270);
            btnClose.Click += new EventHandler(btnClose_Click);
            this.Controls.Add(btnClose);
        }
        private void AddToListView(Models.Car car, int id)
        {
            string[] row = { id.ToString(), car.Brand, car.Model, car.Year.ToString(), car.Color, car.LicensePlate, car.Type, car.Price.ToString() };
            ListViewItem item = new ListViewItem(row);
            list.Items.Add(item);
        }

        public void RefreshList()
        {
            list.Items.Clear();

            List<Models.Car> cars = Controllers.CarController.Read();

            int id = 1;

            foreach (Models.Car car in cars)
            {
                AddToListView(car, id);
                id++;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var registerCar = new Views.RegisterCar();
            registerCar.Show();
        }

        // public void btnEdit_Click(object sender, EventArgs e)
        // {
        //     if (list.SelectedItems.Count > 0)
        //     {
        //         int id = int.Parse(list.SelectedItems[0].Text);
        //         var editCar = new Views.RegisterCar(id);
        //         editCar.ShowDialog();
        //         RefreshList(); // update the list after editing a car
        //     }
        //     else
        //     {
        //         MessageBox.Show("Please select a car to edit.");
        //     }
        // }


    private void btnDelete_Click(object sender, EventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                int id = int.Parse(list.SelectedItems[0].Text);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Models.Car car = Controllers.CarController.ReadById(id);
                    Controllers.CarController.Delete(car);
                    RefreshList(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.SelectedItems.Count > 0)
            {
                // obtém o id do carro selecionado
                int id = int.Parse(list.SelectedItems[0].Text);

                // obtém o carro completo a partir do id
                Models.Car selectedCar = Controllers.CarController.ReadById(id);

                // abre a janela de detalhes do carro
                // var detailsForm = new Views.Details(selectedCar);
                // detailsForm.ShowDialog();
            }
        }
    }
}