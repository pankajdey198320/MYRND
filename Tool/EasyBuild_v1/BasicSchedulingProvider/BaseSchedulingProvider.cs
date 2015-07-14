namespace BasicSchedulingProvider
{
    using System.Collections.Generic;
    using Infrastructure.Configuration;
    using Infrastructure.Interface;

    public class BaseSchedulingProvider : ISchedulingProvider
    {
        public IEnumerable<TaskScheduleEntry> GetTaskSchedules(IConfigurationResolver<TaskScheduleEntry> schedule)
        {
            return schedule.GetConfiguration();
        }
    }
    
}
