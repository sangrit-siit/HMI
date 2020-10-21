namespace HMI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CurrentFlowLed = new System.Windows.Forms.Panel();
            this.CurrentFlowLabel = new System.Windows.Forms.Label();
            this.ProcessActiveLed = new System.Windows.Forms.Panel();
            this.ProcessActiveLabel = new System.Windows.Forms.Label();
            this.MainCurrentLed = new System.Windows.Forms.Panel();
            this.MainCurrentLabel = new System.Windows.Forms.Label();
            this.CollisionProtectionLed = new System.Windows.Forms.Panel();
            this.CollisionProtectionLabel = new System.Windows.Forms.Label();
            this.PowerSourceReadyLed = new System.Windows.Forms.Panel();
            this.PowerSourceReadyLabel = new System.Windows.Forms.Label();
            this.CommunicationReadyLed = new System.Windows.Forms.Panel();
            this.CommunicationReadyLabel = new System.Windows.Forms.Label();
            this.PulseSyncLed = new System.Windows.Forms.Panel();
            this.PulseSyncLabel = new System.Windows.Forms.Label();
            this.PilotArcLed = new System.Windows.Forms.Panel();
            this.PilotArcLabel = new System.Windows.Forms.Label();
            this.StickingRemediedLed = new System.Windows.Forms.Panel();
            this.StickingRemediedLabel = new System.Windows.Forms.Label();
            this.WireAvailableLed = new System.Windows.Forms.Panel();
            this.WireAvailableLabel = new System.Windows.Forms.Label();
            this.WeldingVoltageMeasureLabel = new System.Windows.Forms.Label();
            this.WeldingCurrentMeasureLabel = new System.Windows.Forms.Label();
            this.MotorCurrentMeasureLabel = new System.Windows.Forms.Label();
            this.WireSpeedMeasureLabel = new System.Windows.Forms.Label();
            this.PilotArcButton = new System.Windows.Forms.Button();
            this.ArcButton = new System.Windows.Forms.Button();
            this.PlasmaGasFlowLabel = new System.Windows.Forms.Label();
            this.ShieldGasFlowLabel = new System.Windows.Forms.Label();
            this.AnalogMeasure0 = new System.Windows.Forms.Label();
            this.AnalogMeasure1 = new System.Windows.Forms.Label();
            this.AnalogMeasure2 = new System.Windows.Forms.Label();
            this.AnalogMeasure3 = new System.Windows.Forms.Label();
            this.AnalogMeasure4 = new System.Windows.Forms.Label();
            this.AnalogMeasure5 = new System.Windows.Forms.Label();
            this.mUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CurrentFlowLed
            // 
            this.CurrentFlowLed.BackColor = System.Drawing.Color.Red;
            this.CurrentFlowLed.Location = new System.Drawing.Point(12, 12);
            this.CurrentFlowLed.Name = "CurrentFlowLed";
            this.CurrentFlowLed.Size = new System.Drawing.Size(15, 15);
            this.CurrentFlowLed.TabIndex = 0;
            // 
            // CurrentFlowLabel
            // 
            this.CurrentFlowLabel.AutoSize = true;
            this.CurrentFlowLabel.Location = new System.Drawing.Point(33, 14);
            this.CurrentFlowLabel.Name = "CurrentFlowLabel";
            this.CurrentFlowLabel.Size = new System.Drawing.Size(66, 13);
            this.CurrentFlowLabel.TabIndex = 1;
            this.CurrentFlowLabel.Text = "Current Flow";
            // 
            // ProcessActiveLed
            // 
            this.ProcessActiveLed.BackColor = System.Drawing.Color.Red;
            this.ProcessActiveLed.Location = new System.Drawing.Point(12, 33);
            this.ProcessActiveLed.Name = "ProcessActiveLed";
            this.ProcessActiveLed.Size = new System.Drawing.Size(15, 15);
            this.ProcessActiveLed.TabIndex = 1;
            // 
            // ProcessActiveLabel
            // 
            this.ProcessActiveLabel.AutoSize = true;
            this.ProcessActiveLabel.Location = new System.Drawing.Point(33, 35);
            this.ProcessActiveLabel.Name = "ProcessActiveLabel";
            this.ProcessActiveLabel.Size = new System.Drawing.Size(78, 13);
            this.ProcessActiveLabel.TabIndex = 2;
            this.ProcessActiveLabel.Text = "Process Active";
            // 
            // MainCurrentLed
            // 
            this.MainCurrentLed.BackColor = System.Drawing.Color.Red;
            this.MainCurrentLed.Location = new System.Drawing.Point(12, 54);
            this.MainCurrentLed.Name = "MainCurrentLed";
            this.MainCurrentLed.Size = new System.Drawing.Size(15, 15);
            this.MainCurrentLed.TabIndex = 2;
            // 
            // MainCurrentLabel
            // 
            this.MainCurrentLabel.AutoSize = true;
            this.MainCurrentLabel.Location = new System.Drawing.Point(33, 56);
            this.MainCurrentLabel.Name = "MainCurrentLabel";
            this.MainCurrentLabel.Size = new System.Drawing.Size(67, 13);
            this.MainCurrentLabel.TabIndex = 3;
            this.MainCurrentLabel.Text = "Main Current";
            this.MainCurrentLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CollisionProtectionLed
            // 
            this.CollisionProtectionLed.BackColor = System.Drawing.Color.Red;
            this.CollisionProtectionLed.Location = new System.Drawing.Point(12, 75);
            this.CollisionProtectionLed.Name = "CollisionProtectionLed";
            this.CollisionProtectionLed.Size = new System.Drawing.Size(15, 15);
            this.CollisionProtectionLed.TabIndex = 3;
            // 
            // CollisionProtectionLabel
            // 
            this.CollisionProtectionLabel.AutoSize = true;
            this.CollisionProtectionLabel.Location = new System.Drawing.Point(33, 77);
            this.CollisionProtectionLabel.Name = "CollisionProtectionLabel";
            this.CollisionProtectionLabel.Size = new System.Drawing.Size(96, 13);
            this.CollisionProtectionLabel.TabIndex = 4;
            this.CollisionProtectionLabel.Text = "Collision Protection";
            this.CollisionProtectionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PowerSourceReadyLed
            // 
            this.PowerSourceReadyLed.BackColor = System.Drawing.Color.Red;
            this.PowerSourceReadyLed.Location = new System.Drawing.Point(12, 96);
            this.PowerSourceReadyLed.Name = "PowerSourceReadyLed";
            this.PowerSourceReadyLed.Size = new System.Drawing.Size(15, 15);
            this.PowerSourceReadyLed.TabIndex = 4;
            // 
            // PowerSourceReadyLabel
            // 
            this.PowerSourceReadyLabel.AutoSize = true;
            this.PowerSourceReadyLabel.Location = new System.Drawing.Point(33, 98);
            this.PowerSourceReadyLabel.Name = "PowerSourceReadyLabel";
            this.PowerSourceReadyLabel.Size = new System.Drawing.Size(108, 13);
            this.PowerSourceReadyLabel.TabIndex = 5;
            this.PowerSourceReadyLabel.Text = "Power Source Ready";
            this.PowerSourceReadyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CommunicationReadyLed
            // 
            this.CommunicationReadyLed.BackColor = System.Drawing.Color.Red;
            this.CommunicationReadyLed.Location = new System.Drawing.Point(12, 117);
            this.CommunicationReadyLed.Name = "CommunicationReadyLed";
            this.CommunicationReadyLed.Size = new System.Drawing.Size(15, 15);
            this.CommunicationReadyLed.TabIndex = 5;
            // 
            // CommunicationReadyLabel
            // 
            this.CommunicationReadyLabel.AutoSize = true;
            this.CommunicationReadyLabel.Location = new System.Drawing.Point(33, 119);
            this.CommunicationReadyLabel.Name = "CommunicationReadyLabel";
            this.CommunicationReadyLabel.Size = new System.Drawing.Size(113, 13);
            this.CommunicationReadyLabel.TabIndex = 6;
            this.CommunicationReadyLabel.Text = "Communication Ready";
            this.CommunicationReadyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PulseSyncLed
            // 
            this.PulseSyncLed.BackColor = System.Drawing.Color.Red;
            this.PulseSyncLed.Location = new System.Drawing.Point(12, 138);
            this.PulseSyncLed.Name = "PulseSyncLed";
            this.PulseSyncLed.Size = new System.Drawing.Size(15, 15);
            this.PulseSyncLed.TabIndex = 6;
            // 
            // PulseSyncLabel
            // 
            this.PulseSyncLabel.AutoSize = true;
            this.PulseSyncLabel.Location = new System.Drawing.Point(33, 140);
            this.PulseSyncLabel.Name = "PulseSyncLabel";
            this.PulseSyncLabel.Size = new System.Drawing.Size(60, 13);
            this.PulseSyncLabel.TabIndex = 7;
            this.PulseSyncLabel.Text = "Pulse Sync";
            this.PulseSyncLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PilotArcLed
            // 
            this.PilotArcLed.BackColor = System.Drawing.Color.Red;
            this.PilotArcLed.Location = new System.Drawing.Point(12, 159);
            this.PilotArcLed.Name = "PilotArcLed";
            this.PilotArcLed.Size = new System.Drawing.Size(15, 15);
            this.PilotArcLed.TabIndex = 7;
            // 
            // PilotArcLabel
            // 
            this.PilotArcLabel.AutoSize = true;
            this.PilotArcLabel.Location = new System.Drawing.Point(33, 159);
            this.PilotArcLabel.Name = "PilotArcLabel";
            this.PilotArcLabel.Size = new System.Drawing.Size(46, 13);
            this.PilotArcLabel.TabIndex = 8;
            this.PilotArcLabel.Text = "Pilot Arc";
            this.PilotArcLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StickingRemediedLed
            // 
            this.StickingRemediedLed.BackColor = System.Drawing.Color.Red;
            this.StickingRemediedLed.Location = new System.Drawing.Point(12, 180);
            this.StickingRemediedLed.Name = "StickingRemediedLed";
            this.StickingRemediedLed.Size = new System.Drawing.Size(15, 15);
            this.StickingRemediedLed.TabIndex = 8;
            // 
            // StickingRemediedLabel
            // 
            this.StickingRemediedLabel.AutoSize = true;
            this.StickingRemediedLabel.Location = new System.Drawing.Point(33, 182);
            this.StickingRemediedLabel.Name = "StickingRemediedLabel";
            this.StickingRemediedLabel.Size = new System.Drawing.Size(96, 13);
            this.StickingRemediedLabel.TabIndex = 9;
            this.StickingRemediedLabel.Text = "Sticking Remedied";
            this.StickingRemediedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WireAvailableLed
            // 
            this.WireAvailableLed.BackColor = System.Drawing.Color.Red;
            this.WireAvailableLed.Location = new System.Drawing.Point(12, 201);
            this.WireAvailableLed.Name = "WireAvailableLed";
            this.WireAvailableLed.Size = new System.Drawing.Size(15, 15);
            this.WireAvailableLed.TabIndex = 9;
            // 
            // WireAvailableLabel
            // 
            this.WireAvailableLabel.AutoSize = true;
            this.WireAvailableLabel.Location = new System.Drawing.Point(33, 203);
            this.WireAvailableLabel.Name = "WireAvailableLabel";
            this.WireAvailableLabel.Size = new System.Drawing.Size(75, 13);
            this.WireAvailableLabel.TabIndex = 10;
            this.WireAvailableLabel.Text = "Wire Available";
            this.WireAvailableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WeldingVoltageMeasureLabel
            // 
            this.WeldingVoltageMeasureLabel.AutoSize = true;
            this.WeldingVoltageMeasureLabel.Location = new System.Drawing.Point(394, 14);
            this.WeldingVoltageMeasureLabel.Name = "WeldingVoltageMeasureLabel";
            this.WeldingVoltageMeasureLabel.Size = new System.Drawing.Size(129, 13);
            this.WeldingVoltageMeasureLabel.TabIndex = 11;
            this.WeldingVoltageMeasureLabel.Text = "Welding Voltage Measure";
            this.WeldingVoltageMeasureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WeldingCurrentMeasureLabel
            // 
            this.WeldingCurrentMeasureLabel.AutoSize = true;
            this.WeldingCurrentMeasureLabel.Location = new System.Drawing.Point(394, 33);
            this.WeldingCurrentMeasureLabel.Name = "WeldingCurrentMeasureLabel";
            this.WeldingCurrentMeasureLabel.Size = new System.Drawing.Size(127, 13);
            this.WeldingCurrentMeasureLabel.TabIndex = 12;
            this.WeldingCurrentMeasureLabel.Text = "Welding Current Measure";
            this.WeldingCurrentMeasureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MotorCurrentMeasureLabel
            // 
            this.MotorCurrentMeasureLabel.AutoSize = true;
            this.MotorCurrentMeasureLabel.Location = new System.Drawing.Point(394, 54);
            this.MotorCurrentMeasureLabel.Name = "MotorCurrentMeasureLabel";
            this.MotorCurrentMeasureLabel.Size = new System.Drawing.Size(115, 13);
            this.MotorCurrentMeasureLabel.TabIndex = 13;
            this.MotorCurrentMeasureLabel.Text = "Motor Current Measure";
            this.MotorCurrentMeasureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WireSpeedMeasureLabel
            // 
            this.WireSpeedMeasureLabel.AutoSize = true;
            this.WireSpeedMeasureLabel.Location = new System.Drawing.Point(394, 75);
            this.WireSpeedMeasureLabel.Name = "WireSpeedMeasureLabel";
            this.WireSpeedMeasureLabel.Size = new System.Drawing.Size(107, 13);
            this.WireSpeedMeasureLabel.TabIndex = 14;
            this.WireSpeedMeasureLabel.Text = "Wire Speed Measure";
            this.WireSpeedMeasureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PilotArcButton
            // 
            this.PilotArcButton.Location = new System.Drawing.Point(397, 213);
            this.PilotArcButton.Name = "PilotArcButton";
            this.PilotArcButton.Size = new System.Drawing.Size(75, 23);
            this.PilotArcButton.TabIndex = 15;
            this.PilotArcButton.Text = "Piloat Arc";
            this.PilotArcButton.UseVisualStyleBackColor = true;
            // 
            // ArcButton
            // 
            this.ArcButton.Location = new System.Drawing.Point(397, 242);
            this.ArcButton.Name = "ArcButton";
            this.ArcButton.Size = new System.Drawing.Size(75, 23);
            this.ArcButton.TabIndex = 16;
            this.ArcButton.Text = "Arc On/Off";
            this.ArcButton.UseVisualStyleBackColor = true;
            // 
            // PlasmaGasFlowLabel
            // 
            this.PlasmaGasFlowLabel.AutoSize = true;
            this.PlasmaGasFlowLabel.Location = new System.Drawing.Point(394, 117);
            this.PlasmaGasFlowLabel.Name = "PlasmaGasFlowLabel";
            this.PlasmaGasFlowLabel.Size = new System.Drawing.Size(88, 13);
            this.PlasmaGasFlowLabel.TabIndex = 17;
            this.PlasmaGasFlowLabel.Text = "Plasma Gas Flow";
            this.PlasmaGasFlowLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ShieldGasFlowLabel
            // 
            this.ShieldGasFlowLabel.AutoSize = true;
            this.ShieldGasFlowLabel.Location = new System.Drawing.Point(394, 138);
            this.ShieldGasFlowLabel.Name = "ShieldGasFlowLabel";
            this.ShieldGasFlowLabel.Size = new System.Drawing.Size(83, 13);
            this.ShieldGasFlowLabel.TabIndex = 18;
            this.ShieldGasFlowLabel.Text = "Shield Gas Flow";
            this.ShieldGasFlowLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AnalogMeasure0
            // 
            this.AnalogMeasure0.AutoSize = true;
            this.AnalogMeasure0.Location = new System.Drawing.Point(529, 14);
            this.AnalogMeasure0.Name = "AnalogMeasure0";
            this.AnalogMeasure0.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure0.TabIndex = 19;
            this.AnalogMeasure0.Text = "A0";
            // 
            // AnalogMeasure1
            // 
            this.AnalogMeasure1.AutoSize = true;
            this.AnalogMeasure1.Location = new System.Drawing.Point(529, 35);
            this.AnalogMeasure1.Name = "AnalogMeasure1";
            this.AnalogMeasure1.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure1.TabIndex = 20;
            this.AnalogMeasure1.Text = "A1";
            // 
            // AnalogMeasure2
            // 
            this.AnalogMeasure2.AutoSize = true;
            this.AnalogMeasure2.Location = new System.Drawing.Point(529, 54);
            this.AnalogMeasure2.Name = "AnalogMeasure2";
            this.AnalogMeasure2.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure2.TabIndex = 21;
            this.AnalogMeasure2.Text = "A2";
            // 
            // AnalogMeasure3
            // 
            this.AnalogMeasure3.AutoSize = true;
            this.AnalogMeasure3.Location = new System.Drawing.Point(529, 75);
            this.AnalogMeasure3.Name = "AnalogMeasure3";
            this.AnalogMeasure3.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure3.TabIndex = 22;
            this.AnalogMeasure3.Text = "A3";
            // 
            // AnalogMeasure4
            // 
            this.AnalogMeasure4.AutoSize = true;
            this.AnalogMeasure4.Location = new System.Drawing.Point(529, 117);
            this.AnalogMeasure4.Name = "AnalogMeasure4";
            this.AnalogMeasure4.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure4.TabIndex = 23;
            this.AnalogMeasure4.Text = "A4";
            // 
            // AnalogMeasure5
            // 
            this.AnalogMeasure5.AutoSize = true;
            this.AnalogMeasure5.Location = new System.Drawing.Point(529, 138);
            this.AnalogMeasure5.Name = "AnalogMeasure5";
            this.AnalogMeasure5.Size = new System.Drawing.Size(20, 13);
            this.AnalogMeasure5.TabIndex = 24;
            this.AnalogMeasure5.Text = "A5";
            // 
            // mUpdateTimer
            // 
            this.mUpdateTimer.Tick += new System.EventHandler(this.mUpdateTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AnalogMeasure5);
            this.Controls.Add(this.AnalogMeasure4);
            this.Controls.Add(this.AnalogMeasure3);
            this.Controls.Add(this.AnalogMeasure2);
            this.Controls.Add(this.AnalogMeasure1);
            this.Controls.Add(this.AnalogMeasure0);
            this.Controls.Add(this.ShieldGasFlowLabel);
            this.Controls.Add(this.PlasmaGasFlowLabel);
            this.Controls.Add(this.ArcButton);
            this.Controls.Add(this.PilotArcButton);
            this.Controls.Add(this.WireSpeedMeasureLabel);
            this.Controls.Add(this.MotorCurrentMeasureLabel);
            this.Controls.Add(this.WeldingCurrentMeasureLabel);
            this.Controls.Add(this.WeldingVoltageMeasureLabel);
            this.Controls.Add(this.WireAvailableLabel);
            this.Controls.Add(this.WireAvailableLed);
            this.Controls.Add(this.StickingRemediedLabel);
            this.Controls.Add(this.StickingRemediedLed);
            this.Controls.Add(this.PilotArcLabel);
            this.Controls.Add(this.PilotArcLed);
            this.Controls.Add(this.PulseSyncLabel);
            this.Controls.Add(this.PulseSyncLed);
            this.Controls.Add(this.CommunicationReadyLabel);
            this.Controls.Add(this.CommunicationReadyLed);
            this.Controls.Add(this.PowerSourceReadyLabel);
            this.Controls.Add(this.PowerSourceReadyLed);
            this.Controls.Add(this.CollisionProtectionLabel);
            this.Controls.Add(this.CollisionProtectionLed);
            this.Controls.Add(this.MainCurrentLabel);
            this.Controls.Add(this.MainCurrentLed);
            this.Controls.Add(this.ProcessActiveLabel);
            this.Controls.Add(this.ProcessActiveLed);
            this.Controls.Add(this.CurrentFlowLabel);
            this.Controls.Add(this.CurrentFlowLed);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CurrentFlowLed;
        private System.Windows.Forms.Label CurrentFlowLabel;
        private System.Windows.Forms.Panel ProcessActiveLed;
        private System.Windows.Forms.Label ProcessActiveLabel;
        private System.Windows.Forms.Panel MainCurrentLed;
        private System.Windows.Forms.Label MainCurrentLabel;
        private System.Windows.Forms.Panel CollisionProtectionLed;
        private System.Windows.Forms.Label CollisionProtectionLabel;
        private System.Windows.Forms.Panel PowerSourceReadyLed;
        private System.Windows.Forms.Label PowerSourceReadyLabel;
        private System.Windows.Forms.Panel CommunicationReadyLed;
        private System.Windows.Forms.Label CommunicationReadyLabel;
        private System.Windows.Forms.Panel PulseSyncLed;
        private System.Windows.Forms.Label PulseSyncLabel;
        private System.Windows.Forms.Panel PilotArcLed;
        private System.Windows.Forms.Label PilotArcLabel;
        private System.Windows.Forms.Panel StickingRemediedLed;
        private System.Windows.Forms.Label StickingRemediedLabel;
        private System.Windows.Forms.Panel WireAvailableLed;
        private System.Windows.Forms.Label WireAvailableLabel;
        private System.Windows.Forms.Label WeldingVoltageMeasureLabel;
        private System.Windows.Forms.Label WeldingCurrentMeasureLabel;
        private System.Windows.Forms.Label MotorCurrentMeasureLabel;
        private System.Windows.Forms.Label WireSpeedMeasureLabel;
        private System.Windows.Forms.Button PilotArcButton;
        private System.Windows.Forms.Button ArcButton;
        private System.Windows.Forms.Label PlasmaGasFlowLabel;
        private System.Windows.Forms.Label ShieldGasFlowLabel;
        private System.Windows.Forms.Label AnalogMeasure0;
        private System.Windows.Forms.Label AnalogMeasure1;
        private System.Windows.Forms.Label AnalogMeasure2;
        private System.Windows.Forms.Label AnalogMeasure3;
        private System.Windows.Forms.Label AnalogMeasure4;
        private System.Windows.Forms.Label AnalogMeasure5;
        private System.Windows.Forms.Timer mUpdateTimer;
    }
}

