using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChaturbateChatMonitor
{
    public partial class MonitorWindow : Form
    {
        public Monitor.NewMessageCallBackDelegate NewMessageCallback;
        public System.Timers.Timer _listenTimer;

        public MonitorWindow(string address)
        {
            Environment.SetEnvironmentVariable("WEBKIT_IGNORE_SSL_ERRORS", "1");
            InitializeComponent();

            webBrowser1.Navigate(address);
            webKitBrowser1.Navigate(address);

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listenTimer = new System.Timers.Timer();
            _listenTimer.Interval = 2000;
            _listenTimer.Elapsed += _listenTimer_Elapsed;
            _listenTimer.Start();

        }

        void _listenTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _listenTimer.Enabled = false;

            if (NewMessageCallback == null)
                return;

            string html = getDocText();
            int chatboxStart = html.IndexOf("<div class=\"chat-list\"");

        
            if (chatboxStart > -1)
            {
                List<string> Messages = new List<string>();

                while(true)
                {
                    int nextDivStart = html.IndexOf("<div", chatboxStart + 1);
                    int nextDivEnd = html.IndexOf("</div", chatboxStart);

                    if (nextDivStart == -1 || nextDivEnd == -1 || nextDivEnd < nextDivStart)
                        break;

                    string divContents = html.Substring(nextDivStart, nextDivEnd);

                }

                if (Messages.Any())
                    NewMessageCallback(Messages.First());
            }

            _listenTimer.Enabled = true;
        }

        public delegate string getDocTextDelegate();
        public string getDocText()
        {
            //if (webKitBrowser1.InvokeRequired)
            //    return webKitBrowser1.Invoke(new getDocTextDelegate(getDocText)) as string;

            if (webBrowser1.InvokeRequired)
                return webBrowser1.Invoke(new getDocTextDelegate(getDocText)) as string;

            return webKitBrowser1.StringByEvaluatingJavaScriptFromString("document.getElementsByTagName('html')[0].outerHTML");
          //  return webBrowser1.Document.Body.OuterHtml ;
        }
      
        private void webKitBrowser1_Error(object sender, WebKit.WebKitBrowserErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(webKitBrowser1.DocumentText);
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

       
    }
}
