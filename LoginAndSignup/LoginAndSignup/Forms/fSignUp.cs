using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginAndSignup.Forms
{
    public partial class fSignUp : Form
    {
        public fSignUp()
        {
            InitializeComponent();
        }
        private string conString = "Data Source=DESKTOP-5NRSJ78;Initial Catalog=loginAndSignup;Integrated Security=True";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Open();
                string query = "insert into users(firstName,lastName,userName,userPassword) values('" + txtfname.Text.ToString() + "','" + txtlname.Text.ToString() + "','" + txtusername.Text.ToString() + "','" + txtpassword.Text.ToString() + "') ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("user Added successfully");
            }
            catch
            {
                MessageBox.Show("cannot connect to server");
            }

        }
    }
}
