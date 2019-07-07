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
    public partial class EditProfile : MaterialForm
    {
        public string filename;
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        static MySqlConnection conn = new MySqlConnection(conn_str);
        public EditProfile()
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

        private void EditProfile_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("select login, first_name, last_name, email, acad from ics_users where ID=@ID", conn);
            command.Parameters.Add(parameter);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            login.Text = reader[0].ToString();
            first_name.Text = reader[1].ToString();
            last_name.Text = reader[2].ToString();
            email.Text = reader[3].ToString();
            acad.Text = reader[4].ToString();
            conn.Close();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filename);
            }
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            switch (Login.type_user)
            {
                case 1:
                    saveUser();
                    this.Close();
                    break;
                case 3:
                    saveKonsult();
                    this.Close();
                    break;
                default:
                    break;
            }

        }
        private void saveUser()
        {
            conn.Open();
            MySqlCommand query = new MySqlCommand("update ics_users set first_name=@first_name, last_name=@last_name,email=@email, login=@login where ID=@ID;commit", conn);
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = login.Text;
            parameter.ParameterName = "@login";
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
            query.ExecuteScalar();
            conn.Close();
        }
        private void saveKonsult()
        {
            conn.Open();
            MySqlCommand query = new MySqlCommand("update ics_users set first_name=@first_name, last_name=@last_name,email=@email, login=@login, acad=@acad, position=@position where ID=@ID;commit;", conn);
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = login.Text;
            parameter.ParameterName = "@login";
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
            parameter.ParameterName = "@acad";
            parameter.Value = last_name.Text;
            query.Parameters.Add(parameter);

            parameter = new MySqlParameter();
            parameter.Value = email.Text;
            parameter.ParameterName = "@position";
            query.Parameters.Add(parameter);
            query.ExecuteScalar();
            conn.Close();
        }
    }
}
