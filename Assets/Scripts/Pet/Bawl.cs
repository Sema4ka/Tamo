using Unity.VisualScripting;
using UnityEngine;

public class Bawl : MonoBehaviour
{
    [SerializeField] private Sprite[] stages;
    [SerializeField] private float eatingRadius;
    [SerializeField] private float eatingTime;
    [SerializeField, Range(0, 7)] private int currentStage;
    [SerializeField] private float defaultTime = 2;
    
    private GameManager gm;
    private Pet _pet;
    private GameObject _petObj;
    private Rigidbody2D _petRb;
    private Transform _petTransform;
    private SpriteRenderer _spriteRenderer;

    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();
        _petObj = GameObject.FindGameObjectWithTag("Player");  
        _pet = _petObj.GetComponent<Pet>();
        _petRb = _petObj.GetComponent<Rigidbody2D>();
        _petTransform = _petObj.GetComponent<Transform>();
        defaultTime = eatingTime;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(currentStage!=0)
            _petRb.AddForce(transform.position - _petTransform.position);
        _spriteRenderer.sprite = stages[currentStage];
        Eat();
    }

    private void Eat()
    {
        Collider2D obj = Physics2D.OverlapCircle(transform.position, eatingRadius, 
            LayerMask.GetMask("Player"));
        if (obj)
        {
            eatingTime -= Time.deltaTime;
        }
        else
        {
            eatingTime = defaultTime;
        }

        if (eatingTime <= 0 && !_pet.isFull)
        { 
            currentStage = currentStage > 0 ? currentStage - 1: 0;
            eatingTime = defaultTime;
            
            if(currentStage!=0)
                _pet.Eat();
        }
    }
    
}
