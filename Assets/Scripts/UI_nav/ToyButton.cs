using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyButton : MonoBehaviour
{
    [SerializeField] private GameObject toy;
    [SerializeField] private GameManager manager;

    public void Click()
    {
        manager.toy = toy;
        manager.SetState("Ball");
        print("button works");
    }
}
    