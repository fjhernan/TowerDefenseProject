using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    private int index;
    private int health = 3;
    private Queue enemies = new Queue();
    private float ti = 0;
    private bool remove;
    public GameObject HealthBar;
    public Sprite H2;
    public Sprite H3;
    private GameObject hp;
    private LineRenderer lr;
    private void Start()
    {
        // health = 3;
        lr = GetComponent<LineRenderer>();
        hp = GameObject.Instantiate(HealthBar, transform);
        hp.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
    }

    private void Update()
    {
        GameObject temp = null;
        if(enemies.Count > 0)
            temp = enemies.Peek() as GameObject;
        if(temp != null){
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, temp.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Enemy_1(Clone)")
        {
            lr.enabled = true;
            enemies.Enqueue(other.gameObject);
        }  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Enemy_1(Clone)")
        {
            GameObject temp = null; //= enemies.Peek() as GameObject;

            do
            {
                if(enemies.Count >= 1)
                    temp = enemies.Peek() as GameObject;
                else if(enemies.Count == 0){
                    break;
                }
                if(temp == null)
                {
                    enemies.Dequeue();
                }

            } while (temp == null);

            ti += Time.deltaTime;
            if (ti > 3.0f)
            {
                if (temp != null)
                {
                    remove = temp.GetComponent<Enemy>().Hurt();
                    if (remove == false)
                    {
                        enemies.Dequeue();
                        remove = true;
                    }
                }
                ti = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Enemy_1(Clone)")
        {
            Debug.Log("Enemy left");
            enemies.Dequeue();
            if (enemies.Count == 0)
                lr.enabled = false;
        }
    }

    public void Hurt(){
        health--;
        if (health == 2)
        {
            hp.GetComponent<SpriteRenderer>().sprite = H2;
        }
        if (health == 1)
        {
            hp.GetComponent<SpriteRenderer>().sprite = H3;
        }
        if(health == 0) { 
            //GameObject.Find("TowerManager").GetComponent<TowerManager>().RemoveTower(index);
            Destroy(gameObject);
        }
    }

    public void UpdateIndex(){
        index--;
    }

    public void SetIndex(int ind)
    {
        Debug.Log(ind);
        index = ind;
    }

    
}
