using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public class Generic_Combat_Citadel : GenericCitadel
    {
        public override void OnPrefabCreation()
        {
            base.OnPrefabCreation();
            MMContracts.Items.Add("Durability - 100mm Steel Plates - ⚀"); // + 10%
            MMContracts.Items.Add("Durability - 800mm Steel Plates - ⚁"); // + 100%
            MMContracts.Items.Add("Durability - 25000mm Steel Plates - ⚂"); // + 500%
            MMContracts.Items.Add("Durability - Damage Control I - ⚀"); // Module Damage -50%
            MMContracts.Items.Add("Durability - Damage Control II - ⚁"); // Module Damage -80%

            MMContracts.Items.Add("Weaponry - Rear-Aspect Missile - ⚀"); // + 10%
            MMContracts.Items.Add("Weaponry - High Maneuveribility Missile - ⚁"); // + 100%
            MMContracts.Items.Add("Weaponry - Poxy Fuse Missile - ⚁"); // + 500%

            MMContracts.Items.Add("Weaponry - Rear-Aspect Missile - ⚀"); // + 10%
            MMContracts.Items.Add("Weaponry - High Maneuveribility Missile - ⚁"); // + 100%
            MMContracts.Items.Add("Weaponry - Poxy Fuse Missile - ⚁"); // + 500%
        }
    }
}
