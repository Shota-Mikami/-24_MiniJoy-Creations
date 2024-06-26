//--------------------------------------------------------------
//Player�S�̂��Ǘ��������
//�������̂͊T�O�ł����Ȃ��ړ������Ȃ����ߒ��ӂ��K�v
//��������X�e�[�^�X�͂����ňꊇ�Ǘ�������
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Player : MonoBehaviour
{
    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Joint_Body;

    [SerializeField] private float move_speed = 25.0f;
    [SerializeField] private float rotate_speed = 100.0f;

    //private bool is_release;    //���������ۂ�

    void Start()
    {
        Body.GetComponent<Move_Player>().SetMoveSpeed(move_speed);
        Joint_Body.GetComponent<Rotate_Player>().SetRotateSpeed(rotate_speed);
    }

    void Update()
    {
        //�n���}�[�������Ă���(���Ɏq�I�u�W�F�N�g������)�̂ł���΃v���C���[�̈ʒu�ƃn���}�[����������
        if (Joint_Body.transform.IsChildOf(Joint_Body.transform))
        {
            Joint_Body.transform.position = Body.transform.position;
        }
        
    }
}
