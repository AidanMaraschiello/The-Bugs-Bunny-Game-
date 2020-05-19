using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundboard : MonoBehaviour
{
    private List<AudioSource> sounds;
    private List<string> names;

    // Start is called before the first frame update
    void Start()
    {
        sounds = new List<AudioSource>();
        names = new List<string>();
        foreach (AudioSource audioSource in GetComponents<AudioSource>())
        {
            sounds.Add(audioSource);
            names.Add(audioSource.clip.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(string name)
    {
        int i = 0;
        while (i < names.Count)
        {
            if (names[i] == name)
            {
                sounds[i].Play();
                return;
            }
            i += 1;
        }
        Debug.Log("Sound \"" + name + "\" not found");
    }

    public void Stop(string name)
    {
        int i = 0;
        while (i < names.Count)
        {
            if (names[i] == name)
            {
                sounds[i].Stop();
                return;
            }
            i += 1;
        }
        Debug.Log("Sound \"" + name + "\" not found");
    }
}
