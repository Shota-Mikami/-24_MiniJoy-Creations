using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_move : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private bool _active = true;

    private Vector3 _localPos;

    // Start is called before the first frame update
    void Start()
    {
        _localPos = this.transform.position - _player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            this.transform.position = _player.position + _localPos;
        }
    }
}
