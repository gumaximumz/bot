using System;
using Unity;

namespace WebApi.Unity
{
    public class UnityServiceProvider : IServiceProvider
    {
        private IUnityContainer _container;

        public IUnityContainer UnityContainer => _container;

        public UnityServiceProvider()
        {
            _container = new UnityContainer();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {

                return null;
            }
        }
    }
}
