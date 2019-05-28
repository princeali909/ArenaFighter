using System;
using System.Collections;
using System.Collections.Generic;
using Arena.Helper;
using UnityEngine;

namespace Arena.General
{
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator anim;


        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Walk(bool move)
        {
            anim.SetBool(TagManager.MOVEMENT, move);
        }

        public void Punch1()
        {
            anim.SetTrigger(TagManager.PUNCH_1_TRIGGER);
            
        }
        
        public void Punch2()
        {
            anim.SetTrigger(TagManager.PUNCH_2_TRIGGER);
            
        }
        
        public void Punch3()
        {
            anim.SetTrigger(TagManager.PUNCH_3_TRIGGER);
            
        }
        
        public void Kick1()
        {
            anim.SetTrigger(TagManager.KICK_1_TRIGGER);
            
        }
        
        public void Kick2()
        {
            anim.SetTrigger(TagManager.KICK_2_TRIGGER);
            
        }
        
        public void Kick3()
        {
            anim.SetTrigger(TagManager.KICK_3_TRIGGER);
            
        }
        
        
        // AI Animations
        
        // Enemy Attack
        public void EnemyAttack(int attack)
        {
            if (attack == 0)
            {
                anim.SetTrigger(TagManager.ATTACK_1_TRIGGER);
            }
            if (attack == 1)
            {
                anim.SetTrigger(TagManager.ATTACK_2_TRIGGER);
            }
            if (attack == 2)
            {
                anim.SetTrigger(TagManager.ATTACK_3_TRIGGER);
            }
        }


        public void PlayIdleAnimation()
        {
            anim.Play(TagManager.IDE_ANIMATION);
        }

        public void KnockDown()
        {
            anim.SetTrigger(TagManager.KNOCK_DOWN_TRIGGER);
        }
        
        public void Standup()
        {
            anim.SetTrigger(TagManager.STAND_UP_TRIGGER);
        }

        public void Hit()
        {
            anim.SetTrigger(TagManager.HIT_TRIGGER);
        }
        
        public void Death()
        {
            anim.SetTrigger(TagManager.DEATH_TRIGGER);
        }



    }
    
}
