using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Resize : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        
        transform.localScale = new Vector3(
            worldScreenWidth / sr.size.x,
            worldScreenHeight / sr.size.y, 1);
        
        print(worldScreenWidth);
        print(worldScreenHeight);
    }
    
    
}