using UnityEngine;

public class ARStepController : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audioSource;

    // MARKER TERDETEKSI
    void OnEnable()
    {
        panel.SetActive(true);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // MARKER HILANG
    void OnDisable()
    {
        panel.SetActive(false);

        audioSource.Stop();
    }
}