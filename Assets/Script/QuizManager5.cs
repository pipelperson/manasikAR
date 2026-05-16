using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager5 : MonoBehaviour
{
    [Header("Button Pilihan")]
    public GameObject btnTahallul2;
    public GameObject btnSai;
    public GameObject btnMabit;

    [Header("Button Salah")]
    public GameObject btnSalah1;
    public GameObject btnSalah2;

    [Header("UI Setelah Jawab")]
    public GameObject btnJawaban;
    public GameObject panelPenjelasan;
    public GameObject btnLanjut;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip bubblePopSound;

    private bool sudahMenjawab = false;

    // =========================
    // JAWABAN BENAR
    // =========================
    public void JawabanBenar()
    {
        if (sudahMenjawab) return;

        sudahMenjawab = true;

        // bunyi benar
        audioSource.PlayOneShot(correctSound);

        // hide pilihan
        SembunyikanPilihan();

        // tampil jawaban benar
        btnJawaban.SetActive(true);

        // tampil tombol lanjut
        btnLanjut.SetActive(true);
    }

    // =========================
    // SALAH TAHALLUL2
    // =========================
    public void JawabanSalah1()
    {
        if (sudahMenjawab) return;

        sudahMenjawab = true;

        // tampil tombol merah
        btnSalah1.SetActive(true);

        // bunyi salah
        audioSource.PlayOneShot(wrongSound);

        // jeda bentar
        Invoke("TampilkanJawaban", 0.5f);
    }

    // =========================
    // SALAH MABIT
    // =========================
    public void JawabanSalah2()
    {
        if (sudahMenjawab) return;

        sudahMenjawab = true;

        // tampil tombol merah
        btnSalah2.SetActive(true);

        // bunyi salah
        audioSource.PlayOneShot(wrongSound);

        // jeda bentar
        Invoke("TampilkanJawaban", 0.5f);
    }

    // =========================
    // TAMPILKAN JAWABAN
    // =========================
    void TampilkanJawaban()
    {
        // hide pilihan
        btnTahallul2.SetActive(false);
        btnSai.SetActive(false);
        btnMabit.SetActive(false);

        // hide tombol merah
        btnSalah1.SetActive(false);
        btnSalah2.SetActive(false);

        // tampil jawaban benar
        btnJawaban.SetActive(true);

        // tampil panel penjelasan
        panelPenjelasan.SetActive(true);

        // tampil tombol lanjut
        btnLanjut.SetActive(true);
    }

    // =========================
    // HIDE PILIHAN
    // =========================
    void SembunyikanPilihan()
    {
        btnTahallul2.SetActive(false);
        btnSai.SetActive(false);
        btnMabit.SetActive(false);
    }

    // =========================
    // PINDAH SELESAI QUIZ
    // =========================
    
    public void PindahKeSelesaiQuiz()
    {
        if (audioSource != null && bubblePopSound != null)
        {
            audioSource.PlayOneShot(bubblePopSound);
        }

        Invoke("LoadSceneSelesai", 0.3f);
    }

    void LoadSceneSelesai()
    {
        SceneManager.LoadScene("selesaiquiz");
    }

    // =========================
    // MAIN MENU
    // =========================
    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}