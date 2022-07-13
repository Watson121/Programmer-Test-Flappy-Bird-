using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sound Manager manages which sound should be played and when
/// </summary>
public class SoundManager : MonoBehaviour
{

    [Header("Player Sounds")]
    public AudioClip PlayerJump;
    public AudioClip PlayerCrash;
    public AudioClip PlayerPointUp;

    // Audio Source
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Playing Player Jump Sound
    public void PlayPlayerJump()
    {
        audioSource.PlayOneShot(PlayerJump);
    }

    // Playing Player Crash Sound
    public void PlayPlayerCrash()
    {
        audioSource.PlayOneShot(PlayerCrash);
    }

    // Playing Player Point Up Sound
    public void PlayPlayerPointUp()
    {
        audioSource.PlayOneShot(PlayerPointUp);
    }

}
