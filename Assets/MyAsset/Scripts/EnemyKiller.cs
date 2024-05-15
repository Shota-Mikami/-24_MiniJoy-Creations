using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : Enemy
{
    public float speed = 3.0f;

    public bool right = false;

    public override void Move(float time)
    {
        // ���݂̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // ���̈ʒu���v�Z�i���Ԃɂ���Ĉړ��ʂ𒲐��j
        Vector3 nextPosition;

        if (right)
        {
            nextPosition = currentPosition + transform.right * speed * time;
        }
        else 
        {
            nextPosition = currentPosition + -transform.right * speed * time;
        }
        // ���̈ʒu�Ɉړ�
        transform.position = nextPosition;

        if(HP <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().mass = 1;
        }
    }
}
