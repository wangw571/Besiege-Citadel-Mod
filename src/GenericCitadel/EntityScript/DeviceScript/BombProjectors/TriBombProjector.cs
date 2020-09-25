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
    public class TriBombProjector : BombProjector
    {
        private int timeForCD = 0;
        public override void Operation()
        {
            timeForCD -= 1;
            if (timeForCD <= 0 && target != null && CheckIfAttackable(target.transform.position))
            {
                System.Random randomGen = new System.Random((int)Time.fixedDeltaTime);
                timeForCD = 400;
                for (int i = 0; i <= 3; ++i)
                {
                    GameObject Bombball = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Bombball.name = i.ToString();
                    Bombball.transform.position = this.transform.position;
                    BombBall BBB = Bombball.AddComponent<BombBall>();
                    BBB.targetPosition = target.transform.position + target.GetComponent<Rigidbody>().velocity;
                    BBB.targetPosition += new Vector3((2.5f - (float)randomGen.Next(0, 5)), (2.5f - (float)randomGen.Next(0, 5)), (2.5f - (float)randomGen.Next(0, 5))) * 3;
                    d.l(BBB.targetPosition);
                }
            }
        }

        public override bool CheckIfAttackable(Vector3 worldPosition)
        {
            return (this.transform.position - worldPosition).sqrMagnitude < 400 * 400;
        }
    }
}
