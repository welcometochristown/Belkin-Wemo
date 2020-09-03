using NAudio.CoreAudioApi;
using NAudio.Wave;
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
using VoiceRecorder.Audio;

namespace WeMo.Visual
{
    public partial class WemoControl : Form
    {
       
        #region Fields
        Belkin.WeMo.WeMoSwitch _switch = null;

        Timer _toggleDelayTimer = null;

        Timer _toggleOnDelayTimer = null;
        Timer _toggleOffDelayTimer = null;

        Timer _recorderListtimer = null;

        #endregion

        #region Constructor
        public WemoControl()
        {
            InitializeComponent();

            UpdateControls();
        }

        #endregion

        #region Form Load
        MMDevice recordingDevice;
        WaveIn waveIn;
        private SampleAggregator sampleAggregator ;

        private void Form1_Load(object sender, EventArgs e)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            recordingDevice = devices.FirstOrDefault();

            UpdateControls();
        }

     

        private void NewChaturbateMessage(string message)
        {
            /* process this */
            //if(message == "On")
            //{
            //    _switch.On();
            //}
            //else
            //{
            //    _switch.Off();
            //}

            Console.WriteLine(message);
           
        }

        #endregion

        #region Events

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (_switch == null)
            {
                //connect
                string host = hostTxt.Text;
                string port = portTxt.Text;

                if (String.IsNullOrWhiteSpace(host) || String.IsNullOrWhiteSpace(port))
                    return;

                _switch = new Belkin.WeMo.WeMoSwitch(new IPEndPoint(IPAddress.Parse(host), int.Parse(port)));

                Cursor = Cursors.WaitCursor;
                try
                {
                    //check this switch is alive
                    Belkin.WeMo.WeMoSwitchReponse response = _switch.GetState();

                    if (!response.Success || !response.BinaryState.HasValue)
                        _switch = null;
                    else
                        SetSwitchImageState(response.BinaryState.Value);

                }catch{
                    _switch = null;
                }

                Cursor = Cursors.Default;
            }
            else
            {
                //disconnect
                _switch = null;
            }

            UpdateControls();

