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
    public partial class InformationKonsult : MaterialForm
    {
        public static DataTable table = new DataTable();
        class data
        {
            public int ID;
            public string name;
        }
        public static int zakaz_ID;
        public int status;
        static List<data> napr_list = new List<data>();
        static List<data> spec_list = new List<data>();
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        static MySqlConnection conn = new MySqlConnection(conn_str);
        public InformationKonsult()
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
            materialFlatButton4.Enabled = true;
            materialFlatButton5.Enabled = false;
            table.Columns.Clear();
            table.Columns.Add("Направление");
            table.Columns.Add("Специализация");
            table.Columns.Add("Стоимость быстрой консультации");
            dataGridView1.DataSource = table;
            conn.Open();
            checkForZakaz();
            conn.Close();
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void MaterialLabel1_Click(object sender, EventArgs e)
        {
            
        }
        private void Information_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("select login, first_name, last_name, email, acad, status from ics_users where ID=@ID", conn);
            command.Parameters.Add(parameter);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            login.Text = reader[0].ToString();
            first_name.Text = reader[1].ToString();
            last_name.Text = reader[2].ToString();
            email.Text = reader[3].ToString();
            acad.Text = reader[4].ToString();
            status = Convert.ToInt32(reader[5]);
            conn.Close();
            
            getNaprData();
            comboBox1.Items.Clear();
            for (int i = 0; i < napr_list.Count; i++)
            {
                comboBox1.Items.Add(napr_list[i].name);
            }
            setSpecList();
            switch (status)
            {
                case 0:
                    panel2.BackColor = Color.Red;
                    break;
                case 1:
                    panel2.BackColor = Color.Orange;
                    break;
                case 2:
                    panel2.BackColor = Color.LightGreen;
                    break;
                default:
                    break;
            }
        }
        public void checkForZakaz()
        {
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("select ID from zakaz_list where id_konsult=@ID and enable=true", conn);
            command.Parameters.Add(parameter);
            zakaz_ID = Convert.ToInt32(command.ExecuteScalar());
            if (zakaz_ID>0)
            {
                message.Text = "У Вас новая заявка на консультацию №" + zakaz_ID.ToString();
                materialFlatButton4.Enabled = false;
                materialFlatButton5.Enabled = true;
            }
        }
        public static void getNaprData()
        {
            
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("select ID, name from ics_naprav", conn);
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                data dataset = new data();
                dataset.ID = Convert.ToInt32(reader[0]);
                dataset.name = reader[1].ToString();
                napr_list.Add(dataset);
            }
            conn.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {

        }
        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (spec_list[i].name != comboBox2.SelectedItem.ToString())
            {
                i++;
            }
            if (spec_list[i].name == comboBox2.SelectedItem.ToString())
            {
                conn.Open();
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = Login.ID;
                MySqlParameter parameter1 = new MySqlParameter();
                parameter1.ParameterName = "@spec_id";
                parameter1.Value = spec_list[i].ID;
                MySqlParameter parameter2 = new MySqlParameter();
                parameter2.ParameterName = "@id_napr";
                parameter2.Value = napr_list[comboBox1.SelectedIndex].ID;
                MySqlParameter parameter3 = new MySqlParameter();
                parameter3.ParameterName = "@qpk";
                parameter3.Value = materialSingleLineTextField1.Text;
                MySqlCommand command = new MySqlCommand("insert into ics_spec(id_species, id_user, id_napr, quick_konsult_pay) values (@spec_id, @ID, @id_napr, @qpk);commit;", conn);
                command.Parameters.Add(parameter);
                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);
                command.ExecuteScalar();
                conn.Close();
            }
            setSpecList();
        }
        static void setSpecList()
        {
            
            table.Rows.Clear();
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand sqlCommand = new MySqlCommand("select ics_spec.id_user, ics_species.spec_name, ics_naprav.name, ics_spec.quick_konsult_pay from ics_spec inner join ics_species on ics_spec.id_species=ics_species.ID inner join ics_naprav on ics_spec.id_napr = ics_naprav.ID where ics_spec.id_user=@ID;", conn);
            sqlCommand.Parameters.Add(parameter);
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                table.Rows.Add(reader[1].ToString(),reader[2].ToString(),Convert.ToInt32(reader[3]));
            }
            conn.Close();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (napr_list[i].name != comboBox1.SelectedItem.ToString())
            {
                i++;
            }
            if (napr_list[i].name == comboBox1.SelectedItem.ToString())
            {
                comboBox2.Items.Clear();
                spec_list.Clear();
                conn.Open();
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = napr_list[i].ID;
                MySqlCommand command = new MySqlCommand("SELECT ics_species.ID,spec_name,ics_naprav.name FROM ics_species inner join ics_naprav on ics_naprav.ID=ics_species.napr_id where napr_id=@ID", conn);
                command.Parameters.Add(parameter);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data usrdata = new data();
                    usrdata.ID = Convert.ToInt32(reader[0]);
                    usrdata.name = reader[1].ToString();
                    spec_list.Add(usrdata);
                }
                for (int j = 0; j < spec_list.Count; j++)
                {
                    comboBox2.Items.Add(spec_list[j].name);
                }
                conn.Close();
            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            EditProfile edit = new EditProfile();
            edit.Show();
            this.Close();
        }
        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("update ics_users set status=0 where ID=@ID;commit;", conn);
            command.Parameters.Add(parameter);
            command.ExecuteScalar();
            conn.Close();
            this.Close();
            Login.ID = 0;
        }
        private void InformationKonsult_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TabPage4_Click(object sender, EventArgs e)
        {

        }

        private void MaterialFlatButton4_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlParameter parameter = new MySqlParameter();
            parameter.Value = Login.ID;
            parameter.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("update ics_users set status=2 where ics_users.ID = @ID;commit;",conn);
            command.Parameters.Add(parameter);
            command.ExecuteScalar();
            conn.Close();
            materialFlatButton4.Enabled = false;
        }

        private void InformationKonsult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F7)
            {
                checkForZakaz();
            }
        }

        private void MaterialFlatButton5_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlParameter param = new MySqlParameter();
            param.Value = Login.ID;
            param.ParameterName = "@ID";
            MySqlCommand command = new MySqlCommand("update zakaz_list set enable=false where id_konsult=@ID;commit",conn);
            command.Parameters.Add(param);
            command.ExecuteScalar();
            conn.Close();
            materialFlatButton4.Enabled = true;
            materialFlatButton5.Enabled = false;
            message.Text = "";
        }
    }
}
