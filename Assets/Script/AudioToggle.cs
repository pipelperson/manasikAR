using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    public AudioSource audioSource;

    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private Image iconImage;

    private bool isMuted = false;

    void Start()
    {
        iconImage = GetComponent<Image>();
        UpdateIcon();
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }

        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (isMuted)
        {
            iconImage.sprite = soundOffSprite;
        }
        else
        {
            iconImage.sprite = soundOnSprite;
        }
    }
}