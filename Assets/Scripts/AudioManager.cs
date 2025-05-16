using UnityEngine;
using System;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.frequency = s.clip.frequency;
            s.samples = s.clip.samples;
            s.length = s.clip.length;
            Debug.Log("Estimated length: " + s.samples / s.frequency);
            s.source.loop = s.loop;
        }
    }

    public Sound Play(string name, double startTime)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            return null;
        }
        s.source.PlayScheduled(startTime);
        return s;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Pause();
    }
}
