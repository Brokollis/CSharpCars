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
        private ComboBox cboGarageId;
        private ComboBox cboCarId;

        private void btnModify_Click(object sender, EventArgs e){

            salesBalance.CarId = Convert.ToInt32(cboCarId.SelectedValue);
            salesBalance.GarageId = Convert.ToInt32(cboGarageId.SelectedValue);
            salesBalance.Amount = Convert.ToInt32(txtAmount.Text);
            
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

            this.Icon = new Icon("Assets/iconEdit.ico", 52,52);

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
            this.Controls.Add(lblCarId);

            this.cboCarId = new ComboBox();
            this.cboCarId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCarId.Location = new System.Drawing.Point(110, 40);
            this.cboCarId.Size = new System.Drawing.Size(150, 20);
            this.cboCarId.DisplayMember = "Model";
            this.cboCarId.ValueMember = "Id";
            this.cboCarId.DataSource = RegisterSalesBalance.GetNameCarToComboBox();
            foreach (Car car in cboCarId.Items)
            {
                if (car.Id == salesBalance.CarId)
                {
                    cboCarId.SelectedItem = car;
                    break;
                }
            }
            this.Controls.Add(cboCarId);


            this.lblGarageId = new Label();
            this.lblGarageId.Text = "Id da garagem";
            this.lblGarageId.Location = new System.Drawing.Point(10, 70);
            this.lblGarageId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lblGarageId);

     
            this.cboGarageId = new ComboBox();
            this.cboGarageId.SelectedValue = salesBalance.GarageId.ToString();
            this.cboGarageId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGarageId.Location = new System.Drawing.Point(110, 70);
            this.cboGarageId.Size = new System.Drawing.Size(150, 20);
            this.cboGarageId.DisplayMember = "Name";
            this.cboGarageId.ValueMember = "Id";
            this.cboGarageId.DataSource = RegisterSalesBalance.GetNameGarageToComboBox();
            this.Controls.Add(cboGarageId);

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