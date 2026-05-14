using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    public AudioSource sfxSource;

    public AudioClip clickSFX;
    public AudioClip winSFX;
    public AudioClip loseSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClick()
    {
        sfxSource.PlayOneShot(clickSFX);
    }

    public void PlayWin()
    {
        sfxSource.PlayOneShot(winSFX);
    }

    public void PlayLose()
    {
        sfxSource.PlayOneShot(loseSFX);
    }
}