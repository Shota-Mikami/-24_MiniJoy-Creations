using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : DestroyObj
{
    public override void Damage(int damage, GameObject gameObject)
    {
        Debug.Log("damage!");
        if (gameObject.transform.childCount == 1)
        {
            Debug.Log("gimmick?");
            if (gameObject.transform.GetChild(0).transform.GetChild(0).tag == "DestroyWall")
            {
                Destroy(this.gameObject);
                Debug.Log("destroy");
            }
            else
            {
                Debug.Log(gameObject.transform.GetChild(0).tag);
            }
        }
    }
}
