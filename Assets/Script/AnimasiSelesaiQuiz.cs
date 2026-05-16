using UnityEngine;

public class AnimasiSelesaiQuiz : MonoBehaviour
{
    [Header("Komponen UI yang akan dianimasikan")]
    public RectTransform cowo;
    public RectTransform cewe;
    public RectTransform bannerSelamat;

    [Header("Pengaturan Animasi Karakter (Lompat)")]
    public float kecepatanLompat = 4f;
    public float tinggiLompat = 15f;

    [Header("Pengaturan Animasi Banner (Membesar/Mengecil)")]
    public float kecepatanBanner = 3f;
    public float skalaBanner = 0.05f;

    // Menyimpan posisi dan skala awal
    private Vector2 posisiAwalCowo;
    private Vector2 posisiAwalCewe;
    private Vector3 skalaAwalBanner;

    void Start()
    {
        // Simpan posisi awal saat scene baru mulai
        if (cowo != null) posisiAwalCowo = cowo.anchoredPosition;
        if (cewe != null) posisiAwalCewe = cewe.anchoredPosition;
        if (bannerSelamat != null) skalaAwalBanner = bannerSelamat.localScale;
    }

    void Update()
    {
        // 1. Animasi Lompat Cowo
        if (cowo != null)
        {
            float lompatCowo = Mathf.Sin(Time.time * kecepatanLompat) * tinggiLompat;
            cowo.anchoredPosition = new Vector2(posisiAwalCowo.x, posisiAwalCowo.y + lompatCowo);
        }

        // 2. Animasi Lompat Cewe (ditambah +1 agar lompatnya agak gantian/tidak barengan persis)
        if (cewe != null)
        {
            float lompatCewe = Mathf.Sin((Time.time * kecepatanLompat) + 1f) * tinggiLompat;
            cewe.anchoredPosition = new Vector2(posisiAwalCewe.x, posisiAwalCewe.y + lompatCewe);
        }

        // 3. Animasi Banner (Pulsing / Skala membesar & mengecil)
        if (bannerSelamat != null)
        {
            float efekSkala = Mathf.Sin(Time.time * kecepatanBanner) * skalaBanner;
            bannerSelamat.localScale = new Vector3(skalaAwalBanner.x + efekSkala, skalaAwalBanner.y + efekSkala, 1f);
        }
    }
}