using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HealthBar;
    //public GameObject particleEffect;
    public Sprite H2;
    public Sprite H3;
    private GameObject hp;
    private int arrayIndex;
    private int wayIndex = 1;
    private int health;
    private int loot;
    private Transform waypoint;
    private Queue towers = new Queue();
    private float ti = 0.0f;
    private LineRenderer lr;

    public void WhenCreated(int ty, int ind, Transform target) {
        if (ty == 1)
        {
            health = 3;
            loot = 3;
            hp = GameObject.Instantiate(HealthBar, transform);
            hp.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
        arrayIndex = ind;
        waypoint = target;
        lr = GetComponent<LineRenderer>();
        lr.SetColors(Color.black, Color.green);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tower(Clone)")
        {
            //lr.enabled = true;
            towers.Enqueue(other.gameObject);
        }
    }

    private void Update()
    {
        GameObject temp = null;
        if (towers.Count > 0)
            temp = towers.Peek() as GameObject;
        if (temp != null)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, temp.transform.position);
        }
        if(health == 0)
        {
            Death();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Tower(Clone)")
        {
            GameObject temp = null; //= towers.Peek() as GameObject;
            do
            {
                if(towers.Count >= 1)
                    temp = towers.Peek() as GameObject;

                if (temp == null)
                {
                    towers.Dequeue();
                }
                
                if (towers.Count == 0)
                    break;
            } while (temp == null);


            ti += Time.deltaTime;
            if (ti > 4.0f)
            {
                if (temp != null)
                {
                    //foreach (GameObject tower in towers)
                    // {
                    //   if (tower != null)
                    //     tower.GetComponent<Tower>().Hurt();
                    //}
                    temp.GetComponent<Tower>().Hurt();
                }
                ti = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tower(Clone)")
        {
            towers.Dequeue();
            if(towers.Count == 0)
            {
                lr.enabled = false;
            }
        }
    }

    public void UpdateArrayIndex() {
        arrayIndex--;
    }

    public int GetWaypointIndex() {
        int temp = wayIndex;
        return temp;
    }

    public void UpdateWayPointIndex() {
        wayIndex++;
    }
    public bool Hurt() {
        health--;
        if (health == 2)
            hp.GetComponent<SpriteRenderer>().sprite = H2;
        if (health == 1)
            hp.GetComponent<SpriteRenderer>().sprite = H3;
        if (health == 0) {
            return false;
        }
        return true;
    }

    public void Movement(float movement) {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, movement * Time.deltaTime);
    }

    public bool Distance() {
        if (Vector3.Distance(transform.position, waypoint.position) <= 0.1f)
            return true;

        return false;
    }
    public void SetWaypoint(Transform wp) {
        waypoint = wp;
    }

    private void Death(){
        GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>().EarnCoins(loot);
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().EnemyDestroyed(arrayIndex);
        Destroy(gameObject);
    }
}
