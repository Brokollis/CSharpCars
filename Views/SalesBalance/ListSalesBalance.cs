using Models;
using Controllers;

namespace Views{

    public class ListSalesBalance : Form{

        ListView listSalesBalance;


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var registerSalesBalance = new Views.RegisterSalesBalance();
            registerSalesBalance.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SalesBalance salesBalance = GetSelectedSalesBalance(Option.Edit);
                RefreshList();
                var modifySalesBalance = new Views.ModifySalesBalance(salesBalance);
                if (modifySalesBalance.ShowDialog() == DialogResult.OK)
                {
                    // Atualizar a lista após modificar o carro
                    RefreshList();
                    MessageBox.Show("Balanço de saldo modificado com sucesso!");
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
                SalesBalance salesBalance = GetSelectedSalesBalance(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse balanço de saldo?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.SalesBalanceController.Delete(salesBalance);
                    RefreshList();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void AddToListView(Models.SalesBalance salesBalance)
        {  
            Car nameCarId = CarController.ReadById(salesBalance.CarId);
            Garage nameGarageId = GarageController.ReadById(salesBalance.GarageId);

            string[] row = { 
                salesBalance.Id.ToString(),
                nameCarId.Model,
                nameGarageId.Name,
                salesBalance.Amount.ToString()
            };
            ListViewItem item = new ListViewItem(row);
            listSalesBalance.Items.Add(item);

        }



        public void RefreshList()
        {
            listSalesBalance.Items.Clear();

            List<Models.SalesBalance> salesBalances = Controllers.SalesBalanceController.Read();


            foreach (Models.SalesBalance salesBalance in salesBalances)
            {
                AddToListView(salesBalance);
            }
        }
        

        public SalesBalance GetSelectedSalesBalance(Option option)
        {
            if (listSalesBalance.SelectedItems.Count > 0)
            {
                int selectedSalesBalanceId = int.Parse(listSalesBalance.SelectedItems[0].Text);
                return Controllers.SalesBalanceController.ReadById(selectedSalesBalanceId);
            }
            else
            {
                throw new Exception($"Por gentileza, selecione um balanço de saldo para {(option == Option.Edit ? "editar" : "deletar")}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListSalesBalance(){
            this.Text = "Balanços dos saldos";
            this.Size = new Size(720, 370);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            listSalesBalance = new ListView();
            listSalesBalance.Size = new Size(605, 180);
            listSalesBalance.Location = new Point(50, 50);
            listSalesBalance.GridLines = true;
            listSalesBalance.MultiSelect = true;
            listSalesBalance.View = View.Details;
            listSalesBalance.Columns.Add("Id");
            listSalesBalance.Columns.Add("Carro");
            listSalesBalance.Columns.Add("Garagem");
            listSalesBalance.Columns.Add("Saldo");
            listSalesBalance.Columns[0].Width = 30;
            listSalesBalance.Columns[1].Width = 80;
            listSalesBalance.Columns[2].Width = 100;
            listSalesBalance.Columns[3].Width = 50;
            listSalesBalance.FullRowSelect = true; // permite selecionar a linha inteira ao clicar
            this.Controls.Add(listSalesBalance);

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