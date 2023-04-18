
namespace Views
{
    public class Menu{
        
        public static void index(){
            Form menu = new Form();
            
            menu.Text = "Menu";
            menu.Size = new Size(300, 300);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;
            menu.ShowIcon = false;
            menu.ShowInTaskbar = false;

            Button btnAdd = new Button();
            btnAdd.Text = "Produto";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(100, 100);
            btnAdd.Click += (sender, e) => {
                menu.Hide();
                new Produto();
                menu.Show();
            };

            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new Size(100, 30);
            sair.Location = new Point(100, 150);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(btnAdd);
            menu.Controls.Add(sair);
            menu.ShowDialog();


            

                    
        }
    }
}