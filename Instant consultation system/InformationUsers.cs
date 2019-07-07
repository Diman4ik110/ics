using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlTypes;
namespace Instant_consultation_system
{
    public partial class InformationUsers : MaterialForm
    {
        class data
        {
            public int ID;
            public string name;
        }
        static List<data> napr_list = new List<data>();
        static List<data> spec_list = new List<data>();
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        static MySqlConnection conn = new MySqlConnection(conn_str);
        public InformationUsers()
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

        private void InformationUsers_Load(object sender, EventArgs e)
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
            conn.Close();
        }
        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            EditProfile edit = new EditProfile();
            edit.acad.Hide();
            edit.materialLabel8.Hide();
            edit.position.Hide();
            edit.materialLabel4.Hide();
            edit.Show();
            this.Close();
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            Login.ID = 0;
            this.Close();
        }
    }
}
