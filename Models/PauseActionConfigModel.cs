using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class PauseActionConfigModel : ISerializableConfiguration {
		public EMode Mode { get; set; } = EMode.Toggle;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static PauseActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<PauseActionConfigModel>(config);
		}
	}
}
