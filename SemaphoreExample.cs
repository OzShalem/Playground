namespace Practice;

public class SemaphoreExample
{
    static SemaphoreSlim _gate = new SemaphoreSlim(0, 100);
    static Mutex _mutex = new Mutex(false);
    static HttpClient _client = new HttpClient
    {
        Timeout = new TimeSpan(0, 0, 5)
    };
    
    static IEnumerable<Task> CreateCalls()
    {
        for (int i = 0; i < 100000; i++)
        {
            yield return CallGoogle();
        }
    }

    static async Task CallGoogle()
    {
        try
        {
            await _gate.WaitAsync();
            var response = await _client.GetAsync("https://www.google.com/");
            _gate.Release();
            Console.WriteLine(response.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}


public class Testing
{
    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private string _data;

    public void Upsert(string newData)
    {
        _lock.EnterUpgradeableReadLock(); // Allow read, but reserve the option to write
        try
        {
            if (_data != newData) // Check if an update is needed
            {
                _lock.EnterWriteLock(); // Upgrade to a write lock
                try
                {
                    _data = newData;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            else
            {
                // Data is up-to-date; no write needed
            }
        }
        finally
        {
            _lock.ExitUpgradeableReadLock();
        }
    }

}