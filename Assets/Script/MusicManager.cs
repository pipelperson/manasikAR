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
    public float playSceneVolume = 0.1f; // 🔉 10% volume PlayScene
    public float quizVolume = 1f;

    float targetVolume;

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
        SetVolume(menuVolume);
        ChangeMusic(menuMusic);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // =========================
        // QUIZ MODE
        // =========================
        if (FindObjectOfType<QuizBGMManager>() != null)
        {
            SetVolume(quizVolume);
            ChangeMusic(quizMusic);
            return;
        }

        // =========================
        // PLAY SCENE
        // =========================
        if (scene.name == "PlayScene")
        {
            SetVolume(playSceneVolume);
            ChangeMusic(playMusic);
        }

        // =========================
        // MENU / OTHER SCENES
        // =========================
        else
        {
            SetVolume(menuVolume);
            ChangeMusic(menuMusic);
        }
    }

    public void SetVolume(float volume)
    {
        targetVolume = volume;
        audioSource.volume = volume;
    }

    public void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip == newClip && audioSource.isPlaying)
            return;

        StopAllCoroutines();
        StartCoroutine(FadeMusic(newClip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        // FADE OUT
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
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