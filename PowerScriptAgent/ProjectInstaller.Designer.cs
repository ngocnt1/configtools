namespace PowerScriptAgent
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PowerScriptAgent = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // PowerScriptAgent
            // 
            this.PowerScriptAgent.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.PowerScriptAgent.Password = null;
            this.PowerScriptAgent.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "PowerScriptAgent for Powershell running";
            this.serviceInstaller1.DisplayName = "PowerScriptAgent";
            this.serviceInstaller1.ServiceName = "PowerScriptAgent";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PowerScriptAgent,
            this.serviceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PowerScriptAgent;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}