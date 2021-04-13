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
        if (_cameraMode == Defines.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
    }
}
