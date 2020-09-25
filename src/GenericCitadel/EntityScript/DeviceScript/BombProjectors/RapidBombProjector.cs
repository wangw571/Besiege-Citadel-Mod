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
    public class RapidBombProjector : BombProjector
    {
        private int timeForCD = 0;
        public override void Operation()
        {
            timeForCD -= 1;
            if (timeForCD <= 0 && target != null && CheckIfAttackable(target.transform.position))
            {
                
                    timeForCD = 100;
                    GameObject BombballRapid = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    BombballRapid.transform.position = this.transform.position;
                    BombBall BBR = BombballRapid.AddComponent<BombBall>();
                    BBR.targetPosition = target.transform.position + target.GetComponent<Rigidbody>().velocity;
                
            }
        }
        public override bool CheckIfAttackable(Vector3 worldPosition)
        {
            return (this.transform.position - worldPosition).sqrMagnitude < 500 * 500;
        }
    }
}
