using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int tropasCivA;
    public int tropasCivB;
    private bool paused = false;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TropaDeath(Troop troop)
    {
        if (troop.gameObject.layer == LayerMask.NameToLayer("TroopBlue"))
        {
            tropasCivA--;
        }
        else
        {
            tropasCivB--;
        }

        troopList.Remove(troop);

        if (tropasCivA <= 0)
        {
            EndGame(true);
        }
        else if (tropasCivB <= 0)
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

    List<Troop> troopList = new List<Troop>();
    public void AddToTroopList(Troop troop)
    {
        troopList.Add(troop);
        troop.weather = weather;
    }

    public Weather weather;
    public void UpdateWeather(Weather nextWeather) {
        weather = nextWeather;
        foreach (Troop troop in troopList)
            troop.weather = weather;
    }
}
