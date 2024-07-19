using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Nmp_body;

    [SerializeField] private GameObject CheckPoint;
    [SerializeField] private GameObject GoalPoint;
    [SerializeField] private GameObject HpUI;

    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 CheckPos;
    private Vector3 RespawnPos;

    [SerializeField] private string NextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Nmp_body.transform.position = RespawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        //���X�|�[��
        if(Nmp_body.GetComponent<NMP_Body>().hpNow <= 0.0f)
        {
            Nmp_body.transform.position = RespawnPos;
            //player�̏󋵃��Z�b�g
            Nmp_body.GetComponent<NMP_Body>().hpNow = Nmp_body.GetComponent<NMP_Body>().hpMax;
            Nmp_body.GetComponent<Rigidbody>().velocity = Vector3.zero;

            HpUI.GetComponent<DrawHp>().ReserLifeGuage(Nmp_body.GetComponent<NMP_Body>().hpMax);
        }

        //���X�|�[���X�V
        if (CheckPoint)
        {
            RespawnPos = StartPos;
        }
        else
        {
            RespawnPos = CheckPos;
        }

        //�S�[��
        if (!GoalPoint)
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
