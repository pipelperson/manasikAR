using UnityEngine;
using UnityEngine.SceneManagement;

public class AwanTahanBanting : MonoBehaviour
{
    private static AwanTahanBanting instance;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += PadaSaatSceneDimuat;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= PadaSaatSceneDimuat;
    }

    void PadaSaatSceneDimuat(Scene scene, LoadSceneMode mode)
    {
        if (IsQuizScene(scene.name) || scene.name == "PlayScene")
        {
            AturTampilanAwan(false);
        }
        else
        {
            AturTampilanAwan(true);
        }
    }

    bool IsQuizScene(string sceneName)
    {
        return sceneName == "Quiz1Scene" ||
               sceneName == "Quiz2Scene" ||
               sceneName == "Quiz3Scene" ||
               sceneName == "Quiz4Scene" ||
               sceneName == "Quiz5Scene";
    }

    void AturTampilanAwan(bool tampil)
    {
        foreach (Transform anakAwan in transform)
        {
            anakAwan.gameObject.SetActive(tampil);
        }
    }
}