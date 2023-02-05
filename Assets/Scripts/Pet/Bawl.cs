using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Bawl : MonoBehaviour
{
    [SerializeField] private Sprite[] stages;
    [SerializeField] private float eatingRadius;
    [SerializeField] private float eatingTime = 2;
    [SerializeField, Range(0, 7)] private int currentStage;
    
    private Pet _pet;
    private Rigidbody2D _petRb;
    private Transform _petTransform;
    private float _defaultTime;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _pet = FindObjectOfType<Pet>();
        _petRb = _pet.GetComponent<Rigidbody2D>();
        _petTransform = _pet.GetComponent<Transform>();
        _defaultTime = eatingTime;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _petRb.AddForce(transform.position - _petTransform.position);
        _spriteRenderer.sprite = stages[currentStage];
        Eat();
    }

    private void Eat()
    {
        if (Physics2D.OverlapCircle(transform.position, eatingRadius, LayerMask.GetMask("Player")))
        {
            eatingTime -= Time.deltaTime;
        }
        else
        {
            eatingTime = _defaultTime;
        }

        if (eatingTime <= 0)
        { 
            currentStage = currentStage > 0 ? currentStage - 1: 0;
            eatingTime = _defaultTime;
        }
    }
    
}
