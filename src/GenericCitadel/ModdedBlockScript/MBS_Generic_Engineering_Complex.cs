using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class MBS_Generic_Engineering_Complex : MBS_GenericCitadel
    {
        private const string ConflictArmor = "Armor";
        private const string ConflictDamaCon = "Damage Control";
        private const string ConflictMissile = "Missile";
        private const string ConflictTurret = "Turret";

        Contract SmallRepairer = new Contract("Small Armor Repairer", Level.One, ContractTypes.Durability, ConflictArmor);
        Contract MediumRepairer = new Contract("Medium Armor Repairer", Level.Two, ContractTypes.Durability, ConflictArmor);
        Contract HeavyRepairer = new Contract("Heavy Armor Repairer", Level.Three, ContractTypes.Durability, ConflictArmor);

        Contract DamaConOne = new Contract("Damage Control I", Level.One, ContractTypes.Durability, ConflictDamaCon);
        Contract DamaConTwo = new Contract("Damage Control II", Level.Two, ContractTypes.Durability, ConflictDamaCon);

        Contract RAMissile = new Contract("Rear-Aspect Missile", Level.One, ContractTypes.Weaponry, ConflictMissile);
        Contract HMMissile = new Contract(" High Maneuveribility Missile", Level.Two, ContractTypes.Weaponry, ConflictMissile);
        Contract PFMissile = new Contract("Poxy Fuse Missile", Level.Two, ContractTypes.Weaponry, ConflictMissile);

        Contract Blaster = new Contract("Blaster Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);
        Contract Artillery = new Contract("Artillery Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);

        Contract Drone = new Contract("Drones", Level.One, ContractTypes.Weaponry);

        Contract Webifier = new Contract("Stasis Webifier", Level.Three, ContractTypes.Electronic_Warfare);
        Contract ExorbitantSuppressor = new Contract("Exorbitant Suppressor", Level.One, ContractTypes.Electronic_Warfare);

        public override void SafeAwake()
        {
            base.SafeAwake();
            AddNewContract(SmallRepairer); // + 1% per 20s
            AddNewContract(MediumRepairer); // + 5% per 15s
            AddNewContract(HeavyRepairer); // + 8% per 8s
            AddNewContract(DamaConOne); // Module Damage -50%
            AddNewContract(DamaConTwo); // Module Damage -80%

            AddNewContract(RAMissile);
            AddNewContract(HMMissile);
            AddNewContract(PFMissile);

            AddNewContract(Blaster);
            AddNewContract(Artillery);

            AddNewContract(Webifier);
            AddNewContract(ExorbitantSuppressor);
            AddNewContract(Drone);

        }
    }
}
