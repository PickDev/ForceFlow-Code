using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 
using System; 

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    public static AudioManager instance; 

    // The difference between Awake and Start is that Awake still runs 
    // even if the gameObject is inactive. 
    void Awake()
    {
        // For all of the given sounds, assign their properties to the ones in the Sound class. 
        // This makes it much easier to edit through code. 
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = s.group; 
            s.source.clip = s.clip; 
            s.source.volume = s.volume; 
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;   
        } 

        // Don't destroy AudioManager instances when loading new scenes. 
        // That way, sounds won't suddenly cut off and restart. 
        DontDestroyOnLoad(gameObject);
        // Prevent instance duplicates. 
        if (instance != null) {
            // Instead of deleting the current instance, simply make it inactive.
            // This is to prevent null ref exceptions when switching between scenes. 
            gameObject.SetActive(false); 
            return; 
        } else {
            instance = this; 
        }
    }

    void Start() {
        Play("Music");
    }

    // Play a sound by name. 
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name); 
        // Check if the sound exists in the sounds array. 
        if (s == null) {
            return; 
        }
        s.source.Play(); 
    }

    // Stop playing a sound by name. 
    public void StopPlaying(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name); 
        if (s == null) {
            return; 
        }
        s.source.Stop(); 
    }
}
