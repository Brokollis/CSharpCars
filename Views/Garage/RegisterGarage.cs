using Controllers;
using Models;

namespace Views{

    public class RegisterGarage : Form{

        public Label lblName;
        public TextBox txtName;
        public Label lblAddress;
        public TextBox txtAddress;
        public Button btnSave;
                

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Garage garage = new Garage(
                txtName.Text,
                txtAddress.Text
            );

            GarageController.Create(garage);
            MessageBox.Show("Garagem foi registrada com sucesso!");

            ClearForm();
            RefreshList();
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
        }

        private void RefreshList(){
            ListGarage GarageList = Application.OpenForms.OfType<ListGarage>().FirstOrDefault();
            if (GarageList != null)
            {
                GarageList.RefreshList();
            }
        }

        public RegisterGarage(){

            this.Icon = new Icon("Assets/iconCar.ico", 52,52);

            this.Text = "Cadastro de Garagem";
            this.Size = new Size(300, 190);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            this.lblName = new Label();
            this.lblName.Text = "Nome";
            this.lblName.Size = new Size(60, 20);
            this.lblName.Location = new System.Drawing.Point(10, 25);
            this.Controls.Add(lblName);

            this.txtName = new TextBox();
            this.txtName.Size = new Size(150, 20);
            this.txtName.Location = new System.Drawing.Point(80, 25);
            this.Controls.Add(txtName);

            this.lblAddress = new Label();
            this.lblAddress.Text = "Endereço";
            this.lblAddress.Size = new Size(60, 20);
            this.lblAddress.Location = new System.Drawing.Point(10, 55);
            this.Controls.Add(lblAddress);

            this.txtAddress = new TextBox();
            this.txtAddress.Size = new Size(150, 20);
            this.txtAddress.Location = new System.Drawing.Point(80, 55);
            this.Controls.Add(txtAddress);

            this.btnSave = new Button();
            this.btnSave.Text = "Salvar";
            this.btnSave.Size = new Size(150, 35);
            this.btnSave.Location = new System.Drawing.Point(80, 100);
            this.btnSave.Click += new EventHandler(btnRegister_Click);
            this.Controls.Add(btnSave);

        }


    }
}