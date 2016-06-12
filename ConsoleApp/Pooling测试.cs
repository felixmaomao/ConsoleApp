//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp
//{
//    //自己尝试创建pool 失败，原因在于搞不清楚 具体的实现机制
//    class Pooling测试
//    {

//    }

//    public interface IPoolingObject
//    {
//        bool Used { get; set; }
//    }

//    public class ObjectPool
//    {
//        private int _maxCount = 100;
//        private int _currentUsed = 0;
//        private Queue<IPoolingObject> PooledObjects = new Queue<IPoolingObject>();
//        public ObjectPool(IList<IPoolingObject> poolingObjects)
//        {
//            foreach(IPoolingObject poolingObject in poolingObjects)
//            {
//                PooledObjects.Enqueue(poolingObject);
//            }
//        }
//        public IPoolingObject GetOne()
//        {
//            return PooledObjects.Dequeue();
//        }
//        public void ReleaseOne(IPoolingObject poolingObject)
//        {
//            PooledObjects.Enqueue(poolingObject);
//        }       
//    }


//}
