using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class ShuffleActionConfigModel : ISerializableConfiguration {
		public EMode Mode { get; set; } = EMode.Toggle;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static ShuffleActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<ShuffleActionConfigModel>(config);
		}
	}
}
