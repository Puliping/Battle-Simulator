using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int tropasCivBlue;
    public int tropasCivRed;
    private bool paused = false;
    public List<Troop> soldiersTeamBlue = new List<Troop>();
    public List<Troop> archersTeamBlue = new List<Troop>();
    public List<Troop> knightsTeamBlue = new List<Troop>();
    public List<Troop> soldiersTeamRed = new List<Troop>();
    public List<Troop> archersTeamRed = new List<Troop>();
    public List<Troop> knightsTeamRed = new List<Troop>();
    public List<Troop> troopList = new List<Troop>();
    public Weather weather;
    private void Awake()
    {
        Instance = this;
    }
    public void TropaDeath(Troop troop)
    {
        if (troop.gameObject.layer == LayerMask.NameToLayer("TroopBlue"))
        {
            tropasCivBlue--;
        }
        else
        {
            tropasCivRed--;
        }

        troopList.Remove(troop);

        if (tropasCivBlue <= 0)
        {
            EndGame(true);
        }
        else if (tropasCivRed <= 0)
        {
            EndGame(false);
        }
    }
    public void EndGame(bool Ateam)
    {
        Time.timeScale = 0f;
        if (Ateam)
        {
            Debug.Log("time A ganhou");
        }
        else
        {
            Debug.Log("time B ganhou");
        }        
    }
    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }    
    public void AddToTroopList(Troop troop)
    {
        troopList.Add(troop);
        troop.weather = weather;
    }    
    public void UpdateWeather(Weather nextWeather) {
        weather = nextWeather;
        foreach (Troop troop in troopList)
            troop.weather = weather;
    }
}
