using Models;
using Controllers;


namespace Views{

    public class ModifyGarage : Form{

        public Label lblName;
        public TextBox txtName;
        public Label lblAddress;
        public TextBox txtAddress;
        public Button btnModify;
        public Button btnCancel;

        public Garage garage;

        private void btnModify_Click(object sender, EventArgs e){
                
            garage.Name = txtName.Text;
            garage.Address = txtAddress.Text;

            GarageController.Update(garage);


            ListGarage GarageList = Application.OpenForms.OfType<ListGarage>().FirstOrDefault();
            if (GarageList != null)
            {
                GarageList.RefreshList();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.Close();
        }

        public ModifyGarage(Garage garage){

            this.garage = garage;

            this.Text = "Editar garagem";

            this.Size = new Size(300, 190);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            this.lblName = new Label();
            this.lblName.Text = "Nome";
            this.lblName.Size = new Size(60, 20);
            this.lblName.Location = new System.Drawing.Point(10, 25);
            this.Controls.Add(this.lblName);

            this.txtName = new TextBox();
            this.txtName.Text = garage.Name;
            this.txtName.Size = new Size(150, 20);
            this.txtName.Location = new System.Drawing.Point(80, 25);
            this.Controls.Add(this.txtName);

            this.lblAddress = new Label();
            this.lblAddress.Text = "Endereço";
            this.lblAddress.Size = new Size(60, 20);
            this.lblAddress.Location = new System.Drawing.Point(10, 55);
            this.Controls.Add(this.lblAddress);

            this.txtAddress = new TextBox();
            this.txtAddress.Text = garage.Address;
            this.txtAddress.Size = new Size(150, 20);
            this.txtAddress.Location = new System.Drawing.Point(80, 55);
            this.Controls.Add(this.txtAddress);
            
            this.btnModify = new Button();
            this.btnModify.Text = "Modificar";
            this.btnModify.Size = new Size(150, 35);
            this.btnModify.Location = new System.Drawing.Point(80, 100);
            this.btnModify.Click += new EventHandler(this.btnModify_Click);
            this.Controls.Add(this.btnModify);
        }
    }
}