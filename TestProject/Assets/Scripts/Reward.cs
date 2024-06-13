using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType {  Add, Sub, Mul, Div}
public class Reward : MonoBehaviour
{
    public RewardType type;
    public int value;
    public float speed;
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.back;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ApplyAttackValue(other.GetComponent<Character>());
        }
    }

    public void ApplyAttackValue(Character character)
    {
        switch(type)
        {
            case RewardType.Add:
                character.AttackValue += value;
                break;
            case RewardType.Sub:
                character.AttackValue -= value;
                break;
            case RewardType.Mul:
                character.AttackValue *= value;
                break;
            case RewardType.Div:
                character.AttackValue /= value;
                break;
        }
    }
}
