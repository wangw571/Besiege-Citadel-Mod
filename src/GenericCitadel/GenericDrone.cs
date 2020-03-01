using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class GenericDrone: MonoBehaviour
    {
        public abstract void Operation();

        public abstract void UponDestoryed();
    }
}
