using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;

namespace Click_Wizard
{
    public partial class Application : Form
    {
        private const int WM_HOTKEY = 0x0312;
        private const int INPUT_MOUSE = 0;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint Type;
            public MOUSEINPUT MouseInput;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        private System.Threading.Timer timer;
        private bool autoClickerRunning = false;
        
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int hotkeyId = 0;

        
        public Application()
        {
            InitializeComponent();
            RegisterHotKey();
        }
        
        private void Application_Load(object sender, EventArgs e)
        {
            this.Text = "Click Wizard" + " BETA" + " - " + "Version: " + GetAppVersion();
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.Size = new Size(465, 325);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            appTitle.Text = "Click Wizard";
            appTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            appTitle.TextAlign = ContentAlignment.MiddleCenter;
            groupBox1.Text = "Time Unit Configurator";
            millisecondsText.Text = "0";
            secondsText.Text = "0";
            minutesText.Text = "0";
            
            clickerstartButton.Text = "Start (F6)";
            clickerstopButton.Text = "Stop (F6)";
            leftRadio.Text = "Left Click";
            leftRadio.Checked = true;
            middleRadio.Text = "Middle Click";
            rightRadio.Text = "Right Click";
            millisecondsLabel.Text = "Miliseconds";
            secondsLabel.Text = "Seconds";
            minutesLabel.Text = "Minutes";
            clickerStatus.Text = "Status: Inactive";
            clickerStatus.TextAlign = ContentAlignment.MiddleRight;
            cpsCounter.Text = "CPS: [ 0.00 ]";
            millisecondsText.TextChanged += TextBox_TextChanged;
            secondsText.TextChanged += TextBox_TextChanged;
            minutesText.TextChanged += TextBox_TextChanged;
            
            this.KeyPreview = true;
            this.KeyPress += Application_KeyPress;
            
        }
        
        private string GetAppVersion()
        {
            // Get the entry assembly (main executable) and then get its version
            Assembly assembly = Assembly.GetEntryAssembly();
            Version version = assembly.GetName().Version;

            // Format the version as a string without the revision component
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }
        
        private void RegisterHotKey()
        {
            // Register F6 as the global hotkey
            hotkeyId = 1; // You can choose any unique identifier
            RegisterHotKey(this.Handle, hotkeyId, 0, (uint)Keys.F6);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                // F6 key is pressed
                if (autoClickerRunning)
                {
                    StopAutoClicker();
                }
                else
                {
                    // Retrieve the values from the text boxes and radio buttons
                    int milliseconds = int.Parse(millisecondsText.Text);
                    int seconds = int.Parse(secondsText.Text);
                    int minutes = int.Parse(minutesText.Text);
                    bool leftClick = leftRadio.Checked;
                    bool middleClick = middleRadio.Checked;
                    bool rightClick = rightRadio.Checked;

                    // Validate the input values
                    if (milliseconds < 0 || seconds < 0 || minutes < 0)
                    {
                        MessageBox.Show("Time values cannot be negative.");
                        return;
                    }

                    // Calculate the total time in milliseconds
                    int totalTime = milliseconds + (seconds * 1000) + (minutes * 60000);

                    // Determine the mouse button to be clicked
                    string mouseButton = "";
                    if (leftClick)
                    {
                        mouseButton = "left";
                    }
                    else if (middleClick)
                    {
                        mouseButton = "middle";
                    }
                    else if (rightClick)
                    {
                        mouseButton = "right";
                    }

                    // Start the auto clicker
                    AutoClicker(totalTime, mouseButton);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unregister the hotkey when the form is closing
            UnregisterHotKey(this.Handle, hotkeyId);
            base.OnFormClosing(e);
        }
        
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate CPS based on the values in millisecondsText, secondsText, and minutesText
            int milliseconds = string.IsNullOrEmpty(millisecondsText.Text) ? 0 : int.Parse(millisecondsText.Text);
            int seconds = string.IsNullOrEmpty(secondsText.Text) ? 0 : int.Parse(secondsText.Text);
            int minutes = string.IsNullOrEmpty(minutesText.Text) ? 0 : int.Parse(minutesText.Text);

            double totalTimeInSeconds = milliseconds / 1000.0 + seconds + minutes * 60.0;
    
            // Calculate CPS
            double cps = totalTimeInSeconds > 0 ? 1.0 / totalTimeInSeconds : 0;

            // Display CPS in cpsCounter
            cpsCounter.Text = $"CPS: [ {cps:F2} ]";
        }
        
        private void clickerstartButton_Click(object sender, EventArgs e)
        {
            // Set the default values to 0 if the text boxes are blank
            millisecondsText.Text = string.IsNullOrEmpty(millisecondsText.Text) ? "0" : millisecondsText.Text;
            secondsText.Text = string.IsNullOrEmpty(secondsText.Text) ? "0" : secondsText.Text;
            minutesText.Text = string.IsNullOrEmpty(minutesText.Text) ? "0" : minutesText.Text;

            // Trigger CPS calculation
            TextBox_TextChanged(null, EventArgs.Empty);

            // Retrieve the values from the text boxes and radio buttons
            int milliseconds = int.Parse(millisecondsText.Text);
            int seconds = int.Parse(secondsText.Text);
            int minutes = int.Parse(minutesText.Text);
            bool leftClick = leftRadio.Checked;
            bool middleClick = middleRadio.Checked;
            bool rightClick = rightRadio.Checked;

            // Validate the input values
            if (milliseconds < 0 || seconds < 0 || minutes < 0)
            {
                MessageBox.Show("Time values cannot be negative.");
                return;
            }

            // Calculate the total time in milliseconds
            int totalTime = milliseconds + (seconds * 1000) + (minutes * 60000);

            // Determine the mouse button to be clicked
            string mouseButton = "";
            if (leftClick)
            {
                mouseButton = "left";
            }
            else if (middleClick)
            {
                mouseButton = "middle";
            }
            else if (rightClick)
            {
                mouseButton = "right";
            }

            // Start the auto clicker
            AutoClicker(totalTime, mouseButton);
        }




