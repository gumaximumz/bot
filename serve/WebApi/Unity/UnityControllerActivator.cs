using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using Unity;

namespace WebApi.Unity
{
    public class UnityControllerActivator : IControllerActivator
    {
        private IUnityContainer unityContainer;

        private Dictionary<int, IUnityContainer> _controllerUnityContainer
            = new Dictionary<int, IUnityContainer>();

        private static object locker = new object();

        public UnityControllerActivator(IUnityContainer container)
        {
            unityContainer = container;
        }

        public object Create(ControllerContext context)
        {
            var childContainer = unityContainer.CreateChildContainer();
            var controller = childContainer.Resolve(context.ActionDescriptor.ControllerTypeInfo.AsType());

            lock (locker)
            {
                _controllerUnityContainer.Add(controller.GetHashCode(), childContainer);
            }

            return controller;
        }

        public void Release(ControllerContext context, object controller)
        {

            if (_controllerUnityContainer.TryGetValue(controller.GetHashCode(), out IUnityContainer unityContainer))
            {
                /*var unitOfWork = unityContainer.Resolve<IMyUnitOfWork>();

                if (unitOfWork == null) return;

                unitOfWork.Flush();

                if (unitOfWork.HasErrors)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();

                unitOfWork.DisposeSession();

                unityContainer.Dispose();*/

                lock (locker)
                {
                    _controllerUnityContainer.Remove(controller.GetHashCode());
                }
            }
        }
    }
}
