using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float zoomOutSpeed = 0;    //�J�����������X�s�[�h
    public float limit;�@�@�@�@�@     //�J������Z���̌��E�ʒu
    public float moveCameraSpeed = 0.01f; //�J�������ړ�����X�s�[�h�@
    public float moveCameraLimit = 10; //�J�������ړ��ł�����E�l
    private float moveCameraPower = 0.04f; //�J�����̈ړ���
    public Vector2 cameraOffsetXY;
    private Vector3 cameraTargetPos;
    private float lerpRatio;
    public float lerpSpeed;
    private bool isRight = true;
    private bool oldisRight;

    float zOS = 0;

    float mCS = 0;
    float mCL = 0;
    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        lerpRatio = 0.0f;

        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            isRight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRight = false;
        }

        lerpRatio += lerpSpeed;
        lerpRatio = Mathf.Min(lerpRatio, 1.0f);
        if (isRight != oldisRight)
        {
            lerpRatio = 0.0f;
        }

        if (isRight)
        {
            cameraTargetPos = new Vector3(target.transform.position.x + cameraOffsetXY.x, target.transform.position.y + cameraOffsetXY.y, transform.position.z);
        }
        else
        {
            cameraTargetPos = new Vector3(target.transform.position.x - cameraOffsetXY.x, target.transform.position.y + cameraOffsetXY.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, cameraTargetPos, lerpRatio);

        if (Input.GetMouseButton(0) && transform.position.z >= -limit)
        {
            zOS = zoomOutSpeed;
        }
        else if (transform.position.z != -20)
        {
            zOS = -zoomOutSpeed;
        }
        else
        {
            zOS = 0;
        }

        transform.position += -transform.forward * zOS;


        if (Input.GetKey("d"))
        {
            mCS = moveCameraSpeed;
            mCL = moveCameraLimit;
        }
        if (Input.GetKey("a"))
        {
            mCS = -moveCameraSpeed;
            mCL = -moveCameraLimit;
        }

        moveCameraPower += mCS;

        if (mCL < moveCameraPower && mCS > 0)
        {
            moveCameraPower = mCL;
        }
        if (mCL > moveCameraPower && mCS < 0)
        {
            moveCameraPower = mCL;
        }

        oldisRight = isRight;
    }
}
