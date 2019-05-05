using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumeClient
{
    public partial class Form1 : Form
    {
        private ARP _myArp = new ARP();

        public Form1()
        {
            InitializeComponent();
            _myArp.OnPermissionChanged += _myArp_OnPermissionChanged;
        }

        private void _myArp_OnPermissionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Was changed");
        }

        private async void button1_Click(object sender, EventArgs e)
        {

           var output =  await _myArp.HasAccess("", "");


        //    int i = 2;
             //_myArp.Load("", null).Wait();


        }
    }
}
