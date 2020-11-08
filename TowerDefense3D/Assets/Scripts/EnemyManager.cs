using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy_1;
    public GameObject WaypointManager;
    private WaypointManager wmComponent;
    public float movement = 2.0f;
    private ArrayList enemies = new ArrayList();
    private int size;
    public int spawnAmount = 0;
    public GameObject ParticleEffect;
    public void StartGame()
    {
        Debug.Log("SpawnAmount" + spawnAmount);
        wmComponent = WaypointManager.GetComponent<WaypointManager>();
        size = wmComponent.waypoints.Count - 1;
        InvokeRepeating("CreateEnemy", 0.5f, 1.0f);   
    }

    void Update()
    {
        foreach (GameObject e in enemies)
        {
            Enemy ec = e.GetComponent<Enemy>();
            ec.Movement(movement);
            if ((ec.Distance() == true) && (ec.GetWaypointIndex() < size))
            {
                ec.SetWaypoint(wmComponent.waypoints[ec.GetWaypointIndex() + 1]);
                ec.UpdateWayPointIndex();
            }
            else if ((ec.Distance() == true) && (ec.GetWaypointIndex() >= size)){
                GameObject.Find("GameManager").GetComponent<GameManager>().GameEnds('f');
            }
        }
    }

    public void Restart(){
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
        enemies.Clear();
        spawnAmount = 0;
    }

    void CreateEnemy()
    {
        GameObject temp = Instantiate(Enemy_1, wmComponent.waypoints[0]);
        temp.GetComponent<Enemy>().WhenCreated(1, spawnAmount, wmComponent.waypoints[1]);
        enemies.Add(temp);
        spawnAmount++;
        if(spawnAmount >= 4)
        {
            Debug.Log(spawnAmount);
            CancelInvoke();
        }
    }

    public void EnemyDestroyed(int index)
    {
        GameObject temp = enemies[index] as GameObject;
        Vector3 tpos = new Vector3(temp.transform.position.x, temp.transform.position.y, temp.transform.position.z - 0.1f);
        GameObject Particle = Instantiate(ParticleEffect, tpos, Quaternion.identity);
        Destroy(Particle, 2.0f);
        int i = 0;
        foreach(GameObject enemy in enemies){
            if(i >= index){
                enemy.GetComponent<Enemy>().UpdateArrayIndex();
            }
            i++;
        }

        enemies.RemoveAt(index);

        if(enemies.Count == 0){
            GameObject.Find("GameManager").GetComponent<GameManager>().GameEnds('t');
        }
    }
}
