using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource Source;
    private bool isOpen;
    private void Start()
    {
        DontDestroyOnLoad(Source);
        DontDestroyOnLoad(transform.parent);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isOpen && !EventSystem.current.IsPointerOverGameObject())
        {
            CloseMenu();
        }
    }

    public void SetMusic(bool check)
    {
        if (check)
            Source.Play();
        else
            Source.Stop();
    }

    public void OpenMenu()
    {
        isOpen = true;
        Time.timeScale = 0.2f;
    }

    public void CloseMenu()
    {
        isOpen = false;
        Time.timeScale = 1f;
        GetComponent<Animator>().SetTrigger("Close");
    }
}
