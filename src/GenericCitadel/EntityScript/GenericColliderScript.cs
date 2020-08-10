using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Serialization;

namespace CitadelMod.EntityScript
{
    public class GenericColliderScript : MonoBehaviour
    {
        public GenericCitadel sourceCitadel;
        public virtual void OnCollisionEnter(Collision collision)
        {
            sourceCitadel.HP -= Mathf.Pow(UnityEngine.Vector3.Dot(collision.impactForceSum, collision.transform.position - this.transform.position), 2);
        }
    }
}
