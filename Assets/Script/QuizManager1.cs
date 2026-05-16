using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager1 : MonoBehaviour
{
    [Header("Button Pilihan")]
    public GameObject btnMiqat;
    public GameObject btnMuzdalifa;
    public GameObject btnMina;

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
    // SALAH MUZDALIFA
    // =========================
    public void JawabanSalah1()
    {
    if (sudahMenjawab) return;

    sudahMenjawab = true;

    // munculkan merah
    btnSalah1.SetActive(true);

    // bunyi salah
    audioSource.PlayOneShot(wrongSound);

    // tunggu bentar baru tampil jawaban
    Invoke("TampilkanJawaban", 0.5f);
    }

    // =========================
    // SALAH MINA
    // =========================
    public void JawabanSalah2()
    {
    if (sudahMenjawab) return;

    sudahMenjawab = true;

    // munculkan merah
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
    // sembunyikan semua tombol pilihan
    btnMiqat.SetActive(false);
    btnMuzdalifa.SetActive(false);
    btnMina.SetActive(false);

    // sembunyikan tombol merah
    btnSalah1.SetActive(false);
    btnSalah2.SetActive(false);

    // tampilkan jawaban benar
    btnJawaban.SetActive(true);

    // tampilkan penjelasan
    panelPenjelasan.SetActive(true);

    // tampilkan tombol lanjut
    btnLanjut.SetActive(true);
    }

    // =========================
    // HIDE PILIHAN
    // =========================
    void SembunyikanPilihan()
    {
        btnMiqat.SetActive(false);
        btnMuzdalifa.SetActive(false);
        btnMina.SetActive(false);
    }

    // =========================
    // QUIZ 2
    // =========================
    public void PindahKeQuiz2()
    {
        audioSource.PlayOneShot(bubblePopSound);
        Invoke("LoadSceneQuiz2", 0.3f);
    }
    void LoadSceneQuiz2()
    {
        SceneManager.LoadScene("Quiz2Scene");
    }

    // =========================
    // MAIN MENU
    // =========================
    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}