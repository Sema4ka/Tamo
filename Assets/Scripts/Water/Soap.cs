using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteAlways]
public class Soap : MonoBehaviour
{

    public List<Collider2D> ignoreColliders;
    public Collider2D shelf;
    public float WhereToRoll;

    private bool isDraging;
    private float _startHeight;
    private ParticleSystem _ps;
    private List<ParticleSystem.Particle> _enteredParticles = new List<ParticleSystem.Particle>();
    private Collider2D _enteredCollider;


    private Vector3 point;



    private void Start()
    {
        foreach(Collider2D col in ignoreColliders)
        {
            Physics2D.IgnoreCollision(col, GetComponent<Collider2D>(), true);
        }
        _startHeight = transform.position.y;
        _ps = GetComponent<ParticleSystem>();
    }

    private void OnMouseDrag()
    {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;

        Physics2D.IgnoreCollision(shelf, GetComponent<Collider2D>(), true);
        GetComponent<Rigidbody2D>().MovePosition(point);

        transform.rotation = Quaternion.FromToRotation(Vector2.up,new Vector2(transform.position.x, _startHeight + transform.position.y - WhereToRoll));

        if (Mathf.Abs(transform.rotation.z) > 0.75 && !_ps.isPlaying)
        {
            _ps.Play();
        }
        else if(Mathf.Abs(transform.rotation.z) < 0.75)
            _ps.Stop();
        //print(Mathf.Abs(transform.rotation.z) > 0.75);
        //print(_ps.isPlaying);

        isDraging = true;

    }

    private void OnMouseUp()
    {
        isDraging = false;
        _startHeight = transform.position.y;
        Physics2D.IgnoreCollision(shelf, GetComponent<Collider2D>(), false);
        GetComponent<ParticleSystem>().Stop();


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(point, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector2(transform.position.x, _startHeight + transform.position.y - WhereToRoll), 0.1f);
    }
    private void OnParticleTrigger()
    {
        ParticleSystem.ColliderData _enteredColliderData;
        _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _enteredParticles, out _enteredColliderData);
        if(_enteredCollider==null)
            _enteredCollider = _enteredColliderData.GetCollider(0, 0) as Collider2D;
        print(_enteredCollider);
        foreach (ParticleSystem.Particle p in _enteredParticles)
        {
            _enteredCollider.GetComponent<SpriteShapeRenderer>().color = new Color(p.startColor.r*0.05f, p.startColor.g * 0.05f, p.startColor.b * 0.05f, 150);
        }
    }
}
