using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimTerrain : MonoBehaviour
{
    public Dictionary<string, float> effects = new Dictionary<string, float>();
    public TerrainData data;
    // Start is called before the first frame update
    void Start()
    {
        effects.Add("speed", data.speed);
        effects.Add("attackRange", data.attackRange);
        effects.Add("visibilityRange", data.visibilityRange);
        effects.Add("attackDamage", data.attackDamage);
        effects.Add("attackInterval", data.attackInterval);
        effects.Add("defense", data.defense);
        effects.Add("accuracy", data.accuracy);
    }

    private void OnTriggerEnter(Collider other)
    {
        Troop troop = other.GetComponentInChildren<Troop>();

        if (troop != null)
            troop.terrain = this;
    }
}
