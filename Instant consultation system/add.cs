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
namespace Instant_consultation_system
{
    public partial class add : MaterialForm
    {
        static string conn_str = "server=172.24.0.212;user=user;database=sdk;password=718397Dm;";
        MySqlConnection conn = new MySqlConnection(conn_str);
        public add()
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
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            conn.Open();
            
            conn.Close();
        }
    }
}
