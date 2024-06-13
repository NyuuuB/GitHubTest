using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RewardType {   Add, Sub, Mul, Div}
public class Reward : MonoBehaviour
{
    TextMeshProUGUI rewardText;

    public RewardType type;
    public int value;
    public float speed;

    void Start()
    {
        rewardText = GetComponentInChildren<TextMeshProUGUI>();
        switch(type)
        {
            case RewardType.Add:
                rewardText.text = $"+ {value}";
                break;
            case RewardType.Sub:
                rewardText.text = $"- {value}";
                break;
            case RewardType.Mul:
                rewardText.text = $"¡¿ {value}";
                break;
            case RewardType.Div:
                rewardText.text = $"¡À {value}";
                break;
        }
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.back;
        rewardText.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ApplyAttackValue(other.GetComponent<Character>());
            Destroy(gameObject);
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
