using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barricade : MonoBehaviour
{
    public int hpMax;
    public int hpCurrent;

    public RewardType type;
    public int value;

    public float speed;

    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Character>(out Character col))
        {

        }
        else
        {
            
        }


    }

}
