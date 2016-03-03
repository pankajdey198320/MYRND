using Component.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Interface;
using System.Timers;
using Component.MessageContext;

namespace ComPoint.ComImplementation.TimerComp
{
    public class SimpleTimer: CommunicationComponentBase
    {
        Timer _timr = new Timer();
        public SimpleTimer()
        {
            base.IsStart = true;
            double interval = 0;
            if (double.TryParse(Properties["Interval"], out interval))
            {
                _timr.Interval = interval;
            }
            _timr.Elapsed += _timr_Elapsed;
        }
        public SimpleTimer(List<IConnector> connectors) : base(connectors)
        {
            base.IsStart = true;
            double interval = 0;
            if (double.TryParse(Properties["Interval"], out interval))
            {
                _timr.Interval = interval;
            }
            _timr.Elapsed += _timr_Elapsed;
        }

        private void _timr_Elapsed(object sender, ElapsedEventArgs e)
        {
            var msgCtx = new BaseMessageContext();
            msgCtx.Message = "some Message";

            base.SartComponent(msgCtx);
        }

        public override void SartComponent(IMessageContext obj)
        {
            _timr.Start();
        }
    }
}
