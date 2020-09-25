//SS_RPC_200_PPI-24
using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Common;

namespace CitadelMod.EntityScript.DeviceScript
{
    public class ArmorPlate800 : GenericModule
    {
        protected bool Applied = false;
        public override void Operation()
        {
            parentCitadel.HPMultiplier = 3;
        }
        public override bool CheckIfAttackable(Vector3 worldPosition)
        {
            return (this.transform.position - worldPosition).sqrMagnitude < 500 * 500;
        }
    }
}
