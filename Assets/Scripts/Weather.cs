using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public static Weather Instance;
    public WeatherData data;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        UpdateDict();
    }

    public Dictionary<string, float> effects;
    private void UpdateDict()
    {
        effects.Add("speed", data.speed);
        effects.Add("attackRange", data.attackRange);
        effects.Add("visibilityRange", data.visibilityRange);
        effects.Add("attackDamage", data.attackDamage);
        effects.Add("attackInterval", data.attackInterval);
        effects.Add("defense", data.defense);
        effects.Add("accuracy", data.accuracy);
    }
}
