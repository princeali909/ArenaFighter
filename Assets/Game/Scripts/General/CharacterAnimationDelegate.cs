using System;
using System.Collections;
using System.Collections.Generic;
using Arena.Helper;
using UnityEngine;
using Arena.AI;
using Arena.Camera;
using UnityEditor;

namespace Arena.General
{
    public class CharacterAnimationDelegate : MonoBehaviour
    {

        public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;

        public float standUpTimer = 2f;
        private CharacterAnimation animationScript;


        private AudioSource audioSource;
        
        [SerializeField]
        private AudioClip whooshSound, fallSound, groundHitSound, deadSound;

        private AIMovement enemyMovement;

        private ShakeCamera shakeCamera;

        private void Awake()
        {
            animationScript = GetComponent<CharacterAnimation>();

            audioSource = GetComponent<AudioSource>();

            if (gameObject.CompareTag(TagManager.ENEMY_TAG))
            {
                enemyMovement = GetComponentInParent<AIMovement>();
            }

            shakeCamera = GameObject.FindWithTag(TagManager.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
        }

        void LeftArmAttackOn()
        {
            leftArmAttackPoint.SetActive(true);
        }
        
        void LeftArmAttackOff()
        {
            if (leftArmAttackPoint.activeInHierarchy)
            {
                leftArmAttackPoint.SetActive(false);
            }
        }
        
        
        void RightArmAttackOn()
        {
            rightArmAttackPoint.SetActive(true);
        }
        
        void RightArmAttackOff()
        {
            if (rightArmAttackPoint.activeInHierarchy)
            {
                rightArmAttackPoint.SetActive(false);
            }
        }
        
        
        void RightLegAttackOn()
        {
            rightLegAttackPoint.SetActive(true);
        }
        
        void RightLegAttackOff()
        {
            if (rightLegAttackPoint.activeInHierarchy)
            {
                rightLegAttackPoint.SetActive(false);
            }
        }
        
        
        void LeftLegAttackOn()
        {
            leftLegAttackPoint.SetActive(true);
        }
        
        void LeftLegAttackOff()
        {
            if (leftLegAttackPoint.activeInHierarchy)
            {
                leftLegAttackPoint.SetActive(false);
            }
        }


        void TagRightArm()
        {
            rightArmAttackPoint.tag = TagManager.RIGHT_ARM_TAG;
        }

        void UntagRightArm()
        {
            rightArmAttackPoint.tag = TagManager.UNTAGGED_TAG;
        }
        
        void TagRightLeg()
        {
            rightLegAttackPoint.tag = TagManager.RIGHT_LEG_TAG;
        }

        void UntagRightLeg()
        {
            rightLegAttackPoint.tag = TagManager.UNTAGGED_TAG;
        }


        void EnemyStandup()
        {
            StartCoroutine(StandUpAfterTime());
        }

        IEnumerator StandUpAfterTime()
        {
            yield return new WaitForSeconds(standUpTimer);
            animationScript.Standup();
        }

        public void AttackFXSound()
        {
            audioSource.volume = 0.2f;
            audioSource.clip = whooshSound;
            audioSource.Play();
        }

        public void CharacterDiedSound()
        {
            audioSource.volume = 1f;
            audioSource.clip = deadSound;
            audioSource.Play();
        }

        public void enemyKnockDown()
        {
            audioSource.clip = fallSound;
            audioSource.Play();
        }
        
        public void enemyHitGround()
        {
            audioSource.clip = groundHitSound;
            audioSource.Play();
        }

        void DisableMovement()
        {
            enemyMovement.enabled = false;
            
            // Sets enemy to default layer
            transform.gameObject.layer = 0;
        }

        void EnableMovement()
        {
            enemyMovement.enabled = true;
            
            // Sets enemy back to enemy layer
            transform.gameObject.layer = 11;
        }

        void ShakeCameraOnFall()
        {
            shakeCamera.ShouldShake = true;
        }

        void CharacterDied()
        {
            Invoke("DeactivateGameObject", 2f);
        }

        void DeactivateGameObject()
        {
            //EnemyManager.instance.SpawnEnemy();
            
            gameObject.SetActive(false);
        }
        
    }

}