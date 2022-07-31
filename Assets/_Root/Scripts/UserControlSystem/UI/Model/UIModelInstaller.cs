using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model

{
    internal class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _fighter;
        [SerializeField] private Sprite _healer;

        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceFighterUnitCommand>>()
            .To<ProduceFighterUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceHealerUnitCommand>>()
            .To<ProduceHealerUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
                .To<SetRallyPointCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();

            Container.Bind<float>().WithId("Fighter").FromInstance(5f);
            Container.Bind<string>().WithId("Fighter").FromInstance("Fighter");
            Container.Bind<Sprite>().WithId("Fighter").FromInstance(_fighter);

            Container.Bind<BottomCenterModel>().AsSingle();
        }

    }
}
