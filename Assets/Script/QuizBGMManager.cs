using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizBGMManager : MonoBehaviour
{
    private static QuizBGMManager instance;

    void Awake()
    {
        
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
        if (scene.name == "Quiz1Scene" || 
            scene.name == "Quiz2Scene" || 
            scene.name == "Quiz3Scene" || 
            scene.name == "Quiz4Scene" || 
            scene.name == "Quiz5Scene")
        {
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
