using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public float maxHP;
    private float hp;
    private float hpPercent => Mathf.Max(hp / maxHP, 0);
    public float attack;
    public float defense;
    public float maxMorale;
    private float morale;
    private float moraleReduction => (1 - Mathf.Max(morale / maxMorale, 0)) * .2f;
    public float speed;
    public float attackRange;

    private LayerMask enemyLayer;
    private SoldierAI target;

    public Rigidbody rb;
    public FieldOfView fov;

    private bool attacking;

    void Start()
    {
        hp = maxHP;
        morale = maxMorale;

        enemyLayer = gameObject.layer == LayerMask.NameToLayer("TroopBlue") ?
            LayerMask.NameToLayer("TroopRed") : LayerMask.NameToLayer("TroopBlue");
    }

    // Update is called once per frame
    void Update()
    {
        target = fov.closestEnemy;
        if (target != null)
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
    }

    IEnumerator AttackRoutine()
    {
        attacking = true;
        while (Vector3.Distance(transform.position, target.transform.position) < attackRange)
        {
            Attack(target);
            yield return new WaitForSeconds(.4f);
        }
        attacking = false;
    }

    private void Attack(SoldierAI enemy)
    {
        float damage = attack * hpPercent;
        damage -= damage * moraleReduction;
        enemy.TakeDamage(damage);
        Debug.Log($"attacking for {damage}");
    }

    private void TakeDamage(float damage)
    {
        float taken = Mathf.Min(Mathf.Max(damage - defense, damage * 0.05f), hp);
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
}
