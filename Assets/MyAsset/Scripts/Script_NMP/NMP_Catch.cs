using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP_Catch : MonoBehaviour
{
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject tail;
    [SerializeField] private float radius_catch = 1.0f;
    [SerializeField] private float range_catch = 2.0f;
    private GameObject obj_ball = null;


    public RectTransform CatchUI;//‚±‚ê‚ÉUI‚ðŽæ‚è•t‚¯‚é
    // Start is called before the first frame update
    void Start()
    {

        CatchUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (obj_ball)
        {
            CatchUI.gameObject.SetActive(false);
            obj_ball.transform.position = tail.transform.position;
            if (Input.GetKeyDown(KeyCode.G))
            {
                ResetTail();
            }
        }
        else
        {
            RaycastHit hit;
            
            if (Physics.SphereCast(body.transform.position, radius_catch, body.transform.forward, out hit, range_catch))
            {
                if (hit.collider.tag == "ball")
                {

                    CatchUI.gameObject.SetActive(true);
                    CatchUI.position = RectTransformUtility.WorldToScreenPoint(Camera.main, hit.collider.transform.position);//UI‚ÌˆÊ’u‚ÌˆÚ“®
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        obj_ball = hit.collider.gameObject;
                        obj_ball.transform.position = tail.transform.position;
                        obj_ball.transform.parent = tail.transform;
                        tail.GetComponent<NMP_Attack>().SetDamage(obj_ball.GetComponent<Ball>().AttackPower);
                        tail.GetComponent<NMP_Tail>().SetThrowPowerCoefficient(obj_ball.GetComponent<Ball>().speed_coefficient);
                        Destroy(obj_ball.GetComponent<Rigidbody>());
                    }
                }
            }
            else
            {

                CatchUI.gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(body.transform.position + body.transform.forward * range_catch, radius_catch);
    }

    public void ResetTail()
    {
        Destroy(obj_ball);
        tail.GetComponent<NMP_Attack>().ResetDamage();
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

    public void SetPosBall(Vector3 pos)
    {
        obj_ball.transform.position = pos;
    }
}
