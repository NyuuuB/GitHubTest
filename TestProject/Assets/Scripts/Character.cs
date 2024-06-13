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

    public float attackSpeedMax; // ���� ������ ���ڰ� �۾����� ��������.
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
        // ����
        if (attackSpeedCurrent <= 0f)
        {
            Attack();
            attackSpeedCurrent = attackSpeedMax;
        }
        else
        {
            attackSpeedCurrent -= Time.deltaTime;
        }

        // �̵�
        transform.position += dir * Time.deltaTime * moveSpeed;
    }

    public virtual void TakeDamage()
    {
        hpCurrent -= 1;
        if (hpCurrent <= 0)
        {
            Debug.Log("���ӿ���");
        }
    }
}
