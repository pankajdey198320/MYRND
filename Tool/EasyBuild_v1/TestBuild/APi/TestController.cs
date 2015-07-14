using System.Web.Http;

namespace TestBuild.APi
{
    public class TestController :ApiController
    {
        public string Result() {
            return "hello world";
        }
    }
}
