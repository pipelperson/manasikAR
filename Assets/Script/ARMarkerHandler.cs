using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARMarkerHandler : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;

    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Sound Button")]
    public UnityEngine.UI.Image soundButtonImage;

    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isMuted = false;

    ObserverBehaviour observerBehaviour;

    void Start()
    {
        // panel hidden saat awal
        panel.SetActive(false);

        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        UpdateButtonIcon();
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // MARKER KETEMU
        if (status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED)
        {
            panel.SetActive(true);

            // play kalau tidak muted
            if (!audioSource.isPlaying && !isMuted)
            {
                audioSource.Play();
            }
        }

        // MARKER HILANG
        else
        {
            panel.SetActive(false);

            audioSource.Stop();
        }
    }

    // BUTTON SOUND
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

        UpdateButtonIcon();
    }

    void UpdateButtonIcon()
    {
        if (isMuted)
        {
            soundButtonImage.sprite = soundOffSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOnSprite;
        }
    }

    void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}