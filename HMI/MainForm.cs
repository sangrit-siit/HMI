using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PowerSource;

using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace HMI
{
    public partial class MainForm : Form
    {
        
        private Cebora mCebora;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TPCANHandle channel;
            TPCANBaudrate baudrate;
            TPCANType hwType;

            channel = Convert.ToByte("51", 16);
            baudrate = TPCANBaudrate.PCAN_BAUD_125K;
            hwType = TPCANType.PCAN_TYPE_ISA;

            mCebora = new Cebora(0x2, channel, baudrate, hwType);
            TPCANStatus result = mCebora.Init();

            if (result == TPCANStatus.PCAN_ERROR_OK)
                mUpdateTimer.Enabled = true;

        }

        private void Update()
        {
            #region Digital Signals
            this.CurrentFlowLed.BackColor = this.mCebora.DigitalSignals["CurrentFlow"] == 1 ? Color.Green : Color.Red;            
            this.ProcessActiveLed.BackColor = this.mCebora.DigitalSignals["ProcessActive"] == 1 ? Color.Green : Color.Red;
            this.MainCurrentLed.BackColor = this.mCebora.DigitalSignals["MainCurrent"] == 1 ? Color.Green : Color.Red;
            this.CollisionProtectionLed.BackColor = this.mCebora.DigitalSignals["CollisionProtection"] == 1 ? Color.Green : Color.Red;
            this.PowerSourceReadyLed.BackColor = this.mCebora.DigitalSignals["PowerSourceReady"] == 1 ? Color.Green : Color.Red;
            this.CommunicationReadyLed.BackColor = this.mCebora.DigitalSignals["CommunicationReady"] == 1 ? Color.Green : Color.Red;
            this.PulseSyncLed.BackColor = this.mCebora.DigitalSignals["PulseSync"] == 1 ? Color.Green : Color.Red;
            this.PilotArcLed.BackColor = this.mCebora.DigitalSignals["PilotArc"] == 1 ? Color.Green : Color.Red;
            this.StickingRemediedLed.BackColor = this.mCebora.DigitalSignals["StickingRemedied"] == 1 ? Color.Green : Color.Red;
            this.WireAvailableLed.BackColor = this.mCebora.DigitalSignals["WireAvailable"] == 1 ? Color.Green : Color.Red;
            #endregion Digital Signals

            #region Analog Signals
            this.AnalogMeasure0.Text = this.mCebora.AnalogSignals["A0"].ToString("0.#");
            this.AnalogMeasure1.Text = this.mCebora.AnalogSignals["A1"].ToString("0.#");
            this.AnalogMeasure2.Text = this.mCebora.AnalogSignals["A2"].ToString("0.#");
            this.AnalogMeasure3.Text = this.mCebora.AnalogSignals["A3"].ToString("0.#");
            this.AnalogMeasure4.Text = this.mCebora.AnalogSignals["A4"].ToString("0.#");
            this.AnalogMeasure5.Text = this.mCebora.AnalogSignals["A5"].ToString("0.#");
            #endregion Analog Signals
        }

        private void mUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.Update();
        }
    }

}
