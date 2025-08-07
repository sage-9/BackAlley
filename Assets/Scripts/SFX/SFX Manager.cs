using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SFX
{
    public class SFXManager : MonoBehaviour
    {
        public Sound[] sounds;
        public static SFXManager Instance;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        public void PlaySound(string soundName)
        {
            Sound s = Array.Find(sounds, sound => soundName == sound.name);
            s.source.Play();
        }
        
        
        
    }
    
    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;
        public bool loop;
        [HideInInspector]
        public AudioSource source;
        
    
    }
}
