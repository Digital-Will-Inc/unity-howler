# Howler for Unity

This package is a minimal wrapper for [howler.js](https://github.com/goldfire/howler.js) to use in Unity.
This project was created for a specific use case and is not intended to be a full wrapper for howler.js.

The goal was to provide a web-first alternative to the built-in Unity audio system to use in WebGL builds. The need for
this arose due to a game release being blocked on Facebook Instant Games due to Unity audio not being muted when
iOS users enabled silent mode.

## Installation

### Unity Package Manager

Add the package via git URL:
https://github.com/Digital-Will-Inc/unity-howler.git

### Assets

To avoid having to deal with audio encoding/decoding and passing audio files between Unity and the jslib plugin,
the audio files are expected to be stored in the `assets/audio` folder under the `WebGLTemplate` used to build.
This allows howler.js to access them directly without them being included in the Unity build.

For games using the Wortal SDK the path is `Assets/WebGLTemplates/Wortal/assets/audio`.

If you wish to store them in a different folder, you can modify the `Howler.jslib` script accordingly.

## Usage

Currently only playing sounds is supported, no spatial or other fancy stuff.

Howler.js is automatically loaded when the game starts and will fire the `Howler.OnInitialized` event when ready to use.
You can also check the `Howler.IsInitialized` property to see if it's ready.

### Playing a sound

```csharp
// The first parameter is the name of the audio file without extension.
// The second parameter is the format of the audio file which is used to determine the file extension.
// The third parameter is an optional struct that allows you to override the default settings.

// Default settings
Howler.Play("bgm", EAudioFormat.MP3);

// Custom settings
Howler.Play("sfx_campfire_crackle", EAudioFormat.WAV, new PlayOptions {
    volume = 0.5f,
    loop = true
});
```
