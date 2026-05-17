using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void PlayAR()
    {
        SceneLoader.instance.LoadPlayScene();
    }

    public void Guide()
    {
        SceneLoader.instance.LoadGuideScene();
    }

    public void Quiz()
    {
        SceneLoader.instance.LoadQuizScene();
    }

    public void About()
    {
        SceneLoader.instance.LoadAboutScene();
    }

    public void Setting()
    {
        SceneLoader.instance.LoadSettingScene();
    }

    // 🔙 BACK TO MAIN MENU
    public void MainMenu()
    {
        SceneLoader.instance.LoadMainMenu();
    }
}