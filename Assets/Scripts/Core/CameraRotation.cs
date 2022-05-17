using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private List<Transform> LocomotivesTransform = new List<Transform>();
    [SerializeField]
    [Header("Sensative of camera")]
    private float _cameraRotationSensative = 100f;
    internal bool AllowReadSwipeData = false;
    internal static CameraRotation Instance;

    void Start()
    {
            Instance = this;

        SwipeManager.OnWasSwipe += SetMovementOfCamera;
        Locomotive.OnLocomotiveWasArrived += () =>
        {
            AllowReadSwipeData = true;
        };
    }


    private void SetMovementOfCamera(Vector2 targetRotation)
    {
        if (!AllowReadSwipeData) return;

        transform.position += new Vector3(targetRotation.x * _cameraRotationSensative, 0f, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LocomotivesTransform[0].position.x, LocomotivesTransform[LocomotivesTransform.Count - 1].position.x), Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    void OnDestroy()
    {
        SwipeManager.OnWasSwipe -= SetMovementOfCamera;
    }
}
