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
        public string ComSkipProgram
        {
            get { return textBoxComSkipProg.Text; }
            set { textBoxComSkipProg.Text = value; }
        }

        public string ComSkipParameters
        {
            get { return textBoxComSkipParameters.Text; }
            set { textBoxComSkipParameters.Text = value; }
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

            TvSpaceSaver.ComSkipProgram = ComSkipProgram;
            TvSpaceSaver.ComSkipParameters = ComSkipParameters;

            TvSpaceSaver.ProcessCommercials = radioButtonComIgnore.Checked;
            TvSpaceSaver.CutCommercials = radioButtonComCut.Checked;

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

            ComSkipProgram = TvSpaceSaver.ComSkipProgram;
            ComSkipParameters = TvSpaceSaver.ComSkipParameters;

            if (TvSpaceSaver.ProcessCommercials)
            {
                radioButtonComCut.Checked = TvSpaceSaver.CutCommercials;
                radioButtonComSkip.Checked = !TvSpaceSaver.CutCommercials;
            } else
            {
                radioButtonComIgnore.Checked = false;
            }

            if (dataGridViewRecordings.DataSource == null)
            {
                dataGridViewRecordings.AutoGenerateColumns = false;
                dataGridViewRecordings.ColumnCount = 3;
                
                dataGridViewRecordings.Columns[0].Name = "ID";
                dataGridViewRecordings.Columns[0].DataPropertyName = "IdRecording";
                dataGridViewRecordings.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewRecordings.Columns[1].Name = "Title";
                dataGridViewRecordings.Columns[1].DataPropertyName = "Title";
                dataGridViewRecordings.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewRecordings.Columns[2].Name = "Description";
                dataGridViewRecordings.Columns[2].DataPropertyName = "Description";
                dataGridViewRecordings.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                BindingSource bindingSourceRecordings = new BindingSource();
                bindingSourceRecordings.DataSource = Recording.ListAll();
                dataGridViewRecordings.DataSource = bindingSourceRecordings;
            }

            base.OnSectionActivated();
        }

        #endregion SetupTv.SectionSettings

        private void buttonCompressProg_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select Compression Program To Execute";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                textBoxCompressProg.Text = openFileDialog.FileName;
        }

        private void buttonComSkipProg_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select Location of ComSkip.exe";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                textBoxComSkipProg.Text = openFileDialog.FileName;
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

        private void radioButtonComIgnore_CheckedChanged(object sender, EventArgs e)
        {
            textBoxComSkipProg.Enabled = !radioButtonComIgnore.Checked;
            textBoxComSkipParameters.Enabled = !radioButtonComIgnore.Checked;
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewRecordings.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    Recording rec = (Recording)dataGridViewRecordings.SelectedRows[i].DataBoundItem;
                    TvSpaceSaver.ProcessRecording(rec.FileName);
                }
            }
        }
    }
}