        private void AutoClicker(int interval, string mouseButton)
        {
            timer = new System.Threading.Timer(_ =>
            {
                // Perform the mouse click
                switch (mouseButton)
                {
                    case "left":
                        SimulateMouseClick(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP);
                        break;
                    case "middle":
                        SimulateMouseClick(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP);
                        break;
                    case "right":
                        SimulateMouseClick(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP);
                        break;
                }
            }, null, 0, interval);

            // Update the status label
            autoClickerRunning = true;
            UpdateStatusLabel();

            // Disable the Start button and Radio buttons
            clickerstartButton.Enabled = false;
            leftRadio.Enabled = false;
            middleRadio.Enabled = false;
            rightRadio.Enabled = false;
            millisecondsText.Enabled = false;
            secondsText.Enabled = false;
            minutesText.Enabled = false;
        }

        private void SimulateMouseClick(uint flags)
        {
            INPUT[] inputs = new INPUT[1];

            // Press down and then release
            inputs[0] = new INPUT
            {
                Type = INPUT_MOUSE,
                MouseInput = new MOUSEINPUT
                {
                    Flags = flags,
                    Time = 0
                }
            };

            SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
        }


        private void StopAutoClicker()
        {
            // Stop the Timer
            if (timer != null)
            {
                timer.Dispose();

                // Update the status label
                autoClickerRunning = false;
                UpdateStatusLabel();

                // Enable the Start button and Radio buttons
                clickerstartButton.Enabled = true;
                leftRadio.Enabled = true;
                middleRadio.Enabled = true;
                rightRadio.Enabled = true;
                millisecondsText.Enabled = true;
                secondsText.Enabled = true;
                minutesText.Enabled = true;
            }
        }

        private void UpdateStatusLabel()
        {
            // Update the status label based on the auto clicker state
            clickerStatus.Text = "Status: " + (autoClickerRunning ? "Active" : "Inactive");
        }

        private void clickerstopButton_Click(object sender, EventArgs e)
        {
            StopAutoClicker();
        }

        private void Application_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is F6
            if (e.KeyChar == (char)Keys.F6)
            {
                
                if (autoClickerRunning)
                {
                    StopAutoClicker();
                }
                else
                {
                    // Retrieve the values from the text boxes and radio buttons
                    int milliseconds = int.Parse(millisecondsText.Text);
                    int seconds = int.Parse(secondsText.Text);
                    int minutes = int.Parse(minutesText.Text);
                    bool leftClick = leftRadio.Checked;
                    bool middleClick = middleRadio.Checked;
                    bool rightClick = rightRadio.Checked;

                    // Validate the input values
                    if (milliseconds < 0 || seconds < 0 || minutes < 0)
                    {
                        MessageBox.Show("Time values cannot be negative.");
                        return;
                    }

                    // Calculate the total time in milliseconds
                    int totalTime = milliseconds + (seconds * 1000) + (minutes * 60000);

                    // Determine the mouse button to be clicked
                    string mouseButton = "";
                    if (leftClick)
                    {
                        mouseButton = "left";
                    }
                    else if (middleClick)
                    {
                        mouseButton = "middle";
                    }
                    else if (rightClick)
                    {
                        mouseButton = "right";
                    }

                    // Start the auto clicker
                    AutoClicker(totalTime, mouseButton);
                }
            }
        }
        
        private void Apication_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is F6
            if (e.KeyCode == Keys.F6)
            {
                if (autoClickerRunning)
                {
                    StopAutoClicker();
                }
                else
                {
                    // Retrieve the values from the text boxes and radio buttons
                    int milliseconds = int.Parse(millisecondsText.Text);
                    int seconds = int.Parse(secondsText.Text);
                    int minutes = int.Parse(minutesText.Text);
                    bool leftClick = leftRadio.Checked;
                    bool middleClick = middleRadio.Checked;
                    bool rightClick = rightRadio.Checked;

                    // Validate the input values
                    
                    if (milliseconds < 0 || seconds < 0 || minutes < 0)
                    {
                        MessageBox.Show("Time values cannot be negative.");
                        return;
                    }

                    // Calculate the total time in milliseconds
                    int totalTime = milliseconds + (seconds * 1000) + (minutes * 60000);

                    // Determine the mouse button to be clicked
                    string mouseButton = "";
                    if (leftClick)
                    {
                        mouseButton = "left";
                    }
                    else if (middleClick)
                    {
                        mouseButton = "middle";
                    }
                    else if (rightClick)
                    {
                        mouseButton = "right";
                    }

                    // Start the auto clicker
                    AutoClicker(totalTime, mouseButton);
                }
            }
        }


        ~Application()
        {
            // Ensure to dispose the timer when the form is closed
            if (timer != null)
            {
                timer.Dispose();
            }
        }
    }
}
