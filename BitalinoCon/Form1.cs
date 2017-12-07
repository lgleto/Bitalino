using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitalinoCon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DeviceSingletone.Instance.NewData += Instance_NewData;
        }

        private void buttonSearchDevices_Click(object sender, EventArgs e)
        {
            SearchDevices sd = new SearchDevices();
            sd.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            await DeviceSingletone.Instance.ReadDevice();
           
        }

        private void Instance_NewData(string data)
        {
            AddTextToTextBox(data);
        }


        delegate void AddTextDelegate(string text);

        private void AddTextToTextBox(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AddTextDelegate d = new AddTextDelegate(AddTextToTextBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.Text += text;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            DeviceSingletone.Instance.disconnect();
        }
    }
}
