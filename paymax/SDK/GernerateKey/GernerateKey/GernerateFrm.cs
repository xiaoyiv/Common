using Cn.Ubingo.Security.RSA.Key;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GernerateKey
{
    public partial class GernerateFrm : Form
    {
        public GernerateFrm()
        {
            InitializeComponent();
        }

        private void btnGernerate_Click(object sender, EventArgs e)
        {
            //生成公私钥对
            KeyPair keyPair = KeyGenerator.GenerateKeyPair();

            //转换成不同的格式
            KeyPair asnKeyPair = keyPair.ToASNKeyPair();
            KeyPair xmlKeyPair = asnKeyPair.ToXMLKeyPair();
            KeyPair pemKeyPair = xmlKeyPair.ToPEMKeyPair();

            //获取公私钥
            txtNetPublicKey.Text = xmlKeyPair.PublicKey;
            txtNetPrivateKey.Text= xmlKeyPair.PrivateKey;

            txtJavaPublicKey.Text = asnKeyPair.PublicKey;
            txtJavaPrivateKey.Text = asnKeyPair.PrivateKey;
     
        }
    }
}
