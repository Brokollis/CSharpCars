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
        private ComboBox cboCarId;
        private ComboBox cboGarageId;


        private void btnSave_Click(object sender, EventArgs e)
        {
            int carId = GetCarIdFromName(cboCarId.Text);
            int garageId = GetGarageIdFromName(cboGarageId.Text);

            Models.SalesBalance salesBalance = new SalesBalance(
                carId,
                garageId,
                Convert.ToInt32(txtAmount.Text)
            );

            SalesBalanceController.Create(salesBalance);
            MessageBox.Show("Balanço de saldo foi registrado com sucesso!");

            ClearForm();
            RefreshList();
            this.Close();
        }

        public static int GetCarIdFromName(string carName)
        {
            foreach (Car car in CarController.Read())
            {
                if (car.Model == carName)
                {
                    return car.Id;
                }
            }

            // Caso não tenha encontrado nenhum carro correspondente, retornar -1 ou lançar uma exceção
            return -1;
        }

        public static int GetGarageIdFromName(string garageName)
        {
            foreach (Garage garage in GarageController.Read())
            {
                if (garage.Name == garageName)
                {
                    return garage.Id;
                }
            }

            // Caso não tenha encontrado nenhuma garagem correspondente, retornar -1 ou lançar uma exceção
            return -1;
        }

        public List<string> GetCarModelNames(){

            List<string> namesOfCars = new List<string>();

            foreach(Car car in CarController.Read()){
                namesOfCars.Add(car.Model);
            }

            return namesOfCars;
        }

        public List<string> GetGarageNames(){

            List<string> namesOfGarages = new List<string>();

            foreach(Garage garage in GarageController.Read()){
                namesOfGarages.Add(garage.Name);
            }

            return namesOfGarages;
        }

        public void GetIdCarName(){
            List<string> carModelNames = GetCarModelNames();
            if (!carModelNames.Contains(cboCarId.Text))
            {
                MessageBox.Show("Modelo de carro inválido!");
                return;
            }
            
            foreach(Car car in CarController.Read()){
                if(car.Model == cboCarId.Text){
                    cboCarId.Text = car.Id.ToString();
                }
            }
        }

        public void GetIdGarageName(){
            List<string> garageNames = GetGarageNames();
            if (!garageNames.Contains(cboGarageId.Text))
            {
                MessageBox.Show("Nome de garagem inválido!");
                return;
            }
            
            foreach(Garage garage in GarageController.Read()){
                if(garage.Name == cboGarageId.Text){
                    cboGarageId.Text = garage.Id.ToString();
                }
            }
        }

        private void RefreshList(){
            ListSalesBalance SalesBalanceList = Application.OpenForms.OfType<ListSalesBalance>().FirstOrDefault();
            if (SalesBalanceList != null)
            {
                SalesBalanceList.RefreshList();
            }
        }

        private void ClearForm(){
            txtCarId.Clear();
            txtGarageId.Clear();
            txtAmount.Clear();
        }
        public RegisterSalesBalance(){

            this.Icon = new Icon("Assets/iconAdd.ico", 52,52);

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

            List<string> namesOfCars = GetCarModelNames();
            this.cboCarId = new ComboBox();
            this.cboCarId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCarId.Items.AddRange(namesOfCars.ToArray());
            this.cboCarId.Location = new System.Drawing.Point(110, 40);
            this.cboCarId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(cboCarId);

            this.txtCarId = new TextBox();
            this.txtCarId.Location = new System.Drawing.Point(110, 40);
            this.txtCarId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(txtCarId);

            this.lblGarageId = new Label();
            this.lblGarageId.Text = "Id da garagem";
            this.lblGarageId.Location = new System.Drawing.Point(10, 70);
            this.lblGarageId.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lblGarageId);

            List<string> nameOfGarages = GetGarageNames();
            this.cboGarageId = new ComboBox();
            this.cboGarageId.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGarageId.Items.AddRange(nameOfGarages.ToArray());
            this.cboGarageId.Location = new System.Drawing.Point(110, 70);
            this.cboGarageId.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(cboGarageId);

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