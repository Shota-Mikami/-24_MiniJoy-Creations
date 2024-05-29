using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MobEnemy_move : Enemy
{
    public GameObject target;
    public float targetPos;
    public float startPos;
    public bool turn = false;
    public float speed;
    void Start()
    {
        targetPos = target.transform.position.x;
        startPos = transform.position.x;

        if(targetPos > startPos)
        {
            turn = true;
        }
        else
        {
            float p = targetPos;
            targetPos = startPos;
            startPos = p;

            turn = true;
        }
    }

    public override void Move(float time)
    {
        // ���݂̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // ���̈ʒu���v�Z�i���Ԃɂ���Ĉړ��ʂ𒲐��j
        Vector3 nextPosition;

        if (turn)
        {
            nextPosition = currentPosition + transform.right * speed * time;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            nextPosition = currentPosition + transform.right * speed * time;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        // ���̈ʒu�Ɉړ�
        transform.position = nextPosition;

       
        if (transform.position.x < startPos)
        {
            turn = true;
           // transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x > targetPos)
        {
            turn = false;
            //transform.position = new Vector3(targetPos, transform.position.y, transform.position.z);
        };
    }


}
