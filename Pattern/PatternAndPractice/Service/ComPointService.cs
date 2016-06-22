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

        //TcpServerCompoint compBase;
        //IComponent<IMessageContext> _display;

        IComponent<IMessageContext> _begin;


        public ComPointService()
        {
            //_display = new DisplayComponent();
            //var displayF = new FormatatedDispayComponent();
            //compBase = new TcpServerCompoint();
            //var connector = new ForwardConnector();
            //connector.SetTarget(_display.SartComponent);

            //var c2 = new ForwardConnector();
            //c2.SetTarget(displayF.SartComponent);
            //c2.AddConditionLogic("a", "b", Component.Implementation.Common.Operator.Equal);
            //compBase.AddNextCompExecutionPoint(connector);
            //compBase.AddNextCompExecutionPoint(c2);
          //  var x = new ComPoint.ComImplementation.TimerComp.SimpleTimer();

            //IConnector c2 = new ForwardConnector();

            var c = JsonConvert.DeserializeObject<ComponentConfiguration>(System.IO.File.ReadAllText(@"C:\Projects\me\MyRND\Pattern\PatternAndPractice\ConsoleTest\SampleService.json"));
            _begin = c.Comp;
            //_begin = new StartComponent(
            //    new List<IConnector>()
            //    {
            //    new ForwardConnector(
            //        new FormatatedDispayComponent(
            //                new List<IConnector>() { new ForwardConnector(new EndComponent()) }
            //            )
            //        ),
            //     new ForwardConnector(
            //        new  DisplayComponent(
            //                new List<IConnector>() { new ForwardConnector(new EndComponent()) }
            //            )
            //        )
            //    }
            //);
            //IConnector c1 = new ForwardConnector();


            //c2.SetTarget(new EndComponent().SartComponent);
            // var displayF = new FormatatedDispayComponent(new List<IConnector>() { c2 });
            // c1.SetTarget(displayF.SartComponent);
            // _begin.AddNextCompExecutionPoint(c1);

        }
        public void Start()
        {
            _begin.SartComponent(new BaseMessageContext()
            {
                Message = "pass of siberia"
            });
        }
    }

    //public class ComponentConfiguration {
    //    public IComponent<IMessageContext> ComponentName { get; set; }
    //    public List<ConnectorConfiguration> Connectors { get; set; }

    //}

    //public class ConnectorConfiguration
    //{
    //    public IConnector Connector { get; set; }
    //    public ComponentConfiguration Component { get; set; }
    //}

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
