using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public float maxHP;
    private float hp;
    private float hpPercent => Mathf.Max(hp / maxHP, 0);
    public float attackDamage;
    public float attackInterval;
    public float defense;
    public float maxMorale;
    private float morale;
    private float moraleReduction => (1 - Mathf.Max(morale / maxMorale, 0)) * .2f;
    public float speed;
    public float visibilityRange;
    public float attackRange;

    [Range(0f,1f)]
    public float accuracy;

    private LayerMask enemyLayer;
    private Troop target;
    private bool inCombat => target != null;
    private Transform moveTarget;

    public Rigidbody rb;
    public FieldOfView fov;

    private bool attacking;

    private Climate climate;
    
    private Terrain terrain;

    private float effects(string key) => climate.effects[key] + terrain.effects[key];

    void Start()
    {
        fov.radius = visibilityRange;
        hp = maxHP;
        morale = maxMorale;

        enemyLayer = gameObject.layer == LayerMask.NameToLayer("TroopBlue") ?
            LayerMask.NameToLayer("TroopRed") : LayerMask.NameToLayer("TroopBlue");
    }

    void Update()
    {
        target = fov.closestEnemy;
        if (inCombat)
        {
            target = fov.closestEnemy;
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) >= attackRange)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (!attacking)
            {
                StartCoroutine(AttackRoutine());
            }
        }
        else
        {
            if(moveTarget == null) return;
            transform.LookAt(moveTarget);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    IEnumerator AttackRoutine()
    {
        attacking = true;
        while (Vector3.Distance(transform.position, target.transform.position) < attackRange)
        {
            Attack(target);
            yield return new WaitForSeconds(attackInterval);
        }
        attacking = false;
    }

    private void Attack(Troop enemy)
    {
        float admg = attackDamage + effects("attackDamage");
        float damage = admg * hpPercent;
        damage -= damage * moraleReduction;
        enemy.TakeDamage(damage);
        Debug.Log($"attacking for {damage}");
    }

    private void TakeDamage(float damage)
    {
        float def = defense + effects("defense");
        float taken = Mathf.Min(Mathf.Max(damage - def, damage * 0.05f), hp);
        hp -= taken;
        Debug.Log($"took {taken} damage");
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("died");
        Destroy(this.gameObject);
    }

    private void ChangeClimate(Climate next) {
        climate = next;
    }

    private void ChangeTerrain(Terrain next){
        terrain = next;
    }

    private void Move(Transform target) {
        moveTarget = target;
    }
}
