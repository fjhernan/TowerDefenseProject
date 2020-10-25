using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy_one;
    public GameObject PM;
    public GameObject WaypointManager;
    public Transform spawnPoint;
    public ArrayList enemies = new ArrayList();
    private PurseManager pmComponent;
    private WaypointManager wmComponent;
    private int currentIndex = 2;
    private const float movement = 1.0f;
    void Start()
    {
        pmComponent = PM.GetComponent<PurseManager>();
        wmComponent = WaypointManager.GetComponent<WaypointManager>();
        SpawnEnemies();
        foreach(GameObject e in enemies){
            e.GetComponent<Enemy_1>().SetWaypoint(wmComponent.waypoints[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject e in enemies){
            Enemy_1 ec = e.GetComponent<Enemy_1>();
            ec.Movement(movement);
            if((ec.Distance() == true) && (currentIndex < wmComponent.waypoints.Count))
            {
                ec.SetWaypoint(wmComponent.waypoints[currentIndex]);
                currentIndex++;
            }
        }
    }

    private void SpawnEnemies(){
        GameObject temp = GameObject.Instantiate(Enemy_one, spawnPoint);
        enemies.Add(temp);
    }

    public void EnemyDestroyed(){
        pmComponent.EarnCoins(3);
        enemies.RemoveAt(0);
    }
}