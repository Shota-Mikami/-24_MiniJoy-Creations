using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP_Attack : MonoBehaviour
{
    [SerializeField] private int damage_attack_init = 1;
    private int damage_attack;

    void Start()
    {
        damage_attack = damage_attack_init;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("HIT");
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "BossEnemy")
        {
            coll.gameObject.GetComponent<Enemy>().Damage(damage_attack);
        }

        if (coll.gameObject.tag == "DestroyObj")
        {
            coll.gameObject.GetComponent<DestroyObj>().Damage(1, this.gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        damage_attack = damage;
    }
    public void ResetDamage()
    {
        damage_attack = damage_attack_init;
    }
}
