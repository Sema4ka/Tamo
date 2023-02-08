using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Pet : Entity
{
    [SerializeField] protected int jumpForce = 10;
    
    [SerializeField] private int saturation;
    [SerializeField] private int maxSaturation = 100;
    [SerializeField] private float hungerTime = 300;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(GetHungryCorutine());
    }
    public void Catch(Transform target)
    {
        MyRigitbody.AddForce((transform.position - target.position)*-jumpForce, ForceMode2D.Impulse);
    }

    public void Eat()
    {
        if(saturation + 5 < maxSaturation)
        {
            saturation += 5;
            MyTransform.localScale += new Vector3(0.05f, 0.05f, 0);
        }        
    }
    
    private void GetHungry()
    {
        if(saturation - 5 > 0)
        {
            saturation -= 5;
            MyTransform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }        
    }

    IEnumerator GetHungryCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerTime);
            GetHungry();
        }
    }
}
