using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HealthBar;
    public Sprite H2;
    public Sprite H3;
    private GameObject h;
    public int index;
    private int health; 
    private int loot;
    private Transform waypoint;
    public void WhenCreated(int ty, int ind, Transform target){
        if(ty == 1)
        {
            health = 3;
            loot = 3;
            h = GameObject.Instantiate(HealthBar, transform);
            h.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
        index = ind;
        waypoint = target;
    }

    void Update(){
        if (health <= 0)
        {
            Death();
        }
    }

    public void UpdateIndex(int ind){
        index = ind;
    }

    public void Hurt(){
        health--;
        if(health == 2)
            h.GetComponent<SpriteRenderer>().sprite = H2;
        if (health == 1)
            h.GetComponent<SpriteRenderer>().sprite = H3;
    }

    public void Movement(float movement){
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, movement * Time.deltaTime);
    }

    public bool Distance(){
        if (Vector3.Distance(transform.position, waypoint.position) <= 0.1f)
            return true;

        return false;
    }
    public void SetWaypoint(Transform wp){
        waypoint = wp;
    }

    private void Death(){
        GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>().EarnCoins(loot);
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().EnemyDestroyed(index);
        Destroy(gameObject);
    }
}
