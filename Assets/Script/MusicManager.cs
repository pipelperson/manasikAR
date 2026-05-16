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

    float baseVolume;

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
        baseVolume = audioSource.volume;

        ChangeMusic(menuMusic);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ====================================
        // QUIZ MODE
        // ====================================

        if (FindObjectOfType<QuizBGMManager>() != null)
        {
            ChangeMusic(quizMusic);
            return;
        }

        // ====================================
        // PLAY SCENE
        // ====================================

        if (scene.name == "PlayScene")
        {
            ChangeMusic(playMusic);
        }

        // ====================================
        // MENU / GUIDE / ABOUT / SPLASH
        // ====================================

        else
        {
            ChangeMusic(menuMusic);
        }
    }

    public void ChangeMusic(AudioClip newClip)
    {
        // kalau music sama & masih play
        if (audioSource.clip == newClip &&
            audioSource.isPlaying)
        {
            return;
        }

        StopAllCoroutines();

        StartCoroutine(FadeMusic(newClip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        // FADE OUT
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume =
                Mathf.Lerp(startVolume, 0, t / fadeDuration);

            yield return null;
        }

        audioSource.volume = 0;

        audioSource.Stop();

        // GANTI MUSIC
        audioSource.clip = newClip;

        audioSource.loop = true;

        audioSource.Play();

        // FADE IN
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume =
                Mathf.Lerp(0, baseVolume, t / fadeDuration);

            yield return null;
        }

        audioSource.volume = baseVolume;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}