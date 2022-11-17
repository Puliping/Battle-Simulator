using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    public Dictionary<string, float> effects;
    // Start is called before the first frame update
    void Start()
    {
        effects.Add("speed", 0f);
        effects.Add("attackRange", 0f);
        effects.Add("visibilityRange", 0f);
        effects.Add("attackDamage", 0f);
        effects.Add("attackInterval", 0f);
        effects.Add("defense", 0f);
        effects.Add("accuracy", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
