// using System;
// using System.Windows.Forms;
// using Controllers;
// using Models;

// namespace Views
// {
//     public class EditCar : Form
//     {
//         private Label lblId;
//         private TextBox txtId;
//         private Label lblBrand;
//         private TextBox txtBrand;
//         private Label lblModel;
//         private TextBox txtModel;
//         private Label lblYear;
//         private NumericUpDown numYear;
//         private Label lblColor;
//         private TextBox txtColor;
//         private Label lblLicensePlate;
//         private MaskedTextBox mskLicensePlate;
//         private Label lblType;
//         private ComboBox cboType;
//         private Label lblPrice;
//         private TextBox txtPrice;
//         private Button btnSave;

//         private Car car; // o carro que está sendo editado

//         public EditCar(Car car)
//         {
//             this.car = car; // salva o carro que está sendo editado

//              this.Text = "Edit Car";
//             this.StartPosition = FormStartPosition.CenterScreen;
//             this.FormBorderStyle = FormBorderStyle.FixedSingle;
//             this.MaximizeBox = false;
//             this.MinimizeBox = false;
//             this.ShowIcon = false;
//             this.ShowInTaskbar = false;
//             this.Size = new System.Drawing.Size(400, 500);

//             this.lblId = new Label();
//             this.lblId.Text = "Id:";
//             this.lblId.Location = new System.Drawing.Point(10, 10);
//             this.lblId.Size = new System.Drawing.Size(50, 20);
//             this.Controls.Add(this.lblId);

//             this.txtId = new TextBox();
//             this.txtId.Location = new System.Drawing.Point(80, 10);
//             this.txtId.Size = new System.Drawing.Size(150, 20);
//             this.txtId.ReadOnly = true; // o ID não pode ser alterado
//             this.Controls.Add(this.txtId);

//             this.lblBrand = new Label();
//             this.lblBrand.Text = "Brand:";
//             this.lblBrand.Location = new System.Drawing.Point(10, 40);
//             this.lblBrand.Size = new System.Drawing.Size(50, 20);

//             this.txtBrand = new TextBox();
//             this.txtBrand.Location = new System.Drawing.Point(80, 40);
//             this.txtBrand.Size = new System.Drawing.Size(150, 20);
//             this.txtBrand.Text = car.Brand; // preenche a marca do carro

//             this.lblModel = new Label();
//             this.lblModel.Text = "Model:";
//             this.lblModel.Location = new System.Drawing.Point(10, 70);
//             this.lblModel.Size = new System.Drawing.Size(50, 20);

//             this.txtModel = new TextBox();
//             this.txtModel.Location = new System.Drawing.Point(80, 70);
//             this.txtModel.Size = new System.Drawing.Size(150, 20);
//             this.txtModel.Text = car.Model; // preenche o modelo do carro


//             this.lblYear = new Label();
//             this.lblYear.Text = "Year:";
//             this.lblYear.Location = new
//             this.numYear = new NumericUpDown();
//             this.numYear.Location = new System.Drawing.Point(80, 100);
//             this.numYear.Size = new System.Drawing.Size(150, 20);
//             this.numYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 }); // define o valor mínimo do ano como 1900
//             this.numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 }); // define o valor máximo do ano como 2100
//             this.numYear.Value = car.Year; // preenche o ano do carro

//             this.lblColor = new Label();
//             this.lblColor.Text = "Color:";
//             this.lblColor.Location = new System.Drawing.Point(10, 130);
//             this.lblColor.Size = new System.Drawing.Size(50, 20);

//             this.txtColor = new TextBox();
//             this.txtColor.Location = new System.Drawing.Point(80, 130);
//             this.txtColor.Size = new System.Drawing.Size(150, 20);
//             this.txtColor.Text = car.Color; // preenche a cor do carro

//             this.lblLicensePlate = new Label();
//             this.lblLicensePlate.Text = "License Plate:";
//             this.lblLicensePlate.Location = new System.Drawing.Point(10, 160);
//             this.lblLicensePlate.Size = new System.Drawing.Size(80, 20);

