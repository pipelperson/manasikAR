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
        if (scene.name == "PlayScene" || scene.name == "Quiz1Scene")
        {
            // Sembunyikan awan
            AturTampilanAwan(false);
        }
        else
        {
            // Tampilkan kembali awan di scene lainnya (MainMenu, About, Guide)
            AturTampilanAwan(true);
        }
    }

    void AturTampilanAwan(bool tampil)
    {
        foreach (Transform anakAwan in transform)
        {
            anakAwan.gameObject.SetActive(tampil);
        }
    }
}