using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Common;

namespace CitadelMod.EntityScript
{
    public abstract class GenericCitadel : MonoBehaviour
    {
        public GameObject currentTarget;

        public float HPMultiplier;
        public float HP;

        public int TargetingRange;
        public int TargetingTime = 300;
        //public float ScanResolution;
        public MeshCollider citadelColliding;

        public List<AnimateEvent> FakeAnimationFrame;


        public Dictionary<string, MToggle> DictMTContracts = new Dictionary<string, MToggle>();

        public Dictionary<string, Contract> ExistingContract = new Dictionary<string, Contract>();


        public virtual void deploySelf(Vector3 scale, Vector3 position, Quaternion rotation, Dictionary<string, Contract> existingContract)
        {
            this.transform.localScale = scale;
            this.transform.position = position;
            this.transform.rotation = rotation;
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            GenericColliderScript GCollS = this.transform.FindChild("MeshCollider").gameObject.AddComponent<GenericColliderScript>();
            GCollS.sourceCitadel = this;

            foreach(string key in existingContract.Keys) // Really horrible design, will refactor soon™
            {
                
            }
        }


        public void Targeting()
        {
            System.Random targetingRandom = new System.Random();
            if (StatMaster.isMP)
            {
                int nextRandom = targetingRandom.Next(0, Player.GetAllPlayers().Count);
                BesiegeConsoleController.ShowMessage("MP target attempt at " + nextRandom.ToString());
                currentTarget = Player.GetAllPlayers()[nextRandom].Machine.SimulationBlocks[0].GameObject;
            }
            else
            {
                BesiegeConsoleController.ShowMessage("SP target attempt");
                currentTarget = Machine.Active().SimulationBlocks[0].gameObject;
            }
        }

        public virtual void UponDestroyed()
        {
            GameObject bomb = (GameObject)Instantiate(
                            PrefabMaster.BlockPrefabs[23].gameObject,
                            this.transform.position,
                            this.transform.rotation);
            ExplodeOnCollideBlock eocb = bomb.GetComponent<ExplodeOnCollideBlock>();
            eocb.radius = 70;
            bomb.transform.localScale = UnityEngine.Vector3.one * 20;
            eocb.explosionEffectPrefab.localScale = Vector3.one * 8;
            eocb.explosionEffectPrefab.GetComponent<ExplosionEffect>().explosionGrowthSpeed *= 15f;
            eocb.explosionEffectPrefab.GetComponent<ExplosionEffect>().explosionMoveUpSpeed *= 0f; 
            eocb.explosionEffectPrefab.GetComponent<ExplosionEffect>().explosionShrinkSpeed *= 2f;
            eocb.SimPhysics = true;
            eocb.Explodey();

            DestroyImmediate(this.gameObject);
        }

        public virtual void ReinforcedMode()
        {
            throw new NotImplementedException();
        }

        public virtual void DeployDevice(GenericModule device, UnityEngine.Vector3 localPosition, Quaternion localRotation)
        {
            throw new NotImplementedException();
        }

        public virtual UnityEngine.Vector3 RandomDevicePositionCast(GenericModule device)
        {
            throw new NotImplementedException();
        }

        public virtual void FixedUpdate()
        {
            if(HP <= 0)
            {
                UponDestroyed();
            }
            TargetingTime -= 1;
            if(TargetingTime <= 0 && currentTarget == null)
            {
                TargetingTime = 300;
                Targeting();
            }
        }

    }
}
