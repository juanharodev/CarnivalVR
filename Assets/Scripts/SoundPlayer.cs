using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource source;
    [SerializeField] float minPitch;
    [SerializeField] float maxcPitch;


    public void PlaySound()
    {
        source.Stop();
        int i = Random.Range(0,clips.Count);
        source.pitch = Random.Range(minPitch,maxcPitch);
        source.PlayOneShot(clips[i]);
    }
}