using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool shoot = false;
    private Rigidbody rb;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){
        if(shoot == true) {
            Debug.Log("shooting");
            rb.velocity = Vector3.MoveTowards(transform.position, direction, 3.0f * Time.deltaTime);
        }
    }

    public void Towards(Transform dir){
        direction = dir.position;
        shoot = true;
    }
}
