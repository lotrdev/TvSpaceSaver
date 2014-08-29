using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TvLibrary.Log;
using TvEngine;
using TvControl;
using TvDatabase;

namespace SetupTv.Sections
{
    [CLSCompliant(false)]
    public partial class TvSpaceSaverSetup : SetupTv.SectionSettings
    {
        #region Constants

        #endregion Constants

        #region Constructor

        #region Properties

        public int NumberOfHours
        {
            get { return Convert.ToInt32(textBoxNumHours.Text); }
            set { textBoxNumHours.Text = value.ToString(); }
        }

        public string CompressionProgram
        {
            get { return textBoxCompressProg.Text; }
            set { textBoxCompressProg.Text = value; }
        }

        public string CompressionParameters
        {
            get { return textBoxCompressParam.Text; }
            set { textBoxCompressParam.Text = value; }
        }

        #endregion Properties

        public TvSpaceSaverSetup()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region SetupTv.SectionSettings

        public override void OnSectionDeActivated()
        {
            Log.Info("TvSpaceSaver: Configuration deactivated");


            TvSpaceSaver.Immediately = radioButtonImmediately.Checked;
            TvSpaceSaver.RunInHours = radioButtonRunInHours.Checked;
            TvSpaceSaver.NumberOfHours = NumberOfHours;

            TvSpaceSaver.CompressionProgram = this.CompressionProgram;
            TvSpaceSaver.CompressionParameters = this.CompressionParameters;

            TvSpaceSaver.SaveSettings();

            base.OnSectionDeActivated();
        }

        public override void OnSectionActivated()
        {
            Log.Info("TvSpaceSaver: Configuration activated");

            TvSpaceSaver.LoadSettings();

            radioButtonImmediately.Checked = TvSpaceSaver.Immediately;
            radioButtonRunInHours.Checked = TvSpaceSaver.RunInHours;
            textBoxNumHours.Enabled = radioButtonRunInHours.Checked;
            NumberOfHours = TvSpaceSaver.NumberOfHours;

            CompressionProgram = TvSpaceSaver.CompressionProgram;
            CompressionParameters = TvSpaceSaver.CompressionParameters;

            base.OnSectionActivated();
        }

        #endregion SetupTv.SectionSettings

        private void buttonCompressProg_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select Compression Program To Execute";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                textBoxCompressProg.Text = openFileDialog.FileName;
        }

        private void radioButtonExecuteInHours_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNumHours.Enabled = radioButtonRunInHours.Checked;
        }

        private void textBoxNumHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
