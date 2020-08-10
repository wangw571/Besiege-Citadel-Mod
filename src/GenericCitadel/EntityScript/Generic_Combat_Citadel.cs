using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Common;
using CitadelMod.EntityScript.DeviceScript;

namespace CitadelMod.EntityScript
{
    public abstract class GenericCombatCitadel : GenericCitadel
    {
        protected bool useWebifier = false;
        protected StasisWebifierApplier webDevice;
        protected int BombNum = 0;
        public override void deploySelf(Vector3 scale, Vector3 position, Quaternion rotation, Dictionary<string, Contract> existingContract)
        {
            base.deploySelf(scale, position, rotation, existingContract);
            foreach (string key in existingContract.Keys) // Really horrible design, will refactor soon™
            {
                if (key.Contains("Stasis Webifier"))
                {
                    useWebifier = true;
                }
                if (key.Contains("100mm"))
                {
                    HPMultiplier = 1.2f;
                }
                if (key.Contains("800mm"))
                {
                    HPMultiplier = 1.6f;
                }
                if (key.Contains("25000mm"))
                {
                    HPMultiplier = 3f;
                }
                if(key.Contains("Void Bomb "))
                {
                    BombNum = 1;
                }
                if (key.Contains("3 * Void Bombs "))
                {
                    BombNum = 3;
                }
                if (key.Contains("Rapid"))
                {
                    BombNum = 5;
                }
                if (key.Contains("Stasis"))
                {
                    useWebifier = true;
                }
            }
            if (useWebifier)
            {
                webDevice = this.gameObject.AddComponent<StasisWebifierApplier>();
            }
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (currentTarget != null) { 
                if (useWebifier)
                {
                    //BesiegeConsoleController.ShowMessage("Web Attempt");
                    webDevice.SetTarget(currentTarget);
                }
        }
        }
    }
}
