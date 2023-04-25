using Models;
using Controllers;
using System;

namespace Views{

    public class ModifyCar : Form{

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
        public Button btnModify;
        public Button btnCancel;

        public Car car;


        private void btnModify_Click(object sender, EventArgs e){

            Car carToModify = this.car;
            carToModify.Brand = this.txtBrand.Text;
            carToModify.Model = this.txtModel.Text;
            carToModify.Year = (int)this.numYear.Value;
            carToModify.Color = this.txtColor.Text;
            carToModify.LicensePlate = this.mskLicensePlate.Text;
            carToModify.Type = this.cboType.Text;
            carToModify.Price = Convert.ToDecimal(this.txtPrice.Text);

            if(
                carToModify.Brand == "" || carToModify.Model == "" || carToModify.Color == "" || carToModify.LicensePlate == "" ||  carToModify.Type == "" || carToModify.Price == 0){
                MessageBox.Show("Preencha todos os campos!");
                return;

            }else if(VerifyLicensePlate()){
                MessageBox.Show("Placa já cadastrada, favor escolha outra!");
                return;

            }else{
                CarController.Update(carToModify);
                MessageBox.Show("Carro foi modificado com sucesso!");
            }

            ListCar ProdutoList = Application.OpenForms.OfType<ListCar>().FirstOrDefault();
            if (ProdutoList != null)
            {
                ProdutoList.RefreshList();
            }
            this.Close();            
        }
        public bool VerifyLicensePlate(){
                
            foreach(Car car in CarController.Read()){
                if(car.LicensePlate == this.mskLicensePlate.Text){
                    return true;
                }
            }
            return false;
        }
        
        public ModifyCar(Car car){

            this.car = car;

            this.Icon = new Icon("Assets/iconEdit.ico", 52,52);
            this.Text = "Modificar Carro";
            this.Size = new System.Drawing.Size(280, 360);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
        
            this.lblBrand = new Label();
            this.lblBrand.Text = "Marca";
            this.lblBrand.Location = new System.Drawing.Point(10, 40);
            this.lblBrand.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblBrand);
            
            this.txtBrand = new TextBox();
            this.txtBrand.Text = car.Brand;
            this.txtBrand.Location = new System.Drawing.Point(80, 40);
            this.txtBrand.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtBrand);
            
            this.lblModel = new Label();
            this.lblModel.Text = "Modelo";
            this.lblModel.Location = new System.Drawing.Point(10, 70);
            this.lblModel.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblModel);

            this.txtModel = new TextBox();
            this.txtModel.Text = car.Model;
            this.txtModel.Location = new System.Drawing.Point(80, 70);
            this.txtModel.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtModel);

            this.lblYear = new Label();
            this.lblYear.Text = "Ano";
            this.lblYear.Location =new System.Drawing.Point(10, 100);
            this.lblYear.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblYear);

            this.numYear = new NumericUpDown();
            this.numYear.Location = new System.Drawing.Point(80, 100);
            this.numYear.Size = new System.Drawing.Size(150, 20);
            this.numYear.Maximum = DateTime.Now.Year;
            this.numYear.Minimum = DateTime.Now.Year - 50;
            this.numYear.Value = car.Year;
            this.Controls.Add(this.numYear);

            this.lblColor = new Label();
            this.lblColor.Text = "Cor";
            this.lblColor.Location = new System.Drawing.Point(10, 130);
            this.lblColor.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblColor);

            this.txtColor = new TextBox();
            this.txtColor.Text = car.Color;
            this.txtColor.Location = new System.Drawing.Point(80, 130);
            this.txtColor.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtColor);

            this.lblLicensePlate = new Label();
            this.lblLicensePlate.Text = "Placa";
            this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
            this.lblLicensePlate.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblLicensePlate);

            this.mskLicensePlate = new MaskedTextBox();
            this.mskLicensePlate.Mask = "AAA-0000";
            this.mskLicensePlate.Text = car.LicensePlate;
            this.mskLicensePlate.Location = new System.Drawing.Point(80, 160);
            this.mskLicensePlate.Size = new System.Drawing.Size(70, 20);
            this.Controls.Add(this.mskLicensePlate);

            this.lblType = new Label();
            this.lblType.Text = "Tipo";
            this.lblType.Location = new System.Drawing.Point(10, 190);
            this.lblType.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblType);
            
            this.cboType = new ComboBox();
            this.cboType.Items.AddRange(new object[] { "Sedan", "Hatch", "SUV", "Picape", "Van", "Perua","Coupê","Roadster"});
            this.cboType.Location = new System.Drawing.Point(80, 190);
            this.cboType.Size = new System.Drawing.Size(150, 20);
            this.cboType.Text = car.Type;
            this.Controls.Add(this.cboType);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço";
            this.lblPrice.Location = new System.Drawing.Point(10, 220);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(this.lblPrice);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new System.Drawing.Point(80, 220);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);
            this.txtPrice.Text = car.Price.ToString();
            this.Controls.Add(this.txtPrice);

            this.btnModify = new Button();
            this.btnModify.Text = "Modificar";
            this.btnModify.Location = new System.Drawing.Point(80, 260);
            this.btnModify.Size = new System.Drawing.Size(150, 35);
            this.btnModify.Click += new EventHandler(btnModify_Click);
            this.Controls.Add(this.btnModify);
            
        }

    
           
    }
}