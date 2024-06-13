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
        // �����ϸ� ������ ����, �ٸ����̵�� Ŵ.
        rewardObject.SetActive(false);
        barricadeObject.SetActive(true);
        hpText.text = hpCurrent.ToString();

    }

    private void Update()
    {
        // �Ź� ������ ����.
        transform.position += Vector3.back * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� �༮��. ĳ���Ͷ��
        if(other.TryGetComponent<Character>(out Character col))
        {
            // �������� ����.
            col.TakeDamage();
        }
        // ���� �༮�� �Ѿ��̶��
        else if(TryGetComponent<Bullet>(out Bullet bullet))
        {
            // �Ѿ� ���ݷ� ��ŭ �������� ����.
            hpCurrent -= bullet.AttackValue;
            hpText.text = hpCurrent.ToString();
            
            //�ٸ����̵� hp�� 0���ϰ� �Ǹ� ������ ����
            if(hpCurrent<=0)
            {
                OnDestroyBarricade();
            }
        }


    }

    // �ٸ����̵尡 �μ���.
    void OnDestroyBarricade()
    {
        // �ٸ�����Ʈ ����, ���� Ŵ.
        rewardObject.SetActive(true);
        barricadeObject.SetActive(false);
        // ������ Ÿ��, ����� ������.
        
    }

}
