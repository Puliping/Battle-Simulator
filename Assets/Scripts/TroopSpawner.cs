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

    public Collider blueSpawn;
    public GameObject blueInfantry;
    // public GameObject blueCavalry;
    // public GameObject blueArcher;
    public Collider redSpawn;
    public GameObject redInfantry;
    // public GameObject redCavalry;
    // public GameObject redArcher;
    public void SpawnTroop(bool red)
    {
        GameObject toSpawn;
        Vector3 min, max;
        if (red) {
            toSpawn = redInfantry;
            min = redSpawn.bounds.min;
            max = redSpawn.bounds.max;
        } else {
            toSpawn = blueInfantry;
            min = blueSpawn.bounds.min;
            max = blueSpawn.bounds.max;
        }

        Vector3 pointToSpawn = new Vector3(
            Random.Range(min.x, max.x),
            1.5f,
            Random.Range(min.z, max.z)
        );

        GameObject.Instantiate(toSpawn, pointToSpawn, toSpawn.transform.rotation);
    }
}
