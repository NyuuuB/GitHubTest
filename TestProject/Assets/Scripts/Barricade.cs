using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Barricade : MonoBehaviour
{
    [SerializeField] GameObject rewardObject;
    [SerializeField] GameObject barricadeObject;
    [SerializeField] TextMeshProUGUI hpText;
    public int hpMax;
    public int hpCurrent;

    public RewardType type;
    public int value;

    public float speed;

    private void Awake()
    {
        if (rewardObject.TryGetComponent<Reward>(out Reward reward))
        {
            reward.type = this.type;
            reward.value = this.value;
        }
        // 시작하면 보상은 끄고, 바리케이드는 킴.
        rewardObject.SetActive(false);
        barricadeObject.SetActive(true);
        hpText.text = hpCurrent.ToString();

    }

    private void Update()
    {
        // 매번 앞으로 보냄.
        transform.position += Vector3.back * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 녀석이. 캐릭터라면
        if(other.TryGetComponent<Character>(out Character col))
        {
            // 데미지를 받음.
            col.TakeDamage();
        }
        // 닿은 녀석이 총알이라면
        else if(TryGetComponent<Bullet>(out Bullet bullet))
        {
            // 총알 공격력 만큼 데미지를 받음.
            hpCurrent -= bullet.AttackValue;
            hpText.text = hpCurrent.ToString();
            
            //바리케이드 hp가 0이하가 되면 보상이 나옴
            if(hpCurrent<=0)
            {
                OnDestroyBarricade();
            }
        }


    }

    // 바리케이드가 부서짐.
    void OnDestroyBarricade()
    {
        // 바리케이트 끄고, 보상 킴.
        rewardObject.SetActive(true);
        barricadeObject.SetActive(false);
        // 보상의 타입, 밸류를 정해줌.
        
    }

}
