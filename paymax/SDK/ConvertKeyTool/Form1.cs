using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertKeyTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtJavaPublicKey.Text!=null)
            {
                string publickey = txtJavaPublicKey.Text;
                txtNetPublicKey.Text = RSAKeyConvert.RSAPublicKeyJava2DotNet(publickey);
            }

            //if (txtJavaPrivateKey.Text!=null)
            //{
            //    string privatekey = txtJavaPrivateKey.Text;
            //    txtNetPrivateKey.Text = RSAKeyConvert.RSAPrivateKeyJava2DotNet(privatekey);
            //}
         
        }
    }
}
