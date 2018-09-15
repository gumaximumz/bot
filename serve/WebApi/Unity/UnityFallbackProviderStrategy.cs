
using System;
using Unity;
using Unity.Builder;
using Unity.Builder.Strategy;

namespace WebApi.Unity
{
    public class UnityFallbackProviderStrategy : BuilderStrategy
    {
        private IUnityContainer _container;

        public UnityFallbackProviderStrategy(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Called during the chain of responsibility for a build operation. The
        /// PreBuildUp method is called when the chain is being executed in the
        /// forward direction.
        /// </summary>
        /// <param name="context">Context of the build operation.</param>
        public override void PreBuildUp(IBuilderContext context)
        {
            INamedType key = context.OriginalBuildKey;

            // Checking if the Type we are resolving is registered with the Container
            if (!_container.IsRegistered(key.Type))
            {
                // If not we first get our default IServiceProvider and then try to resolve the type with it
                // Then we save the Type in the Existing Property of IBuilderContext to tell Unity
                // that it doesnt need to resolve the Type

                var serviceProvider = _container.Resolve<IServiceProvider>(UnityFallbackProviderExtension.FALLBACK_PROVIDER_NAME);

                context.Existing = serviceProvider.GetService(key.Type);
            }

        }
    }
}
