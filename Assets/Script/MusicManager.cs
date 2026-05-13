using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip playMusic;
    public AudioClip quizMusic;

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
        // Musik pertama saat app dibuka
        ChangeMusic(menuMusic);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "PlayScene":
                ChangeMusic(playMusic);
                break;

            case "QuizScene":
                ChangeMusic(quizMusic);
                break;

            default:
                ChangeMusic(menuMusic);
                break;
        }
    }

    void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return;

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}