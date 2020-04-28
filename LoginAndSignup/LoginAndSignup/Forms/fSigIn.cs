using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndSignup.Forms
{
    public partial class fSigIn : Form
    {
        public fSigIn()
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
                string query = "select * from users where userName='" + txtusername.Text.Trim() + "' and userPassword='" + txtpassword.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    MessageBox.Show("hello "+ dr[1].ToString()+" "+ dr[2].ToString()+" nice to see you again...!!!");
                }
            }
            catch
            {
                MessageBox.Show("cannot connect to server");
            }
            
        }
    }
}
