using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizBGMManager : MonoBehaviour
{
    private static QuizBGMManager instance;

    void Awake()
    {
        // kalau sudah ada
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // keluar dari semua scene quiz
        if (!scene.name.Contains("Quiz") &&
            scene.name != "SelesaiQuiz")
        {
            // kembali ke music normal
            if (MusicManager.instance != null)
            {
                if (scene.name == "PlayScene")
                {
                    MusicManager.instance.ChangeMusic(
                        MusicManager.instance.playMusic
                    );
                }
                else
                {
                    MusicManager.instance.ChangeMusic(
                        MusicManager.instance.menuMusic
                    );
                }
            }

            Destroy(gameObject);
        }
    }
}