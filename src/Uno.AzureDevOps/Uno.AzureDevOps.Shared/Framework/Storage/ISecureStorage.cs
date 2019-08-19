﻿namespace Uno.AzureDevOps.Framework.Storage
{
	public interface ISecureStorage
	{
		bool Delete(string key);

		bool DeleteAll();

		T GetValue<T>(string key);

		bool HasKey(string key);

		bool SetValue<T>(string key, T value)
			where T : class;
	}
}
