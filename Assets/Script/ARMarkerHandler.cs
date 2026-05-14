using UnityEngine;
using Vuforia;

public class ARMarkerHandler : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audioSource;

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
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED)
        {
            // MARKER KETEMU
            panel.SetActive(true);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // MARKER HILANG
            panel.SetActive(false);

            audioSource.Stop();
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