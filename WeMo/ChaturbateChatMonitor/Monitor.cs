using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WebKit.DOM;

namespace ChaturbateChatMonitor
{
    public class Monitor
    {
        public delegate void NewMessageCallBackDelegate(string msg);
        public NewMessageCallBackDelegate NewMessageCallback;
            
        public bool Enabled {get; set;}
        public List<string> Messages {get; set;}

        MonitorWindow frm = null;

        public void Go(string address)
        {
            MonitorWindow frm = new MonitorWindow( address);
            frm.NewMessageCallback = NewMessageCallback;
            frm.Show();
        }

        public void Stop()
        {
            if (frm != null)
            {
                frm.Close();
                frm = null;
            }
                
        }
    }
}
