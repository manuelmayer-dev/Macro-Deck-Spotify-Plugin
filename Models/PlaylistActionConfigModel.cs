using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class PlaylistActionConfigModel : ISerializableConfiguration {
		public string Name { get; set; } = string.Empty;
		public string Uri { get; set; } = string.Empty;
		public int Track { get; set; } = 0;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static PlaylistActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<PlaylistActionConfigModel>(config);
		}
	}
}
