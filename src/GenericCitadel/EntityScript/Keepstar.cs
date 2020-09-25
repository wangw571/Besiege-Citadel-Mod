using System.Collections.Generic;
using System.Linq;
using System.Text;
using Localisation;
using UnityEngine;

namespace CitadelMod.EntityScript
{
    public class KeepstarScript : GenericCombatCitadel
    {
        public override void deploySelf(Vector3 scale, Vector3 position, Quaternion rotation, Dictionary<string, MToggle> SelectedContracts)
        {
            base.deploySelf(scale, position, rotation, SelectedContracts);
            this.HP = 500000000 * HPMultiplier;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
