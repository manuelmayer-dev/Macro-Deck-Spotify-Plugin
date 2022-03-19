using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class VolumeActionConfigModel : ISerializableConfiguration {
		public EMode Mode { get; set; } = EMode.Toggle;
		public int Value { get; set; } = 100;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static VolumeActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<VolumeActionConfigModel>(config);
		}
	}
}
