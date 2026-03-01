using Doinject;
using Domain.Interfaces;
using Domain.UseCase;
using Presentation;
using UnityEngine;

namespace Installer
{
    public class GameInstaller : MonoBehaviour, IBindingInstaller
    {
        [SerializeField] private PlayerMasterData playerMasterData;
        [SerializeField] private DamageDealerEvent damageDealerEvent;
        [SerializeField] private PlayerHealthVariable playerHealthVariable;

        public void Install(DIContainer container, IContextArg contextArg)
        {
            container.Bind<Domain.Player>().Args(playerMasterData.Value).AsSingleton();
            container.BindSingleton<DamageCalculationUseCase>();
            
            container.BindFromInstance<IDamageDealer>(damageDealerEvent);
            container.BindFromInstance<IHealthPresenter>(playerHealthVariable);
        }
    }
}