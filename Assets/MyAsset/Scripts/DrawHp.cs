using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawHp : MonoBehaviour
{
    [SerializeField] Sprite hpImage;
    [SerializeField] GameObject Nmp_body;
    // Start is called before the first frame update
   

    public void SetLifeGauge(int hp)
    {
        //　最後のライフゲージを削除
        if (hp - 1 >= 0)
            Destroy(transform.GetChild(hp - 1).gameObject);
    }

    public void ReserLifeGuage(int hp)
    {
        //一旦全部削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        GameObject gameObject = new GameObject();
        Image newImage = gameObject.AddComponent<Image>();
        newImage.sprite = hpImage;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);

        for (int i = 0; i < hp; i++)
        {
            Instantiate(gameObject, transform);
        }
    }

    void Start()
    {
        ReserLifeGuage(Nmp_body.GetComponent<NMP_Body>().hpMax);
    }
}
