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
    public partial class buy : MaterialForm
    {
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        static MySqlConnection conn = new MySqlConnection(conn_str);
        public buy()
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
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Main.panelID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("select first_name, last_name, acad, position, status from ics_users where ID=@ID", conn);
            command.Parameters.Add(parameter);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                first_name.Text = reader[0].ToString();
                last_name.Text = reader[1].ToString();
                acad.Text = reader[2].ToString();
                position.Text = reader[3].ToString();
                switch (Convert.ToInt32(reader[4]))
                {
                    case 0:
                        status.Text = "Не в сети";
                        materialFlatButton1.Enabled = false;
                        materialFlatButton2.Enabled = false;
                        break;
                    case 1:
                        status.Text = "Занят";
                        materialFlatButton1.Enabled = true;
                        break;
                    case 2:
                        status.Text = "Свободен";
                        materialFlatButton1.Enabled = true;
                        materialFlatButton2.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            conn.Close();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Оплата", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                materialLabel1.Visible = true;
                conn.Open();
                MySqlParameter parameter = new MySqlParameter();
                parameter.Value = Main.panelID;
                parameter.ParameterName = "@ID";
                MySqlCommand command = new MySqlCommand("select number from ics_users where ID=@ID", conn);
                command.Parameters.Add(parameter);
                materialLabel1.Text = command.ExecuteScalar().ToString();
                parameter = new MySqlParameter();
                parameter.Value = Main.panelID;
                parameter.ParameterName = "@ID";
                command = new MySqlCommand("insert into zakaz_list(id_konsult, enable) values (@ID,true)", conn);
                command.Parameters.Add(parameter);
                command.ExecuteScalar();
                conn.Close();
            }
            materialFlatButton1.Enabled = false;
            materialFlatButton2.Enabled = true;
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlParameter param = new MySqlParameter();
            param.Value = Main.panelID;
            param.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("update zakaz_list set enable=false where id_konsult=@ID;commit", conn);
            command.Parameters.Add(param);
            command.ExecuteScalar();
            conn.Close();
            materialLabel1.Text = "";
            materialFlatButton2.Enabled = false;
            materialFlatButton1.Enabled = true;
        }
    }
}
