using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackOnStage : MonoBehaviour {

    public AudioClip audioClip;

    private TrackOnStage() { }
    public static TrackOnStage Instance { get; private set; }

    // For Play:
    // TrackOnStage.Instance.PlayTrack(TrackOnStage.Instance.audioClip);

    private void Awake()
    {
        PlayTrack(audioClip);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayTrack(AudioClip track)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.Play();
    }
}
