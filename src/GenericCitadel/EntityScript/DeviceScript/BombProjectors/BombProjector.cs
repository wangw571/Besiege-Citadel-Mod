//SS_RPC_200_PPI-24
using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Common;

namespace CitadelMod.EntityScript.DeviceScript
{
    public class BombProjector : GenericModule
    {
        private int timeForCD = 0;
        public override void Operation()
        {
            timeForCD -= 1;
            if (timeForCD <= 0 && target != null && CheckIfAttackable(target.transform.position))
            {
                    timeForCD = 400;
                    GameObject BombballOne = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    BombballOne.transform.position = this.transform.position;
                    BombBall BBOne = BombballOne.AddComponent<BombBall>();
                    BBOne.targetPosition = target.transform.position + target.GetComponent<Rigidbody>().velocity;
                
            }
        }
        public override bool CheckIfAttackable(Vector3 worldPosition)
        {
            return (this.transform.position - worldPosition).sqrMagnitude < 300 * 300;
        }
    }

    public class BombBall : MonoBehaviour
    {
        public Vector3 targetPosition;
        private float timeLeft = 120;
        Renderer thisRenderer;
        void Start()
        {
            thisRenderer = this.gameObject.GetComponent<Renderer>();
            //thisRenderer.material = new Material(Shader.Find("FX/Glass/Stained BumpDistort"));
            thisRenderer.material = new Material(Shader.Find("Transparent/Diffuse"));
            thisRenderer.material.color = new Color(0, 0, 0, 0);
            this.GetComponent<Collider>().isTrigger = true;
            this.transform.localScale = Vector3.one * 25;
        }
        void FixedUpdate()
        {
            timeLeft -= 1;
            if (timeLeft > 50)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 0.3f);
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one * 0.015f, 0.08f);
                thisRenderer.material.color = Color.Lerp(thisRenderer.material.color, Color.red, 0.07f);
            }
            else if (timeLeft == 50)
            {
                GameObject bomb = (GameObject)Instantiate(
                            PrefabMaster.BlockPrefabs[23].gameObject,
                            this.transform.position,
                            this.transform.rotation);
                ExplodeOnCollideBlock eocb = bomb.GetComponent<ExplodeOnCollideBlock>();
                eocb.SimPhysics = true;
                eocb.Explodey();

                DestroyImmediate(this.gameObject);
            }
            else if (timeLeft > 10 && timeLeft < 50)
            {
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one * 15f, 0.02f);
                thisRenderer.material.color = Color.Lerp(thisRenderer.material.color, new Color(20, 0, 0, 5), 0.07f);
            }
            if (timeLeft <= -30) { Destroy(this.gameObject); }
        }
        void OnTriggerEnter(Collider other)
        {
            Joint joint = other.gameObject.GetComponent<Joint>();
            if (joint != null)
            {
                joint.breakForce = joint.breakForce > 55000 ? 55000 : joint.breakForce;
                joint.breakTorque = joint.breakTorque > 55000 ? 55000 : joint.breakTorque;
                joint.breakForce -= 5000;
                joint.breakTorque -= 5000;
            }

            Rigidbody rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.isKinematic = false;
            }


        }
        void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

    }
}
