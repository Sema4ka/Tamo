using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteAlways]
public class Soap : MonoBehaviour
{

    public Collider2D shelf;
    public float WhereToRoll;

    private ParticleSystem _ps;
    private List<ParticleSystem.Particle> _enteredParticles = new List<ParticleSystem.Particle>();
    private Collider2D _enteredCollider;


    private Vector3 dragPoint;




    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    private void OnMouseDrag()
    {
        dragPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragPoint.z = 0;

        Physics2D.IgnoreCollision(shelf, GetComponent<Collider2D>(), true);
        //GetComponent<Rigidbody2D>().MovePosition(dragPoint);
        transform.position = dragPoint;
        transform.rotation = Quaternion.FromToRotation(shelf.transform.position + new Vector3(0, WhereToRoll), transform.position);

        if (Mathf.Abs(transform.rotation.z) > 0.75 && !_ps.isPlaying)
        {
            _ps.Play();
        }
        else if(Mathf.Abs(transform.rotation.z) < 0.75)
            _ps.Stop();

    }

    private void OnMouseUp()
    {
        Physics2D.IgnoreCollision(shelf, GetComponent<Collider2D>(), false);
        GetComponent<ParticleSystem>().Stop();


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(dragPoint, 0.1f);

    }
    private void OnParticleTrigger()
    {
        ParticleSystem.ColliderData _enteredColliderData;
        Color c = new Color();
        _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _enteredParticles, out _enteredColliderData);
        if (_enteredCollider == null && _enteredParticles.Count != 0)
        {
            _enteredCollider = _enteredColliderData.GetCollider(0, 0).gameObject.GetComponent<Collider2D>();
        }
        foreach (ParticleSystem.Particle p in _enteredParticles)
        {
            c = _enteredCollider.GetComponent<SpriteShapeRenderer>().color;

            _enteredCollider.GetComponent<SpriteShapeRenderer>().color = Color.Lerp(c, p.startColor, 0.05f);
        }
    }
}
