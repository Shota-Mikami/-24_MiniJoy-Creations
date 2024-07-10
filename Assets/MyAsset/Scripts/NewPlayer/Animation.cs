using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Animation : MonoBehaviour
{

    private bool is_ground;

    [SerializeField]
    private GameObject nmp_tail;
    [SerializeField]
    private GameObject nmp_body;


    // 目標の方向ベクトル
    public Transform targetDirection;
    public Transform self;

    private bool left_right = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        //身体の反転


        if (!Input.GetMouseButton(0))
        {

            if (Input.GetAxis("Horizontal") != 0)
            {

                if (Input.GetAxis("Horizontal") < 0)
                {
                    left_right = true;
                }
                else
                {
                    left_right = false;
                }

            }

        }
        if (left_right)
        {
            nmp_body.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
            transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        }
        else
        {
            nmp_body.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }

        if (!this.GetComponent<Animator>().GetBool("flg_move") &&
            !this.GetComponent<Animator>().GetBool("flg_jump") &&
            !this.GetComponent<Animator>().GetBool("flg_swing") &&
            !this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_idle", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_idle", false);
        }


        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            this.GetComponent<Animator>().SetBool("flg_move", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_move", false);
        }



        //ジャンプ
        RaycastHit hit;

            if (Physics.Raycast(nmp_body.transform.position, new Vector3(0.0f, -1.0f, 0.0f), out hit, 1.0f))
            {
                if (hit.collider.tag == "Field")
                {
                    is_ground = true;

                    this.GetComponent<Animator>().SetBool("flg_jump", false);
                }
            }
            else
            {
                is_ground = false;
                this.GetComponent<Animator>().SetBool("flg_jump", true);
            }


        if (!nmp_tail.GetComponent<NMP_Tail>().GetIsCatched())
        {
            this.GetComponent<Animator>().SetBool("flg_fly", true);


            transform.rotation = Quaternion.LookRotation(targetDirection.position - self.position, Vector3.up);


        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_fly", false);


        }
        if (Input.GetMouseButton(0))
        {
            this.GetComponent<Animator>().SetBool("flg_swing", true);
            this.GetComponent<Animator>().SetBool("flg_jump", false);
            this.GetComponent<Animator>().SetBool("flg_move", false);

            this.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            if (left_right)
            {
                this.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
            }
            else
            {
                this.transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);
            }

        }
 

        if (Input.GetMouseButtonUp(0))
        {
            this.GetComponent<Animator>().SetBool("flg_swing", false);
            this.GetComponent<Animator>().SetBool("flg_fly", true);
            this.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }


        if (this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_jump", false);
        }

        if(this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_jump", false);
            this.GetComponent<Animator>().SetBool("flg_move", false);
            this.GetComponent<Animator>().SetBool("flg_swing", false);

        }

        
    }
}
