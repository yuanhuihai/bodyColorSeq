namespace bodyColorSeq
{
    partial class bodyToTopCoatOneInfo
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
            this.listInfo = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listInfo
            // 
            this.listInfo.FormattingEnabled = true;
            this.listInfo.Location = new System.Drawing.Point(24, 15);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(335, 550);
            this.listInfo.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bodyToTopCoatOneInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 582);
            this.Controls.Add(this.listInfo);
            this.Name = "bodyToTopCoatOneInfo";
            this.Text = "前往面漆一线车身信息";
            this.Load += new System.EventHandler(this.bodyToTopCoatOneInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listInfo;
        private System.Windows.Forms.Timer timer1;
    }
}