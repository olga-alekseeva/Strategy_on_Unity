using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model

{
    internal class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _secondUnitSprite;

        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
            .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();

            Container.Bind<float>().WithId("SecondUnit").FromInstance(5f);
            Container.Bind<string>().WithId("SecondUnit").FromInstance("SecondUnit");
            Container.Bind<Sprite>().WithId("SecondUnit").FromInstance(_secondUnitSprite);

            Container.Bind<BottomCenterModel>().AsSingle();
        }

    }
}
