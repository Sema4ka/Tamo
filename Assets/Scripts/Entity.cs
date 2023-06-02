using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int dragForce = 50;
    [HideInInspector]public Rigidbody2D myRigitbody;
    [HideInInspector]public Transform myTransform;
    
     protected virtual void Start() {
        myRigitbody =  GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
     }
    
    private void OnMouseDrag()
    {
        Vector2 v2 = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));
        myRigitbody.AddForce(v2 * dragForce);
    }

    public void Make()
    {
        Instantiate(this);
    }
    
    public void Make(Vector3 pos, Quaternion quaternion)
    {
        Instantiate(this, pos, quaternion);
    }
}
