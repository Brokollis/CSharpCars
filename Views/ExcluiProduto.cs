
namespace Views
{
    public class ExcluiProduto{

        public static void index(){
            Form form = new Form();

            form.Text = "Excluir Produto";
            form.Size = new Size(300, 300);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Size = new Size(100, 30);
            lblNome.Location = new Point(10, 10);

            TextBox txtNome = new TextBox();
            txtNome.Size = new Size(100, 30);
            txtNome.Location = new Point(10, 40);

            Button btnExcluir = new Button();
            btnExcluir.Text = "Excluir";
            btnExcluir.Size = new Size(100, 30);
            btnExcluir.Location = new Point(10, 70);
            form.Close();

            form.Controls.Add(lblNome);
            form.Controls.Add(txtNome);
            form.Controls.Add(btnExcluir);
            form.ShowDialog();

        }





        
    }
}