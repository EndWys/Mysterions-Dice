using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.voulume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void Music_button()
    {
        string music = "Gamemusic";
        Sound s = Array.Find(sounds, sound => sound.name == music);
        if (s.source.isPlaying)
            s.source.Stop();
        else s.source.Play();
    }

    public void Sounds_button()
    {
        if (AudioListener.volume > 0)
            AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }

    private void Start()
    {
        Play("Gamemusic");
    }
}
