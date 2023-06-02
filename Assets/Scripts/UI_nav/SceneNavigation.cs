using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{

    public int scene = -1;
    private int _unRigisteredScenes=1;
    private void OnMouseDown()
    {
        if(scene!=-1)
        {
            ChangeScene(scene);
            return;
        } 
        int way = SceneManager.GetActiveScene().buildIndex;
        if (gameObject.transform.position.x > 0)
        {
            way += 1;
            if (SceneManager.sceneCountInBuildSettings - _unRigisteredScenes == way)
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
                ChangeScene(SceneManager.sceneCountInBuildSettings - 1 - _unRigisteredScenes);
                return;
            }
        }
        SceneManager.LoadScene(way);
    }

    public void ChangeScene(int index)
    {
        print("pfuheprf dfyys");
        SceneManager.LoadScene(index);
    }
}
