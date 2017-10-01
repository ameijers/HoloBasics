using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSounds : MonoSingleton<GlobalSounds>
{
    Dictionary<string, AudioSource> sources = new Dictionary<string, AudioSource>();

	// Use this for initialization
	void Start()
    {
        InitializeSounds();
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    private void InitializeSounds()
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();

        foreach(AudioSource audioSource in audioSources)
        {
            sources[audioSource.clip.name] = audioSource;
        }
    }

    public void Play(string name, float delay)
    {
        if (delay == 0f)
        {
            sources[name].PlayDelayed(delay);
        }
        else
        {
            sources[name].Play();
        }
    }
}
