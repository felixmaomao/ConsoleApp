//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Routing;
//namespace ConsoleApp
//{

//    public class MvcHandler : IHttpHandler
//    {
//        public bool IsReusable
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//        }

//        public void ProcessRequest(HttpContext context)
//        {
//            ControllerContext controllerContext = new ControllerContext {HttpContext=context};
//            IControllerFactory controllerFactory;
//            IController controller;
//            ProcessInit(out controllerFactory,out controller);
//            controller.Execute(controllerContext);
//        }
//        public void ProcessInit(out IControllerFactory controllerFactory,out IController controller)
//        {
//            controllerFactory = ControllerBuilder.Current.GetControllerFactory();
//            controller = controllerFactory.CreateController();
//        }
//    }

//    public class ControllerBuilder
//    {
//        private static ControllerBuilder _instance = new ControllerBuilder();
//        private ControllerBuilder()
//        {

//        }
//        public static ControllerBuilder Current
//        {
//            get { return _instance; }
//        }
//        public IControllerFactory GetControllerFactory()
//        {
//            return new DefaultControllerFactory();
//        }
//    }

//    public interface IControllerFactory
//    {
//        IController CreateController();
//    }
//    public class DefaultControllerFactory : IControllerFactory
//    {
//        public IController CreateController()
//        {
//            throw new NotImplementedException();
//        }
//    }


//    public interface IController
//    {
//        void Execute(ControllerContext context);
//    }
//    public abstract class ControllerBase : IController
//    {
//        public void Execute(ControllerContext context)
//        {
//            //do some other things
//            ExecuteCore(context);
//        }
//        public abstract void ExecuteCore(ControllerContext context);
//    }
//    public class Controller : ControllerBase
//    {       
//        public override void ExecuteCore(ControllerContext context)
//        {
//            throw new NotImplementedException();
//        }
//    }
//    public interface IActionInvoker
//    {
//        void InvokeAction();
//    }

//    public class ControllerContext
//    {
//        public HttpContext HttpContext { get; set; }
//    }




//}
