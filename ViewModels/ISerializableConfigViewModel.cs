namespace Develeon64.SpotifyPlugin.ViewModels {
	internal interface ISerializableConfigViewModel {
		protected Models.ISerializableConfiguration SerializableConfiguration { get; }

		void SetConfig ();

		bool SaveConfig ();
	}
}
