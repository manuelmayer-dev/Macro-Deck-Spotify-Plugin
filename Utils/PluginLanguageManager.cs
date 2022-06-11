using SuchByte.MacroDeck.Language;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Develeon64.SpotifyPlugin.Utils {
	public static class PluginLanguageManager {
		public static PluginStrings PluginStrings = new PluginStrings();

		public static void Initialize () {
			LoadLanguage();
			LanguageManager.LanguageChanged += LangaugeChanged;
		}

		private static void LangaugeChanged (object sender, EventArgs e) {
			LoadLanguage();
		}

		private static void LoadLanguage () {
			try {
				using (TextReader languageReader = new StringReader(GetXmlLanguageResource(LanguageManager.GetLanguageName())))
					PluginStrings = (PluginStrings)new XmlSerializer(typeof(PluginStrings)).Deserialize(languageReader);
			}
			catch {
				PluginStrings = new PluginStrings();
			}
		}

		private static string GetXmlLanguageResource (string languageName) {
			var assembly = typeof(PluginStrings).Assembly;
			if (string.IsNullOrEmpty(languageName) || !assembly.GetManifestResourceNames().Any(nameof => nameof.EndsWith($"{languageName}.xml")))
				languageName = "English";

			using var resourceStream = assembly.GetManifestResourceStream($"Develeon64.SpotifyPlugin.Resources.Languages.{languageName}.xml");
			using var streamReader = new StreamReader(resourceStream);
			return streamReader.ReadToEnd();
		}
	}

	public class PluginStrings {
		public string __Language__ = "English";
		public string __LanguageCode__ = "en";
		public string __Author__ = "Develeon64";

		public string PluginName = "Spotify Plugin";
		public string PluginDescription = "Control your Spotify app with Macro Deck 2";
		
		public string TokenCannotBeEmpty = "Token cannot be empty";

		public string SpotifyAuthorize = "Authorize Spotify";
		public string SpotifyOkButton = "Ok";

		public string LoopActionName = "Repeat";
		public string LoopActionDescription = "Set repeating mode";
		public string LoopActionModeActivate = "Repeat playlist";
		public string LoopActionModeDeactivate = "Repeating off";
		public string LoopActionModeToggle = "Repeat track";
		public string LoopActionWorkingModeText = "Working mode";
		public string LoopActionOff = "Off";
		public string LoopActionSingle = "Single track";
		public string LoopActionContext = "Whole playlist";

		public string PauseActionName = "Toggle playing";
		public string PauseActionDescription = "Play your music, pause it or resume";
		public string PauseActionModeActivate = "Play playback";
		public string PauseActionModeDeactivate = "Pause playback";
		public string PauseActionModeToggle = "Toggle playback";
		public string PauseActionWorkingModeText = "Working mode";
		public string PauseActionPause = "Pause";
		public string PauseActionPlay = "Play";
		public string PauseActionToggle = "Toggle";

		public string PlaylistActionName = "Play playlist";
		public string PlaylistActionDescription = "Play a specific playlist";
		public string PlaylistActionPlaylist = "Playlist";
		public string PlaylistActionTrack = "Track";
		public string PlaylistActionSetPlaylist = "Set playlist to";

		public string PreviousActionName = "Previous Track";
		public string PreviousActionDescription = "Go back to the last track";

		public string ShuffleActionName = "Toggle shuffle mode";
		public string ShuffleActionDescription = "Toggle if music should be played in random order";
		public string ShuffleActionModeActivate = "Activate shuffle mode";
		public string ShuffleActionModeDeactivate = "Deactivate shuffle mode";
		public string ShuffleActionModeToggle = "Toggle shuffle mode";
		public string ShuffleActionWorkingModeText = "Working mode";
		public string ShuffleActionOff = "Off";
		public string ShuffleActionOn = "On";
		public string ShuffleActionToggle = "Toggle";

		public string SkipActionName = "Skip Track";
		public string SkipActionDescription = "Skip the current track";

		public string VolumeActionName = "Set volume";
		public string VolumeActionDescription = "Change the volume of your Spotify player";
		public string VolumeActionModeIncrease = "Increase";
		public string VolumeActionModeDecrease = "Decrease";
		public string VolumeActionModeSet = "Set to";
		public string VolumeActionWorkingModeText = "Working mode";
		public string VolumeActionDecrease = "Reduce by";
		public string VolumeActionIncrease = "Increase by";
		public string VolumeActionSet = "Set to";

		public string LibraryActionName = "Add/Remove Library";
		public string LibraryActionDescription = "Add or Remove the currently playing Track to your personal Library";
		public string LibraryActionModeActivate = "Add to Library";
		public string LibraryActionModeDeactivate = "Remove from Library";
		public string LibraryActionModeToggle = "Toggle Library";
		public string LibraryActionWorkingModeText = "Working mode";
		public string LibraryActionRemove = "Remove";
		public string LibraryActionAdd = "Add";
		public string LibraryActionToggle = "Toggle";
	}
}
