using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    private void OnMouseDown()
    {
        int way = SceneManager.GetActiveScene().buildIndex;
        if (gameObject.transform.position.x > 0)
        {
            way += 1;
            if (SceneManager.sceneCountInBuildSettings == way)
            {
                SceneManager.LoadScene(0);
                return;
            }
        }

        else
        {
            way -= 1;
            if (way < 0)
            {
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings -1);
                print(SceneManager.sceneCountInBuildSettings -1);
                return;
            }
        }
        Debug.Log(way);
        SceneManager.LoadScene(way);
    }
}
