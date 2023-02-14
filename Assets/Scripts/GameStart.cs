using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameManager gm;
    private void  Awake()
    {
        Instantiate(gm);
    }

 
}
