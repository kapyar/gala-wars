using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Game
{
    public class AudioController : ITickable
    {
        //TODO (yk): Extract to configurable window
        private const float EffectVolume = 0.8f;
        private const float AmbientVolume = 1f;

        private enum SoundType
        {
            Background,
            Music,
            Effect
        }

        private class SoundClip
        {
            public string Id;
            public AudioSource Channel;
            public SoundType SoundType;
        }


        private const string Shoot = "test";

        private static readonly string[] PreloadedSounds = new[]
        {
            Shoot,
        };

        private readonly HashSet<AudioSource> _sceneAudioSources = new HashSet<AudioSource>();

        private readonly Stack<AudioSource> _channels = new Stack<AudioSource>(5);
        private readonly List<SoundClip> _cache = new List<SoundClip>(5);
        private readonly List<SoundClip> _playingItems = new List<SoundClip>(5);
        private AudioSource _ambient;

        private const int ChannelCount = 5;
        private readonly Dictionary<string, AudioClip> _preloadedSounds = new Dictionary<string, AudioClip>(5);

        private SignalBus _signalBus;

        public AudioController(SignalBus signalBus)
        {
            _signalBus = signalBus;

            CreateChannels();
            PreloadSounds();
        }

        private void SetBackgroundVolume(float? val)
        {
            SetSoundLevel(SoundType.Background, val.Value);
        }

        private void SetMusicVolume(float? val)
        {
            SetSoundLevel(SoundType.Music, val.Value);
        }

        private void SetEffectsVolume(float? val)
        {
            SetSoundLevel(SoundType.Effect, val.Value);
        }

        private void SetSoundLevel(SoundType type, float val)
        {
            foreach (var playingItem in _playingItems)
            {
                if (playingItem.SoundType == type)
                {
                    playingItem.Channel.volume = val;
                }
            }
        }

        private void CreateChannels()
        {
            for (var i = 0; i < ChannelCount; ++i)
            {
                var go = new GameObject($"AudioChannel({i})");
                var source = go.AddComponent<AudioSource>();

                _channels.Push(source);
            }
        }

        public void Tick()
        {
            _cache.Clear();

            foreach (var clip in _playingItems)
            {
                if (clip.SoundType == SoundType.Effect || clip.SoundType == SoundType.Music)
                {
                    continue;
                }

                if (clip.Channel == null || !clip.Channel.isPlaying)
                {
                    _cache.Add(clip);
                }
            }

            foreach (var source in _cache)
            {
                _playingItems.Remove(source);
                _channels.Push(source.Channel);
            }
        }


        private void PreloadSounds()
        {
            foreach (var sound in PreloadedSounds)
            {
                var req = Resources.LoadAsync<AudioClip>(GetClipPath(sound));
                req.completed += handler => { _preloadedSounds.Add(GetClipPath(sound), req.asset as AudioClip); };
            }
        }

        private static string GetClipPath(string sound)
        {
            return $"Sounds/{sound}";
        }

        private void LoadAmbientSound(string path)
        {
            var go = new GameObject("AmbientSound");
            var source = go.AddComponent<AudioSource>();
            source.loop = true;

            _sceneAudioSources.Add(source);

            var req = Resources.LoadAsync<AudioClip>(path);

            req.completed += handle =>
            {
                if (_sceneAudioSources.Contains(source) && handle.isDone)
                {
                    source.clip = req.asset as AudioClip;
                    source.Play();
                    source.volume = 0;
                    source.DOFade(AmbientVolume, 1.5f);

                    _playingItems.Add(new SoundClip()
                    {
                        Id = path,
                        Channel = source,
                        SoundType = SoundType.Background
                    });

                    _ambient = source;
                }
            };
        }


        private void PlaySound(string id)
        {
            AudioClip clip;

            if (_preloadedSounds.TryGetValue(GetClipPath(id), out clip))
            {
                if (_channels.Count == 0)
                {
                    Debug.LogError("No free channels");
                }
                else
                {
                    var channel = _channels.Pop();
                    channel.volume = EffectVolume;
                    channel.clip = clip;
                    channel.Play();

                    _playingItems.Add(new SoundClip
                    {
                        Id = id,
                        Channel = channel,
                        SoundType = SoundType.Effect
                    });
                }
            }
            else
            {
                Debug.LogError("Sound " + id + " is not preloaded");
            }
        }


        private void StopSound(string id)
        {
            foreach (var soundClip in _playingItems)
            {
                if (soundClip.Id == id)
                {
                    soundClip.Channel.Stop();
                }
            }
        }
    }
}