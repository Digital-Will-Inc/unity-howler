using System;
using Newtonsoft.Json;

namespace HowlerUnity
{
    /// <summary>
    /// Options used to define the play behavior of an audio clip.
    /// </summary>
    [Serializable]
    public struct HowlOptions
    {
        [JsonProperty("loop")]
        public bool Loop;
        [JsonProperty("autoplay")]
        public bool AutoPlay;
        [JsonProperty("volume")]
        public float Volume;
    }
}
