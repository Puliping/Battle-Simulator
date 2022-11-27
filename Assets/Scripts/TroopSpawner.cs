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
    public void SpawnTroop(bool red)
    {
        // TODO do stuff
        // Somar a tropa que for spawnada para a tropa respectiva
        GameController.Instance.tropasCivA++;
        GameController.Instance.tropasCivB++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
