using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager4 : MonoBehaviour
{
    [Header("Button Pilihan")]
    public GameObject btnKurban;
    public GameObject btnRambut;
    public GameObject btnKerikil;

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
    // SALAH KURBAN
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
    // SALAH RAMBUT
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
        btnKurban.SetActive(false);
        btnRambut.SetActive(false);
        btnKerikil.SetActive(false);

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
        btnKurban.SetActive(false);
        btnRambut.SetActive(false);
        btnKerikil.SetActive(false);
    }

    // =========================
    // PINDAH QUIZ5
    // =========================
    public void PindahKeQuiz5()
    {
        audioSource.PlayOneShot(bubblePopSound);

        Invoke("LoadSceneQuiz5", 0.3f);
    }
    void LoadSceneQuiz5()
    {
        SceneManager.LoadScene("Quiz5Scene");
    }

    // =========================
    // MAIN MENU
    // =========================
    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}