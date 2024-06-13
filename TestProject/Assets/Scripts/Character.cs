using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Character : MonoBehaviour
{

    public GameObject bulletPrefab; 

    public int hpMax;
    public int hpCurrent;
    
    public int attackValue;
    public int AttackValue
    {
        get => attackValue;
        set
        {
            attackValue = Mathf.Max(1, value);
        }
    }

    public float attackSpeedMax; // 공격 딜레이 숫자가 작아지면 빨라진다.
    public float attackSpeedCurrent;

    public float moveSpeed;
    public Vector3 dir;

    public virtual void Attack()
    {
        GameObject inst = Instantiate(bulletPrefab, transform.position + Vector3.forward, transform.rotation);
        inst.GetComponent<Bullet>().SetAttackValue(attackValue);
    }
    public virtual void OnMove(InputValue value)
    {
        Move(value.Get<Vector3>());
    }
    public virtual void Move(Vector3 dir)
    {
        this.dir = dir.normalized;
    }

    private void Update()
    {
        // 공격
        if (attackSpeedCurrent <= 0f)
        {
            Attack();
            attackSpeedCurrent = attackSpeedMax;
        }
        else
        {
            attackSpeedCurrent -= Time.deltaTime;
        }

        // 이동
        transform.position += dir * Time.deltaTime * moveSpeed;
    }

    public virtual void TakeDamage()
    {
        hpCurrent -= 1;
        if (hpCurrent <= 0)
        {
            Debug.Log("게임오버");
        }
    }
}
