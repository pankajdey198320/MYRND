namespace Engine.ScheduleEngine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Configuration;
    using Infrastructure.Interface;
    public class ScheduleTaskEngine
    {
        private ISchedulingProvider _provider;
        IConfigurationResolver<TaskScheduleEntry> _schedule;
        List<TaskMonitor> _monitor;
        public ScheduleTaskEngine(ISchedulingProvider provider, IConfigurationResolver<TaskScheduleEntry> schedule)
        {
            _provider = provider;
            _schedule = schedule;
            _monitor = new List<TaskMonitor>();
        }
        public void start()
        {
            var _Tasks = _provider.GetTaskSchedules(_schedule);

            while (true)
            {
                foreach (var task in _Tasks)
                {
                    if (task.Schedule.Status == TaskSchedule.TaskScheduleStatus.Ready)
                    {
                        var monitor = new TaskMonitor()
                        {
                            Runner = task,
                            Token = new CancellationTokenSource()
                        };
                        _monitor.Add(monitor);
                        ExecuteCode(monitor);
                    }
                }
                Display();
                Thread.Sleep(100);
            }
        }

        private void ExecuteCode(TaskMonitor monitor)
        {
            monitor.Runner.Schedule.Status = TaskSchedule.TaskScheduleStatus.Running;
            int delay = monitor.Runner.Schedule.GetIntervalActual();



            var s = Task.Delay(delay).ContinueWith((x, T) =>
              {
                  var tsch = T as TaskMonitor;
                  var histEntry = new TaskSchedule.ExecutionHistoryEntry() { StartTime = DateTime.Now };
                  Console.WriteLine(string.Format(" {2}  Process executing at :{0} and Scheduled: {1} \n\n ", DateTime.Now, tsch.Runner.Schedule.NextIteration, tsch.Runner.Task.GetType().Name));
                  try
                  {
                      tsch.Runner.Task.Run();
                      x.Wait();
                  }
                  catch (Exception e)
                  {
                      Console.WriteLine("error" + e.ToString());
                      tsch.Runner.Schedule.Status = TaskSchedule.TaskScheduleStatus.StopOnError;
                  }


                  if (x.IsCompleted)
                  {
                      histEntry.EndTime = DateTime.Now;
                      tsch.Runner.Schedule.ExecutionHistory.Add(histEntry);


                      tsch.Runner.Schedule.AssignNextIteration();
                      if (tsch.Runner.Schedule.Status != TaskSchedule.TaskScheduleStatus.StopOnError)
                      {
                          ExecuteCode(tsch);
                      }
                  }

              }, monitor, monitor.Token.Token);

        }

        private void Display()
        {
            foreach (var m in _monitor)
            {
                //Console.WriteLine(string.Format("Task {0} is {1} and it executed {2} times", m.Runner.Task.GetType().Name, m.Runner.Schedule.Status.ToString(), m.Runner.Schedule.ExecutionHistory.Count));
            }
        }
    }
}
