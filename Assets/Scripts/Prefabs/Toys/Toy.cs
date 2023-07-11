using UnityEngine;

public class Toy : Entity
{
    public float actInSeconds;

    private ToyManager _pet;
    private Pet _petObject;

    protected override void Start()
    {
        base.Start();
        _petObject = FindObjectOfType<Pet>();
        _pet = _petObject.GetComponent<ToyManager>();
        _pet.toys.Add(this);
    }


    public virtual void m_Action()
    {
        _petObject.myRigidbody.AddForce((_petObject.transform.position - transform.position)*-_petObject.petConsts.jumpForce, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        _pet.toys.Remove(this);
        if (_pet.activeToy == this)
            _pet.activeToy = null;
    }
    
}
