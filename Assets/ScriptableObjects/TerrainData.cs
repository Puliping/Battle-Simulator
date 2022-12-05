using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Object/Terrain Data", order = 1)]
public class TerrainData : ScriptableObject
{
    public float speed = 1;
    public float attackRange = 1;
    public float visibilityRange = 1;
    public float attackDamage = 1;
    public float attackInterval = 1;
    public float defense = 1;
    public float accuracy = 1;
    public float moraleReduction = 1;
}
