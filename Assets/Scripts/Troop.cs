using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Range(0f, 1f)]
    public float accuracy;

    private LayerMask enemyLayer;
    private Troop target;
    private bool inCombat => target != null;
    [HideInInspector] public Vector3 moveTarget;

    public Rigidbody rb;
    public FieldOfView fov;

    private bool attacking;

    private Weather weather;

    private Terrain terrain;

    private float effects(string key) => weather?.effects[key] + terrain?.effects[key] ?? 1;

    [SerializeField] private Slider slider;

    private void Awake() {
        StartCoroutine(ChooseNewMoveTarget());
    }

    IEnumerator ChooseNewMoveTarget() {
        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        moveTarget = new Vector3(x, 1.5f, z);
        yield return new WaitForSeconds(5f);
        StartCoroutine(ChooseNewMoveTarget());
    }

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
            if (moveTarget == null) return;
            if (Vector3.Distance(transform.position, moveTarget) < .1) return;
            transform.LookAt(moveTarget);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    IEnumerator AttackRoutine()
    {
        attacking = true;
        while (target != null && Vector3.Distance(transform.position, target.transform.position) < attackRange)
        {
            Attack(target);
            yield return new WaitForSeconds(attackInterval);
        }
        attacking = false;
    }

    private void Attack(Troop enemy)
    {
        float admg = attackDamage * effects("attackDamage");
        float damage = admg * hpPercent;
        damage -= damage * moraleReduction;
        enemy.TakeDamage(damage, this.transform.position);
    }

    private void TakeDamage(float damage, Vector3 from)
    {
        float def = defense * effects("defense");
        float taken = Mathf.Min(Mathf.Max(damage - def, damage * 0.05f), hp);
        hp -= taken;
        slider.value = hpPercent;
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
        else
        {
            transform.LookAt(from);
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void ChangeClimate(Weather next)
    {
        weather = next;
    }

    private void ChangeTerrain(Terrain next)
    {
        terrain = next;
    }

    private void Move(Transform target)
    {
        moveTarget = target.position;
    }
}
