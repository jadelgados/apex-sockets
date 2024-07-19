namespace Launcher_001
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmdLaunchServer = new Button();
            cmdLaunchClient = new Button();
            SuspendLayout();
            // 
            // cmdLaunchServer
            // 
            cmdLaunchServer.Location = new Point(12, 30);
            cmdLaunchServer.Name = "cmdLaunchServer";
            cmdLaunchServer.Size = new Size(137, 23);
            cmdLaunchServer.TabIndex = 0;
            cmdLaunchServer.Text = "Launch Server";
            cmdLaunchServer.UseVisualStyleBackColor = true;
            cmdLaunchServer.Click += cmdLaunchServer_Click;
            // 
            // cmdLaunchClient
            // 
            cmdLaunchClient.Location = new Point(171, 30);
            cmdLaunchClient.Name = "cmdLaunchClient";
            cmdLaunchClient.Size = new Size(137, 23);
            cmdLaunchClient.TabIndex = 1;
            cmdLaunchClient.Text = "Launch Client";
            cmdLaunchClient.UseVisualStyleBackColor = true;
            cmdLaunchClient.Click += cmdLaunchClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 87);
            Controls.Add(cmdLaunchClient);
            Controls.Add(cmdLaunchServer);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "App Launcher";
            ResumeLayout(false);
        }

        #endregion

        private Button cmdLaunchServer;
        private Button cmdLaunchClient;
    }
}
