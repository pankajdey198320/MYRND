using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComPoint.ComImplementation.Tcp;
using Component;
using Component.Implementation;
using Component.Implementation.LogicComponent;
using Component.Interface;
using Component.MessageContext;
using Newtonsoft.Json;
using ComPoint.ComImplementation.TimerComp;
namespace Service
{
    public class ComPointService : IService
    {

        IComponent<IMessageContext> _begin;


        public ComPointService()
        {
            
            var c = JsonConvert.DeserializeObject<ComponentConfiguration>(System.IO.File.ReadAllText(@"C:\Projects\me\MyRND\Pattern\PatternAndPractice\ConsoleTest\SampleService.json"));
            _begin = c.Comp;
            }
        public void Start()
        {
            _begin.SartComponent(new BaseMessageContext()
            {
                Message = "pass of siberia"
            });
        }
    }

   
    public class ComponentConfiguration
    {
        public IComponent<IMessageContext> Comp
        {
            get
            {

                if (!string.IsNullOrEmpty(ComponentName))
                {
                    var t = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == ComponentName);
                    // return c as IComponent<IMessageContext>;
                    List<IConnector> xx = null;
                    if (Connectors != null)
                    {
                        xx = new List<IConnector>();
                        foreach (var c in Connectors)
                        {
                            xx.Add(c.Comt);
                        }
                    }
                    return Activator.CreateInstance(t, new object[] { xx }) as IComponent<IMessageContext>;
                }
                return null;
            }
        }
        public string ComponentName { get; set; }
        public List<ConnectorConfiguration> Connectors { get; set; }

    }

    public class ConnectorConfiguration
    {
        public IConnector Comt
        {
            get
            {

                if (!string.IsNullOrEmpty(Connector))
                {
                    var t = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == Connector);
                    return Activator.CreateInstance(t, new object[] { Component.Comp }) as IConnector;
                }
                return null;
            }
        }
        public string Connector { get; set; }
        public ComponentConfiguration Component { get; set; }
    }
}
