using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject CheckPoint;
    [SerializeField] private GameObject GoalPoint;

    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 CheckPos;
    private Vector3 RespawnPos;

    [SerializeField] private string NextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = RespawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        //���X�|�[��
        if(Input.GetKeyDown(KeyCode.R))
        {
            Player.transform.position = RespawnPos;
            //player�̏󋵃��Z�b�g

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
            SceneManager.LoadScene("NextSceneName");
        }
    }
}
