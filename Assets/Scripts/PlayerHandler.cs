using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour
{

    public UnityEvent onCollisionEnter;

    public int countCollision;
    private void Start()
    {
        onCollisionEnter.AddListener(Foo);
    }

    private void Update()
    {

    }

    private void Foo()
    {
        Debug.Log("Foo");
    }

    private void OnCollisionEnter(Collision other)
    {


        countCollision--;
        onCollisionEnter.Invoke();
    }


}
