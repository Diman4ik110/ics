using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Instant_consultation_system
{
    public partial class Main : MaterialForm
    {
        public class save
        {
            public int ID;
            public Panel Panel;
        }
        public class user_data
        {
            public int ID;
            public string first_name;
            public string last_name;
            public string email;
            public string skype;
            public string acad;
            public string position;
            public int status = 0;
        }
        public class data
        {
            public int ID;
            public string name;
        }
        public user_data forData;
        public static Panel user = new Panel();
        public static Label first_name = new Label();
        public static Panel status = new Panel();
        public static List<save> user_panels = new List<save>();
        public static List<data> napr_list = new List<data>();
        public List<user_data> user_list = new List<user_data>();
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        public static MySqlConnection conn = new MySqlConnection(conn_str);
        public Main()
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
            getNaprData();
            getUserList();
            setUserList();
            setNaprData();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
        }
        private void MaterialLabel1_Click(object sender, EventArgs e)
        {
            if (Login.ID > 0)
            {
                switch (Login.type_user)
                {
                    case 1:
                        InformationUsers info = new InformationUsers();
                        info.ShowDialog();
                        break;
                    case 3:
                        InformationKonsult infoKonsult = new InformationKonsult();
                        infoKonsult.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Login log = new Login();
                log.Show();
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
        public void setNaprData()
        {
            for (int i = 0; i < napr_list.Count; i++)
            {
                comboBox1.Items.Add(napr_list[i].name);
            }
        }
        private void getUserList()
        {
            flowLayoutPanel1.Controls.Clear();
            user_list.Clear();
            conn.Open();
            MySqlCommand command = new MySqlCommand("select ID, first_name, last_name, email, skype, acad, position, status from ics_users where type_user=3",conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                forData = new user_data();
                forData.ID = Convert.ToInt32(reader[0]);
                forData.first_name = reader[1].ToString();
                forData.last_name = reader[2].ToString();
                forData.email = reader[3].ToString();
                forData.skype = reader[4].ToString();
                forData.acad = reader[5].ToString();
                forData.position = reader[6].ToString();
                forData.status = Convert.ToInt32(reader[7]);
                user_list.Add(forData);
            }
            reader.Close();
            conn.Close();
        }
        public void OnlineFilter()
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("select ID, first_name, status from isc_users where status=2",conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                flowLayoutPanel1.Controls.Clear();
                user = new Panel();
                first_name = new Label();
                user.Width = 140;
                user.Height = 140;
                status = new Panel();
                user.BackColor = Color.Blue;
                status.Width = user.Width;
                status.Height = 5;
                first_name.TextAlign = ContentAlignment.BottomCenter;
                first_name.BackColor = Color.Transparent;
                first_name.Dock = DockStyle.Bottom;
                first_name.Text = reader[1].ToString();
                switch (Convert.ToInt32(reader[2]))
                {
                    case 0:
                        status.BackColor = Color.Red;
                        break;
                    case 1:
                        status.BackColor = Color.Orange;
                        break;
                    case 2:
                        status.BackColor = Color.LightGreen;
                        break;
                    default:
                        break;
                }
                first_name.Parent = user;
                status.Parent = user;
                user.Parent = flowLayoutPanel1;
            }
            conn.Close();
        }
        private void setUserList()
        {
            for (int i = 0; i < user_list.Count; i++)
            {
                user = new Panel();
                first_name = new Label();
                user.Width = 140;
                user.Height = 140;
                user.Click += User_Click;
                first_name.Click += User_Click;
                status.Click += User_Click;
                status = new Panel();
                user.BackColor = Color.Blue;
                status.Width = user.Width;
                status.Height = 5;
                user.Tag = i.ToString();
                first_name.TextAlign = ContentAlignment.BottomCenter;
                first_name.BackColor = Color.Transparent;
                first_name.Dock = DockStyle.Bottom;
                first_name.Text = user_list[i].first_name;
                switch (user_list[i].status)
                {
                    case 0:
                        status.BackColor = Color.Red;
                        break;
                    case 1:
                        status.BackColor = Color.Orange;
                        break;
                    case 2:
                        status.BackColor = Color.LightGreen;
                        break;
                    default:
                        break;
                }
                first_name.Parent = user;
                status.Parent = user;
                user.Parent = flowLayoutPanel1;

                save save = new save();
                save.ID = user_list[i].ID;
                save.Panel = user;

                user_panels.Add(save);

            }
        }
        public static int panelID;
        private void User_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < user_panels.Count; i++)
            {
                if (user_panels[i].Panel == (Panel)sender)
                {
                    panelID = user_panels[i].ID;
                    break;
                }
            }
            buy sell = new buy();
            sell.ShowDialog();
        }
        private void MaterialLabel1_Enter(object sender, EventArgs e)
        {

        }
        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            user_list.Clear();
            getUserList();
            setUserList();
        }

        private void MaterialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Online_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT ID, first_name, status from ics_users where status=2            MySqlDataReader reader = command.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            while (reader.Read())
            {
                user = new Panel();
                first_name = new Label();
                user.Width = 140;
                user.Height = 140;
                user.Click += User_Click;
                first_name.Click += User_Click;
                status.Click += User_Click;
                status = new Panel();
                user.BackColor = Color.Blue;
                status.Width = user.Width;
                status.Height = 5;
                first_name.TextAlign = ContentAlignment.BottomCenter;
                first_name.BackColor = Color.Transparent;
                first_name.Dock = DockStyle.Bottom;
                first_name.Text = reader[1].ToString();
                switch (Convert.ToInt32(reader[2]))
                {
                    case 0:
                        status.BackColor = Color.Red;
                        break;
                    case 1:
                        status.BackColor = Color.Orange;
                        break;
                    case 2:
                        status.BackColor = Color.LightGreen;
                        break;
                    default:
                        break;
                }
                first_name.Parent = user;
                status.Parent = user;
                user.Parent = flowLayoutPanel1;
            }   conn.Close();
        }
    }
}
