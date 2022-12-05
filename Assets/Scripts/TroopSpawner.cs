using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSpawner : MonoBehaviour
{
    enum Team
    {
        Blue,
        Red
    }

    public GameObject[] troopPrefabs;
    public Collider blueSpawn;
    public Collider redSpawn;
    public void SpawnTroop(int type)
    {
        GameObject toSpawn = troopPrefabs[type];
        Vector3 min, max;
        if (type < 3) {
            min = blueSpawn.bounds.min;
            max = blueSpawn.bounds.max;
            GameController.Instance.tropasCivA++;
        } else {
            min = redSpawn.bounds.min;
            max = redSpawn.bounds.max;
            GameController.Instance.tropasCivB++;
        }
        
        Vector3 pointToSpawn = new Vector3(
            Random.Range(min.x, max.x),
            1.5f,
            Random.Range(min.z, max.z)
        );

        GameObject.Instantiate(toSpawn, pointToSpawn, toSpawn.transform.rotation);
    }
}
