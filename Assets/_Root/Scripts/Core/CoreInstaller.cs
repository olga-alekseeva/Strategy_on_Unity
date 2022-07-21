using System.ComponentModel;
using Zenject;
public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
      //  Container.Bind<IGameStatus>().FromInstance(_gameStatus);
    }
}