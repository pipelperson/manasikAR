using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager3 : MonoBehaviour
{
    [Header("Button Pilihan")]
    public GameObject btnTawaf;
    public GameObject btnWukuf;
    public GameObject btnTahallul;

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

        // tampil lanjut
        btnLanjut.SetActive(true);
    }

    // =========================
    // SALAH TAWAF
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
    // SALAH TAHALLUL
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
        btnTawaf.SetActive(false);
        btnWukuf.SetActive(false);
        btnTahallul.SetActive(false);

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
        btnTawaf.SetActive(false);
        btnWukuf.SetActive(false);
        btnTahallul.SetActive(false);
    }

    // =========================
    // PINDAH QUIZ4
    // =========================
    public void PindahKeQuiz4()
    {
        audioSource.PlayOneShot(bubblePopSound);

        Invoke("LoadSceneQuiz4", 0.3f);
    }
    void LoadSceneQuiz4()
    {
        SceneManager.LoadScene("Quiz4Scene");
    }

    // =========================
    // MAIN MENU
    // =========================
    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}