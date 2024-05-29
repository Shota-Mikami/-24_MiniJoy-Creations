using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //��X�X�e�[�g�p�^�[���ǉ��H
    // Update is called once per frame
    void Update()
    {
        Move(Time.deltaTime);
        if (HP <= 0)
        {
            this.gameObject.GetComponent<Ball>().enabled = true;
            this.gameObject.tag = "ball";
            enabled = false;
        }
    }

    //��Όp����ǋL,�ړ����x��time�Ő��䂷�邱��(time = deltaTime)
    public virtual void Move(float time)
    {

    }

    //�߂�l�ő����Q�ƁH
    public virtual void Damage(int damage)
    {
        HP -= damage;
        HP = Mathf.Max(0, HP);
    }
}
