namespace Abstractions
{
    public interface IHealerUnitProductionTask:IIconHolder
    {
        public string UnitName { get; }
        public float TimeLeft { get; }
        public float ProductionTime { get; }
    }
}