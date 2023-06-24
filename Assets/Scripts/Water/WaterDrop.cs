using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WaterDrop : MonoBehaviour
{
    public float velocity = 0;
    public float force = 0;
    // current height
    public float height = 0f;
    // normal height
    private float _target_height = 0f;
    public Transform springTransform;
    [SerializeField]
    private static SpriteShapeController spriteShapeController = null;
    private int _waveIndex = 0;
    private List<WaterDrop> springs = new();
    private float _resistance = 500f;
    public void Init(SpriteShapeController ssc)
    {

        var index = transform.GetSiblingIndex();
        _waveIndex = index + 1;
        spriteShapeController = ssc;
        velocity = 0;
        height = transform.localPosition.y;
        _target_height = transform.localPosition.y;
    }
    public void WaveSpringUpdate(float springStiffness, float dampening)
    {
        height = transform.localPosition.y;
        var x = height - _target_height;
        var loss = -dampening * velocity;

        force = -springStiffness * x + loss;
        velocity += force;
        var y = transform.localPosition.y;
        transform.localPosition = new Vector3(transform.localPosition.x, y + velocity, transform.localPosition.z);

    }
    public void WavePointUpdate()
    {
        if (spriteShapeController != null)
        {
            Spline waterSpline = spriteShapeController.spline;
            Vector3 wavePosition = waterSpline.GetPosition(_waveIndex);
            waterSpline.SetPosition(_waveIndex, new Vector3(wavePosition.x, transform.localPosition.y, wavePosition.z));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D fallingObject = other.gameObject.GetComponent<Rigidbody2D>();
        var speed = fallingObject.velocity;
        velocity += speed.y / _resistance;
        GetComponent<ParticleSystem>().Play();
    }
}