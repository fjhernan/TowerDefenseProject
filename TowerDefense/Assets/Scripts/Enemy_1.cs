using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    private int health = 3;
    private Transform waypoint;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            Death();
        }
    }

    public void Hurt(){
        health--;
        Debug.Log(health);
    }

    public void Movement(float movement){
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, movement * Time.deltaTime);
    }

    public bool Distance()
    {
        if (Vector3.Distance(transform.position, waypoint.position) <= 0.1f)
            return true;

        return false;
    }
    public void SetWaypoint(Transform wp){
        waypoint = wp;
    }

    private void Death(){
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().EnemyDestroyed();
        Destroy(gameObject);
    }
}
