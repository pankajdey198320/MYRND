using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Configuration;
using Infrastructure.Interface;

namespace Engine.ScheduleEngine
{
    class TaskMonitor
    {
        
        public CancellationTokenSource Token { get; set; }
        public TaskScheduleEntry Runner { get; set; }

        
        
    }
}
