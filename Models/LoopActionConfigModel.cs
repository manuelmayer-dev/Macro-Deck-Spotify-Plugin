using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class LoopActionConfigModel : ISerializableConfiguration {
		public EMode Mode { get; set; } = EMode.Toggle;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static LoopActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<LoopActionConfigModel>(config);
		}
	}
}
