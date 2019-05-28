using System;
using System.Collections;
using System.Collections.Generic;
using Arena.AI;
using Arena.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arena.General
{
    public class Health : MonoBehaviour
    {


        public float health = 100f;

        private CharacterAnimation animationScript;
        private AIMovement enemyMovement;

        private bool characterDied;
        public bool isPlayer;


        private void Awake()
        {
            animationScript = GetComponent<CharacterAnimation>();
        }

        public void ApplyDamage(float damage, bool knockDown)
        {
            if (characterDied)
                return;

            health -= damage;
            
            // Display health UI

            if (health <= 0)
            {
                animationScript.Death();
                characterDied = true;

                // If it's a player then deactivate enemy script
                if (isPlayer)
                {
                    GameObject.FindWithTag(TagManager.ENEMY_TAG).GetComponent<AIMovement>().enabled = false;
                }
                return;
            }

            if (!isPlayer)
            {
                if (knockDown)
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        animationScript.KnockDown();
                    }
                }
                else
                {
                    if (Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
        }
    }
}