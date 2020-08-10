using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding.Common;

namespace CitadelMod
{
    public abstract class MBS_GenericCitadel : Modding.BlockScript
    {
        public MSlider MSSeed;
        public MMenu MMTab;

        public MToggle MTDeploy;
        public MToggle MTConfirmDeploy;

        public MMenu MMContracts;
        public MToggle MTAddContract;

        public Dictionary<string, MToggle> DictMTContracts = new Dictionary<string, MToggle>();

        public Dictionary<string, Contract> ExistingContract = new Dictionary<string, Contract>();

        //Contract MFLOPS = new Contract("MFLOPS", Level.One, ContractTypes.AI, "CalcLevel");
        //Contract GFLOPS = new Contract("GFLOPS", Level.Two, ContractTypes.AI, "CalcLevel");
        //Contract TFLOPS = new Contract("TFLOPS", Level.Three, ContractTypes.AI, "CalcLevel");

        public override void SafeAwake()
        {
            MSSeed = AddSlider("Seed", "Seed", 0, float.NegativeInfinity, float.PositiveInfinity);
            MMTab = AddMenu("Tab", 0, new List<string> { "Configuration", "Contingency\nContract" });

            MTDeploy = AddToggle("Deploy", "Deploy", "Click this button to initialize deployment of the citadel.", false);
            MTConfirmDeploy = AddToggle("Confirm Deploy", "CDeploy", "Click this button to confirm.", false);

            MMContracts = AddMenu("MMContracts", 0, new List<string> { });
            //AddNewContract(MFLOPS);
            //AddNewContract(GFLOPS);
            //AddNewContract(TFLOPS);
            base.SafeAwake();

            MTAddContract = AddToggle("Add Contract", "add", false);
        }

        public override void BuildingUpdate()
        {
            base.BuildingUpdate();
            MMContracts.DisplayInMapper = MMTab.Value == 1;
            MTAddContract.DisplayInMapper = MMTab.Value == 1;

            MTDeploy.DisplayInMapper = MMTab.Value == 0;
            MTDeploy.SetValue(MMTab.Value == 0? MTDeploy.IsActive : false);
            MTConfirmDeploy.DisplayInMapper = MTDeploy.IsActive;
            if(MTConfirmDeploy.DisplayInMapper == false) { MTConfirmDeploy.SetValue(false); }

            if (MTConfirmDeploy.IsActive)
            {
                randommer = new System.Random((int)MSSeed.Value);
                deploySelf();
                return;
            }

            if (MTAddContract.IsActive)
            {
                AddNewContract();
            }

            foreach (String existingContractTag in DictMTContracts.Keys)
            {
                if (DictMTContracts[existingContractTag].IsActive == false)
                {
                    RemoveContract(existingContractTag);
                }
                else
                {
                    DictMTContracts[existingContractTag].DisplayInMapper = MMTab.Value == 1;
                }
            }
        }

        protected abstract void deploySelf();

        private void AddNewContract()
        {
            MTAddContract.SetValue(false);
            Contract CorrespondingContract = ExistingContract[MMContracts.Selection];
            // Remove old one
            if (DictMTContracts.ContainsKey(CorrespondingContract.ConflictTag))
            {
                RemoveContract(CorrespondingContract.ConflictTag);
            }
            // Add new one
            DictMTContracts.Add(
                CorrespondingContract.ConflictTag,
                AddToggle(
                    CorrespondingContract.ContractName, CorrespondingContract.ContractName, true
                    )
                );
            if (BlockMapper.CurrentInstance != null)
            {
                BlockMapper.CurrentInstance.Refresh();
            }
        }

        
        private void RemoveContract(String ConflictTag)
        {
            DictMTContracts[ConflictTag].DisplayInMapper = false;
            DictMTContracts.Remove(ConflictTag);
        }

        protected void AddNewContract(Contract newContract)
        {
            MMContracts.Items.Add(newContract.ToString());
            ExistingContract.Add(newContract.ToString(), newContract);
            BesiegeConsoleController.ShowMessage(newContract.ToString());
        }


        private System.Random randommer;

        public void UponDestoryed()
        {
            throw new NotImplementedException();
        }

        public void ReinforcedMode()
        {
            throw new NotImplementedException();
        }

        public void DeployDevice(EntityScript.GenericModule device, UnityEngine.Vector3 localPosition, Quaternion localRotation)
        {
            throw new NotImplementedException();
        }

        public RaycastHit RandomDevicePositionCast()
        {
            Vector3 direction = new Vector3(randommer.Next(-1, 1), randommer.Next(-1, 1), randommer.Next(-1, 1));
            Vector3 point = this.transform.TransformPoint(direction * MouseOrbit.Instance.cam.farClipPlane);
            Ray newRay = new Ray(point, (point - this.transform.position).normalized);
            List<RaycastHit> hits = Physics.RaycastAll(newRay, MouseOrbit.Instance.cam.farClipPlane).ToList();
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.gameObject == this)
                {
                    return hit;
                }
            }
            return RandomDevicePositionCast();
        }
    }
}
