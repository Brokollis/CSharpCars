using Models;
using Controllers;

namespace Views{

    public class ModifySalesBalance : Form{

        private Label lblCarId;
        private TextBox txtCarId;
        private Label lblGarageId;
        private TextBox txtGarageId;
        private Label lblAmount;
        private TextBox txtAmount;
        private Button btnModify;

        private SalesBalance salesBalance;

         private void btnModify_Click(object sender, EventArgs e){

            salesBalance.CarId = Convert.ToInt32(txtCarId.Text);
            salesBalance.GarageId = Convert.ToInt32(txtGarageId.Text);
            salesBalance.Amount = Convert.ToDecimal(txtAmount.Text);
            
            SalesBalanceController.Update(salesBalance);

            MessageBox.Show("Balanço de saldo modificado com sucesso!");

            ListSalesBalance SalesBalanceList = Application.OpenForms.OfType<ListSalesBalance>().FirstOrDefault();
            if (SalesBalanceList != null)
            {
                SalesBalanceList.RefreshList();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.Close();
        }
        public ModifySalesBalance(SalesBalance salesBalance){

            this.salesBalance = salesBalance;

            this.Icon = new Icon("Assets/iconCar.ico", 52,52);

            this.Text = "Modificar Balanço de saldo";
            this.Size = new System.Drawing.Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            this.lblCarId = new Label();
            this.lblCarId.Text = "Id do carro";
            this.lblCarId.Location = new System.Drawing.Point(10, 40);
            this.lblCarId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(this.lblCarId);

            this.txtCarId = new TextBox();
            this.txtCarId.Text = salesBalance.CarId.ToString();
            this.txtCarId.Location = new System.Drawing.Point(110, 40);
            this.txtCarId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtCarId);

            this.lblGarageId = new Label();
            this.lblGarageId.Text = "Id da garagem";
            this.lblGarageId.Location = new System.Drawing.Point(10, 70);
            this.lblGarageId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(this.lblGarageId);

            this.txtGarageId = new TextBox();
            this.txtGarageId.Text = salesBalance.GarageId.ToString();
            this.txtGarageId.Location = new System.Drawing.Point(110, 70);
            this.txtGarageId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtGarageId);

            this.lblAmount = new Label();
            this.lblAmount.Text = "Quantidade";
            this.lblAmount.Location = new System.Drawing.Point(10, 100);
            this.lblAmount.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(this.lblAmount);

            this.txtAmount = new TextBox();
            this.txtAmount.Text = salesBalance.Amount.ToString();
            this.txtAmount.Location = new System.Drawing.Point(110, 100);
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtAmount);
            
            this.btnModify = new Button();
            this.btnModify.Text = "Modificar";
            this.btnModify.Location = new System.Drawing.Point(110, 150);
            this.btnModify.Size = new System.Drawing.Size(150, 35);
            this.btnModify.Click += new EventHandler(this.btnModify_Click);
            this.Controls.Add(this.btnModify);


            


            
        }
    }
}