using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------------- Audio Source ----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("---------------- Audio Clip ----------------")]
    public AudioClip background;
    public static GameObject instance;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        if(instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this);
        }
    }

    public void PauseSFXs()
    {
        SFXSource.Pause();
    }

    public IEnumerator TransitionSongsSlow(AudioClip newSong)
    {
        for(int i = 0; i < 40; i++)
        {
            musicSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        musicSource.Stop();
        musicSource.clip = newSong;
        musicSource.Play();
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < 40; i++)
        {
            musicSource.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TransitionSongsMedium(AudioClip newSong)
    {
        for(int i = 0; i < 40; i++)
        {
            musicSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
        musicSource.Stop();
        musicSource.clip = newSong;
        musicSource.Play();
        for(int i = 0; i < 40; i++)
        {
            musicSource.volume += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator TransitionSongsFast(AudioClip newSong)
    {
        musicSource.Stop();
        yield return new WaitForSeconds(2f);
        musicSource.clip = newSong;
        musicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
