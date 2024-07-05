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
    [SerializeField]
    private GameObject nmp_tail;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //‰¡ˆÚ“®
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed_move, ForceMode.Impulse);

        //ƒWƒƒƒ“ƒv
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

        Debug.Log(Input.GetAxis("Horizontal"));
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
    }

    public void SetMoveSpeed(float sp)
    {
        speed_move = sp;
    }

    public void SetJumpSpeed(float sp)
    {
        speed_jump = sp;
    }
}
