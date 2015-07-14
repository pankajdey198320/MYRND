namespace TaskScheduleConfigurationResolver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    using Infrastructure.Configuration;
    using Infrastructure.Interface;
    public class TaskScheduleConfigurationResolver : IConfigurationResolver<TaskScheduleEntry>
    {
        public IEnumerable<TaskScheduleEntry> GetConfiguration()
        {
           
            XDocument xdoc1 = XDocument.Load(@"Z:\Tool\EasyBuild_v1\TaskScheduleConfigurationResolver\XML\TaskConfig.xml");
            var lstObj = (from obj in xdoc1.Element("Schedules").Elements("TaskScheduleEntry")
                          select new TaskScheduleEntry
                          {
                              Task = LoadTaskPlugin(obj.Element("Task").Attribute("assamblyPath").Value, obj.Element("Task").Attribute("module").Value),
                              Schedule = new TaskSchedule()
                              {
                                  StartDate = DateTime.ParseExact(obj.Element("TaskSchedule").Element("StartDate").Value, "yyyyMMddHHmm", null),
                                  NextIteration = DateTime.ParseExact(obj.Element("TaskSchedule").Element("NextIteration").Value, "yyyyMMddHHmm", null),
                                  Interval = Convert.ToInt64(obj.Element("TaskSchedule").Element("Interval").Value)
                              }

                          }).ToList();
            return lstObj;
        }

        private ITask LoadTaskPlugin(string path, string name)
        {
            string assembly = Path.GetFullPath(path);
            Assembly ptrAssembly = Assembly.LoadFile(assembly);
            foreach (Type item in ptrAssembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(typeof(ITask)) && item.Name == name)
                {
                    return (ITask)Activator.CreateInstance(item);
                }
            }
            throw new Exception("Invalid DLL, Interface not found!");

        }
    }
}
