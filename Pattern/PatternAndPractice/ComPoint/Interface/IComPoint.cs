using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPoint
{
    interface IComPoint
    {
        void Start(Action postAction);
        bool Stop();
        void ReStart(Action postAction);
    }
}
