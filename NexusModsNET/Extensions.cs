using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NexusModsNET.DataModels;

namespace NexusModsNET
{
	internal static class Extensions
	{
		internal static Uri AddQuery(this Uri url, string paramName, string paramValue)
		{
			var uriBuilder = new UriBuilder(url);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			query[paramName] = paramValue;
			uriBuilder.Query = query.ToString();

			return uriBuilder.Uri;
		}

		internal static async Task<T> DeserializeContent<T>(this HttpContent httpContent)
		{
			using (var content = await httpContent.ReadAsStreamAsync())
			using (var reader = new StreamReader(content))
			using (var jsonReader = new JsonTextReader(reader))
			{
				var jsonSerializer = new JsonSerializer();
				return jsonSerializer.Deserialize<T>(jsonReader);
			}
		}

		internal static string GetCategoryName(this NexusModFileCategory category)
		{
			switch (category)
			{
				case NexusModFileCategory.Main:
					return "main";
				case NexusModFileCategory.Update:
					return "update";
				case NexusModFileCategory.Optional:
					return "optional";
				case NexusModFileCategory.Old:
					return "old_version";
				case NexusModFileCategory.Miscellaneous:
					return "miscellaneous";
				case NexusModFileCategory.Deleted:
				case NexusModFileCategory.None:
				default:
					return "";
			}
		}

		internal static string GetTimePeriod(this NexusTimePeriod timePeriod)
		{
			switch (timePeriod)
			{
				case NexusTimePeriod.Day:
					return "1d";
				case NexusTimePeriod.Week:
					return "1w";
				case NexusTimePeriod.Month:
				default:
					return "1m";
			}
		}
	}
}
