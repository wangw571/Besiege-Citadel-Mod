using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class GenericCitadel : LevelEntity
    {
        public void Targeting()
        {
            throw new NotImplementedException();
        }

        public void UponDestoryed()
        {
            throw new NotImplementedException();
        }

        public void ReinforcedMode()
        {
            throw new NotImplementedException();
        }

        public void DeployDevice(GenericDevice device, Vector3 localPosition, Quaternion localRotation)
        {
            throw new NotImplementedException();
        }

        public Vector3 RandomDevicePositionCast(GenericDevice device)
        {
            throw new NotImplementedException();
        }
    }
}
