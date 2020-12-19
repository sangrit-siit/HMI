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
            this.mPollingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PowerSourceStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.CommunicationStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.PilotArcStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ProcessStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.WeldingVoltageGauge = new LiveCharts.WinForms.SolidGauge();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.WeldingCurrentGauge = new LiveCharts.WinForms.SolidGauge();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.PilotArcButton = new System.Windows.Forms.Button();
            this.ArcButton = new System.Windows.Forms.Button();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.ErrorNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.MotionControllerStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPollingTimer
            // 
            this.mPollingTimer.Tick += new System.EventHandler(this.mPollingTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 116);
            this.panel1.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PowerSourceStatus);
            this.panel7.Location = new System.Drawing.Point(-1, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(205, 58);
            this.panel7.TabIndex = 12;
            // 
            // PowerSourceStatus
            // 
            this.PowerSourceStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PowerSourceStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerSourceStatus.ForeColor = System.Drawing.Color.Red;
            this.PowerSourceStatus.Location = new System.Drawing.Point(0, 0);
            this.PowerSourceStatus.Name = "PowerSourceStatus";
            this.PowerSourceStatus.Size = new System.Drawing.Size(205, 58);
            this.PowerSourceStatus.TabIndex = 1;
            this.PowerSourceStatus.Text = "DISCONNECTED";
            this.PowerSourceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Source";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(223, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 116);
            this.panel2.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.CommunicationStatus);
            this.panel8.Location = new System.Drawing.Point(-1, 28);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(205, 58);
            this.panel8.TabIndex = 13;
            // 
            // CommunicationStatus
            // 
            this.CommunicationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommunicationStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommunicationStatus.ForeColor = System.Drawing.Color.Red;
            this.CommunicationStatus.Location = new System.Drawing.Point(0, 0);
            this.CommunicationStatus.Name = "CommunicationStatus";
            this.CommunicationStatus.Size = new System.Drawing.Size(205, 58);
            this.CommunicationStatus.TabIndex = 1;
            this.CommunicationStatus.Text = "DISCONNECTED";
            this.CommunicationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Communication";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(12, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(205, 116);
            this.panel4.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.PilotArcStatus);
            this.panel9.Location = new System.Drawing.Point(-1, 28);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(205, 58);
            this.panel9.TabIndex = 14;
            // 
            // PilotArcStatus
            // 
            this.PilotArcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PilotArcStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PilotArcStatus.ForeColor = System.Drawing.Color.Red;
            this.PilotArcStatus.Location = new System.Drawing.Point(0, 0);
            this.PilotArcStatus.Name = "PilotArcStatus";
            this.PilotArcStatus.Size = new System.Drawing.Size(205, 58);
            this.PilotArcStatus.TabIndex = 1;
            this.PilotArcStatus.Text = "DISCONNECTED";
            this.PilotArcStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pilot Arc";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(223, 134);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(205, 116);
            this.panel5.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.ProcessStatus);
            this.panel10.Location = new System.Drawing.Point(-1, 28);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(205, 58);
            this.panel10.TabIndex = 15;
            // 
            // ProcessStatus
            // 
            this.ProcessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessStatus.ForeColor = System.Drawing.Color.Red;
            this.ProcessStatus.Location = new System.Drawing.Point(0, 0);
            this.ProcessStatus.Name = "ProcessStatus";
            this.ProcessStatus.Size = new System.Drawing.Size(205, 58);
            this.ProcessStatus.TabIndex = 1;
            this.ProcessStatus.Text = "DISCONNECTED";
            this.ProcessStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Process";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.WeldingVoltageGauge);
            this.panel3.Location = new System.Drawing.Point(434, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 116);
            this.panel3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "V";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "Welding Voltage";
            // 
            // WeldingVoltageGauge
            // 
            this.WeldingVoltageGauge.Location = new System.Drawing.Point(-1, 15);
            this.WeldingVoltageGauge.Name = "WeldingVoltageGauge";
            this.WeldingVoltageGauge.Size = new System.Drawing.Size(197, 96);
            this.WeldingVoltageGauge.TabIndex = 3;
            this.WeldingVoltageGauge.Text = "solidGauge1";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.WeldingCurrentGauge);
            this.panel6.Location = new System.Drawing.Point(434, 134);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(205, 116);
            this.panel6.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "Welding Current";
            // 
            // WeldingCurrentGauge
            // 
            this.WeldingCurrentGauge.Location = new System.Drawing.Point(-1, 16);
            this.WeldingCurrentGauge.Name = "WeldingCurrentGauge";
            this.WeldingCurrentGauge.Size = new System.Drawing.Size(197, 95);
            this.WeldingCurrentGauge.TabIndex = 4;
            this.WeldingCurrentGauge.Text = "solidGauge1";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(12, 378);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(205, 43);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "CONNECT";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(223, 378);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(205, 43);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "RESET";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // PilotArcButton
            // 
            this.PilotArcButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PilotArcButton.Location = new System.Drawing.Point(434, 378);
            this.PilotArcButton.Name = "PilotArcButton";
            this.PilotArcButton.Size = new System.Drawing.Size(205, 43);
            this.PilotArcButton.TabIndex = 10;
            this.PilotArcButton.Text = "PILOT ARC";
            this.PilotArcButton.UseVisualStyleBackColor = true;
            this.PilotArcButton.Click += new System.EventHandler(this.PilotArcButton_Click);
            // 
            // ArcButton
            // 
            this.ArcButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArcButton.Location = new System.Drawing.Point(434, 427);
            this.ArcButton.Name = "ArcButton";
            this.ArcButton.Size = new System.Drawing.Size(205, 43);
            this.ArcButton.TabIndex = 11;
            this.ArcButton.Text = "ARC ON";
            this.ArcButton.UseVisualStyleBackColor = true;
            this.ArcButton.Click += new System.EventHandler(this.ArcButton_Click);
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigureButton.Location = new System.Drawing.Point(12, 427);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(416, 43);
            this.ConfigureButton.TabIndex = 12;
            this.ConfigureButton.Text = "CONFIGURATION";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Location = new System.Drawing.Point(12, 256);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(205, 116);
            this.panel11.TabIndex = 15;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.ErrorNumber);
            this.panel12.Location = new System.Drawing.Point(-1, 28);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(205, 58);
            this.panel12.TabIndex = 14;
            // 
            // ErrorNumber
            // 
            this.ErrorNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorNumber.ForeColor = System.Drawing.Color.Red;
            this.ErrorNumber.Location = new System.Drawing.Point(0, 0);
            this.ErrorNumber.Name = "ErrorNumber";
            this.ErrorNumber.Size = new System.Drawing.Size(205, 58);
            this.ErrorNumber.TabIndex = 1;
            this.ErrorNumber.Text = "DISCONNECTED";
            this.ErrorNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Error Number";
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.label8);
            this.panel13.Location = new System.Drawing.Point(228, 257);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(205, 116);
            this.panel13.TabIndex = 16;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.MotionControllerStatus);
            this.panel14.Location = new System.Drawing.Point(-1, 28);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(205, 58);
            this.panel14.TabIndex = 15;
            // 
            // MotionControllerStatus
            // 
            this.MotionControllerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MotionControllerStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotionControllerStatus.ForeColor = System.Drawing.Color.Red;
            this.MotionControllerStatus.Location = new System.Drawing.Point(0, 0);
            this.MotionControllerStatus.Name = "MotionControllerStatus";
            this.MotionControllerStatus.Size = new System.Drawing.Size(205, 58);
            this.MotionControllerStatus.TabIndex = 1;
            this.MotionControllerStatus.Text = "DISCONNECTED";
            this.MotionControllerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Motion Controller";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 485);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.ConfigureButton);
            this.Controls.Add(this.ArcButton);
            this.Controls.Add(this.PilotArcButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer mPollingTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PowerSourceStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button PilotArcButton;
        private System.Windows.Forms.Button ArcButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label CommunicationStatus;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label PilotArcStatus;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label ProcessStatus;
        private LiveCharts.WinForms.SolidGauge WeldingVoltageGauge;
        private LiveCharts.WinForms.SolidGauge WeldingCurrentGauge;
        private System.Windows.Forms.Button ConfigureButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label ErrorNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label MotionControllerStatus;
        private System.Windows.Forms.Label label8;
    }
}