//             this.mskLicensePlate = new MaskedTextBox();
//             this.mskLicensePlate.Location = new System.Drawing.Point(100, 160);
//             this.mskLicensePlate.Size = new System.Drawing.Size(130, 20);
//             this.mskLicensePlate.Mask = ">LLL-0000"; // define o formato da placa como três letras seguidas de quatro dígitos
//             this.mskLicensePlate.Text = car.LicensePlate; // preenche a placa do carro

//             this.lblType = new Label();
//             this.lblType.Text = "Type:";
//             this.lblType.Location = new System.Drawing.Point(10, 190);
//             this.lblType.Size = new System.Drawing.Size(50, 20);

//             this.cboType = new ComboBox();
//             this.cboType.Location = new System.Drawing.Point(80, 190);
//             this.cboType.Size = new System.Drawing.Size(150, 20);
//             this.cboType.DropDownStyle = ComboBoxStyle.DropDownList; // define que o usuário só pode selecionar valores da lista
//             this.cboType.Items.Add("Hatchback");
//             this.cboType.Items.Add("Sedan");
//             this.cboType.Items.Add("SUV");
//             this.cboType.Items.Add("Pickup");
//             this.cboType.SelectedItem = car.Type; // seleciona o tipo de carro do combo box

//             this.lblPrice = new Label();
//             this.lblPrice.Text = "Price:";
//             this.lblPrice.Location = new System.Drawing.Point(10, 220);
//             this.lblPrice.Size = new System.Drawing.Size(50, 20);

//             this.txtPrice = new TextBox();
//             this.txtPrice.Location = new System.Drawing.Point(80, 220);
//             this.txtPrice.Size = new System.Drawing.Size(150, 20);
//             this.txtPrice.Text = car.Price.ToString(); // preenche o preço do carro

//             this.btnSave = new Button();
//             this.btnSave.Text = "Save";
//             this.btnSave.Location = new System.Drawing.Point(150, 260);
//             this.btnSave.Size = new System.Drawing.Size(80, 30);
//             this.btnSave.Click += new EventHandler(btnSave_Click);

//             this.Controls.Add(this.lblBrand);
//             this.Controls.Add(this.txtBrand);
//             this.Controls.Add(this.lblModel);
//             this.Controls.Add(this.txtModel);
//             this.Controls.Add(this.lblYear);
//             this.Controls.Add(this.numYear);
//             this.Controls.Add(this.lblColor);
//             this.Controls.Add(this.txtColor);
//             this.Controls.Add(this.lblLicensePlate);
//             this.Controls.Add(this.mskLicensePlate);
//             this.Controls.Add(this.lblType);
//             this.Controls.Add(this.cboType);
//             this.Controls.Add(this.lblPrice);
//             this.Controls.Add(this.txtPrice);
//             this.Controls.Add(this.btnSave);
//         }

//         private void btnSave_Click(object sender, EventArgs e)
//         {
//             // verifica se todos os campos foram preenchidos
//             if (string.IsNullOrWhiteSpace(txtBrand.Text) ||
//                 string.IsNullOrWhiteSpace(txtModel.Text) ||
//                 numYear.Value == 0 ||
//                 string.IsNullOrWhiteSpace(txtColor.Text) ||
//                 string.IsNullOrWhiteSpace(mskLicensePlate.Text) ||
//                 string.IsNullOrWhiteSpace(cboType.Text) ||
//                 string.IsNullOrWhiteSpace(txtPrice.Text))
//             {
//                 MessageBox.Show("Please fill all fields.");
//                 return;
//             }

//             // atualiza as informações do carro
//             car.Brand = txtBrand.Text;
//             car.Model = txtModel.Text;
//             car.Year = (int)numYear.Value;
//             car.Color = txtColor.Text;
//             car.LicensePlate = mskLicensePlate.Text;
//             car.Type = cboType.Text;
//             car.Price = double.Parse(txtPrice.Text);

//             // salva as informações do carro no arquivo
//             CarController carController = new CarController();
//             carController.Edit(car);

//             MessageBox.Show("Car edited successfully.");

//             this.Close();
//         }
//     }
// }