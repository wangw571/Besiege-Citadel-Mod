using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Localisation;
using Modding.Blocks;
using CitadelMod.EntityScript;

namespace CitadelMod
{
    public class MBS_Keepstar : MBS_Generic_Combat_Citadel
    {
        //Contract VortonProjector = new Contract("Doomsday Vorton Projector", Level.Two, ContractTypes.Weaponry);

        public override void SafeAwake()
        {
            base.SafeAwake();
            //AddNewContract(VortonProjector);
        }

        public override void OnPrefabCreation()
        {
            GameObject ActualCollider = new GameObject("RealCollider");
            ActualCollider.transform.SetParent(transform.FindChild("Colliders"));
            MeshCollider colliderMesh = ActualCollider.AddComponent<MeshCollider>();
            MeshFilter colliderMeshF = ActualCollider.AddComponent<MeshFilter>();
            colliderMeshF.mesh = ModResource.GetMesh("KeepstarCollider");
            colliderMesh.sharedMesh = colliderMeshF.mesh;
            colliderMesh.convex = false;
            ActualCollider.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);

            this.Rigidbody.useGravity = false;
        }

        protected override void deploySelf()
        {
            ModAssetBundle mab = ModResource.GetAssetBundle("CitadelAssetBundle");
            GameObject KeepStarEntity = GameObject.Instantiate((GameObject)mab.LoadAsset<UnityEngine.Object>("assets/keepstar.prefab"));
            KeepStarEntity.name = "KeepstarEntity";

            KeepstarScript ks = KeepStarEntity.AddComponent<KeepstarScript>();
            ks.deploySelf(new Vector3(0.0005f, 0.0005f, 0.0005f), this.transform.position, this.transform.rotation, ExistingContract);

            this.transform.parent = null;
            Machine.RemoveBlock(Block.From(this));
        }

        public override void SimulateFixedUpdateAlways()
        {
            Destroy(this.gameObject);
            return;
        }

    }
}
