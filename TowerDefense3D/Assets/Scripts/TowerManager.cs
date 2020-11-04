using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private ArrayList towers = new ArrayList();
    
    public void AddTowers(GameObject tower){
        tower.GetComponent<Tower>().SetIndex(towers.Count - 1);
        towers.Add(tower);
    }

    public void RemoveTower(int index){
        towers.RemoveAt(index);
        int i = 0;
        foreach(GameObject tower in towers){
            if(i >= index){
                tower.GetComponent<Tower>().UpdateIndex();
            }
            i++;
        }
    }
}
