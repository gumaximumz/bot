using TradingService.Interfaces;
using TradingService.Services;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace TradingService
{
    public class UnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IClassService, ClassService>(new TransientLifetimeManager());
        }
    }
}
