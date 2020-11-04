﻿using UnityEngine;

namespace Core.Effects
{
    public abstract class EffectorBase : MonoBehaviour
    {
        public EffectBase[] effects;

        protected void PlayEffects()
        {
            foreach (var effect in effects)
            {
                effect.Play();
            }
        }
    }
}