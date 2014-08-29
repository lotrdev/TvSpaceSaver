namespace SetupTv.Sections
{
    partial class TvSpaceSaverSetup
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
            this.groupBoxCompression = new System.Windows.Forms.GroupBox();
            this.buttonCompressProg = new System.Windows.Forms.Button();
            this.textBoxCompressParam = new System.Windows.Forms.TextBox();
            this.labelCompressParameters = new System.Windows.Forms.Label();
            this.textBoxCompressProg = new System.Windows.Forms.TextBox();
            this.labelCompressProg = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxWhenToExecute = new System.Windows.Forms.GroupBox();
            this.labelHours = new System.Windows.Forms.Label();
            this.textBoxNumHours = new System.Windows.Forms.TextBox();
            this.radioButtonRunInHours = new System.Windows.Forms.RadioButton();
            this.radioButtonImmediately = new System.Windows.Forms.RadioButton();
            this.groupBoxCompression.SuspendLayout();
            this.groupBoxWhenToExecute.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCompression
            // 
            this.groupBoxCompression.Controls.Add(this.buttonCompressProg);
            this.groupBoxCompression.Controls.Add(this.textBoxCompressParam);
            this.groupBoxCompression.Controls.Add(this.labelCompressParameters);
            this.groupBoxCompression.Controls.Add(this.textBoxCompressProg);
            this.groupBoxCompression.Controls.Add(this.labelCompressProg);
            this.groupBoxCompression.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCompression.Name = "groupBoxCompression";
            this.groupBoxCompression.Size = new System.Drawing.Size(344, 112);
            this.groupBoxCompression.TabIndex = 0;
            this.groupBoxCompression.TabStop = false;
            this.groupBoxCompression.Text = "Compression Tool";
            // 
            // buttonCompressProg
            // 
            this.buttonCompressProg.Location = new System.Drawing.Point(313, 37);
            this.buttonCompressProg.Name = "buttonCompressProg";
            this.buttonCompressProg.Size = new System.Drawing.Size(24, 20);
            this.buttonCompressProg.TabIndex = 4;
            this.buttonCompressProg.Text = "...";
            this.buttonCompressProg.UseVisualStyleBackColor = true;
            this.buttonCompressProg.Click += new System.EventHandler(this.buttonCompressProg_Click);
            // 
            // textBoxCompressParam
            // 
            this.textBoxCompressParam.Location = new System.Drawing.Point(10, 77);
            this.textBoxCompressParam.Name = "textBoxCompressParam";
            this.textBoxCompressParam.Size = new System.Drawing.Size(296, 20);
            this.textBoxCompressParam.TabIndex = 3;
            // 
            // labelCompressParameters
            // 
            this.labelCompressParameters.AutoSize = true;
            this.labelCompressParameters.Location = new System.Drawing.Point(7, 60);
            this.labelCompressParameters.Name = "labelCompressParameters";
            this.labelCompressParameters.Size = new System.Drawing.Size(63, 13);
            this.labelCompressParameters.TabIndex = 2;
            this.labelCompressParameters.Text = "Parameters:";
            // 
            // textBoxCompressProg
            // 
            this.textBoxCompressProg.Location = new System.Drawing.Point(10, 37);
            this.textBoxCompressProg.Name = "textBoxCompressProg";
            this.textBoxCompressProg.Size = new System.Drawing.Size(296, 20);
            this.textBoxCompressProg.TabIndex = 1;
            // 
            // labelCompressProg
            // 
            this.labelCompressProg.AutoSize = true;
            this.labelCompressProg.Location = new System.Drawing.Point(7, 20);
            this.labelCompressProg.Name = "labelCompressProg";
            this.labelCompressProg.Size = new System.Drawing.Size(49, 13);
            this.labelCompressProg.TabIndex = 0;
            this.labelCompressProg.Text = "Program:";
            // 
            // groupBoxWhenToExecute
            // 
            this.groupBoxWhenToExecute.Controls.Add(this.labelHours);
            this.groupBoxWhenToExecute.Controls.Add(this.textBoxNumHours);
            this.groupBoxWhenToExecute.Controls.Add(this.radioButtonRunInHours);
            this.groupBoxWhenToExecute.Controls.Add(this.radioButtonImmediately);
            this.groupBoxWhenToExecute.Location = new System.Drawing.Point(3, 122);
            this.groupBoxWhenToExecute.Name = "groupBoxWhenToExecute";
            this.groupBoxWhenToExecute.Size = new System.Drawing.Size(344, 112);
            this.groupBoxWhenToExecute.TabIndex = 1;
            this.groupBoxWhenToExecute.TabStop = false;
            this.groupBoxWhenToExecute.Text = "When to compress";
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Location = new System.Drawing.Point(108, 46);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(36, 13);
            this.labelHours.TabIndex = 3;
            this.labelHours.Text = "hours.";
            // 
            // textBoxNumHours
            // 
            this.textBoxNumHours.Location = new System.Drawing.Point(72, 44);
            this.textBoxNumHours.Name = "textBoxNumHours";
            this.textBoxNumHours.Size = new System.Drawing.Size(30, 20);
            this.textBoxNumHours.TabIndex = 2;
            this.textBoxNumHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxNumHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumHours_KeyPress);
            // 
            // radioButtonRunInHours
            // 
            this.radioButtonRunInHours.AutoSize = true;
            this.radioButtonRunInHours.Location = new System.Drawing.Point(10, 44);
            this.radioButtonRunInHours.Name = "radioButtonRunInHours";
            this.radioButtonRunInHours.Size = new System.Drawing.Size(56, 17);
            this.radioButtonRunInHours.TabIndex = 1;
            this.radioButtonRunInHours.Text = "Run in";
            this.radioButtonRunInHours.UseVisualStyleBackColor = true;
            this.radioButtonRunInHours.CheckedChanged += new System.EventHandler(this.radioButtonExecuteInHours_CheckedChanged);
            // 
            // radioButtonImmediately
            // 
            this.radioButtonImmediately.AutoSize = true;
            this.radioButtonImmediately.Location = new System.Drawing.Point(10, 20);
            this.radioButtonImmediately.Name = "radioButtonImmediately";
            this.radioButtonImmediately.Size = new System.Drawing.Size(198, 17);
            this.radioButtonImmediately.TabIndex = 0;
            this.radioButtonImmediately.Text = "Immediately After Recording Finishes";
            this.radioButtonImmediately.UseVisualStyleBackColor = true;
            // 
            // TvSpaceSaverSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxWhenToExecute);
            this.Controls.Add(this.groupBoxCompression);
            this.Name = "TvSpaceSaverSetup";
            this.Size = new System.Drawing.Size(400, 300);
            this.groupBoxCompression.ResumeLayout(false);
            this.groupBoxCompression.PerformLayout();
            this.groupBoxWhenToExecute.ResumeLayout(false);
            this.groupBoxWhenToExecute.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCompression;
        private System.Windows.Forms.Label labelCompressProg;
        private System.Windows.Forms.TextBox textBoxCompressParam;
        private System.Windows.Forms.Label labelCompressParameters;
        private System.Windows.Forms.TextBox textBoxCompressProg;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonCompressProg;
        private System.Windows.Forms.GroupBox groupBoxWhenToExecute;
        private System.Windows.Forms.RadioButton radioButtonRunInHours;
        private System.Windows.Forms.RadioButton radioButtonImmediately;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.TextBox textBoxNumHours;
    }
}
