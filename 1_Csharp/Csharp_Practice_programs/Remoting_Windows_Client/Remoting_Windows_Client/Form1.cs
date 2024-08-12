using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using Remoting_Server;



namespace Remoting_Windows_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                HttpChannel c = new HttpChannel(8002);
                ChannelServices.RegisterChannel(c);


                //create a service class object (that is the proxy for the remote object)
                RemoteServices rserviceproxy = (RemoteServices)Activator.GetObject(typeof(RemoteServices),
                    "http://localhost:86/OurRemoteServices");

                int x = int.Parse(textBox3.Text);
                int y = int.Parse(textBox4.Text);

                if (x == y)
                {
                    throw new Exception("Numbers cannot be the same to check max");
                }

                //invoke the methods of the remote object thru the proxy object
                label6.Text = "The max number is :" + rserviceproxy.WriteMessage(x, y);
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers only");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
