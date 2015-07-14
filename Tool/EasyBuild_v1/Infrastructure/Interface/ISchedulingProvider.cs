namespace Infrastructure.Interface
{
    using System.Collections.Generic;
    using Infrastructure.Configuration;

    public interface ISchedulingProvider
    {
        IEnumerable<TaskScheduleEntry> GetTaskSchedules(IConfigurationResolver<TaskScheduleEntry> schedule);

    }
}
