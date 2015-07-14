using System.Collections.Generic;
using BuildTask;
using Infrastructure.Configuration;
using Infrastructure.Interface;

namespace BasicSchedulingProvider
{
    public class BuildTaskSchedulingProvider :BaseSchedulingProvider
    {
        protected override IDictionary<ITask, TaskSchedule> GetScheduleConfiguration()
        {
            var config = new Dictionary<ITask, TaskSchedule>();
            var schedule = new TaskSchedule()
            {
                Interval = 10000
            };
            schedule.AssignNextIteration();
            config.Add(new BaseBuildTask(), schedule);
            return config;
        }
    }
}
