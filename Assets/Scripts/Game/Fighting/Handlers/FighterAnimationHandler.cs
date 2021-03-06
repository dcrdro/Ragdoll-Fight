﻿using Game.Fighting.Shooting;
using Game.General;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class FighterAnimationHandler : MonoBehaviour
    {
        private readonly int jumpHash = Animator.StringToHash("Jump");
        private readonly int shootHash = Animator.StringToHash("Shoot");
    
        [SerializeField] private Animator animator;
    
        [SerializeField] private Jumper jumper;
        [SerializeField] private Weaponer weaponer;

        private void OnEnable()
        {
            jumper.Jumped += OnJumped;
            weaponer.WeaponApplied += OnWeaponApplied;
        }

        private void OnDisable()
        {
            jumper.Jumped -= OnJumped;
            weaponer.WeaponApplied -= OnWeaponApplied;
        }

        private void OnJumped() => animator.SetTrigger(jumpHash);
        private void OnWeaponApplied() => animator.SetTrigger(shootHash);
    }
}
