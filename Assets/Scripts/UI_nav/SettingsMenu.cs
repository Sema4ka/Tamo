using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioSource Source;
    public GameObject panel;
    private void Start()
    {
        DontDestroyOnLoad(Source);
        DontDestroyOnLoad(this);
    }
    public void SetMusic(bool check)
    {
        if (check)
            Source.Play();
        else
            Source.Stop();
        print(panel.GetType());
    }

    public void OpenMenu()
    {
    }
}
