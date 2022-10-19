using System.Collections;
using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)] public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [HideInInspector] public SoldierAI closestEnemy;

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        Array.Sort(rangeChecks, (a, b) =>
        {
            float distA = Vector3.Distance(this.transform.position, a.transform.position);
            float distB = Vector3.Distance(this.transform.position, b.transform.position);
            return distA.CompareTo(distB);
        });

        foreach (Collider item in rangeChecks)
        {
            Transform target = item.transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    closestEnemy = item.transform.parent.GetComponent<SoldierAI>();
                    return;
                }
            }
        }
        
        closestEnemy = null;
    }
}
