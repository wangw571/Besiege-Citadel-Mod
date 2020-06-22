using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class GenericDevice : ModBlockBehaviour
    {

        public MSlider MSSeed;
        public MMenu MMTab;


        public abstract void Operation();

        public abstract void UponDestoryed();

        public void CheckIfAttackable(Vector3 worldPosition)
        {

        }

    }
}
