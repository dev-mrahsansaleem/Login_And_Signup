using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndSignup.Forms
{
    public partial class fHome : Form
    {
        //variables
        private bool maximized;
        private int mouseX = 0;
        private int mouseY = 0;
        private bool mouseDown;
        private Form activeForm = null;
        //^^^varriables
        //custom function
        private void customizeDesign()
        {
            panelUserSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelUserSubMenu.Visible == true)
            {
                panelUserSubMenu.Visible = false;
            }
        }
        private void showSubMenu(Panel submenu)
        {
            if(submenu.Visible==false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void showChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //^^^custom function
        public fHome()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximze_Click(object sender, EventArgs e)
        {
            if (!maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                maximized = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                maximized = false;
            }
        }

        private void topPanelMover_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void topPanelMover_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void topPanelMover_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void template_Load(object sender, EventArgs e)
        {

            maximized = false;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            showSubMenu(panelUserSubMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showChildForm(new fSigIn());
            //add code here
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showChildForm(new fSignUp());
            //add code here
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add code here
            hideSubMenu();
        }
    }
}
