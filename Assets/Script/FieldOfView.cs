using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FieldOfView : MonoBehaviour
{

    public float radius = 5f;
    [Range(1, 360)]public float angle = 90f;

    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    [SerializeField]
    private float chaseSpeed;
    [SerializeField]
    private float walkSpeed;

    public bool CanSeePlayer { get; private set; }

    private AIDestinationSetter destinationSetterScript;
    private AIPath AIPathScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FOVCheck());
        destinationSetterScript = GetComponent<AIDestinationSetter>();
        AIPathScript = GetComponent<AIPath>();
    }

    // Update is called once per frame

    void Update()
    {
        if (CanSeePlayer)
        {
            destinationSetterScript.EnemySeesPlayer = true;
            AIPathScript.maxSpeed = chaseSpeed;
        }
        else
        {
            destinationSetterScript.EnemySeesPlayer = false;
            AIPathScript.maxSpeed = walkSpeed;
        }
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, directionToTarget.x, obstructionLayer))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
            }
        } else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }
}
