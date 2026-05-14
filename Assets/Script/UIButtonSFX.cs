using UnityEngine;

public class UIButtonSFX : MonoBehaviour
{
    public void Click()
    {
        SFXManager.instance.PlayClick();
    }

    public void Win()
    {
        SFXManager.instance.PlayWin();
    }

    public void Lose()
    {
        SFXManager.instance.PlayLose();
    }
}