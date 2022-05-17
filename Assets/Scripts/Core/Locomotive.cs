using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    [SerializeField]
    [Header("Speed of Locomotive movement")]
    private float _speed = 1;
    internal static Action OnLocomotiveWasArrived;


    void Start()
    {
        StartCoroutine(MoveOnStartLine());
    }

    private IEnumerator MoveOnStartLine()
    {
        while (transform.position.x > Camera.main.transform.position.x)
        {
            transform.position += Vector3.left * _speed;
            yield return null;
        }
        OnLocomotiveWasArrived();
    }

}
