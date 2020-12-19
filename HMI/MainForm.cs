using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cebora;
using Galil;
using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace HMI
{
    public partial class MainForm : Form
    {
        
        private PowerSource mPowerSource;
        private MotionController mMotionController;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Poll()
        {
/*
            #region Digital Signals
            this.PowerSourceStatus.Text = mPowerSource.DigitalSignals["PowerSourceReady"] == 1 ? "ready".ToUpper() : "not ready".ToUpper();
            this.PowerSourceStatus.ForeColor = mPowerSource.DigitalSignals["PowerSourceReady"] == 1 ? Color.Green : Color.Red;

            this.CommunicationStatus.Text = mPowerSource.DigitalSignals["CommunicationReady"] == 1 ? "ready".ToUpper() : "not ready".ToUpper();
            this.CommunicationStatus.ForeColor = mPowerSource.DigitalSignals["CommunicationReady"] == 1 ? Color.Green : Color.Red;

            this.PilotArcStatus.Text = mPowerSource.DigitalSignals["PilotArc"] == 1 ? "started".ToUpper() : "idle".ToUpper();
            this.PilotArcStatus.ForeColor = mPowerSource.DigitalSignals["PilotArc"] == 1 ? Color.Yellow : Color.Green;

            this.ProcessStatus.Text = mPowerSource.DigitalSignals["ProcessActive"] == 1 ? "active".ToUpper() : "inactive".ToUpper();
            this.ProcessStatus.ForeColor = mPowerSource.DigitalSignals["ProcessActive"] == 1 ? Color.Red : Color.Green;

            this.ErrorNumber.Text = mPowerSource.DigitalSignals["ErrorNumber"].ToString();
            #endregion Digital Signals

            #region Analog Signals
            this.WeldingVoltageGauge.To = 100.0;
            this.WeldingVoltageGauge.Value = Convert.ToDouble(mPowerSource.AnalogSignals["A0"].ToString("0.#"));
            this.WeldingCurrentGauge.To = 1000.0;
            this.WeldingCurrentGauge.Value = Convert.ToDouble(mPowerSource.AnalogSignals["A1"].ToString("0.#"));
            #endregion Analog Signals

            this.ArcButton.Text = mPowerSource.RobotDigitalSignals["ArcOn"] == 1 ? "arc off".ToUpper() : "arc on".ToUpper();
*/
            this.MotionControllerStatus.Text = mMotionController.Connected == true ? "connected".ToUpper() : "disconnected".ToUpper();
            this.MotionControllerStatus.ForeColor = mMotionController.Connected == true ? Color.Green : Color.Red;
        }

        private void mPollingTimer_Tick(object sender, EventArgs e)
        {
            this.Poll();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
/*
            TPCANHandle channel;
            TPCANBaudrate baudrate;
            TPCANType hwType;

            channel = Convert.ToByte("51", 16);
            baudrate = TPCANBaudrate.PCAN_BAUD_125K;
            hwType = TPCANType.PCAN_TYPE_ISA;

            mPowerSource = new PowerSource(0x2, channel, baudrate, hwType);
            TPCANStatus result = mPowerSource.Init();
            if(result == TPCANStatus.PCAN_ERROR_OK)
                mPollingTimer.Enabled = true;
*/
            string ip = "192.168.0.43";

            mMotionController = new MotionController(ip);
            mMotionController.Open();
            mPollingTimer.Enabled = true;
        }

        private void PilotArcButton_Click(object sender, EventArgs e)
        {
            mPowerSource.RobotDigitalSignals["PilotArcStart"] ^= 1;
            mPowerSource.Update();
        }

        private void ArcButton_Click(object sender, EventArgs e)
        {
            mPowerSource.RobotDigitalSignals["ArcOn"] ^= 1;
            mPowerSource.RobotDigitalSignals["PilotArcStart"] = 0;
            mPowerSource.Update();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            mPowerSource.Reset();
        }

    }

}
