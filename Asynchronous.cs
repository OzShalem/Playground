namespace Practice;

public class Asynchronous
{
    public void Execute()
    {
        var async1 = new Asynchronous();
        var num = async1.GetFinalBalance().Result;
        Console.WriteLine(num);
    }

    private async Task<decimal> GetNumber()
    {
        decimal number = 0;
        try
        {
            throw new Exception("Out of range");
            number = 10m;
            await Task.Delay(5000);
            return number;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return number;
    }

    public async Task<decimal> GetFinalBalance()
    {
        var finalBalance = await GetNumber();
        
        return finalBalance;
    }
    
}