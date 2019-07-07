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
    public partial class Register : MaterialForm
    {
        class data
        {
            public int ID;
            public string name;
        }
        static List<data> roles = new List<data> ();
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        static MySqlConnection conn = new MySqlConnection(conn_str);
        public Register()
        {
            InitializeComponent();
            password.PasswordChar = '*';
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue700,
                Primary.Blue700, Accent.Blue700,
                TextShade.WHITE);
        }
        private void Register_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            conn.Open();
            string sql = "select ID, name from ics_roles";
            MySqlCommand query = new MySqlCommand(sql, conn);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                data dataset = new data();
                dataset.ID = Convert.ToInt32(reader[0]);
                dataset.name = reader[1].ToString();
                roles.Add(dataset);
                comboBox1.Items.Add(dataset.name);
            }
            comboBox1.SelectedItem = comboBox1.Items[0] ;
            conn.Close();
        }
        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            switch (roles[comboBox1.SelectedIndex].ID)
            {
                case 1:
                    registerUser();
                    break;
                case 3:
                    registerKonsult();
                    break;
                default:
                    break;
            }
            this.Close();
        }
        public void registerUser()
        {
            MySqlParameter parameter = new MySqlParameter();
            conn.Open();
            
            string sql = "insert into ics_users(login, password, first_name, last_name, email, type_user) values (@login, @password, @first_name, @last_name, @email, 1);commit;";
            MySqlCommand query = new MySqlCommand(sql, conn);

            parameter = new MySqlParameter();
            parameter.Value = Login.Text;
            parameter.ParameterName = "@login";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = password.Text;
            parameter.ParameterName = "@password";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.ParameterName = "@first_name";
            parameter.Value = first_name.Text;
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.ParameterName = "@last_name";
            parameter.Value = last_name.Text;
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = email.Text;
            parameter.ParameterName = "@email";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = 1;
            parameter.ParameterName = "@type_user";
            query.Parameters.Add(parameter);

            if (Login.Text == "" || password.Text == "")
            {
                MessageBox.Show("Введите корректный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                query.ExecuteScalar();
            }
            conn.Close();
        }
        public void registerKonsult()
        {
            MySqlParameter parameter = new MySqlParameter();
            conn.Open();

            string sql = "insert into ics_users(login, password, first_name, last_name, email, acad, position, type_user) values (@login, @password, @first_name, @last_name, @email, @acad, @position, 3);commit;";
            MySqlCommand query = new MySqlCommand(sql, conn);

            parameter = new MySqlParameter();
            parameter.Value = Login.Text;
            parameter.ParameterName = "@login";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = password.Text;
            parameter.ParameterName = "@password";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.ParameterName = "@first_name";
            parameter.Value = first_name.Text;
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.ParameterName = "@last_name";
            parameter.Value = last_name.Text;
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = email.Text;
            parameter.ParameterName = "@email";
            query.Parameters.Add(parameter);


            parameter = new MySqlParameter();
            parameter.Value = acad.Text;
            parameter.ParameterName = "@acad";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = position.Text;
            parameter.ParameterName = "@position";
            query.Parameters.Add(parameter);
            if (Login.Text == "" || password.Text == "")
            {
                MessageBox.Show("Введите корректный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                query.ExecuteScalar();
            }
            conn.Close();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (roles[i].name != comboBox1.SelectedItem.ToString())
            {
                i++;
            }
            if (roles[i].name == comboBox1.SelectedItem.ToString())
            {
                switch (roles[i].ID)
                {
                    case 1:
                        acad.Hide();
                        position.Hide();
                        materialLabel4.Hide();
                        materialLabel7.Hide();

                        break;
                    case 3:
                        acad.Show();
                        position.Show();
                        materialLabel4.Show();
                        materialLabel7.Show();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
