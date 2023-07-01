using Unity.VisualScripting.FullSerializer;
using UnityEngine;
[ExecuteAlways]
public class Resize : MonoBehaviour
{
    private SpriteRenderer sr;

    public bool toHeight = true;
    public bool toWidth = true;

    // TODO: change to Start 
    private void Update()
    {
        sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = (Camera.main.orthographicSize * 2) / sr.size.y;
        float worldScreenWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width) / sr.size.x;

        if (!toHeight)
            worldScreenHeight = transform.localScale.y;
        if (!toWidth)
            worldScreenWidth = transform.localScale.x;
        transform.localScale = new Vector3(
            worldScreenWidth,
            worldScreenHeight, 1);
    }
}
