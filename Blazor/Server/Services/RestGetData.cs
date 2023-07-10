using System.Collections.Concurrent;

namespace Failover.Server.Services;

public class RestGetData
{
    readonly CancellationTokenSource cts = new CancellationTokenSource();
    readonly AutoResetEvent are = new AutoResetEvent(false);
    private PeriodicTimer _periodicTimer;
    ConcurrentQueue<object> _cq = new ConcurrentQueue<object>();

    public async Task StartTask(int value /*Func<int, Task> act*/)
    {
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(5000));

        while (await _periodicTimer.WaitForNextTickAsync(cts.Token) )
        {
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
            await act(value);
            are.WaitOne();
            value++;
        }
    }

    private Task act(int value)
    {
        throw new NotImplementedException();
    }

    public void NextStep()
    {
        are.Set();
    }

    public void CancelTask()
    {
        cts.Cancel();
    }

}  

