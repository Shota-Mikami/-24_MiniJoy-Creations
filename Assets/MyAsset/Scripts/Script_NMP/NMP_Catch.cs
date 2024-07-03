using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP_Catch : MonoBehaviour
{
    [SerializeField] private GameObject player_body_model;
    [SerializeField] private GameObject player_tail_model;
    [SerializeField] private float radius_catch = 1.0f;
    [SerializeField] private float range_catch = 2.0f;
    private GameObject obj_ball = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj_ball)
        {
            obj_ball.transform.position = player_tail_model.transform.position;
            if (Input.GetKeyDown(KeyCode.G))
            {
                ResetTail();
            }
        }
        else
        {
            RaycastHit hit;
            
            if (Physics.SphereCast(player_body_model.transform.position, radius_catch, player_body_model.transform.right, out hit, range_catch))
            {
                if (hit.collider.tag == "ball")
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        obj_ball = hit.collider.gameObject;
                        obj_ball.transform.position = player_tail_model.transform.position;
                        obj_ball.transform.parent = player_tail_model.transform;
                        player_tail_model.GetComponent<NMP_Attack>().SetDamage(obj_ball.GetComponent<Ball>().AttackPower);
                        player_tail_model.GetComponent<NMP_Tail>().SetThrowPowerCoefficient(obj_ball.GetComponent<Ball>().speed_coefficient);
                        Destroy(obj_ball.GetComponent<Rigidbody>());
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(player_body_model.transform.position + player_body_model.transform.right * range_catch, radius_catch);
    }

    public void ResetTail()
    {
        Destroy(obj_ball);
        player_tail_model.GetComponent<NMP_Attack>().ResetDamage();
    }

    public bool GetIsBall()
    {
        if (obj_ball)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetTriggerBall(bool trigger)
    {
        obj_ball.GetComponent<Collider>().isTrigger = trigger;
    }
}
