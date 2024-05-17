using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public int AttackPower;
    [SerializeField] public float AirRes;

    //�̂��ɑ����ǉ�

    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            enabled = false;
        }
    }

    //�����ɂ��j�󏈗�����Œǉ�

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (transform.parent)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                coll.gameObject.GetComponent<Enemy>().Damage(AttackPower);
            }
        }
    }
}
