using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
namespace Instant_consultation_system
{
    public partial class Login : MaterialForm
    {
        public static int ID = 0;
        public static int type_user; 
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        MySqlConnection conn = new MySqlConnection(conn_str);
        public Login()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue700,
                Primary.Blue700, Accent.Blue700,
                TextShade.WHITE);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            password.PasswordChar = '*';
        }
        private void checkInputData()
        {
            conn.Open();
            MySqlParameter log1 = new MySqlParameter();
            MySqlParameter passwd = new MySqlParameter();
            log1.Value = login_name.Text;
            log1.ParameterName = "@log1";
            passwd.Value = password.Text;
            passwd.ParameterName = "@passwd";
            MySqlCommand query = new MySqlCommand("select ID, type_user from ics_users where login = @log1 and password = @passwd", conn);
            query.Parameters.Add(log1);
            query.Parameters.Add(passwd);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                if (login_name.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Введите корректный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ID = Convert.ToInt32(reader[0]);
                    type_user = Convert.ToInt32(reader[1]);
                }
            }
            conn.Close();
        }
        private void Log_Click(object sender, EventArgs e)
        {
            checkInputData();
            switch (type_user)
            {
                case 1:
                    if (ID > 0)
                    {
                        this.Hide();
                        InformationUsers info = new InformationUsers();
                        info.ShowDialog();
                        this.Close();
                    }
                    break;
                case 3:
                    if (ID > 0)
                    {
                        this.Hide();
                        InformationKonsult info = new InformationKonsult();
                        info.ShowDialog();
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
            
        }
        private void Login_name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                checkInputData();
            }
        }
        private void MaterialLabel3_Click(object sender, EventArgs e)
        {

        }
        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Register register = new Register();
            register.Show();
        }
    }
}
