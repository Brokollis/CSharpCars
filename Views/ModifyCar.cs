using Models;
using Controllers;
using System.Windows.Forms;
using System.Drawing;


namespace Views{

    public class ModifyCar : Form{
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
        private Button btnModify;
        private Button btnCancel;
       

    

        public ModifyCar(Car car){

            this.Text = "Editar Produto";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Views.RegisterCar registerCar = new RegisterCar();
            this.lblBrand = registerCar.lblBrand;
            this.txtBrand = registerCar.txtBrand;
            this.lblModel = registerCar.lblModel;
            this.txtModel = registerCar.txtModel;
            this.lblYear = registerCar.lblYear;
            this.numYear = registerCar.numYear;
            this.lblColor = registerCar.lblColor;
            this.txtColor = registerCar.txtColor;
            this.lblLicensePlate = registerCar.lblLicensePlate;
            this.mskLicensePlate = registerCar.mskLicensePlate;
            this.lblType = registerCar.lblType;
            this.cboType = registerCar.cboType;
            this.lblPrice = registerCar.lblPrice;
            this.txtPrice = registerCar.txtPrice;
            this.btnModify = registerCar.btnRegister;
            // this.btnCancel = registerCar.btnCancel;

            this.lblBrand.Location = new System.Drawing.Point(10, 40);
            this.txtBrand.Location = new System.Drawing.Point(80, 40);
            this.lblModel.Location = new System.Drawing.Point(10, 70);
            this.txtModel.Location = new System.Drawing.Point(80, 70);
            this.lblYear.Location = new System.Drawing.Point(10, 100);
            this.numYear.Location = new System.Drawing.Point(80, 100);
            this.lblColor.Location = new System.Drawing.Point(10, 130);
            this.txtColor.Location = new System.Drawing.Point(80, 130);
            this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
            this.mskLicensePlate.Location = new System.Drawing.Point(80, 160);
            this.lblType.Location = new System.Drawing.Point(10, 190);
            this.cboType.Location = new System.Drawing.Point(80, 190);
            this.lblPrice.Location = new System.Drawing.Point(10, 220);
            this.txtPrice.Location = new System.Drawing.Point(80, 220);
            this.btnModify.Text = "Editar";
            this.btnModify.Location = new System.Drawing.Point(80, 250);
            this.btnCancel.Location = new System.Drawing.Point(160, 250);

            this.btnModify.Click += new EventHandler(this.btnModify_Click);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

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
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnCancel);

        }

        //     this.lblBrand = new Label();
        //     this.lblBrand.Text = "Brand:";
        //     this.lblBrand.Location = new System.Drawing.Point(10, 40);
        //     this.lblBrand.Size = new System.Drawing.Size(50, 20);

        //     this.txtBrand = new TextBox();
        //     this.txtBrand.Location = new System.Drawing.Point(80, 40);
        //     this.txtBrand.Size = new System.Drawing.Size(150, 20);

        //     this.lblModel = new Label();
        //     this.lblModel.Text = "Model:";
        //     this.lblModel.Location = new System.Drawing.Point(10, 70);
        //     this.lblModel.Size = new System.Drawing.Size(50, 20);

        //     this.txtModel = new TextBox();
        //     this.txtModel.Location = new System.Drawing.Point(80, 70);
        //     this.txtModel.Size = new System.Drawing.Size(150, 20);

        //     this.lblYear = new Label();
        //     this.lblYear.Text = "Year:";
        //     this.lblYear.Location = new System.Drawing.Point(10, 100);
        //     this.lblYear.Size = new System.Drawing.Size(50, 20);

        //     this.numYear = new NumericUpDown();
        //     this.numYear.Location = new System.Drawing.Point(80, 100);
        //     this.numYear.Size = new System.Drawing.Size(70, 20);
        //     this.numYear.Maximum = DateTime.Now.Year;
        //     this.numYear.Minimum = DateTime.Now.Year - 50;
        //     this.numYear.Value = DateTime.Now.Year;

        //     this.lblColor = new Label();
        //     this.lblColor.Text = "Color:";
        //     this.lblColor.Location = new System.Drawing.Point(10, 130);
        //     this.lblColor.Size = new System.Drawing.Size(50, 20);

        //     this.txtColor = new TextBox();
        //     this.txtColor.Location = new System.Drawing.Point(80, 130);
        //     this.txtColor.Size = new System.Drawing.Size(150, 20);

        //     this.lblLicensePlate = new Label();
        //     this.lblLicensePlate.Text = "License Plate:";
        //     this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
        //     this.lblLicensePlate.Size = new System.Drawing.Size(70, 20);

        //     this.mskLicensePlate = new MaskedTextBox();
        //     this.mskLicensePlate.Mask = "AAA-0000";
        //     this.mskLicensePlate.Location = new System.Drawing.Point(80, 160);
        //     this.mskLicensePlate.Size = new System.Drawing.Size(70, 20);

