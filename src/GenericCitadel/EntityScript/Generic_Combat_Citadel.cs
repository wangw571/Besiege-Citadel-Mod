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
        protected bool useWebifier = true;
        protected int BombNum = 3;


        protected StasisWebifierApplier webDevice;
        protected BombProjector bombProjector;
        public override void deploySelf(Vector3 scale, Vector3 position, Quaternion rotation, Dictionary<string, MToggle> SelectedContracts)
        {
            base.deploySelf(scale, position, rotation, SelectedContracts);
            BesiegeConsoleController.ShowMessage(SelectedContracts.Values.Count.ToString());
            foreach (MToggle value in SelectedContracts.Values) // Really horrible design, will refactor soon™
            {
                string key = value.DisplayName;
                BesiegeConsoleController.ShowMessage(key);
                if (key.Contains("100mm"))
                {
                    HPMultiplier = 1.2f;
                }
                else if (key.Contains("800mm"))
                {
                    HPMultiplier = 1.6f;
                }
                else if(key.Contains("25000mm"))
                {
                    HPMultiplier = 3f;
                }
                else if(key.Contains("Void Bomb "))
                {
                    BombNum = 1;
                }
                else if(key.Contains("3 * Void Bombs "))
                {
                    BombNum = 3;
                }
                else if(key.Contains("Rapid"))
                {
                    BombNum = 5;
                }
                else if(key.Contains("Stasis"))
                {
                    useWebifier = true;
                }
            }
            if (useWebifier)
            {
                webDevice = this.gameObject.AddComponent<StasisWebifierApplier>();
            }
            if(BombNum != 0)
            {
                bombProjector = this.gameObject.AddComponent<BombProjector>();
                bombProjector.bombCount = BombNum;
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
                if (BombNum != 0)
                {
                    bombProjector.SetTarget(currentTarget);
                }
            }
        }
    }
}
