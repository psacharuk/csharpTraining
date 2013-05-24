namespace s2gr2
{
    partial class FileView
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.loadPathBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(0, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(393, 257);
            this.treeView1.TabIndex = 0;
            // 
            // loadPathBtn
            // 
            this.loadPathBtn.Location = new System.Drawing.Point(3, 3);
            this.loadPathBtn.Name = "loadPathBtn";
            this.loadPathBtn.Size = new System.Drawing.Size(75, 23);
            this.loadPathBtn.TabIndex = 1;
            this.loadPathBtn.Text = "loadPath";
            this.loadPathBtn.UseVisualStyleBackColor = true;
            this.loadPathBtn.Click += new System.EventHandler(this.loadPathBtn_Click);
            // 
            // FileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadPathBtn);
            this.Controls.Add(this.treeView1);
            this.Name = "FileView";
            this.Size = new System.Drawing.Size(396, 289);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button loadPathBtn;
    }
}
