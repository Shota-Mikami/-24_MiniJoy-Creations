using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_needle : MonoBehaviour
{
    //�R���C�_�[���m���Ԃ������u�ԂɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyWall"))
        {
            Destroy(this.gameObject);
        }
    }
}
