using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    [Header("Button Pilihan")]
    public GameObject btnMaqamIbrahim;
    public GameObject btnHajarAswad;
    public GameObject btnKabah;

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

        audioSource.PlayOneShot(correctSound);

        SembunyikanPilihan();

        btnJawaban.SetActive(true);

        btnLanjut.SetActive(true);
    }

    // =========================
    // SALAH MAQAM IBRAHIM
    // =========================
    public void JawabanSalah1()
    {
        if (sudahMenjawab) return;

        sudahMenjawab = true;

        // tampilkan merah
        btnSalah1.SetActive(true);

        // bunyi salah
        audioSource.PlayOneShot(wrongSound);

        // tunggu bentar
        Invoke("TampilkanJawaban", 0.5f);
    }

    // =========================
    // SALAH KABAH
    // =========================
    public void JawabanSalah2()
    {
        if (sudahMenjawab) return;

        sudahMenjawab = true;

        // tampilkan merah
        btnSalah2.SetActive(true);

        // bunyi salah
        audioSource.PlayOneShot(wrongSound);

        // tunggu bentar
        Invoke("TampilkanJawaban", 0.5f);
    }

    // =========================
    // TAMPILKAN JAWABAN
    // =========================
    void TampilkanJawaban()
    {
        // hide pilihan
        btnMaqamIbrahim.SetActive(false);
        btnHajarAswad.SetActive(false);
        btnKabah.SetActive(false);

        // hide tombol merah
        btnSalah1.SetActive(false);
        btnSalah2.SetActive(false);

        // tampil jawaban benar
        btnJawaban.SetActive(true);

        // tampil penjelasan
        panelPenjelasan.SetActive(true);

        // tampil lanjut
        btnLanjut.SetActive(true);
    }

    // =========================
    // HIDE PILIHAN
    // =========================
    void SembunyikanPilihan()
    {
        btnMaqamIbrahim.SetActive(false);
        btnHajarAswad.SetActive(false);
        btnKabah.SetActive(false);
    }

    // =========================
    // PINDAH QUIZ3
    // =========================
    public void PindahKeQuiz3()
    {
        audioSource.PlayOneShot(bubblePopSound);

        Invoke("LoadSceneQuiz3", 0.3f);
    }
    void LoadSceneQuiz3()
    {
        SceneManager.LoadScene("Quiz3Scene");
    }
    // =========================
    // MAIN MENU
    // =========================
    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}