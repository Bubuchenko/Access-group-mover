using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_browser
{
    public partial class loginForm : Form
    {
        Form1 form;

        public loginForm()
        {
            InitializeComponent();
            form = new Form1();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(credentialsValid(usernameField.Text, passwordField.Text))
            {
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool credentialsValid(string username, string password)
        {
            form.USERNAME = username;
            form.PASSWORD = password;

            try
            {
                form.GetAccessgroups();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
        }
    }

    [XmlRpcUrl("https://qmanage.msanet.nl/admin/rpc")]
    public interface iSearchAction : IXmlRpcProxy
    {
        [XmlRpcMethod("perform_actions")]
        XmlRpcStruct[] perform_actions(XmlRpcStruct[] struc);
    }
}
