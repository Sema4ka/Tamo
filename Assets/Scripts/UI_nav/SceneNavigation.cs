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
                ChangeScene(0);
                return;
            }
        }

        else
        {
            way -= 1;
            if (way < 0)
            {
                ChangeScene(SceneManager.sceneCountInBuildSettings -1);
                return;
            }
        }
        SceneManager.LoadScene(way);
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
