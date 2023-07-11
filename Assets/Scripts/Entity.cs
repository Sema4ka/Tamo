using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int dragForce = 50;
    [HideInInspector]public Rigidbody2D myRigidbody;

     protected virtual void Start() {
        myRigidbody =  GetComponent<Rigidbody2D>();
     }
    
    private void OnMouseDrag()
    {
        Vector2 v2 = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));
        myRigidbody.AddForce(v2 * dragForce);
    }
}
 