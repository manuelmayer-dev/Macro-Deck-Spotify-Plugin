using System.Text.Json;

namespace Develeon64.SpotifyPlugin.Models {
	public class LibraryActionConfigModel : ISerializableConfiguration {
		public EMode Mode { get; set; } = EMode.Toggle;

		public string Serialize () {
			return JsonSerializer.Serialize(this);
		}

		public static LibraryActionConfigModel Deserialize (string config) {
			return ISerializableConfiguration.Deserialize<LibraryActionConfigModel>(config);
		}
	}
}
