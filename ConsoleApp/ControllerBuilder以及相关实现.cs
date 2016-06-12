//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    class ControllerBuilder以及相关实现
//    {
//    }

//    public class ControllerBuilder
//    {
//        //controllerbuilder 需要一个单例
//        private static ControllerBuilder _instance = new ControllerBuilder();
//        private ControllerBuilder() {
//            SetControllerFactory(new DefaultControllerFactory());
//        }
//        public static ControllerBuilder Current
//        {
//            get { return _instance ?? new ControllerBuilder(); }
//        }
//        #region 这边强行把icontrollerFactory的获取与设置交给一个委托去控制，why.只是为了看起来高大上一点么
//        //private Func<IControllerFactory> _factoryThunk;

//        //public IControllerFactory GetControllerFactory()
//        //{
//        //    IControllerFactory controllerFactoryInstance = _factoryThunk();
//        //    return controllerFactoryInstance;
//        //}
//        //public void SetControllerFactory(IControllerFactory controllerFactory)
//        //{
//        //    _factoryThunk = () => controllerFactory;
//        //}
//        //public void SetControllerFactory(Type controllerFactoryType)
//        //{
//        //    _factoryThunk = () => { return (IControllerFactory)Activator.CreateInstance(controllerFactoryType)};
//        //}
//        #endregion

//        #region 正常思路编写,这样也是简单清晰的
//        private IControllerFactory _controllerFactory;

//        public IControllerFactory GetControllerFactory()
//        {
//            return _controllerFactory;
//        }
//        public void SetControllerFactory(IControllerFactory controllerFactory)
//        {
//            //do some validation
//            _controllerFactory = controllerFactory;
//        }
//        public void SerControllerFactory(Type controllerFactoryType)
//        {
//            //do some validation
//            _controllerFactory = (IControllerFactory)Activator.CreateInstance(controllerFactoryType);
//        }
//        #endregion


//    }

//    public interface IControllerFactory
//    {

//    }
//    public class DefaultControllerFactory:IControllerFactory
//    {

//    }



//}
