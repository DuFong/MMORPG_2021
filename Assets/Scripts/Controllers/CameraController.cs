using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Defines.CameraMode _cameraMode = Defines.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta;

    [SerializeField]
    private GameObject _player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);
    }
}
