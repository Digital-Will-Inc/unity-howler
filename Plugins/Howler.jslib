mergeInto(LibraryManager.library, {

    InitializeHowlerJS: function (callback) {
       var script = document.createElement("script");
       script.src = "https://cdnjs.cloudflare.com/ajax/libs/howler/2.2.3/howler.core.min.js";
       script.onload = function() {
           Module.dynCall_v(callback);
       };
       document.head.appendChild(script);
    },

    PlayJS: function (clip, format, payload) {
        if (payload) {
            payload = JSON.parse(UTF8ToString(payload));
        }

        var sound = new Howl({
            src: `assets/audio/${UTF8ToString(clip)}.${UTF8ToString(format)}`,
            autoplay: payload.autoplay || true,
            loop: payload.loop || false,
            volume: payload.volume || 1.0,
        });

        sound.play();
    },

    MuteJS: function (muted) {
        Howler.mute(muted);
    },

    SetVolumeJS: function (volume) {
        Howler.volume(volume);
    },

    GetVolumeJS: function () {
        return Howler.volume();
    }

});
