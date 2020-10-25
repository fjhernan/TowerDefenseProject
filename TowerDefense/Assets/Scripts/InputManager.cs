using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc.name == "Enemy_1(Clone)")
                {
                    bc.GetComponent<Enemy_1>().Hurt();
                }
            }
        }
    }
}
