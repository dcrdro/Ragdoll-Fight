﻿using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Physics
{
    public class RagdollBone : MonoBehaviour, IForceable
    {
        [SerializeField] private Rigidbody2D boneRigidbody;
        [SerializeField] private HingeJoint2D boneJoint;

        public event Action<IForceable, ForceArgs> ForceApplied;

        public void Activate()
        {
            boneRigidbody.isKinematic = false;
            if (boneJoint) boneJoint.enabled = true;
        }

        public void Deactivate()
        {
            boneRigidbody.isKinematic = true;
            if (boneJoint) boneJoint.enabled = false;
        }

        public void ApplyForce(ForceArgs args)
        {
            boneRigidbody.AddForce(args.Force);
            ForceApplied?.Invoke(this, args);
        }

        public void Stop() => boneRigidbody.velocity = Vector2.zero;
    }
}
