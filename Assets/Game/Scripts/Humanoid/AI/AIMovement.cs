using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Arena.Helper;
using Arena.Player;
using UnityEngine;
using Random = System.Random;
using Arena.General;

namespace Arena.AI
{

    
    public class AIMovement : MonoBehaviour
    {
        private CharacterAnimation enemyAnimation;
        private Rigidbody myBody;

        public float speed = 1.8f;
        public float attackDistance = 1.3f;
        public float chasePlayerAfterAttack = 1f;
        private float rotationSpeed = 3f;

        private Transform playerTarget;

        private float currentAttackTime;
        private float defaultAttackTime = 2f;

        private bool followPlayer, attackPlayer;

        private Transform myChild;
        private Transform playerChild;

        private void Awake()
        {
            enemyAnimation = GetComponentInChildren<CharacterAnimation>();
            myBody = GetComponent<Rigidbody>();
            playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
            myChild = transform.GetChild(0);
            playerChild = playerTarget.GetChild(0);
        }


        // Start is called before the first frame update
        void Start()
        {
            followPlayer = true;
            currentAttackTime = defaultAttackTime;
        }

        // Update is called once per frame
        void Update() {
            Attack();
            
        }

        private void FixedUpdate()
        {
            FollowTarget();
            
        }


        void FollowTarget()
        {
            if (!followPlayer) return;

            // If not in attack range, then follow
            if (Vector3.Distance(myChild.position, playerChild.position) > attackDistance)
            {
                myChild.LookAt(playerChild);
                myBody.velocity = myChild.forward * speed;

                if(myBody.velocity.sqrMagnitude != 0) {
                    enemyAnimation.Walk(true);   
                }
                
            }
            else if (Vector3.Distance(myChild.position, playerChild.position) <= attackDistance)
            {
                // Stop moving and attack
                myBody.velocity = Vector3.zero;
                enemyAnimation.Walk(false);
                followPlayer = false;
                attackPlayer = true;
            }
        }


        void Attack()
        {
            // Exit if we shouldn't attack player
            if (!attackPlayer) return;

            currentAttackTime += Time.deltaTime;

            if (currentAttackTime > defaultAttackTime)
            {
                enemyAnimation.EnemyAttack(UnityEngine.Random.Range(0,3));

                // Reset
                currentAttackTime = 0f;
            }

            if (Vector3.Distance(myChild.position, playerChild.position) > 
                attackDistance + chasePlayerAfterAttack)
            {
                attackPlayer = false;
                followPlayer = true;
            }

        }

        
    }

}