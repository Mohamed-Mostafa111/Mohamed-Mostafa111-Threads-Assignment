using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Order_Processing_System.DataManagement
{
	public static class JsonFileStore
	{
		public static readonly SemaphoreSlim FileLock = new SemaphoreSlim(1, 1);
		public static async Task<T> ReadAsync<T>(string FilePath,CancellationToken cancellationToken)
		{
			if (!File.Exists(FilePath))
			{
				return Activator.CreateInstance<T>();
			}

			await FileLock.WaitAsync(cancellationToken);

			var FileContent= await File.ReadAllTextAsync(FilePath, cancellationToken);
			
			try 
			{
				var result = JsonSerializer.Deserialize<T>(FileContent, DataFiles.DefaultOptions);
				return result;
			}
			catch(JsonException ex)
			{
				throw new DataFileCorruptedException($"Failed to deserialize the file: {FilePath}. Error: {ex.Message}");
			}
			finally
			{
				FileLock.Release();
			}
		}

		public static async Task WriteAsync<T>(string FilePath, T data, CancellationToken cancellationToken)
		{
			await FileLock.WaitAsync(cancellationToken);

			try
			{
			  var JsonContent = JsonSerializer.Serialize(data, DataFiles.DefaultOptions);
			  var TempFile= FilePath + ".tmp";

				await File.WriteAllTextAsync(TempFile, JsonContent, cancellationToken);
				File.Move(TempFile, FilePath, true);
			}

			catch(Exception ex)
			{
				throw new Exception($"Failed to write to the file: {FilePath}. Error: {ex.Message}");
			}
			finally
			{
				FileLock.Release();
			}
		}
		/* -------------------------------------------- Sync Method ------------------------------------------*/
		public static T Read<T>(string filePath) where T : new()
		{
			if (!File.Exists(filePath))
			{
				return Activator.CreateInstance<T>();
			}

			lock (FileLock)
			{
				try
				{
					var fileContent = File.ReadAllText(filePath);
					var result = JsonSerializer.Deserialize<T>(fileContent, DataFiles.DefaultOptions);
					return result ?? Activator.CreateInstance<T>();
				}
				catch (JsonException ex)
				{
					throw new DataFileCorruptedException($"Failed to deserialize the file: {filePath}. Error: {ex.Message}");
				}
			}
		}

		public static void Write<T>(string filePath, T data)
		{
			lock (FileLock)
			{
				try
				{
					var jsonContent = JsonSerializer.Serialize(data, DataFiles.DefaultOptions);
					var tempFile = filePath + ".tmp";

					File.WriteAllText(tempFile, jsonContent);
					File.Move(tempFile, filePath, true);
				}
				catch (Exception ex)
				{
					throw new Exception($"Failed to write to the file: {filePath}. Error: {ex.Message}");
				}
			}
		}

	}

}
