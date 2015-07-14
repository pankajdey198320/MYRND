namespace Infrastructure.Configuration
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Interface;

    public class TaskSchedule
    {
        public enum TaskScheduleStatus
        {
            Ready, Running, Cancelled, StopOnError, Executed
        }

        public class ExecutionHistoryEntry
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

        }

        public TaskSchedule()
        {
            this.StartDate = DateTime.Now;
            this.NextIteration = DateTime.Now;
            this.Status = TaskScheduleStatus.Ready;
            this.Interval = 1;
            ExecutionHistory = new List<ExecutionHistoryEntry>();
        }
        public DateTime StartDate { get; set; }
        public DateTime NextIteration { get; set; }
        public TaskScheduleStatus Status { get; set; }
        public long Interval { get; set; }
        public List<ExecutionHistoryEntry> ExecutionHistory { get; set; }
        public void AssignNextIteration()
        {
            NextIteration = NextIteration.AddMilliseconds(Interval);
        }
        public int GetIntervalActual()
        {
            int delay = 0;

            var ts = this.NextIteration.Subtract(DateTime.Now);
            if (ts.TotalMilliseconds > 0)
            {
                if (ts.TotalMilliseconds == this.Interval)
                {
                    delay = (int)this.Interval;
                }
                else
                {
                    delay = (int)ts.TotalMilliseconds;
                }

            }
            return delay;
        }
    }

    public class TaskScheduleEntry
    {
        public ITask Task { get; set; }
        public TaskSchedule Schedule { get; set; }
    }
}
