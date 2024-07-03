//================================================================================
//NoModelPlayer
//================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP_Tail : MonoBehaviour
{
    private float speed_swing = 2.0f;
    private float power_throw_max = 5.0f;
    private float power_throw_charge = 0.1f;
    private float power_throw_coefficient = 1.0f;

    private float power_throw = 0.0f;
    //private float time_count_swing = 0.0f;
    private float vec_throw_z = 0.0f;
    private Rigidbody rb;

    private bool is_catched = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //ハンマー回転
        if (Input.GetMouseButton(0))
        {
            vec_throw_z += 360.0f * (Time.deltaTime / speed_swing);
            if(vec_throw_z > 180.0f)
            {
                vec_throw_z -= 360.0f;
            }

            power_throw += power_throw_charge;
            power_throw = Mathf.Min(power_throw, power_throw_max);
        }

        //ハンマー射出
        if (Input.GetMouseButtonUp(0))
        {
            is_catched = false;
            rb.isKinematic = false;
            rb.AddForce(transform.right * power_throw, ForceMode.Impulse);
        }

        //ハンマー回収
        if (Input.GetMouseButton(1))
        {
            CatchTail();
        }

        //ハンマー物理演算管理
        if (is_catched)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, vec_throw_z);
            rb.isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
            if (transform.parent.GetComponent<NMP_Catch>().GetIsBall())
            {
                transform.parent.GetComponent<NMP_Catch>().SetTriggerBall(true);
            }
        }
        else
        {
            rb.isKinematic = false;
            GetComponent<Collider>().isTrigger = false;
            if (transform.parent.GetComponent<NMP_Catch>().GetIsBall())
            {
                transform.parent.GetComponent<NMP_Catch>().SetTriggerBall(false);
            }
        }
    }

    public bool GetIsCatched()
    {
        return is_catched;
    }

    public void CatchTail()
    {
        is_catched = true;
        rb.isKinematic = true;
        vec_throw_z = 0.0f;
    }

    public void SetSwingSpeed(float sp)
    {
        speed_swing = sp;
    }

    public void SetThrowPowerMax(float pow)
    {
        power_throw_max = pow;
    }

    public void SetThrowPowerCharge(float pow)
    {
        power_throw_charge = pow;
    }

    public void SetThrowPowerCoefficient(float pow)
    {
        power_throw_coefficient = pow;
    }
}
