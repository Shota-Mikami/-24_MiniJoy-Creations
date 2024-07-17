//================================================================================
//NoModelPlayer
//================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP_Body : MonoBehaviour
{
    private float speed_move = 25.0f;
    private float speed_jump = 1.0f;
    private Rigidbody rb;
    private bool is_ground;

    public int hpMax = 3;
    public int hpNow;
    public int damageCoolTime = 120;
    public int damageCoolTimeNow = 0;
    public float knockbackPower = 10.0f;

    [SerializeField]
    private GameObject nmp_tail;

    public GameObject HpUI;

    void Start()
    {
        hpNow = hpMax;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //横移動
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed_move, ForceMode.Impulse);

        //ジャンプ
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            if (hit.collider.tag == "Field")
            {
                is_ground = true;
            }
        }
        else
        {
            is_ground = false;
        }

        if (is_ground && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && nmp_tail.GetComponent<NMP_Tail>().GetIsCatched())
        {
            rb.velocity = Vector3.zero;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (is_ground)
            {
                rb.AddForce(Vector3.up * speed_jump, ForceMode.Impulse);
            }
        }

        damageCoolTimeNow++;
        damageCoolTimeNow = Mathf.Min(damageCoolTime, damageCoolTimeNow);
    }

    public void SetMoveSpeed(float sp)
    {
        speed_move = sp;
    }

    public void SetJumpSpeed(float sp)
    {
        speed_jump = sp;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //敵との当たり判定処理
        if (damageCoolTimeNow >= damageCoolTime)
        {
            if (collision.gameObject.tag == "BossEnemy" || collision.gameObject.tag == "Enemy")
            {
                hpNow--;
                hpNow = Mathf.Max(hpNow, 0);

                damageCoolTimeNow = 0;

                //Hitした敵とのベクトルを取りAddForceでノックバック処理を行う
                Vector3 vec;
                vec = transform.position - collision.transform.position;
                Vector3.Normalize(vec);

                float knockback = vec.x * knockbackPower;

                rb.AddForce(new Vector3(knockback,0.0f,0.0f), ForceMode.Impulse);

                HpUI.GetComponent<DrawHp>().SetLifeGauge(hpNow);
            }
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            Debug.Log("チェックポイント");
            collision.gameObject.GetComponent<CheckPoint>().Check();
        }
    }

}