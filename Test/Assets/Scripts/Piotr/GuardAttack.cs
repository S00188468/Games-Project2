using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float damage=20;
    public float attackSpeed;        
    bool CheckForPlayerCollision;
    [Range(0,1)]
    public float dashAttackOffset;

    

    public IEnumerator AttackTarget(Transform player)
    {
         
            
            
                CheckForPlayerCollision = true;
                bool HasAppliedDamage = false;
                Vector3 startingPosition = transform.position;
                Vector3 directionToTarget = (player.transform.position - transform.position).normalized;
                Vector3 positionToDashTo = player.transform.position - (directionToTarget * dashAttackOffset);

                float percentageComplete = 0;
            while (percentageComplete <= 1)
            {
                percentageComplete += Time.deltaTime * attackSpeed;
                float interpolation = (-(percentageComplete * percentageComplete) + percentageComplete) * 4;
                transform.position = Vector3.Lerp(startingPosition, positionToDashTo, interpolation);

                if (interpolation >= 0.5f & !HasAppliedDamage)
                {
                 HasAppliedDamage = true;
                }

                yield return null;

            } 
       

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (CheckForPlayerCollision && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthComponent>().ApplyDamage(damage);
        }
    }
}
