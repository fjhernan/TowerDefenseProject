using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject Tower;
    // Update is called once per frame
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
                    bc.GetComponent<Enemy>().Hurt();
                }
                else if(bc.name == "TowerPlacement(Clone)"){
                    Purse temp = GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>();
                    if(temp.GetCoins() >= 5){
                        Debug.Log("Tower Placed");
                        Vector3 v = new Vector3(hit.transform.position.x, hit.transform.position.y, -0.1f);
                        GameObject t = Instantiate(Tower, v, Quaternion.identity);
                        //GameObject t = Instantiate(Tower, tra);
                        GameObject.Find("TowerManager").GetComponent<TowerManager>().AddTowers(t);
                        bc.GetComponent<TowerPlacement>().UpdateStatus(true);
                        temp.Buying(5);
                    }
                    else if(temp.GetCoins() < 5){
                        Debug.Log("Not enough coins");
                    }
                }
            }
        }
    }
}
