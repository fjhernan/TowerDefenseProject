using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private bool occupied;
    public void UpdateStatus(bool status){
        occupied = status;
    }
    public bool Status(){
        bool temp = occupied;
        return temp;
    }
}
