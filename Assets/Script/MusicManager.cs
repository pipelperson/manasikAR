using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Music Clips")]
    public AudioClip menuMusic;
    public AudioClip playMusic;
    public AudioClip quizMusic;

    [Header("Settings")]
    public float fadeDuration = 0.5f;

    [Header("Scene Volume Settings")]
    public float menuVolume = 1f;
    public float playSceneVolume = 0.1f;
    public float quizVolume = 1f;

    float targetVolume;
    bool musicEnabled = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // LOAD SAVE
        musicEnabled = PlayerPrefs.GetInt("music", 1) == 1;

        float savedVolume = PlayerPrefs.GetFloat("volume", menuVolume);
        SetVolume(savedVolume);

        if (musicEnabled)
        {
            ChangeMusic(menuMusic);
        }
        else
        {
            audioSource.Stop();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!musicEnabled) return;

        // QUIZ MODE
        if (FindObjectOfType<QuizBGMManager>() != null)
        {
            SetVolume(quizVolume);
            ChangeMusic(quizMusic);
            return;
        }

        // PLAY SCENE
        if (scene.name == "PlayScene")
        {
            SetVolume(playSceneVolume);
            ChangeMusic(playMusic);
        }
        else
        {
            SetVolume(menuVolume);
            ChangeMusic(menuMusic);
        }
    }

    // =========================
    // TOGGLE MUSIC
    // =========================

    public void SetMusicEnabled(bool enabled)
    {
        musicEnabled = enabled;

        PlayerPrefs.SetInt("music", enabled ? 1 : 0);
        PlayerPrefs.Save();

        if (!enabled)
        {
            audioSource.Stop(); // STOP TOTAL
        }
        else
        {
            ChangeMusic(menuMusic);
        }
    }

    public bool IsMusicEnabled()
    {
        return musicEnabled;
    }

    // =========================
    // VOLUME
    // =========================

    public void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();

        targetVolume = volume;

        if (audioSource.isPlaying && musicEnabled)
        {
            audioSource.volume = volume;
        }
    }

    public void SetVolume(float volume)
    {
        targetVolume = volume;

        if (audioSource.isPlaying && musicEnabled)
        {
            audioSource.volume = volume;
        }
    }

    // =========================
    // MUSIC SYSTEM
    // =========================

    public void ChangeMusic(AudioClip newClip)
    {
        if (!musicEnabled) return;

        if (audioSource.clip == newClip && audioSource.isPlaying)
            return;

        StopAllCoroutines();
        StartCoroutine(FadeMusic(newClip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        float startVolume = audioSource.volume;

        // FADE OUT
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();

        // CHANGE MUSIC
        audioSource.clip = newClip;
        audioSource.loop = true;
        audioSource.Play();

        // FADE IN
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, targetVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}