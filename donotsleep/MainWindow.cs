using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Reflection;

using Easy.Logging;
using Easy.Instance;

namespace DAVIDSystems.donotsleep
{
    [FlagsAttribute]
    public enum EXECUTION_STATE : uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
    }

    public partial class MainForm : Form
    {

        #region Interop

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern Int32 WaitForSingleObject(IntPtr Handle, uint Wait);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref long pDueTime, int lPeriod, TimerCompleteDelegate pfnCompletionRoutine, IntPtr pArgToCompletionRoutine, bool fResume);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CancelWaitableTimer(IntPtr hTimer);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        #endregion

        #region Members

        private const int WM_COPYDATA = 0x4A;

        EXECUTION_STATE _processor;
        EXECUTION_STATE _monitor;
        
        private uint INFINITE = 0xFFFFFFFF;

        bool _formLoaded = false;
        bool _noSleep = false;
        bool _allowClose = false;
        DateTime _stopSleeping = new DateTime(2099, 12, 31);
        int[] _sleepArray = new int[] 
        {
            0,0,1,
            0,0,2,
            0,0,5,
            0,0,10,
            0,0,15,
            0,0,30,
            0,1,0,
            0,2,0,
            0,4,0,
            0,8,0,
            0,16,0,
            1,0,0,
            2,0,0,
            4,0,0,
            7,0,0
        };

        ToolStripMenuItem _lastCheck = null;

        bool _wakeUpMode;
        DateTime _lastCheckTime;
        TimeSpan _wakeUpFor;
        public delegate void TimerCompleteDelegate();

        #endregion

        #region Init

        public MainForm()
        {
            InitializeComponent();
            InitBasics();
        }

        private void InitBasics()
        {
            timer1.Enabled = false;
            timer1.Interval = 5000;
            timer1.Tick += OnTimerEvent;
            SetCheck(tbSleep);

            _lastCheckTime = DateTime.Now;
            _wakeUpFor = new TimeSpan(2, 0, 0);
            _wakeUpMode = false;

            SystemEvents.PowerModeChanged += OnPowerModeChanged;

            string[] args = Environment.GetCommandLineArgs();
            string command = "INFINITE";
            string data = "";

            if (args.Length > 1)
            {
                command = args[1];
                if (args.Length > 2)
                {
                    data = args[2];
                }

                TimeSpan delta = GetDelta(command, data);
                StopSleeping(command, delta);
            }
            
        }

        private void OnInitForm(object sender, EventArgs e)
        {
            cbNext.SelectedIndex = 6;
            cbFor.SelectedIndex = 6;

            if (timer1.Enabled)
            {
                lbStatus.Text = "Do not sleep until: " + _stopSleeping.ToString();
                rbUntil.Checked = true;
                dtUntilDate.Value = new DateTime(_stopSleeping.Year, _stopSleeping.Month, _stopSleeping.Day);
                dtUntilTime.Value = _stopSleeping;
            }
            else
            {
                lbStatus.Text = "sleeping allowed...";
                rbAllow.Checked = true;
                dtUntilDate.Value = DateTime.Now;
                dtUntilTime.Value = DateTime.Now + new TimeSpan(1, 0, 0);
            }

            _formLoaded = true;
        }

        #endregion

        #region Gui-Events

        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            Debug.WriteLine("Power down : " + e.Mode.ToString() );
        }

        void OnTimerEvent(object sender, EventArgs e)
        {
            
            if (_noSleep && DateTime.Now >= _stopSleeping)
            {
                _noSleep = false;
                EasyLog.LogInfo("OnTimerEvent->Stop Trigger");
                AllowSleep();
                DisplayBallonMessage("Time-Marker reached: Allow sleep mode !!!", 3000);
                rbAllow.Checked = true;
                return;
            }
            if (_noSleep)
            {
                SetThreadExecutionState(_processor | _monitor);
                Debug.WriteLine("No Sleep Event !");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Analyze
            _processor = (cbSystem.Checked) ? EXECUTION_STATE.ES_SYSTEM_REQUIRED : 0;
            _monitor = (cbMonitor.Checked) ? EXECUTION_STATE.ES_DISPLAY_REQUIRED : 0;

            if (CheckSleepMode())
            {
                notifyIcon.Icon = Properties.Resources.nosleep;
                timer1.Start();
                var message = "Started No-Sleep Mode until: " + _stopSleeping.ToString();
                DisplayBallonMessage(message, 3000);
                SetCheck(tbCustom);
            }
            else 
            {
                AllowSleep();
                SetCheck(tbSleep);
            }

            InitWakeUp();

            this.Hide();
         }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OnShowSettings(object sender, EventArgs e)
        {
            if (_formLoaded)
            {
                cbNext.SelectedIndex = 3;
                dtUntilDate.Value = new DateTime(_stopSleeping.Year, _stopSleeping.Month, _stopSleeping.Day);
                dtUntilTime.Value = _stopSleeping;
                if (timer1.Enabled)
                {
                    lbStatus.Text = "Do not sleep until: " + _stopSleeping.ToString();
                    rbUntil.Checked = true;
                }
                else
                {
                    lbStatus.Text = "sleeping allowed...";
                    rbAllow.Checked = true;
                }
            }
            this.Show();
        }

        private void OnExitApplication(object sender, EventArgs e)
        {
            _allowClose = true;
            this.Close();
            Application.Exit();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose)
                e.Cancel = true;
            this.Hide();
        }

        private void On10Min(object sender, EventArgs e)
        {
            SetCheck(tbm10);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(0, 10, 0);
            StopSleeping(sleepUntil);
        }

        private void On30Min(object sender, EventArgs e)
        {
            SetCheck(tbm30);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(0, 30, 0);
            StopSleeping(sleepUntil);
        }

        private void On1Hour(object sender, EventArgs e)
        {
            SetCheck(tbh1);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(1, 0, 0);
            StopSleeping(sleepUntil);
        }

        private void On2Hours(object sender, EventArgs e)
        {
            SetCheck(tbh2);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(2, 0, 0);
            StopSleeping(sleepUntil);
        }

        private void On4Hours(object sender, EventArgs e)
        {
            SetCheck(tbh4);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(4, 0, 0);
            StopSleeping(sleepUntil);
        }

        private void On12Hours(object sender, EventArgs e)
        {
            SetCheck(tbh12);
            DateTime sleepUntil = DateTime.Now + new TimeSpan(12, 0, 0);
            StopSleeping(sleepUntil);

        }

        private void OnUsersAllowsSleeping(object sender, EventArgs e)
        {
            AllowSleep();
        }

        private void OnDisableSleep(object sender, EventArgs e)
        {
            SetCheck(tbForever);
            DateTime sleepUntil = new DateTime(2099, 12, 31);
            StopSleeping(sleepUntil);
        }

        private void OnAwakeFromSleeping()
        {
            this.InvokeIfRequired(() =>
            {
                DateTime sleepUntil = DateTime.Now + _wakeUpFor;
                StopSleeping(sleepUntil);
            });
        }

        private void OnSleepNow(object sender, EventArgs e)
        {
            notifyIcon.Icon = Properties.Resources.sleep;
            timer1.Stop();
            _noSleep = false;
            SetCheck(tbSleep);
            Sleep();
        }

        private void OnLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = Path.GetTempPath() + @"\donotsleep.xps";
          
            var assembly = Assembly.GetExecutingAssembly();  
            var resourceName = "DAVIDSystems.donotsleep.Resources.Documentation.xps";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var fileStream = File.Create(path))
                {
                    stream.CopyTo(fileStream);
                }
            }

            System.Diagnostics.Process.Start(path);
        }

        #endregion

        #region GUI Display

        // Update the checkmark on the Context Menu
        private void SetCheck(ToolStripMenuItem item)
        {
            if (_lastCheck != null)
            {
                _lastCheck.Checked = false;
            }

            item.Checked = true;
            _lastCheck = item;
        }

        private ToolStripMenuItem GetMenuItemFromCommand(string command)
        {
            ToolStripMenuItem item = tbForever;
            string cmd = command.ToUpper();
            switch(cmd)
            {
                case "10MIN":
                    item = tbm10;
                    break;
                case "30MIN":
                    item = tbm30;
                    break;
                case "1HOUR":
                    item = tbh1;
                    break;
                case "2HOUR":
                    item = tbh2;
                    break;
                case "4HOUR":
                    item = tbh4;
                    break;
                case "12HOUR":
                    item = tbh12;
                    break;
                case "CUSTOM":
                    item = tbCustom;
                    break;
            }

            return item;
        }


        public void DisplayBallonMessage(string message, int mSeconds)
        {
            if (!string.IsNullOrEmpty(message))
            {
                notifyIcon.BalloonTipText = message;
                EasyLog.LogInfo(message);
            }
            notifyIcon.ShowBalloonTip(mSeconds);
        }

        #endregion

        #region Logic

        private bool CheckSleepMode()
        {
            if (rbAllow.Checked)
            {
                if (_noSleep)
                {
                    AllowSleep();
                    DisplayBallonMessage("User stopped No-Sleep Mode", 3000);
                    _noSleep = false;
                }
            }
            else
            {
                _noSleep = true;
                if (rbNever.Checked)
                {
                    _stopSleeping = new DateTime(2099, 12, 31);
                    notifyIcon.Text = "Computer will not go to sleep ....";
                }
                if (rbNext.Checked)
                {
                    int index = cbNext.SelectedIndex * 3;
                    int days = _sleepArray[index];
                    int hours = _sleepArray[index + 1];
                    int minutes = _sleepArray[index + 2];
                    TimeSpan ts = new TimeSpan(days, hours, minutes, 0);
                    _stopSleeping = DateTime.Now + ts;
                    notifyIcon.Text = string.Format("Computer will not go to sleep until: {0}", _stopSleeping);
                }
                if (rbUntil.Checked)
                {
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(dtUntilTime.Value.ToString("HH:mm"));
                        _stopSleeping = dtUntilDate.Value.Date.Add(ts);
                    }
                    catch (Exception ex)
                    {
                        _stopSleeping = DateTime.Now + new TimeSpan(0, 8, 0, 0);
                        Debug.WriteLine(ex.Message);
                    }
                    notifyIcon.Text = string.Format("Computer will not go to sleep until: {0}", _stopSleeping);
                }
            }

            return _noSleep;
        }

        private void StopSleeping(DateTime sleepUntil)
        {
            _processor = EXECUTION_STATE.ES_SYSTEM_REQUIRED;
            _monitor = EXECUTION_STATE.ES_DISPLAY_REQUIRED;

            _stopSleeping = sleepUntil;
            notifyIcon.Icon = Properties.Resources.nosleep;
            _noSleep = true;
            timer1.Start();

            DisplayBallonMessage("Started No-Sleep Mode until: " + _stopSleeping.ToString(), 3000);
        }

        private void AllowSleep()
        {
            notifyIcon.Icon = Properties.Resources.sleep;
            timer1.Stop();
            string message = "Computer is allowed to sleep.....";
            notifyIcon.Text = message;
            DisplayBallonMessage(message, 3000);
            _noSleep = false;
            Debug.WriteLine(notifyIcon.Text);
            SetCheck(tbSleep);
        }

        private void InitWakeUp()
        {
            _wakeUpMode = cbWakeUp.Checked;
            if (_wakeUpMode)
            {
                Debug.WriteLine("Wake up Mode enabled !");

                // Read out duration
                int index = cbFor.SelectedIndex * 3;
                int days = _sleepArray[index];
                int hours = _sleepArray[index + 1];
                int minutes = _sleepArray[index + 2];
                _wakeUpFor = new TimeSpan(days, hours, minutes, 0);

                // Read Out Awake

                var awakeDate = dtAwake.Value;
                var awakeTime = dtAwakeTime.Value;
                var seconds = awakeTime.Second * -1;
                awakeTime = awakeTime.AddSeconds(seconds);

                var handle = SetWakeAt(awakeDate.Date + awakeTime.TimeOfDay);

                Task.Factory.StartNew(() =>
                {
                    WaitTimer(handle);
                });
            }
        }

        private IntPtr SetWakeAt(DateTime dt)
        {
            // read the manual for SetWaitableTimer to understand how this number is interpreted.
            // long interval = dt.ToFileTimeUtc();
            TimerCompleteDelegate timerComplete = null;

            // long interval = -100000000L;
            long interval = dt.ToFileTime();
            IntPtr handle = CreateWaitableTimer(IntPtr.Zero, true, "WaitableTimer");
            bool erg = SetWaitableTimer(handle, ref interval, 0, timerComplete, IntPtr.Zero, true);

            DisplayBallonMessage("Wakeup @: " + dt.ToString(), 10000);
            return handle;
        }

        public static bool Hibernate()
        {
            return SetSuspendState(true, false, false);
        }

        public static bool Sleep()
        {
            return SetSuspendState(false, false, false);
        }

        private void WaitTimer(IntPtr handle)
        {
            // Waiting for the timer to expire
            //
            if (WaitForSingleObject(handle, INFINITE) != 0)
            {
                EasyLog.LogError("Last Error = {0}", Marshal.GetLastWin32Error());
            }
            else
            {
                EasyLog.LogError("Timer expired @ {0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                OnAwakeFromSleeping();
            }

            // Closing the timer
            //
            CloseHandle(handle);
         }

        private void StopSleeping(string command,TimeSpan delta)
        {
            SetCheck(GetMenuItemFromCommand(command));
            DateTime sleepUntil = DateTime.Now + delta;
            StopSleeping(sleepUntil);
        }

        private TimeSpan GetDelta(string command, string data)
        {
            CultureInfo enUS = new CultureInfo("en-US");

            if (command == "10MIN")
            {
                return new TimeSpan(0, 10, 0);
            }
            if (command == "30MIN")
            {
                return new TimeSpan(0, 30, 0);
            }
            if (command == "1HOUR")
            {
                return new TimeSpan(0, 10, 0);
            }
            if (command == "2HOUR")
            {
                return new TimeSpan(0, 10, 0);
            }
            if (command == "4HOUR")
            {
                return new TimeSpan(0, 10, 0);
            }
            if (command == "12HOUR")
            {
                return new TimeSpan(0, 10, 0);
            }
            if (command == "INFINITE")
            {
                DateTime until = new DateTime(2099, 12, 31);
                return until - DateTime.Now;
            }
            if (command == "CUSTOM")
            {
                TimeSpan delta;
                DateTime date;
                bool valid = DateTime.TryParse(data, CultureInfo.CurrentUICulture, DateTimeStyles.AssumeLocal, out date);
                if (valid == false)
                {
                    delta = new TimeSpan(24, 0, 0);
                }
                else
                {
                    delta = date - DateTime.Now;
                }

                return delta;
            }

            return new TimeSpan(1,0,0,0);
        }

        #endregion
    }

    public static class AutoInvoke
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
