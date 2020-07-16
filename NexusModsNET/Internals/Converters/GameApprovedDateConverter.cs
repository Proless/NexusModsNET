using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NexusModsNET.Internals.Converters
{
	internal class GameApprovedDateConverter : UnixDateTimeConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{

			base.WriteJson(writer, value, serializer);
		}
	}
}
