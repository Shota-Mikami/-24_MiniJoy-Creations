using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 target;
    // Start is called before the first frame update

    public Rigidbody ball;
    public static Vector2 m_moveLimit = new Vector2(4.15f, 3.0f);
    public float m_speed;

    public float speed_level;
    public float oldspeed_level;

    public float startTime;
    bool Swich = false;
    void Start()
    {
        speed_level = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Swich)
        {



            //var h = Input.GetAxis("Horizontal");
            //var v = Input.GetAxis("Vertical");

            //var velocity = new Vector3(h, v) * m_speed;
            //transform.localPosition += velocity;

            //transform.localPosition = ClampPosition(transform.localPosition);

            //// �v���C���[�̃X�N���[�����W���v�Z����
            //var screenPos = Camera.main.WorldToScreenPoint(transform.position);

            //// �v���C���[���猩���}�E�X�J�[�\���̕������v�Z����
            //var direction = Input.mousePosition - screenPos;

            //// �}�E�X�J�[�\�������݂�������̊p�x���擾����
            //var angle = GetAngle(Vector3.zero, direction);

            //// �v���C���[���}�E�X�J�[�\���̕���������悤�ɂ���
            //var angles = transform.localEulerAngles;
            //angles.z = angle - 90;
            //transform.localEulerAngles = angles;
            transform.Rotate(new Vector3(0, 0, speed_level));



        }
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
             speed_level = 0.25f;

            Time.timeScale = 0.5f;

            ball.mass = 0.0f;
        }
        if (Input.GetMouseButtonUp(0) || startTime + 1.0f <= Time.time && startTime != 0.0f)
        {
            Time.timeScale = 1.0f;
            startTime = 0.0f;
            Swich = true;

            ball.mass = 1.0f;

        }
            if (Input.GetMouseButtonDown(1))
        {
            Swich = false;

            speed_level = oldspeed_level;
        }

        if (Input.GetKeyDown("1"))
        {
            speed_level = 2.0f;
            oldspeed_level = speed_level;
        }
        if (Input.GetKeyDown("2"))
        {
            speed_level = 3.0f;
            oldspeed_level = speed_level;
        }

    }



}

