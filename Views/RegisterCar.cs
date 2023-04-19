using System;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class RegisterCar : Form
    {
        private Label lblId;
        private TextBox txtId;
        private Label lblBrand;
        private TextBox txtBrand;
        private Label lblModel;
        private TextBox txtModel;
        private Label lblYear;
        private NumericUpDown numYear;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblLicensePlate;
        private MaskedTextBox mskLicensePlate;
        private Label lblType;
        private ComboBox cboType;
        private Label lblPrice;
        private TextBox txtPrice;
        private Button btnRegister;

        public void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Car car = new Car(
                Convert.ToInt32(txtId.Text),
                txtBrand.Text,
                txtModel.Text,
                (int)numYear.Value,
                txtColor.Text,
                mskLicensePlate.Text,
                cboType.SelectedItem.ToString(),
                Convert.ToSingle(txtPrice.Text)
            );

            CarController carController = new CarController();
            carController.Create(car);

            MessageBox.Show("Car registered successfully!");

            ClearForm();

            // atualiza a lista de carros na tela de Produto, se ela estiver aberta
            Produto ProdutoList = Application.OpenForms.OfType<Produto>().FirstOrDefault();
            if (ProdutoList != null)
            {
                ProdutoList.RefreshList();
            }

            // fecha a tela de cadastro
            this.Close();
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            numYear.Value = DateTime.Now.Year;
            txtColor.Clear();
            mskLicensePlate.Clear();
            cboType.SelectedIndex = 0;
            txtPrice.Clear();
        }

        public RegisterCar()
        {
            this.Text = "Car Registration";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(400, 500);

            this.lblId = new Label();
            this.lblId.Text = "Id:";
            this.lblId.Location = new System.Drawing.Point(10, 10);
            this.lblId.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblId);

            this.txtId = new TextBox();
            this.txtId.Location = new System.Drawing.Point(80, 10);
            this.txtId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtId);

            this.lblBrand = new Label();
            this.lblBrand.Text = "Brand:";
            this.lblBrand.Location = new System.Drawing.Point(10, 40);
            this.lblBrand.Size = new System.Drawing.Size(50, 20);

            this.txtBrand = new TextBox();
            this.txtBrand.Location = new System.Drawing.Point(80, 40);
            this.txtBrand.Size = new System.Drawing.Size(150, 20);

            this.lblModel = new Label();
            this.lblModel.Text = "Model:";
            this.lblModel.Location = new System.Drawing.Point(10, 70);
            this.lblModel.Size = new System.Drawing.Size(50, 20);

            this.txtModel = new TextBox();
            this.txtModel.Location = new System.Drawing.Point(80, 70);
            this.txtModel.Size = new System.Drawing.Size(150, 20);

            this.lblYear = new Label();
            this.lblYear.Text = "Year:";
            this.lblYear.Location = new System.Drawing.Point(10, 100);
            this.lblYear.Size = new System.Drawing.Size(50, 20);

            this.numYear = new NumericUpDown();
            this.numYear.Location = new System.Drawing.Point(80, 100);
            this.numYear.Size = new System.Drawing.Size(70, 20);
            this.numYear.Maximum = DateTime.Now.Year;
            this.numYear.Minimum = DateTime.Now.Year - 50;
            this.numYear.Value = DateTime.Now.Year;

            this.lblColor = new Label();
            this.lblColor.Text = "Color:";
            this.lblColor.Location = new System.Drawing.Point(10, 130);
            this.lblColor.Size = new System.Drawing.Size(50, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new System.Drawing.Point(80, 130);
            this.txtColor.Size = new System.Drawing.Size(150, 20);

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "License Plate:";
            this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
            this.lblLicensePlate.Size = new System.Drawing.Size(70, 20);

            this.mskLicensePlate = new MaskedTextBox();
            this.mskLicensePlate.Mask = "AAA-0000";
            this.mskLicensePlate.Location = new System.Drawing.Point(80, 160);
            this.mskLicensePlate.Size = new System.Drawing.Size(70, 20);

            this.lblType = new Label();
            this.lblType.Text = "Type:";
            this.lblType.Location = new System.Drawing.Point(10, 190);
            this.lblType.Size = new System.Drawing.Size(50, 20);

            this.cboType = new ComboBox();
            this.cboType.Items.AddRange(new object[] { "Sedan", "Hatch", "SUV", "Picape", "Van" });
            this.cboType.Location = new System.Drawing.Point(80, 190);
            this.cboType.Size = new System.Drawing.Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Price:";
            this.lblPrice.Location = new System.Drawing.Point(10, 220);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new System.Drawing.Point(80, 220);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new System.Drawing.Point(80, 20);
            this.btnRegister.Size = new System.Drawing.Size(150, 20);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.mskLicensePlate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnRegister);
        }
    }

}