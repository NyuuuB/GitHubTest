using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;

    public float speed;
    public int AttackValue;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            transform.position += speed * Time.deltaTime * Vector3.forward;
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void SetAttackValue(int value)
    {
        AttackValue = value;
    }
}
