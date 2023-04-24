using Controllers;
using Models;

namespace Views
{
    public class RegisterCar : Form
    {
        public Label lblBrand;
        public TextBox txtBrand;
        public Label lblModel;
        public TextBox txtModel;
        public Label lblYear;
        public NumericUpDown numYear;
        public Label lblColor;
        public TextBox txtColor;
        public Label lblLicensePlate;
        public MaskedTextBox mskLicensePlate;
        public Label lblType;
        public ComboBox cboType;
        public Label lblPrice;
        public TextBox txtPrice;
        public Button btnRegister;

        public void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Car car = new Car(
                txtBrand.Text,
                txtModel.Text,
                (int)numYear.Value,
                txtColor.Text,
                mskLicensePlate.Text,
                cboType.SelectedItem.ToString(),
                Convert.ToDecimal(txtPrice.Text)
            );

            CarController carController = new CarController();
            carController.Create(car);

            MessageBox.Show("Carro foi registrado com sucesso!");

            ClearForm();



            // atualiza a lista de carros na tela de Produto, se ela estiver aberta
            ListCar ProdutoList = Application.OpenForms.OfType<ListCar>().FirstOrDefault();
            if (ProdutoList != null)
            {
                ProdutoList.RefreshList();
            }

            // fecha a tela de cadastro
            this.Close();
        }

        private void ClearForm()
        {
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
            this.Text = "Registar carro";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblBrand = new Label();
            this.lblBrand.Text = "Marca:";
            this.lblBrand.Location = new System.Drawing.Point(10, 40);
            this.lblBrand.Size = new System.Drawing.Size(50, 20);

            this.txtBrand = new TextBox();
            this.txtBrand.Location = new System.Drawing.Point(80, 40);
            this.txtBrand.Size = new System.Drawing.Size(150, 20);

            this.lblModel = new Label();
            this.lblModel.Text = "Modelo:";
            this.lblModel.Location = new System.Drawing.Point(10, 70);
            this.lblModel.Size = new System.Drawing.Size(50, 20);

            this.txtModel = new TextBox();
            this.txtModel.Location = new System.Drawing.Point(80, 70);
            this.txtModel.Size = new System.Drawing.Size(150, 20);

            this.lblYear = new Label();
            this.lblYear.Text = "Ano:";
            this.lblYear.Location = new System.Drawing.Point(10, 100);
            this.lblYear.Size = new System.Drawing.Size(50, 20);

            this.numYear = new NumericUpDown();
            this.numYear.Location = new System.Drawing.Point(80, 100);
            this.numYear.Size = new System.Drawing.Size(70, 20);
            this.numYear.Maximum = DateTime.Now.Year;
            this.numYear.Minimum = DateTime.Now.Year - 50;
            this.numYear.Value = DateTime.Now.Year;

            this.lblColor = new Label();
            this.lblColor.Text = "Cor:";
            this.lblColor.Location = new System.Drawing.Point(10, 130);
            this.lblColor.Size = new System.Drawing.Size(50, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new System.Drawing.Point(80, 130);
            this.txtColor.Size = new System.Drawing.Size(150, 20);

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Placa:";
            this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
            this.lblLicensePlate.Size = new System.Drawing.Size(70, 20);

            this.mskLicensePlate = new MaskedTextBox();
            this.mskLicensePlate.Mask = "AAA-0000";
            this.mskLicensePlate.Location = new System.Drawing.Point(80, 160);
            this.mskLicensePlate.Size = new System.Drawing.Size(70, 20);

            this.lblType = new Label();
            this.lblType.Text = "Tipo:";
            this.lblType.Location = new System.Drawing.Point(10, 190);
            this.lblType.Size = new System.Drawing.Size(50, 20);

            this.cboType = new ComboBox();
            this.cboType.Items.AddRange(new object[] { "Sedan", "Hatch", "SUV", "Picape", "Van", "Perua","Coupê","Roadster"});
            this.cboType.Location = new System.Drawing.Point(80, 190);
            this.cboType.Size = new System.Drawing.Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new System.Drawing.Point(10, 220);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new System.Drawing.Point(80, 220);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 260);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);


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