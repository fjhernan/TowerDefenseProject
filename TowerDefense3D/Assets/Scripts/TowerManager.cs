using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private ArrayList towers = new ArrayList();
    
    public void RestartDefeat(){
        foreach(GameObject tower in towers){
            if(tower != null)
                Destroy(tower);
        }
        towers.Clear();
    }
    
    public void AddTowers(GameObject tower){
        tower.GetComponent<Tower>().SetIndex(towers.Count - 1);
        towers.Add(tower);
    }
    /*
    public void RemoveTower(int index){
        int i = 0;
        foreach(GameObject tower in towers){
            if(i >= index){
                tower.GetComponent<Tower>().UpdateIndex();
            }
            i++;
        }

        towers.RemoveAt(index);
    }*/
}
