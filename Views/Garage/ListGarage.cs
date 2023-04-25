using Models;
using Controllers;

namespace Views{

    public class ListGarage : Form {

        public enum Option { Edit, Delete }
        ListView listGarage;

          private void btnAdd_Click(object sender, EventArgs e)
        {
            var registerGarage = new Views.RegisterGarage();
            registerGarage.Show();
        }

         private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Garage garage = GetSelectedGarage(Option.Edit);
                var modifyGarageView = new Views.ModifyGarage(garage);
                if (modifyGarageView.ShowDialog() == DialogResult.OK)
                {
                    // Atualizar a lista após modificar o carro
                    RefreshList();
                    MessageBox.Show("Garagem modificada com sucesso!");
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
                Garage garage = GetSelectedGarage(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar essa garagem?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.GarageController.Delete(garage);
                    RefreshList();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void AddToListView(Models.Garage garage)
        {
            string[] row = { 
                garage.Id.ToString(), 
                garage.Name, 
                garage.Address 
            };
            ListViewItem item = new ListViewItem(row);
            listGarage.Items.Add(item);
        }
        public void RefreshList()
        {
            listGarage.Items.Clear();
            List<Models.Garage> garages = Controllers.GarageController.Read();

            foreach (Models.Garage garage in garages)
            {
                AddToListView(garage);
            }
        }

        public Garage GetSelectedGarage(Option option)
        {
            if (listGarage.SelectedItems.Count > 0)
            {
                int selectGarageItem = int.Parse(listGarage.SelectedItems[0].Text);
                return Controllers.GarageController.ReadById(selectGarageItem);
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

        public ListGarage(){

            this.Icon = new Icon("Assets/iconGarage.ico", 52,52);

            this.Text = "Garagens";
            this.Size = new Size(720, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            listGarage = new ListView();
            listGarage.Size = new Size(605, 200);
            listGarage.Location = new Point(50, 50);
            listGarage.GridLines = true;
            listGarage.MultiSelect = true;
            listGarage.View = View.Details;
            listGarage.Columns.Add("Id");
            listGarage.Columns.Add("Nome");
            listGarage.Columns.Add("Endereço");
            listGarage.Columns[0].Width = 30;
            listGarage.Columns[1].Width = 200;
            listGarage.Columns[2].Width = 370;
            listGarage.FullRowSelect = true; 
            this.Controls.Add(listGarage);

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