using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstWork
{
    public partial class timeDebug : Component
    {
        public event EventHandler Tick;

        public timeDebug()
        {
            InitializeComponent();
        }

        public timeDebug(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            timer.Interval = 1000;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
            
            Debug.WriteLine($"{DateTime.Now}");
        }
    }
}
