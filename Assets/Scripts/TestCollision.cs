using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision !!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger !!");
    }
    void Start()
    {
        
    }

    void Update()
    {
        //// *** Local <-> World
        //// 캐릭터의 Local forward -> World forward
        //Vector3 look = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position + Vector3.up, look * 10);

        //// Raycast 맨 처음 맞는 물체만 검출
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        //{
        //    Debug.Log($"Hit!! : {hit.transform.gameObject.name}");
        //}

        //// Raycast 관통 !! 여러 물체 검출
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        //foreach(RaycastHit h in hits)
        //{
        //    Debug.Log($"RaycastAll : {h.transform.gameObject.name}");
        //}




        ////// Local <-> World <-> Screen  기본적인 단계
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;
        //    dir = dir.normalized;

        //    Debug.DrawRay(Camera.main.transform.position, 10 * dir, Color.red, 1.0f);

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 10))
        //    {
        //        Debug.Log(hit.transform.gameObject.name);
        //    }
        //}



        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 10, Color.blue, 1.0f);

            RaycastHit hit;

            //int layer = (1 << 8); // 8번째 비트 활성화(Monster) or
            LayerMask layer = LayerMask.GetMask("Monster");

            if(Physics.Raycast(ray, out hit, 10, layer)) // layerMask = Bit Flag
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
