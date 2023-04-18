
namespace Views
{
    public class CadastraProduto : Form {

        public CadastraProduto(){
            this.Text = "Cadastrar Produto";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Size = new Size(100, 30);
            lblNome.Location = new Point(10, 10);

            TextBox txtNome = new TextBox();
            txtNome.Size = new Size(100, 30);
            txtNome.Location = new Point(10, 40);

            Label lblPreco = new Label();
            lblPreco.Text = "Preço";
            lblPreco.Size = new Size(100, 30);
            lblPreco.Location = new Point(10, 70);

            TextBox txtPreco = new TextBox();
            txtPreco.Size = new Size(100, 30);
            txtPreco.Location = new Point(10, 100);

            Button btnCadastrar = new Button();
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.Size = new Size(100, 30);
            btnCadastrar.Location = new Point(10, 130);
            btnCadastrar.Click += (sender, e) => {
                Models.Produto produto = new Models.Produto(txtNome.Text, float.Parse(txtPreco.Text));
                Models.Produto.store(produto);
                this.Close();
            };

            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(lblPreco);
            this.Controls.Add(txtPreco);
            this.Controls.Add(btnCadastrar);
            this.ShowDialog();
        }
        
    }
}