using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Character : MonoBehaviour
{
    public int hpMax;
    public int hpCurrent;

    public int attackValue;
    public int AttackValue
    {
        get => attackValue;
        set
        {
            attackValue = Mathf.Max(1 ,value);
        }
    }

    public float attackSpeed;
    public float moveSpeed;
    public Vector3 dir;

    public Rigidbody rb;

    public virtual void Attack()
    {
        
    }
    public void OnMove(InputValue value)
    {
        Move(value.Get<Vector3>());
    }
    public virtual void Move(Vector3 dir)
    {
        this.dir = dir.normalized;
    }
    private void Update()
    {
        rb.AddForce(moveSpeed * Time.deltaTime * dir);        
    }



    
}
