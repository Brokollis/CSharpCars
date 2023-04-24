using Models;
using Controllers;


namespace Views{


    public class RegisterSalesBalance : Form{
        private Label lblCarId;
        private TextBox txtCarId;
        private Label lblGarageId;
        private TextBox txtGarageId;
        private Label lblAmount;
        private TextBox txtAmount;
        private Button btnSave;


        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.SalesBalance salesBalance = new SalesBalance(
                Convert.ToInt32(txtCarId.Text),
                Convert.ToInt32(txtGarageId.Text),
                Convert.ToDecimal(txtAmount.Text)
            );

            SalesBalanceController.Create(salesBalance);
            MessageBox.Show("Balanço de saldo foi registrado com sucesso!");

            ClearForm();
            RefreshList();
            this.Close();
        }

        private void ClearForm(){
            txtCarId.Clear();
            txtGarageId.Clear();
            txtAmount.Clear();
        }

        private void RefreshList(){
            ListSalesBalance SalesBalanceList = Application.OpenForms.OfType<ListSalesBalance>().FirstOrDefault();
            if (SalesBalanceList != null)
            {
                SalesBalanceList.RefreshList();
            }
        }
        public RegisterSalesBalance(){

            this.Icon = new Icon("Assets/iconCar.ico", 52,52);

            this.Text = "Cadastro de balanço de saldo";
            this.Size = new System.Drawing.Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            this.lblCarId = new Label();
            this.lblCarId.Text = "Id do carro";
            this.lblCarId.Location = new System.Drawing.Point(10, 40);
            this.lblCarId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lblCarId);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new System.Drawing.Point(110, 40);
            this.txtCarId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(txtCarId);

            this.lblGarageId = new Label();
            this.lblGarageId.Text = "Id da garagem";
            this.lblGarageId.Location = new System.Drawing.Point(10, 70);
            this.lblGarageId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lblGarageId);

            this.txtGarageId = new TextBox();
            this.txtGarageId.Location = new System.Drawing.Point(110, 70);
            this.txtGarageId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(txtGarageId);

            this.lblAmount = new Label();
            this.lblAmount.Text = "Quantidade";
            this.lblAmount.Location = new System.Drawing.Point(10, 100);
            this.lblAmount.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lblAmount);

            this.txtAmount = new TextBox();
            this.txtAmount.Location = new System.Drawing.Point(110, 100);
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(txtAmount);

            this.btnSave = new Button();
            this.btnSave.Text = "Salvar";
            this.btnSave.Location = new System.Drawing.Point(110, 150);
            this.btnSave.Size = new System.Drawing.Size(150, 35);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.Controls.Add(btnSave);


        }
    }
}