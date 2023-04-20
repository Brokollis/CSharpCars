using Models;
using Controllers;

namespace Views
{
    public class Menu : Form
    {
        public static void index()
        {
            Form menu = new Form();

            menu.Text = "Menu";
            menu.Size = new Size(250, 200);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;
            menu.ShowIcon = false;
            menu.ShowInTaskbar = false;

            Button btnAdd = new Button();
            btnAdd.Text = "Produto";
            btnAdd.Size = new Size(150, 35);
            btnAdd.Location = new Point(40, 40);
            btnAdd.Click += (sender, e) => {
                menu.Hide();
                var produto = new Produto();
                produto.ShowDialog();
                menu.Show();
            };

            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new Size(150, 35);
            sair.Location = new Point(40, 85);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(btnAdd);
            menu.Controls.Add(sair);
            menu.ShowDialog();
        }
    }
}