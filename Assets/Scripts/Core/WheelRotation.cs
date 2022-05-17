using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField]
    [Header("Speed of wheel rotation")]
    private float _speed;
    private bool _allowRotate = true;

    void Start()
    {
        Locomotive.OnLocomotiveWasArrived += () =>
        {
            _allowRotate = false;
        };
    }
    void FixedUpdate()
    {
        if (_allowRotate)
            transform.Rotate(_speed, 0f, 0f);
    }
}