        //     this.lblType = new Label();
        //     this.lblType.Text = "Type:";
        //     this.lblType.Location = new System.Drawing.Point(10, 190);
        //     this.lblType.Size = new System.Drawing.Size(50, 20);

        //     this.cboType = new ComboBox();
        //     this.cboType.Items.AddRange(new object[] { "Sedan", "Hatch", "SUV", "Picape", "Van" });
        //     this.cboType.Location = new System.Drawing.Point(80, 190);
        //     this.cboType.Size = new System.Drawing.Size(150, 20);

        //     this.lblPrice = new Label();
        //     this.lblPrice.Text = "Price:";
        //     this.lblPrice.Location = new System.Drawing.Point(10, 220);
        //     this.lblPrice.Size = new System.Drawing.Size(50, 20);

        //     this.txtPrice = new TextBox();
        //     this.txtPrice.Location = new System.Drawing.Point(80, 220);
        //     this.txtPrice.Size = new System.Drawing.Size(150, 20);

        //     this.btnModify = new Button();
        //     this.btnModify.Text = "Modify";
        //     this.btnModify.Location = new System.Drawing.Point(10, 250);
        //     this.btnModify.Size = new System.Drawing.Size(100, 30);
        //     this.btnModify.Click += new System.EventHandler(this.btnModify_Click);

        //     this.btnCancel = new Button();
        //     this.btnCancel.Text = "Cancel";
        //     this.btnCancel.Location = new System.Drawing.Point(120, 250);
        //     this.btnCancel.Size = new System.Drawing.Size(100, 30);
        //     this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        //     this.Controls.Add(this.lblBrand);
        //     this.Controls.Add(this.txtBrand);
        //     this.Controls.Add(this.lblModel);
        //     this.Controls.Add(this.txtModel);
        //     this.Controls.Add(this.lblYear);
        //     this.Controls.Add(this.numYear);
        //     this.Controls.Add(this.lblColor);
        //     this.Controls.Add(this.txtColor);
        //     this.Controls.Add(this.lblLicensePlate);
        //     this.Controls.Add(this.mskLicensePlate);
        //     this.Controls.Add(this.lblType);
        //     this.Controls.Add(this.cboType);
        //     this.Controls.Add(this.lblPrice);
        //     this.Controls.Add(this.txtPrice);
        //     this.Controls.Add(this.btnModify);
        //     this.Controls.Add(this.btnCancel);

        // }

        
        private void btnModify_Click(object sender, EventArgs e){
            if (string.IsNullOrEmpty(this.txtBrand.Text) || string.IsNullOrEmpty(this.txtModel.Text) || string.IsNullOrEmpty(this.txtColor.Text) || string.IsNullOrEmpty(this.mskLicensePlate.Text) || string.IsNullOrEmpty(this.cboType.Text) || string.IsNullOrEmpty(this.txtPrice.Text)){
                MessageBox.Show("Preencha todos os campos!");
            }
            else{
                try{
                    // Car carToModify = Controllers.CarController.ReadById( Car.car );
                    
                    // if (carToModify != null){

                    //     carToModify.Brand = this.txtBrand.Text;
                    //     carToModify.Model = this.txtModel.Text;
                    //     carToModify.Year = Convert.ToInt32(this.numYear.Value);
                    //     carToModify.Color = this.txtColor.Text;
                    //     carToModify.LicensePlate = this.mskLicensePlate.Text;
                    //     carToModify.Type = this.cboType.Text;
                    //     carToModify.Price = Convert.ToSingle(this.txtPrice.Text);

                    //     // Atualizar o objeto no banco de dados
                    //     
                        Controllers.CarController.Update();

                        MessageBox.Show("Carro modificado com sucesso!");
                        this.Close();

                    }
                    produtoView.Show();
                    this.Close();
                    
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        //             Car carToModify = Controllers.CarController.ReadById( this.carId );

        //             if (carToModify != null){
        //                 carToModify.Brand = this.txtBrand.Text;
        //                 carToModify.Model = this.txtModel.Text;
        //                 carToModify.Year = Convert.ToInt32(this.numYear.Value);
        //                 carToModify.Color = this.txtColor.Text;
        //                 carToModify.LicensePlate = this.mskLicensePlate.Text;
        //                 carToModify.Type = this.cboType.Text;
        //                 carToModify.Price = Convert.ToSingle(this.txtPrice.Text);

        //                 // Atualizar o objeto no banco de dados
        //                 Controllers.CarController.Update(carToModify);

        //                 MessageBox.Show("Carro modificado com sucesso!");
        //                 this.Close();
        //             }
        //             else{
        //                 MessageBox.Show("Esse carro não foi encontrado no nosso banco de dados");
        //             }
        //         }
        //         catch (Exception ex){
        //             MessageBox.Show("Error: " + ex.Message);
        //         }
        //     }
        // }

        private void btnCancel_Click(object sender, EventArgs e){
            this.Close();
        }

    }

}

