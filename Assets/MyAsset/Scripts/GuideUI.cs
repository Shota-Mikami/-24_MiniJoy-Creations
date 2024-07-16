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
        // 左クリックが押されているかどうかを検出
        if (Input.GetMouseButton(0)) // 0 は左クリック
        {
            // 左クリックが押されている間、スプライトレンダラーを有効にする
            spriteRenderer.enabled = true;
        }
        else
        {
            // 左クリックが押されていないとき、スプライトレンダラーを無効にする
            spriteRenderer.enabled = false;
        }
    }
}
