using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Wagon : MonoBehaviour
{
    private bool _wagonIsSelected = false;
    private float _targetRotation;
    [SerializeField]
    private Image BackButtonImage;

    void Awake()
    {
        SwipeManager.OnWasSwipe += RotateWagon;
        EventHandler.OnBackButtonWasClicked += ThrowDownWagon;
    }

    private void RotateWagon(Vector2 value)
    {
        if (_wagonIsSelected)
        {
            _targetRotation += value.x;
            transform.rotation = Quaternion.Euler(transform.rotation.x, _targetRotation, transform.rotation.z);
        }
    }


    async void OnMouseDown()
    {
        
        ThrowUpWagon();
    }

    private void ThrowUpWagon()
    {
        if (!_wagonIsSelected)
        {
            BackButtonImage.enabled = true;
            CameraRotation.Instance.AllowReadSwipeData = false;
            _wagonIsSelected = true;
            transform.DOMove(transform.position + Vector3.up, 0.3f);
        }
    }
    private void ThrowDownWagon()
    {
        if (_wagonIsSelected)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            BackButtonImage.enabled = false;
            transform.DOMove(transform.position + Vector3.down, 0.3f).OnComplete(() =>
            {
                CameraRotation.Instance.AllowReadSwipeData = true;
                _wagonIsSelected = false;
            });
        }
    }

    void OnDestroy()
    {
        SwipeManager.OnWasSwipe -= RotateWagon;
        EventHandler.OnBackButtonWasClicked -= ThrowDownWagon;
    }
}
