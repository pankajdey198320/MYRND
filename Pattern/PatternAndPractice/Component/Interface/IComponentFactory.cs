﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Interface
{
    public class ConnectorConfiguration
    {

        public string Connector { get; set; }
        public ComponentConfiguration Component { get; set; }
    }
    public class ComponentConfiguration
    {
        
        public string ComponentName { get; set; }
        public string AsmToload { get; set; }
        public List<ConnectorConfiguration> Connectors { get; set; }
    }
    public interface IComponentFactory
    {
        IComponent<IMessageContext> CreateComponent(ComponentConfiguration config, IConnectorFactory connectorFactory);
    }
    public interface IConnectorFactory
    {
        IConnector CreateConnector(ConnectorConfiguration ConnectorConfig);
    }
    public class BasicComponentFactory : IComponentFactory
    {

        
        public IComponent<IMessageContext> CreateComponent(ComponentConfiguration config, IConnectorFactory connectorFactory)
        {
            if (!string.IsNullOrEmpty(config.ComponentName))
            {

                var t = System.AppDomain.CurrentDomain.Load(config.AsmToload).GetTypes().FirstOrDefault(x => x.Name == config.ComponentName);
                if (t == null)
                {
                    return null;
                }
                // var t = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == ComponentName);
                // return c as IComponent<IMessageContext>;
                List<IConnector> xx = null;
                if (config.Connectors != null)
                {
                    xx = new List<IConnector>();
                    foreach (var c in config.Connectors)
                    {
                        xx.Add(connectorFactory.CreateConnector(c));
                    }
                }
                return Activator.CreateInstance(t, new object[] { xx }) as IComponent<IMessageContext>;
            }
            return null;
        }

       
    }

    public class BasicConnectorFactory : IConnectorFactory
    {
        public IConnector CreateConnector(ConnectorConfiguration ConnectorConfig)
        {
            if (!string.IsNullOrEmpty(ConnectorConfig.Connector))
            {
                var t = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).First(x => x.Name == ConnectorConfig.Connector);
                var instance = Activator.CreateInstance(t) as IConnector;
                instance.ComponentConfig = ConnectorConfig.Component;
                return instance;
            }
            return null;
        }
    }
}
