using Utils;
using Abstractions;
using Core;

public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
{
    private readonly UnitMovementStop _unitMovementStop;

    public StopAwaiter(UnitMovementStop unitMovementStop)
    {
        _unitMovementStop = unitMovementStop;
        _unitMovementStop.OnStop += ONStop;
    }

    private void ONStop()
    {
        _unitMovementStop.OnStop -= ONStop;
        onWaitingResult(new AsyncExtensions.Void());
    }
}

