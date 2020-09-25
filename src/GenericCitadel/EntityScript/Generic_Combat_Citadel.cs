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
        protected List<GenericModule> Modules = new List<GenericModule>();

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
                    Modules.Add(this.gameObject.AddComponent<BombProjector>());
                }
                else if(key.Contains("3 * Void Bombs "))
                {
                    Modules.Add(this.gameObject.AddComponent<TriBombProjector>());
                }
                else if(key.Contains("Rapid"))
                {
                    Modules.Add(this.gameObject.AddComponent<RapidBombProjector>());
                }
                else if(key.Contains("Stasis"))
                {
                    Modules.Add(this.gameObject.AddComponent<StasisWebifierApplier>());
                }
            }
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (currentTarget != null) {
                foreach (GenericModule module in Modules)
                {
                    module.SetTarget(currentTarget);
                }
            }
        }
    }
}
