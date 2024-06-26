//--------------------------------------------------------------
//Hammer�̉�]���Ǘ��������
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Player : MonoBehaviour
{
    private bool isReady = true;    //�����鏀�����ł��Ă��邩(�n���}�[���茳�ɂ��邩)
    private float speed = 0.0f;     //��]���x

    void Start()
    {
        //�p�x���Z�b�g
        InitRotate();
    }

    void Update()
    {
        //�����鏀�����ł��Ă���(�n���}�[���茳�ɂ���)��
        if (isReady)
        {
            //�}�E�X�E�N���b�N�Ŋp�x���Z�b�g
            if (Input.GetMouseButtonDown(1))
            {
                InitRotate();
            }

            //�}�E�X���{�^���������ŉ�]
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime);
            }
        }

        //�q�I�u�W�F�N�g�����邩���n���}�[�𓊂����邩
        isReady = transform.IsChildOf(transform);
    }

    //��]���x�ύX�֐�
    public void SetRotateSpeed(float sp)
    {
        speed = sp;
    }

    //��]�p�x�������֐�
    public void InitRotate()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
    }

}
