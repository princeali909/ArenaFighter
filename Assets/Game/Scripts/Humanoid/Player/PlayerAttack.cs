using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arena.General;

public enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2,
    KICK3
}


namespace Arena.Player
{
    public class PlayerAttack : MonoBehaviour
    {

        private CharacterAnimation playAnim;

        private bool activateTimerReset;

        private float defaultComboTimer = 0.4f;
        private float currentComboTimer;

        private ComboState currentComboState;

        private void Awake()
        {
            playAnim = GetComponentInChildren<CharacterAnimation>();
        }

        // Start is called before the first frame update
        void Start()
        {
            currentComboTimer = defaultComboTimer;
            currentComboState = ComboState.NONE;
        }

        // Update is called once per frame
        void Update()
        {
            ComboAttacks();
            ResetComboState();
        }


        void ComboAttacks()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (currentComboState == ComboState.PUNCH3 || currentComboState == ComboState.KICK1 ||
                    currentComboState == ComboState.KICK2 || currentComboState == ComboState.KICK3)
                {
                    return;
                }
                
                
                currentComboState++;
                activateTimerReset = true;
                currentComboTimer = defaultComboTimer;

                if (currentComboState == ComboState.PUNCH1)
                {
                    playAnim.Punch1();
                }
                if (currentComboState == ComboState.PUNCH2)
                {
                    playAnim.Punch2();
                }
                if (currentComboState == ComboState.PUNCH3)
                {
                    playAnim.Punch3();
                }
                
            } // Punch
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                // No combos left to perform.
                if (currentComboState == ComboState.KICK3 || currentComboState == ComboState.PUNCH3)
                {
                    return;
                }
                
                // Allow chain combo between punches and kicks
                if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH1 || 
                    currentComboState == ComboState.PUNCH2)
                {
                    currentComboState = ComboState.KICK1;
                } else if (currentComboState == ComboState.KICK1 || currentComboState == ComboState.KICK2)
                {
                    currentComboState++;
                }
                
                activateTimerReset = true;
                currentComboTimer = defaultComboTimer;
                
                if (currentComboState == ComboState.KICK1)
                {
                    playAnim.Kick1();
                }
                if (currentComboState == ComboState.KICK2)
                {
                    playAnim.Kick2();
                }
                if (currentComboState == ComboState.KICK3)
                {
                    playAnim.Kick3();
                }
                
            } //Kick
            
        }

        void ResetComboState()
        {
            if (activateTimerReset)
            {
                currentComboTimer -= Time.deltaTime;

                if (currentComboTimer <= 0f)
                {
                    currentComboState = ComboState.NONE;

                    activateTimerReset = false;
                    currentComboTimer = defaultComboTimer;
                }
            }
        }

    }

}
