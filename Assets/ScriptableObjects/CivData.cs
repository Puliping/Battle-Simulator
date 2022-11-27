using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CivData", order = 1)]

public class CivData : ScriptableObject
{
    /*Soldier*/
    public float speedSoldier;
    public float hpSoldier;

    /*Archer*/
    public float speedArcher;
    public float hpArcher;

    /*Knight*/
    public float speedKnight;
    public float hpKnight;
}
