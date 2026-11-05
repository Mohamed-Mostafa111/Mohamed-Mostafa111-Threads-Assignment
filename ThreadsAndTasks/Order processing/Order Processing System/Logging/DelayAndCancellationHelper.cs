using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.Logging
{
	public static class DelayAndCancellationHelper
	{
		public async static Task DBquery(string repoName, CancellationToken cancellationToken)
		{
			Log.Info("Openning Connection...", repoName);
			await Task.Delay(200, cancellationToken);

			int QueryDelay = new Random().Next(300, 601);
			Log.Info("Executing query...", repoName);
			await Task.Delay(QueryDelay, cancellationToken);
		}

		public static async Task DBWrite(string repoName,string OperationName, CancellationToken cancellationToken)
		{
			Log.Info("Openning Connection...", repoName);
			await Task.Delay(200, cancellationToken);

			Log.Info($"Begin transaction  {OperationName}...", repoName);
			await Task.Delay(100, cancellationToken);

			Log.Info($"Executing {OperationName}...", repoName);
			await Task.Delay(400, cancellationToken);

			Log.Info($"Commiting {OperationName}...", repoName);
			await Task.Delay(200, cancellationToken);
		}
		public static async Task ApiRequesting(string repoName, string OperationName, CancellationToken cancellationToken)
		{
			Log.Info("DNS/handshake...", repoName);
			await Task.Delay(150, cancellationToken);

			Log.Info($"Sending {OperationName} request...", repoName);
			await Task.Delay(300, cancellationToken);

			int WaitForResponseDelay = new Random().Next(500, 1501);
			Log.Info($"Waiting for {OperationName} response...", repoName);
			await Task.Delay(WaitForResponseDelay, cancellationToken);
		}

		public static async Task PayReqpuesting(string repoName, CancellationToken cancellationToken)
		{
			Log.Info("Authorize...", repoName);
			await Task.Delay(800, cancellationToken);

			Log.Info($"Fraud check ...", repoName);
			await Task.Delay(500, cancellationToken);

			Log.Info($"Capture ...", repoName);
			await Task.Delay(700, cancellationToken);

		}

		public static async Task SendEmail(string repoName, CancellationToken cancellationToken)
		{
			Log.Info($"Rendering email template ...", repoName);
			await Task.Delay(200, cancellationToken);

			Log.Info("Connecting to SMTP server...", repoName);
			await Task.Delay(300, cancellationToken);

			Log.Info($"Sending email ...", repoName);
			await Task.Delay(500, cancellationToken);
		}

		// -------------------------------------------- Sync Method ------------------------------------------

		public static void DBquerySYNC(string repoName)
		{
			Log.Info("Opening connection...", repoName);
			Thread.Sleep(200);

			int queryDelay = Random.Shared.Next(300, 601);
			Log.Info("Executing query...", repoName);
			Thread.Sleep(queryDelay);
		}

		public static void DBWriteSYNC(string repoName, string operationName)
		{
			Log.Info("Opening connection...", repoName);
			Thread.Sleep(200);

			Log.Info($"Begin transaction {operationName}...", repoName);
			Thread.Sleep(100);

			Log.Info($"Executing {operationName}...", repoName);
			Thread.Sleep(400);

			Log.Info($"Committing {operationName}...", repoName);
			Thread.Sleep(200);
		}
	}
}
