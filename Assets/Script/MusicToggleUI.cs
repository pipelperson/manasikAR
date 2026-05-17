using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUI : MonoBehaviour
{
    public Toggle musicToggle;

    void Start()
    {
        // set status awal toggle sesuai save
        musicToggle.isOn = MusicManager.instance.IsMusicEnabled();

        // listener
        musicToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        MusicManager.instance.SetMusicEnabled(isOn);
    }
}