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
    private int currentIndex = 1;
    public void StartGame()
    {
        wmComponent = WaypointManager.GetComponent<WaypointManager>();
        SpawnEnemies(wmComponent.waypoints[0], wmComponent.waypoints[currentIndex]);
    }

    void Update()
    {
        foreach (GameObject e in enemies)
        {
            Enemy ec = e.GetComponent<Enemy>();
            ec.Movement(movement);
            if ((ec.Distance() == true) && (currentIndex < wmComponent.waypoints.Count))
            {
                ec.SetWaypoint(wmComponent.waypoints[currentIndex]);
                currentIndex++;
            }
        }
    }

    private void SpawnEnemies(Transform spawnpoint, Transform targetWaypoint){
        GameObject temp = Instantiate(Enemy_1, spawnpoint);
        temp.GetComponent<Enemy>().WhenCreated(1, 0, targetWaypoint);
        enemies.Add(temp);
    }

    public void EnemyDestroyed(int index)
    {
        enemies.RemoveAt(index);
        if(enemies.Count == 0){
            GameObject.Find("GameManager").GetComponent<GameManager>().GameEnds();
        }
    }
}
