using Ma.Executor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ma.View.Controllers
{
    public class BaseController:Controller
    {
        public BaseController()
        {
            Executor = new SqlExecutor();
        }
        public IExecutor Executor { get; set; }
    }
}