using System.Collections;
using System.Collections.Generic;
using Arena.Helper;
using UnityEngine;
using Arena.Player;

namespace Arena.General
{
    public class AttackUniversal : MonoBehaviour
    {


        public LayerMask collisionLayer;
        public float radius = 1f;
        public float damage = 2f;

        public bool isPlayer, isEnemy;

        public GameObject hitFX;



        // Update is called once per frame
        void Update()
        {
            DetectCollision();
        }

        void DetectCollision()
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            // If we have collisions
            if (hit.Length > 0)
            {
                int i = 0;
                if (isPlayer)
                {
                    Vector3 hitFXPos = hit[0].transform.position;
                    
                    // Position our hit effect close to the head
                    hitFXPos.y += 1.3f;
                    
                    //If facing the right side
                    // Position hit effect directly in front of enemy
                    if (hit[0].transform.forward.x > 0)
                    {
                        hitFXPos.x += 0.3f;
                    } else if (hit[0].transform.forward.x < 0) // facing left
                    {
                        hitFXPos.x -= 0.3f;
                    }

                    Instantiate(hitFX, hitFXPos, Quaternion.identity);

                    if (gameObject.CompareTag(TagManager.RIGHT_ARM_TAG) ||
                        gameObject.CompareTag(TagManager.RIGHT_LEG_TAG))
                    {
                        if (hit[0].GetComponent<Health>())
                        {
                            hit[0].GetComponent<Health>().ApplyDamage(damage, true);
                        }
                    }
                    else
                    {
                        if (hit[0].GetComponent<Health>())
                        {
                            hit[0].GetComponent<Health>().ApplyDamage(damage, false);
                        }
                    }
                }

                if (isEnemy)
                {
                    hit[0].GetComponent<Health>().ApplyDamage(damage,false);
                }
                
                
                gameObject.SetActive(false);
            }
        }
    }

}
