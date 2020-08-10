﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Localisation;
using UnityEngine;

namespace CitadelMod.EntityScript
{
    public class KeepstarScript : GenericCombatCitadel
    {
        public override void deploySelf(Vector3 scale, Vector3 position, Quaternion rotation, Dictionary<string, Contract> existingContract)
        {
            base.deploySelf(scale, position, rotation, existingContract);
            this.HP = 5000000 * HPMultiplier;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}