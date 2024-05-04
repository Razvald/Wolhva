using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstWork
{
    public partial class MainForm : Form
    {
        private int totalRecords = 0;
        private int totalAge = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        public void UpdateStatistics()
        {
            totalRecords = flPanel.Controls.Count;
            totalAge = 0;
            foreach (PersonRecordUserControl control in flPanel.Controls)
            {
                totalAge += control.Age;
            }

            lblTotalRecords.Text = $"Всего записей: {totalRecords}";
            lblTotalAge.Text = $"Суммарный возраст: {totalAge}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonRecordUserControl personRecord = new(this);
            int nextId = GenerateUniqueId();
            personRecord.FlPanel = flPanel;
            personRecord.SetPersonData(nextId);

            flPanel.Controls.Add(personRecord);
            UpdateStatistics();
        }

        private int GenerateUniqueId()
        {
            int existingControlsCount = flPanel.Controls.Count;
            return existingControlsCount + 1;
        }
    }
}
