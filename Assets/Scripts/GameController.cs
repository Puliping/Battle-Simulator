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
    public void TropaDeath(bool Ateam)
    {
        if (Ateam)
        {
            tropasCivA--;
        }
        else
        {
            tropasCivB--;
        }
        if (tropasCivA <= 0)
        {
            EndGame(true);
        }
        else
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
}
