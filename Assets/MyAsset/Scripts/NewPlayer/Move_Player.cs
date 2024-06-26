//--------------------------------------------------------------
//Playerの移動を管理するもの
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private float speed = 0.0f;     //移動速度
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //横移動
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed , ForceMode.Impulse);
    }

    //移動速度変更関数
    public void SetMoveSpeed(float sp)
    {
        speed = sp;
    }
}
