//--------------------------------------------------------------
//������Hammer�̋������Ǘ��������
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Player : MonoBehaviour
{
    private float speed = 0.0f;                                 //�������x
    private Vector3 throw_vec = new Vector3(2.0f, 2.0f, 0.0f);  //��������
    private GameObject hammer = null;                           //��[�I�u�W�F�N�g
    private Transform player_transform = null;

    void Start()
    {
        //��[�I�u�W�F�N�g�͏����w��
        hammer = transform.GetChild(0).gameObject;
        player_transform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X���{�^���z�[���h�����œ�����
        if (Input.GetMouseButtonUp(0))
        {
            //�e���番��
            if (transform.parent)
            {
                transform.parent = null;
            }

            //��[�̃��W�b�g�{�f�B�L����
            if (hammer.GetComponent<Rigidbody>().isKinematic)
            {
                hammer.GetComponent<Rigidbody>().isKinematic = false;
            }

            hammer.GetComponent<Rigidbody>().AddForce(throw_vec, ForceMode.Impulse);
        }

        //�茳�ɖ߂�
        if (Input.GetMouseButtonDown(1))
        {
            hammer.GetComponent<Rigidbody>().isKinematic = true;
            hammer.transform.position = player_transform.position;
            transform.parent = player_transform;
            transform.eulerAngles = Vector3.zero;
            hammer.transform.eulerAngles = Vector3.zero;
        }
    }

    //�������x�ύX�֐�
    public void SetThrowSpeed(float sp)
    {
        speed = sp;
    }

    //���������ύX�֐�
    public void SetThrowVec(Vector3 vec)
    {
        throw_vec = vec;
    }

    public void SetThrowTip(GameObject obj)
    {
        hammer = obj;
    }
}
//-0.1533364