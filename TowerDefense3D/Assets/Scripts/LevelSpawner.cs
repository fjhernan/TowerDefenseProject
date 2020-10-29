using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject Hill;
    public GameObject Border;
    public GameObject Path;
    public GameObject TowerPlacement;
    public Transform Spawnpoint;
    public string filename;
    public float y_position = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel();       
    }

    private void SpawnLevel(){
        string file = string.Format(Application.dataPath + "/Resources/" + filename);
        using (StreamReader sr = new StreamReader(file)){
            string line = "";

            
            while((line = sr.ReadLine()) != null){
                int column = -8;
                char[] letters = line.ToCharArray();
                foreach(var letter in letters){
                    SpawnBlock(letter, new Vector3(column, y_position, 0.0f));
                    column++;
                }
                //row--;
                y_position--;
            }
            sr.Close();
        }
    }

    private void SpawnBlock(char type, Vector3 newSpawn){
        GameObject temp = null;

        switch (type){
            case 'h':
                temp = GameObject.Instantiate(Hill, Spawnpoint);
                break;
            case 'p':
                temp = GameObject.Instantiate(Path, Spawnpoint);
                break;
            case 'b':
                temp = GameObject.Instantiate(Border, Spawnpoint);
                break;
            case 't':
                temp = GameObject.Instantiate(TowerPlacement, Spawnpoint);
                break;
            default:
                break;
        }
        temp.transform.position = newSpawn;
    }
}
