using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PetScriptableObject", order = 1)]
public class PetScriptableObject : ScriptableObject
{
    [SerializeField]private int _jumpForce = 10;
    [SerializeField]private int _maxSaturation = 100;
    [SerializeField]private float _hungerTime = 300;

    public int jumpForce => _jumpForce;
    public int maxSaturation => _maxSaturation;
    public float hungerTime => _hungerTime;
}
