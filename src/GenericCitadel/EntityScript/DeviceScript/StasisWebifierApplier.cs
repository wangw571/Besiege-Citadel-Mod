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
    public class StasisWebifierApplier : GenericModule
    {
        private int timeForCD = 1200;
        public override void Operation()
        {
            timeForCD -= 1;
            //BesiegeConsoleController.ShowMessage((timeForCD <= 0).ToString());
            //BesiegeConsoleController.ShowMessage((target != null).ToString());
            //BesiegeConsoleController.ShowMessage((CheckIfAttackable(target.transform.position)).ToString());
            //BesiegeConsoleController.ShowMessage("123");
            if (timeForCD <= 0 && target != null && CheckIfAttackable(target.transform.position))
            {
                timeForCD = 1200;
                GameObject WebBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                WebBall.transform.position = this.transform.position;
                WebBall.GetComponent<Collider>().isTrigger = true;
                StasisWebifierBall swb = WebBall.AddComponent<StasisWebifierBall>();
                swb.targetPosition = target.transform.position + target.GetComponent<Rigidbody>().velocity;
            }
        }
        public override bool CheckIfAttackable(Vector3 worldPosition)
        {
            return (this.transform.position - worldPosition).sqrMagnitude < 200 * 200;
        }
    }

    public class StasisWebifierBall : MonoBehaviour
    {
        public Vector3 targetPosition = Vector3.zero;
        private float timeLeft = 120;
        Renderer thisRenderer;
        void Start()
        {
            thisRenderer = this.gameObject.GetComponent<Renderer>();
            //thisRenderer.material = new Material(Shader.Find("FX/Glass/Stained BumpDistort"));
            thisRenderer.material = new Material(Shader.Find("Transparent/Diffuse"));
            thisRenderer.material.color = new Color(255, 255, 255, 100);
        }
        void FixedUpdate()
        {
            timeLeft -= 1;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 0.3f);
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one * 15, 0.08f);
            thisRenderer.material.color = Color.Lerp(thisRenderer.material.color, new Color(0, 0, 0, 0), 0.07f);
            if (timeLeft <= 0) { Destroy(this.gameObject); }
        }
        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.GetComponent<StasisWebifierEffect>())
            {
                other.gameObject.AddComponent<StasisWebifierEffect>();
            }
        }
        void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

    }

    public class StasisWebifierEffect : MonoBehaviour
    {
        Collider thisOnCollider;

        private int timeLeft = 800;
        float originalMaxAngVelo = -1;
        float originalDrag = -1;
        float originalMass = float.NegativeInfinity;

        float theLimitAng = 0.02f;
        float theLimitDrag = 32.8f;
        float thePowMass = 3;
        void Start()
        {
            thisOnCollider = this.GetComponent<Collider>();
        }
        void FixedUpdate()
        {
            Rigidbody attachedRigidbody = thisOnCollider.attachedRigidbody;
            if (thisOnCollider == null || attachedRigidbody == null || timeLeft < -5)
            {
                DestroyImmediate(this);
                return;
            }

            if (originalMaxAngVelo == -1)
            {
                originalMaxAngVelo = attachedRigidbody.maxAngularVelocity;
                originalDrag = attachedRigidbody.drag;
                originalMass = attachedRigidbody.mass;
            }

            timeLeft -= 1;
            if (timeLeft > 500)
            {
                attachedRigidbody.maxAngularVelocity = Mathf.Lerp(attachedRigidbody.maxAngularVelocity, theLimitAng, 0.05f);
                attachedRigidbody.drag = Mathf.Lerp(attachedRigidbody.drag, theLimitDrag, 0.05f);
                attachedRigidbody.mass = Mathf.Lerp(attachedRigidbody.mass, Mathf.Pow(originalMass, thePowMass), 0.05f);
            }
            else if (timeLeft > 100)
            {
                attachedRigidbody.maxAngularVelocity = Mathf.Lerp(attachedRigidbody.maxAngularVelocity, theLimitAng, 0.95f);
                attachedRigidbody.drag = Mathf.Lerp(attachedRigidbody.drag, theLimitDrag, 0.95f);
                attachedRigidbody.mass = Mathf.Lerp(attachedRigidbody.mass, Mathf.Pow(originalMass, thePowMass), 0.95f);
            }
            else if (timeLeft < 100 && timeLeft > 5)
            {
                attachedRigidbody.maxAngularVelocity = Mathf.Lerp(attachedRigidbody.maxAngularVelocity, originalMaxAngVelo, 0.35f);
                attachedRigidbody.drag = Mathf.Lerp(attachedRigidbody.drag, originalDrag, 0.35f);
                attachedRigidbody.mass = Mathf.Lerp(attachedRigidbody.mass, originalMass, 0.35f);
            }
            else
            {
                attachedRigidbody.maxAngularVelocity = originalMaxAngVelo;
                attachedRigidbody.drag = originalDrag;
                attachedRigidbody.mass = originalMass;
            }

        }
    }
}
