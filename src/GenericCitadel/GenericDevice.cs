using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class GenericDevice : LevelEntity
    {
        public abstract void Operation();

        public abstract void UponDestoryed();

        public void CheckIfAttackable(Vector3 worldPosition)
        {

        }

    }
}
