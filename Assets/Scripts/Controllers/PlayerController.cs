using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    private bool _mouseMoved = false;
    private Vector3 _mouseDest;

    void Start()
    {
        Managers.Input.KeyAction -= OnMove;
        Managers.Input.KeyAction += OnMove;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void Update()
    {
        if(_mouseMoved)
        {
            Vector3 dir = _mouseDest - transform.position;
            if(dir.magnitude < 0.001f)
            {
                _mouseMoved = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(Time.deltaTime * _speed, 0, dir.magnitude); // 목적지가 얼마 안남았을 때를 위해
                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);
            }
        }
    }

    private void OnMove()
    {
        // 갯앰프드 방식

        // Local -> World
        // TransformDirection
        // transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);

        // World -> Local
        // InverseTransformDirection

        Vector3 movePosition = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.3f); // Wolrd Position
            movePosition += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f); // Wolrd Position
            movePosition += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f); // Wolrd Position
            movePosition += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f); // Wolrd Position
            movePosition += Vector3.right;
        }
        movePosition = movePosition.normalized;
        transform.position += movePosition * Time.deltaTime * _speed;

        _mouseMoved = false;
    }

    private void OnMouseClicked(Defines.MouseEvent mouseEvent)
    {
        if (mouseEvent == Defines.MouseEvent.Press)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            LayerMask layerMask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(ray, out hit, 40, layerMask))
            {
                _mouseMoved = true;
                _mouseDest = hit.point;
            }
        }
    }
}
