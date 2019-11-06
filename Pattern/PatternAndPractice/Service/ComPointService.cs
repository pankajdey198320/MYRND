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
    public class ExecutionService : IService
    {

        IComponent<IMessageContext> _begin;


        public ExecutionService(IConfigurationService configService, IComponentFactory componentFactory,IConnectorFactory connectorFactory)
        {

            var c = configService.LoadComponentConfiguration();
            _begin = componentFactory.CreateComponent(c, connectorFactory);// c.Comp;
        }


        public void Start(Action<IMessageContext> onSuccess, Action<IMessageContext> onFailure)
        {
            try
            {
                _begin.SartComponent(new BaseMessageContext()
                {
                    Message = "pass of siberia"
                });
                ExecuteFunc(onFailure, new BaseMessageContext() { Message = "Component service started" });
            }
            catch
            {
                ExecuteFunc(onFailure, new BaseMessageContext() { Message = "Component fault" });
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        #region private methods
        private void ExecuteFunc<IMessageContext>(Action<IMessageContext> dele, IMessageContext msg)
        {
            if (dele != null)
            {
                dele(msg);
            }
        }
        #endregion
    }
    public interface IConfigurationService
    {
        ComponentConfiguration LoadComponentConfiguration();
    }

    public class JsonFileConfigurationService : IConfigurationService
    {
        public ComponentConfiguration LoadComponentConfiguration()
        {
            var componentConfiguration = JsonConvert.DeserializeObject<ComponentConfiguration>(System.IO.File.ReadAllText(@"SampleService.json"));
            return componentConfiguration;
        }
    }
}
