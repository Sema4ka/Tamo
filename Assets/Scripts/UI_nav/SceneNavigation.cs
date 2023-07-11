using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{

    public int targetScene = -1;
    private int _unRigisteredScenes=1;
    private void OnMouseDown()
    {
        if(targetScene!=-1)
        {
            ChangeScene(targetScene);
            return;
        }
        int way = SceneManager.GetActiveScene().buildIndex;
        if (gameObject.transform.position.x > 0)
        {
            way += 1;
            if (SceneManager.sceneCountInBuildSettings - _unRigisteredScenes == way)
            {
                ChangeScene(1);
                return;
            }
        }

        else
        {
            way -= 1;
            if (way < 1)
            {
                ChangeScene(SceneManager.sceneCountInBuildSettings - 1 - _unRigisteredScenes);
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
