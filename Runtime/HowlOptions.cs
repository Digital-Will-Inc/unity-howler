using System;

namespace HowlerUnity
{
    /// <summary>
    /// Options used to define the play behavior of an audio clip.
    /// </summary>
    [Serializable]
    public struct HowlOptions
    {
        public bool Loop;
        public bool AutoPlay;
        public float Volume;
    }
}
