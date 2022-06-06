
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FtpReceive
{
    public partial class clsFtpReceiver : ServiceBase
    {
        Timer _timer { get; set; }
        private int _interval= 10000;
        public clsFtpReceiver()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        { 
            SetTimer();
        }
       
        protected override void OnStop()
        {
            _timer.Dispose();
        }


        public void SetTimer()
        {
            // this is System.Threading.Timer, of course
            _timer = new Timer(UpdateFiles, null, _interval, Timeout.Infinite);
        }

        private void UpdateFiles(object state)
        {
            try
            {
                clsFileUpdater updater=new clsFileUpdater();
                updater.UpdateFiles().Wait();
            }
            finally
            {
                _timer?.Change(_interval, Timeout.Infinite);
            }
        }
    }
}
