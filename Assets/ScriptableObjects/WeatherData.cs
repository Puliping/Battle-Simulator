using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Object/Weather Data", order = 1)]
public class WeatherData : ScriptableObject
{
    public float speed = 0;
    public float attackRange = 0;
    public float visibilityRange = 0;
    public float attackDamage = 0;
    public float attackInterval = 0;
    public float defense = 0;
    public float accuracy = 0;
}
