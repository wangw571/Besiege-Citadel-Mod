using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod.EntityScript
{
    public abstract class GenericModule:MonoBehaviour
    {

        public GameObject target = null;

        public abstract void Operation();

        //public abstract void UponDestoryed();

        public virtual void SetTarget(GameObject newTarget)
        {
            target = newTarget;
        }

        public virtual bool CheckIfAttackable(Vector3 worldPosition)
        {
            return false;
        }

        public virtual void FixedUpdate()
        {
            Operation();
        }
    }
}