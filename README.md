# Spotify plugin for Macro Deck 2
Control Spotify using Macro Deck 2

## Features
| Action | Description |
| --- | --- |
| Resume/Pause playback | Toggles playback |
| Skip/Previous | Skips the playback to the next/previous track |
| Volume | Sets the volume of the Spotify player |
| Shuffle | Sets random play order on or off |
| Repeat | Sets repeating mode |
| Play playlist | Starts playing a specific playlist |

## Variables
| Variable | Description | Type |
| --- | --- | --- |
| spotify_playing_title | Holds the currently playing track | String |
| spotify_playing_artists | Holds the artists of the currently playing track | String |
| spotify_playing_loop | Indicates the repeating mode of the current playback | String |
| spotify_playing_shuffle | Indicates if the playback is played randomly | Boolean |
| spotify_playing_volume | The current player volume | Number |
| spotify_playing | Indicates if the player is playing a track at the moment. (Can be bound to the button state) | Boolean |

## Helping with the translation
All translation files are located under https://github.com/Develeon64/Macro-Deck-Spotify-Plugin/tree/main/Resources/Languages
### Adding/editing a translation file
1. Fork this GitHub repository
2. Add/edit the translation files
3. Create a pull request of the forked repository
### Note
Please use the ISO names for the file name and for the __Language__ node in the file. For __LanguageCode__ use the ISO-639-1 code. You can find more information here: https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes

### This is a plugin for [Macro Deck 2](https://github.com/SuchByte/Macro-Deck), it does NOT function as a standalone app


## Third party licenses
This plugin uses some awesome 3rd party libraries:
- [SpotifyAPI-NET (MIT license)](https://github.com/JohnnyCrazy/SpotifyAPI-NET)
- [Spotify logo in the icon (Copyright Spotify AB)](https://developer.spotify.com/documentation/general/design-and-branding/#using-our-logo)