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
    private int layerMask;
    public GameObject[] troopPrefabs;
    private int intToSpawn;
    private Vector3 pointToSpawn = new Vector3(0, 0, 0);
    public void SpawnTroop(int type)
    {
        intToSpawn = type;
    }
    private void CanSpawnTroop(int type)
    {
        GameObject toSpawn = troopPrefabs[type];
        if (type < 3)
        {
            GameController.Instance.tropasCivBlue++;
        }
        else
        {
            GameController.Instance.tropasCivRed++;
        }

        Troop troop = GameObject.Instantiate(toSpawn, pointToSpawn, toSpawn.transform.rotation).GetComponentInChildren<Troop>();
        GameController.Instance.AddToTroopList(troop);
        SetLists(type, troop);
    }
    private void SetLists(int type, Troop troop)
    {
        switch (type)
        {
            case 0:
                GameController.Instance.soldiersTeamBlue.Add(troop);
                break;
            case 1:
                GameController.Instance.archersTeamBlue.Add(troop);
                break;
            case 2:
                GameController.Instance.knightsTeamBlue.Add(troop);
                break;
            case 3:
                GameController.Instance.soldiersTeamRed.Add(troop);
                break;
            case 4:
                GameController.Instance.archersTeamRed.Add(troop);
                break;
            case 5:
                GameController.Instance.knightsTeamRed.Add(troop);
                break;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) // you can also only accept hits to some layer and put your selectable units in this layer
            {
                if (hit.collider.tag == "Floor")
                {
                    pointToSpawn = hit.point + new Vector3(0, 1.5f, 0);
                    CanSpawnTroop(intToSpawn);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Debug.Log("entrou time scale 2");
                Time.timeScale = 2;
            }
            else if(Time.timeScale == 2)
            {
                Debug.Log("entrou time scale 0");
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("entrou time scale 1");
                Time.timeScale = 1;
            }
        }
    }
    private void Start()
    {
        layerMask = 1 << 8;
        Time.timeScale = 0;
    }
}