            connectBtn.Text = _switch == null ? "Connect" : "Disconnect";

        }

        private void OnOffPic_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void OnOffPic_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void OnOffPic_Click(object sender, EventArgs e)
        {
            ToggleSwitchState();
        }
        #endregion

        protected void SetSwitchImageState(bool state)
        {
            OnOffPic.BackgroundImage = state ? Properties.Resources.switch_on_icon : OnOffPic.BackgroundImage = Properties.Resources.switch_off_icon ;
        }

        protected void SetSwitchState(bool newState)
        {
            if (_switch == null)
                return;

            Belkin.WeMo.WeMoSwitchReponse state = _switch.GetState();

            if (!state.Success || !state.BinaryState.HasValue)
                return;

            SetSwitchState(newState, state.BinaryState.Value);
        }

        protected void SetSwitchState(bool newState, bool currentState)
        {
            if (_switch == null)
                return;

            Belkin.WeMo.WeMoSwitchReponse state;

            bool startingState = currentState;
      
            int attempts = 3;
            int attempt = 0;

            while (attempt < attempts)
            {
                if (newState)
                    _switch.On();
                else
                    _switch.Off();

                //check the state has changed
                state = _switch.GetState();

                if (!state.Success || !state.BinaryState.HasValue)
                    continue; //try again;

                if (state.BinaryState.Value != newState)
                    continue; //try again;

                currentState = newState;

                break;
            }

            SetSwitchImageState(currentState);
            UpdateControls();
        }

        protected void ToggleSwitchState()
        {
            if (_switch == null)
                return;

            Belkin.WeMo.WeMoSwitchReponse state = _switch.GetState();

            if (!state.Success || !state.BinaryState.HasValue)
                return;

            SetSwitchState(!state.BinaryState.Value, state.BinaryState.Value);
            
        }

        /// <summary>
        /// Updates the controls.
        /// </summary>
        protected void UpdateControls()
        {
            connectedPanel.Enabled = (_switch != null);
            connectionStatusLbl.Text = (_switch != null) ? "Connected":"Disconnected";
            connectionStatusLbl.BackColor = (_switch != null) ? Color.Green : Color.Red;

            connectPanel.Enabled = (_switch == null);

            if(_switch == null)
            {
               OnOffPic.BackgroundImage = Properties.Resources.switch_blank_icon;
            }

            wemoDevicePic.BackgroundImage = _switch == null ? null : Properties.Resources.belkin_switch;

        }

        ChaturbateChatMonitor.Monitor m = null;
        private void startActionsBtn_Click(object sender, EventArgs e)
        {
            if (!toggleDelayChk.Checked && !soundonChk.Checked && !soundoffChk.Checked && !weblistenerChk.Checked && !audiocaptimerChk.Checked)
                return;

            if (startActionsBtn.Text == "Start")
            {
                if (toggleDelayChk.Checked)
                {
                    _toggleDelayTimer = new Timer();
                    _toggleDelayTimer.Interval = Convert.ToInt16(toggleNum.Value) * 1000;
                    _toggleDelayTimer.Tick += _toggleDelayTimer_Tick;
                    _toggleDelayTimer.Start();
                }

                if (toggleOnChk.Checked)
                {
                    _toggleOnDelayTimer = new Timer();
                    _toggleOnDelayTimer.Interval = Convert.ToInt16(toggleOnNum.Value) * 1000;
                    _toggleOnDelayTimer.Tick += _toggleOnDelayTimer_Tick;
                    _toggleOnDelayTimer.Start();
                }


                if (toggleOffChk.Checked)
                {
                    _toggleOffDelayTimer = new Timer();
                    _toggleOffDelayTimer.Interval = Convert.ToInt16(toggleOffNum.Value) * 1000;
                    _toggleOffDelayTimer.Tick += _toggleOffDelayTimer_Tick;
                    _toggleOffDelayTimer.Start();
                }


                if(weblistenerChk.Checked)
                {
                    m = new ChaturbateChatMonitor.Monitor();
                    m.NewMessageCallback += NewChaturbateMessage;
                    m.Go(weblistenAddressTxt.Text);
                }

                if (audiocaptimerChk.Checked && recordingDevice != null)
                {
                    waveIn = new WaveIn();
                    waveIn.DeviceNumber = 0;

                    int sampleRate = 8000; // 8 kHz
                    int channels = 1; // mono
                    waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
                    waveIn.StartRecording();
            

                    _recorderListtimer= new Timer();
                    _recorderListtimer.Interval = 25;
                    _recorderListtimer.Tick += _recordingDelayTimer_Tick;
                    _recorderListtimer.Start();
                }

                actionPanel.Enabled = false;
                actionsStatePic.BackgroundImage = Properties.Resources.bullet_green;
                startActionsBtn.Text = "Stop";
            }else
            {
                if (_toggleDelayTimer != null)
                {
                    _toggleDelayTimer.Stop();
                    _toggleDelayTimer = null;  
                }

                if (_toggleOnDelayTimer != null)
                {
                    _toggleOnDelayTimer.Stop();
                    _toggleOnDelayTimer = null;
                }

                if (_toggleOffDelayTimer != null)
                {
                    _toggleOffDelayTimer.Stop();
                    _toggleOffDelayTimer = null;
                }

                if(_recorderListtimer != null)
                {
                    _recorderListtimer.Stop();
                    _recorderListtimer = null;

                    if (waveIn != null)
                    {
                        waveIn.StopRecording();
                        waveIn = null;
                        progressBar1.Value = 0;
                    }
                }

                if (m != null)
                {
                    m.Stop();
                    m = null;
                }

                actionPanel.Enabled = true;
                actionsStatePic.BackgroundImage = Properties.Resources.bullet_red;
                startActionsBtn.Text = "Start";
            }

        }

        void _toggleOffDelayTimer_Tick(object sender, EventArgs e)
        {
            _toggleOnDelayTimer.Enabled = false;
            SetSwitchState(true);
            _toggleOnDelayTimer.Enabled = true;
        }

        void _toggleOnDelayTimer_Tick(object sender, EventArgs e)
        {
            _toggleOffDelayTimer.Enabled = false;
            SetSwitchState(false);
            _toggleOffDelayTimer.Enabled = true;
        }

        void _toggleDelayTimer_Tick(object sender, EventArgs e)
        {
            _toggleDelayTimer.Enabled = false;
            ToggleSwitchState();
            _toggleDelayTimer.Enabled = true;
        }

        public List<int> peaks = new List<int>();
        void _recordingDelayTimer_Tick(object sender, EventArgs e)
        {
            _recorderListtimer.Enabled = false;

            int peak = (int)( (recordingDevice.AudioMeterInformation.MasterPeakValue) * 100);

            peaks.Add(peak);

            if(peaks.Count > 3)
            {
                IEnumerable<int> last3 = peaks.Skip(peaks.Count-3).Take(3);
                int avg = (int)(last3.Sum(i => i) / 3);

                peak = avg;
            }

            peak = (peak > 100 ? 100 : peak);
            progressBar1.Value = peak;

            if (progressBar1.Value > audiocapnum.Value)
            {
                SetSwitchState(false);
            }

            _recorderListtimer.Enabled = true;
        }


        private void toggleDelayChk_CheckedChanged(object sender, EventArgs e)
        {
            toggleNum.Enabled = toggleDelayChk.Checked;
        }

        private void hostTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void hostTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectBtn.PerformClick();
        }

        private void portTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectBtn.PerformClick();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void audiocaptimerChk_CheckedChanged(object sender, EventArgs e)
        {
            audiocapnum.Enabled = audiocaptimerChk.Checked;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

    
       
    }
}
