using UnityEngine;

public class LinkManager : MonoBehaviour
{
    // Fungsi untuk membuka folder Google Drive
    public void BukaFolderMarker()
    {
        string url = "https://drive.google.com/drive/folders/1WqTO0SmkE4GpOH9qt6AbZQ2HM6hBzLNu?usp=sharing";
        Application.OpenURL(url);
    }
}