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
    [SerializeField] private float rotate_power;            //��]������
    [SerializeField] private float rotate_speed_max;        //��]�ő呬�x
    [SerializeField] private float rotate_speed_init;       //��]����
    [SerializeField] private float rotate_speed_down_rate;  //��]�����W��
    [SerializeField] private float rotate_speed_up_rate;    //��]�����W��

    [SerializeField] private float rot_border_DtoU = 90; //���`���ی�
    [SerializeField] private float rot_border_UtoU = 180; //���`��O�ی�
    [SerializeField] private float rot_border_UtoD = 270; //��O�`��l�ی�
    [SerializeField] private int rotatingSE_num;
    private bool charged;
    private int point_playSE;      //�܂킷SE��炵�����Ƃ���
    private int point_rot_now;     //�n���}�[�̈ʒu
    private bool checkSE;

    private float rotate_speed;
    public float oldspeed_level;

    public float startTime;
    bool Swich = false;
    void Start()
    {
        rotate_speed = rotate_speed_init;
        charged = false;
        point_playSE = 0;
        checkSE = true;
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

            if (Input.GetMouseButton(0))
            {
                //�ő呬�x�ł͂Ȃ��Ƃ�
                if (!charged)
                {
                    //��Ɉ��ʉ���
                    rotate_speed += rotate_power;

                    //���ی��Ō���
                    if (transform.eulerAngles.z <= rot_border_DtoU)
                    {
                        rotate_speed *= rotate_speed_down_rate;
                        if(point_playSE == 0)
                        {
                            point_playSE = 1;
                        }
                        point_rot_now = 1;
                    }
                    //���ی��Ŏキ����
                    else if (transform.eulerAngles.z <= rot_border_UtoU)
                    {
                        rotate_speed += rotate_power / 4.0f;
                        if (point_playSE == 0)
                        {
                            point_playSE = 2;
                        }
                        point_rot_now = 2;
                    }
                    //��O�ی��ő傫������
                    else if(transform.eulerAngles.z <= rot_border_UtoD)
                    {
                        rotate_speed *= rotate_speed_up_rate;
                        if (point_playSE == 0)
                        {
                            point_playSE = 3;
                        }
                        point_rot_now = 3;
                    }
                    //��l�ی��Ō���
                    else
                    {
                        rotate_speed *= rotate_speed_down_rate;
                        if (point_playSE == 0)
                        {
                            point_playSE = 4;
                        }
                        point_rot_now = 4;
                    }

                    //�ő呬�x�Ȃ瑬�x����
                    if (rotate_speed >= rotate_speed_max)
                    {
                        rotate_speed = rotate_speed_max;
                        charged = true;
                        Debug.Log("Full_Charged");
                    }

                   
                }
                else    //�ő呬�x�Ȃ瑬�x���
                {
                    rotate_speed = rotate_speed_max;

                    if (transform.eulerAngles.z <= rot_border_DtoU) {
                        point_rot_now = 1;
                    }
                    else if (transform.eulerAngles.z <= rot_border_UtoU) {
                        point_rot_now = 2;
                    }
                    else if (transform.eulerAngles.z <= rot_border_UtoD) {
                        point_rot_now = 3;
                    }
                    else {
                        point_rot_now = 4;
                    }
                }

                CheckPlaySEPoint();
                // startTime = Time.time;

                transform.Rotate(new Vector3(0, 0, rotate_speed));

                //Time.timeScale = 0.5f;

                ball.mass = 0.0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //Time.timeScale = 1.0f;
                //startTime = 0.0f;
                Swich = true;

                ball.mass = 1.0f;

                charged = false;

                point_playSE = 0;

                checkSE = true;
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                RotateInit();
            }

        }

        /*
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
        */
    }

    private void CheckPlaySEPoint()
    {
        if(point_playSE == point_rot_now)
        {
            if (!checkSE)
            {
                checkSE = true;
                SoundManager.instance.PlaySE(0);
            }
        }
        else
        {
            checkSE = false;
        }
        
    }

    public void RotateInit()
    {
        Swich = false;

        rotate_speed = rotate_speed_init;
    }
}