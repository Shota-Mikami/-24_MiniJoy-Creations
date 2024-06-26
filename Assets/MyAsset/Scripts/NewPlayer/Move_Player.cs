//--------------------------------------------------------------
//Player�̈ړ����Ǘ��������
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private float speed = 0.0f;     //�ړ����x
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //���ړ�
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed , ForceMode.Impulse);
    }

    //�ړ����x�ύX�֐�
    public void SetMoveSpeed(float sp)
    {
        speed = sp;
    }
}
