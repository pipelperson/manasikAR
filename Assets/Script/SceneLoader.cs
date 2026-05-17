using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

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

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadGuideScene()
    {
        SceneManager.LoadScene("GuideScene");
    }

    public void LoadQuizScene()
    {
        SceneManager.LoadScene("Quiz1Scene");
    }

    public void LoadAboutScene()
    {
        SceneManager.LoadScene("AboutScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}