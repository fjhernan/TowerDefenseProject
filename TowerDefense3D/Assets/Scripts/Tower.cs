using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private int index;
    private int health;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
    }

    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
    }
    public void Hurt(){
        health--;
        if(health == 0){

            GameObject.Find("TowerManager").GetComponent<TowerManager>().RemoveTower(index);
            Destroy(gameObject);
        }
    }

    public void UpdateIndex(){
        index--;
    }

    public void SetIndex(int ind)
    {
        index = ind;
    }

    
}
