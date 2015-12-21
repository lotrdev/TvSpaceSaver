using System.Windows.Forms;

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
            this.groupBoxComskip = new System.Windows.Forms.GroupBox();
            this.radioButtonComIgnore = new System.Windows.Forms.RadioButton();
            this.radioButtonComCut = new System.Windows.Forms.RadioButton();
            this.radioButtonComSkip = new System.Windows.Forms.RadioButton();
            this.buttonComSkipProg = new System.Windows.Forms.Button();
            this.textBoxComSkipParameters = new System.Windows.Forms.TextBox();
            this.labelComSkipParameters = new System.Windows.Forms.Label();
            this.textBoxComSkipProg = new System.Windows.Forms.TextBox();
            this.labelComSkipPath = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageConfiguration = new System.Windows.Forms.TabPage();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.tabPageManual = new System.Windows.Forms.TabPage();
            this.dataGridViewRecordings = new System.Windows.Forms.DataGridView();
            this.groupBoxCompression.SuspendLayout();
            this.groupBoxWhenToExecute.SuspendLayout();
            this.groupBoxComskip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageConfiguration.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.tabPageManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecordings)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCompression
            // 
            this.groupBoxCompression.Controls.Add(this.buttonCompressProg);
            this.groupBoxCompression.Controls.Add(this.textBoxCompressParam);
            this.groupBoxCompression.Controls.Add(this.labelCompressParameters);
            this.groupBoxCompression.Controls.Add(this.textBoxCompressProg);
            this.groupBoxCompression.Controls.Add(this.labelCompressProg);
            this.groupBoxCompression.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCompression.Name = "groupBoxCompression";
            this.groupBoxCompression.Size = new System.Drawing.Size(344, 111);
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
            this.groupBoxWhenToExecute.Location = new System.Drawing.Point(3, 6);
            this.groupBoxWhenToExecute.Name = "groupBoxWhenToExecute";
            this.groupBoxWhenToExecute.Size = new System.Drawing.Size(344, 78);
            this.groupBoxWhenToExecute.TabIndex = 1;
            this.groupBoxWhenToExecute.TabStop = false;
            this.groupBoxWhenToExecute.Text = "Schedule";
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
            // groupBoxComskip
            // 
            this.groupBoxComskip.Controls.Add(this.radioButtonComIgnore);
            this.groupBoxComskip.Controls.Add(this.radioButtonComCut);
            this.groupBoxComskip.Controls.Add(this.radioButtonComSkip);
            this.groupBoxComskip.Controls.Add(this.buttonComSkipProg);
            this.groupBoxComskip.Controls.Add(this.textBoxComSkipParameters);
            this.groupBoxComskip.Controls.Add(this.labelComSkipParameters);
            this.groupBoxComskip.Controls.Add(this.textBoxComSkipProg);
            this.groupBoxComskip.Controls.Add(this.labelComSkipPath);
            this.groupBoxComskip.Location = new System.Drawing.Point(6, 123);
            this.groupBoxComskip.Name = "groupBoxComskip";
            this.groupBoxComskip.Size = new System.Drawing.Size(344, 181);
            this.groupBoxComskip.TabIndex = 2;
            this.groupBoxComskip.TabStop = false;
            this.groupBoxComskip.Text = "Commercial Skipping";
            // 
            // radioButtonComIgnore
            // 
            this.radioButtonComIgnore.AutoSize = true;
            this.radioButtonComIgnore.Location = new System.Drawing.Point(10, 68);
            this.radioButtonComIgnore.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.radioButtonComIgnore.Name = "radioButtonComIgnore";
            this.radioButtonComIgnore.Size = new System.Drawing.Size(158, 17);
            this.radioButtonComIgnore.TabIndex = 7;
            this.radioButtonComIgnore.TabStop = true;
            this.radioButtonComIgnore.Text = "Do not process commercials";
            this.radioButtonComIgnore.UseVisualStyleBackColor = true;
            this.radioButtonComIgnore.CheckedChanged += new System.EventHandler(this.radioButtonComIgnore_CheckedChanged);
            // 
            // radioButtonComCut
            // 
            this.radioButtonComCut.AutoSize = true;
            this.radioButtonComCut.Location = new System.Drawing.Point(10, 44);
            this.radioButtonComCut.Name = "radioButtonComCut";
            this.radioButtonComCut.Size = new System.Drawing.Size(203, 17);
            this.radioButtonComCut.TabIndex = 6;
            this.radioButtonComCut.TabStop = true;
            this.radioButtonComCut.Text = "Cut commercials out of final output file";
            this.radioButtonComCut.UseVisualStyleBackColor = true;
            // 
            // radioButtonComSkip
            // 
            this.radioButtonComSkip.AutoSize = true;
            this.radioButtonComSkip.Location = new System.Drawing.Point(10, 20);
            this.radioButtonComSkip.Name = "radioButtonComSkip";
            this.radioButtonComSkip.Size = new System.Drawing.Size(211, 17);
            this.radioButtonComSkip.TabIndex = 5;
            this.radioButtonComSkip.TabStop = true;
            this.radioButtonComSkip.Text = "Create chapter markers for commercials";
            this.radioButtonComSkip.UseVisualStyleBackColor = true;
            // 
            // buttonComSkipProg
            // 
            this.buttonComSkipProg.Location = new System.Drawing.Point(313, 107);
            this.buttonComSkipProg.Name = "buttonComSkipProg";
            this.buttonComSkipProg.Size = new System.Drawing.Size(24, 20);
            this.buttonComSkipProg.TabIndex = 4;
            this.buttonComSkipProg.Text = "...";
            this.buttonComSkipProg.UseVisualStyleBackColor = true;
            this.buttonComSkipProg.Click += new System.EventHandler(this.buttonComSkipProg_Click);
            // 
            // textBoxComSkipParameters
            // 
            this.textBoxComSkipParameters.Location = new System.Drawing.Point(10, 147);
            this.textBoxComSkipParameters.Name = "textBoxComSkipParameters";
            this.textBoxComSkipParameters.Size = new System.Drawing.Size(296, 20);
            this.textBoxComSkipParameters.TabIndex = 3;
            // 
            // labelComSkipParameters
            // 
            this.labelComSkipParameters.AutoSize = true;
            this.labelComSkipParameters.Location = new System.Drawing.Point(7, 130);
            this.labelComSkipParameters.Name = "labelComSkipParameters";
            this.labelComSkipParameters.Size = new System.Drawing.Size(128, 13);
            this.labelComSkipParameters.TabIndex = 2;
            this.labelComSkipParameters.Text = "ComSkip.exe Parameters:";
            // 
            // textBoxComSkipProg
            // 
            this.textBoxComSkipProg.Location = new System.Drawing.Point(10, 107);
            this.textBoxComSkipProg.Name = "textBoxComSkipProg";
            this.textBoxComSkipProg.Size = new System.Drawing.Size(296, 20);
            this.textBoxComSkipProg.TabIndex = 1;
            // 
            // labelComSkipPath
            // 
            this.labelComSkipPath.AutoSize = true;
            this.labelComSkipPath.Location = new System.Drawing.Point(7, 90);
            this.labelComSkipPath.Name = "labelComSkipPath";
            this.labelComSkipPath.Size = new System.Drawing.Size(97, 13);
            this.labelComSkipPath.TabIndex = 0;
            this.labelComSkipPath.Text = "ComSkip.exe Path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageConfiguration);
            this.tabControl1.Controls.Add(this.tabPageSchedule);
            this.tabControl1.Controls.Add(this.tabPageManual);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 452);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageConfiguration
            // 
            this.tabPageConfiguration.Controls.Add(this.groupBoxCompression);
            this.tabPageConfiguration.Controls.Add(this.groupBoxComskip);
            this.tabPageConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfiguration.Name = "tabPageConfiguration";
            this.tabPageConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfiguration.Size = new System.Drawing.Size(399, 426);
            this.tabPageConfiguration.TabIndex = 0;
            this.tabPageConfiguration.Text = "Configuration";
            this.tabPageConfiguration.UseVisualStyleBackColor = true;
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.groupBoxWhenToExecute);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(399, 426);
            this.tabPageSchedule.TabIndex = 1;
            this.tabPageSchedule.Text = "Schedule";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // tabPageManual
            // 
            this.tabPageManual.Controls.Add(this.dataGridViewRecordings);
            this.tabPageManual.Location = new System.Drawing.Point(4, 22);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Size = new System.Drawing.Size(399, 426);
            this.tabPageManual.TabIndex = 2;
            this.tabPageManual.Text = "Manual Control";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRecordings
            // 
            this.dataGridViewRecordings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecordings.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRecordings.Name = "dataGridViewRecordings";
            this.dataGridViewRecordings.Size = new System.Drawing.Size(393, 383);
            this.dataGridViewRecordings.TabIndex = 0;
            // 
            // TvSpaceSaverSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TvSpaceSaverSetup";
            this.Size = new System.Drawing.Size(425, 467);
            this.groupBoxCompression.ResumeLayout(false);
            this.groupBoxCompression.PerformLayout();
            this.groupBoxWhenToExecute.ResumeLayout(false);
            this.groupBoxWhenToExecute.PerformLayout();
            this.groupBoxComskip.ResumeLayout(false);
            this.groupBoxComskip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageConfiguration.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.tabPageManual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecordings)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBoxComskip;
        private System.Windows.Forms.Button buttonComSkipProg;
        private System.Windows.Forms.TextBox textBoxComSkipParameters;
        private System.Windows.Forms.Label labelComSkipParameters;
        private System.Windows.Forms.TextBox textBoxComSkipProg;
        private System.Windows.Forms.Label labelComSkipPath;
        private System.Windows.Forms.RadioButton radioButtonComIgnore;
        private System.Windows.Forms.RadioButton radioButtonComCut;
        private System.Windows.Forms.RadioButton radioButtonComSkip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConfiguration;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.TabPage tabPageManual;
        private DataGridView dataGridViewRecordings;
    }
}
