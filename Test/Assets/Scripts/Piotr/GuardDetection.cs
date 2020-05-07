using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDetection : NavMeshEnemy
{
    public Light spotlight;
    public float viewDistance;
    public LayerMask GuardViewMask;
    float GuardViewAngle;

    Transform player;
public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GuardViewAngle = spotlight.spotAngle;
    }
    public bool PlayerDetected()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 DirectionToPlayer = (player.position - transform.position).normalized;
            float AngleGuardToPlayer = Vector3.Angle(transform.forward, DirectionToPlayer);
            if (AngleGuardToPlayer < GuardViewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, GuardViewMask))
                {
                    return true;
                }
            }
        }
        return false;
       
    }
}
