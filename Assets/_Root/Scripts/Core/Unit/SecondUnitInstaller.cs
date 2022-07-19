using Abstractions;
using Zenject;

public class SecondUnitInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IHealthValue>().FromComponentInChildren();
        Container.Bind<float>().WithId("AttackDistance").FromInstance(5f);
        Container.Bind<int>().WithId("AttackPeriod").FromInstance(1400);
    }
}
