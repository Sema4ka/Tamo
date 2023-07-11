using System.Collections;
using UnityEngine;


public class Pet : Entity
{
    public string petName;
    public PetScriptableObject petConsts;
    [SerializeField] public int saturation;
    protected static bool isExist = false;

    public bool isFull { get { return saturation == petConsts.maxSaturation; } }
    
    protected  override void Start()
    {
        base.Start();
        StartCoroutine(GetHungryCorutine());
        PetSaverSystem.PetLoad(gameObject);
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        PetSaverSystem.SavePet(gameObject);
    }

    public void SetValues(PetData data)
    {
        isExist = true;
        petName = data.petName;
        saturation = data.saturation;
        Resources.Load(data.pathToScriptableObj);

    }




    #region HungerLogic

    public void Eat()
    {
        if(saturation + 5 <= petConsts.maxSaturation)
        {
            saturation += 5;
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }        
    }
    
    protected void GetHungry()
    {
        if(saturation - 5 >= 0)
        {
            saturation -= 5;
            transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }        
    }

    protected IEnumerator GetHungryCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(petConsts.hungerTime);
            GetHungry();
        }
    }

    #endregion

}
