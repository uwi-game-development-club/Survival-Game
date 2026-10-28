using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // The [Header] attribute creates a bold section title in the Unity Inspector
    [Header("Audio Players")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    [Tooltip("Drag your .mp3 or .wav background music here")]
    public AudioClip backgroundMusic;
    
    public AudioClip testSound;
    public AudioClip coinSound;

    private void Start()
    {
        playBGMusic();
    }

    public void playBGMusic()
    {
        // Example: Play looping background music on start
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        // PlayOneShot is great for quick sound effects so they don't interrupt each other
        sfxSource.PlayOneShot(testSound);
    }
}