namespace Develeon64.SpotifyPlugin.Models {
	public interface ISerializableConfiguration {
		public string Serialize ();

		protected static T Deserialize<T> (string configuration) where T : ISerializableConfiguration, new() =>
			!string.IsNullOrWhiteSpace(configuration) ? System.Text.Json.JsonSerializer.Deserialize<T>(configuration) : new T();
	}
}
