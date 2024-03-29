using System;
using System.Runtime.InteropServices;
using AOT;
using Newtonsoft.Json;
using UnityEngine;

namespace HowlerUnity
{
    /// <summary>
    /// Provides a wrapper around the Howler.js library.
    /// </summary>
    public static class Howler
    {
        /// <summary>
        /// Event that is fired when the howler.js library has been loaded and initialized.
        /// </summary>
        public static event Action OnInitialized;

        /// <summary>
        /// Returns true when the howler.js library has been loaded and initialized.
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        /// Plays an audio clip with the default options.
        /// </summary>
        /// <param name="clipName">Clip to play.</param>
        /// <param name="format">Format of the clip. This determines the file extension to look for when locating the clip.</param>
        public static void Play(string clipName, EAudioFormat format)
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return;
            }

            PlayJS(clipName, format.ToString().ToLower());
        }

        /// <summary>
        /// Plays an audio clip with the specified options.
        /// </summary>
        /// <param name="clipName">Clip to play.</param>
        /// <param name="format">Format of the clip. This determines the file extension to look for when locating the clip.</param>
        /// <param name="options">Options for play behavior.</param>
        public static void Play(string clipName, EAudioFormat format, HowlOptions options)
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return;
            }

            PlayJS(clipName, format.ToString().ToLower(), JsonConvert.SerializeObject(options));
        }

        /// <summary>
        /// Toggles the mute state of all audio clips.
        /// </summary>
        /// <param name="mute">True for muted, otherwise false.</param>
        public static void Mute(bool mute)
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return;
            }

            MuteJS(mute);
        }

        /// <summary>
        /// Sets the volume of all audio clips.
        /// </summary>
        /// <param name="volume">Volume to set. Range is 0.0 to 1.0. Any value over 1.0 will be clamped to 1.0.</param>
        public static void SetVolume(float volume)
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return;
            }

            SetVolumeJS(Mathf.Clamp01(volume));
        }

        /// <summary>
        /// Gets the global volume of all audio clips.
        /// </summary>
        /// <returns>Volume level.</returns>
        public static float GetVolume()
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return -1f;
            }

            return GetVolumeJS();
        }

        /// <summary>
        /// Stops all audio clips. This will immediately stop all audio clips, unload them from the cache and
        /// destroy them to free up memory.
        /// </summary>
        public static void StopAll()
        {
            if (!IsInitialized)
            {
                Debug.LogWarning("[Howler] has not been initialized. Check IsInitialized or listen to the OnInitialized event.");
                return;
            }

            StopAllJS();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitializeHowler()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            InitializeHowlerJS(InitializationCallback);
#endif
        }

        [DllImport("__Internal")]
        private static extern void InitializeHowlerJS(Action callback);

        [DllImport("__Internal")]
        private static extern string PlayJS(string clipName, string format, string options = null);

        [DllImport("__Internal")]
        private static extern void MuteJS(bool mute);

        [DllImport("__Internal")]
        private static extern void SetVolumeJS(float volume);

        [DllImport("__Internal")]
        private static extern float GetVolumeJS();

        [DllImport("__Internal")]
        private static extern void StopAllJS();

        [MonoPInvokeCallback(typeof(Action))]
        private static void InitializationCallback()
        {
            IsInitialized = true;
            OnInitialized?.Invoke();
        }
    }
}
