using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���N���b�N��������Ă��邩�ǂ��������o
        if (Input.GetMouseButton(0)) // 0 �͍��N���b�N
        {
            // ���N���b�N��������Ă���ԁA�X�v���C�g�����_���[��L���ɂ���
            spriteRenderer.enabled = true;
        }
        else
        {
            // ���N���b�N��������Ă��Ȃ��Ƃ��A�X�v���C�g�����_���[�𖳌��ɂ���
            spriteRenderer.enabled = false;
        }
    }
}
