using Order_Processing_System.Phases;

public class Program
{
	public static async Task Main(string[] args)
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		await Phase1Runner.RunAsync(cts.Token);
	}
}