using System;
using UnityEngine;
using Modding;
using Modding.Levels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitadelMod
{
    public abstract class MBS_Generic_Combat_Citadel : MBS_GenericCitadel
    {
        private const string ConflictArmor = "Armor";
        private const string ConflictDamaCon = "Damage Control";
        private const string ConflictMissile = "Missile";
        private const string ConflictTurret = "Turret";
        private const string ConflictTestBomb = "Bomb";

        public Contract TenPlate = new Contract("100mm Steel Plates", Level.One, ContractTypes.Durability, ConflictArmor);
        public Contract TwoPlate = new Contract("800mm Steel Plates", Level.Two, ContractTypes.Durability, ConflictArmor);
        public Contract FivePlate = new Contract("25000mm Steel Plates", Level.Three, ContractTypes.Durability, ConflictArmor);

        //public Contract DamaConOne = new Contract("Damage Control I", Level.One, ContractTypes.Durability, ConflictDamaCon);
        //public Contract DamaConTwo = new Contract("Damage Control II", Level.Two, ContractTypes.Durability, ConflictDamaCon);

        //Contract RAMissile = new Contract("Rear-Aspect Missile", Level.One, ContractTypes.Weaponry, ConflictMissile);
        //Contract HMMissile = new Contract(" High Maneuveribility Missile", Level.Two, ContractTypes.Weaponry, ConflictMissile);
        //Contract PFMissile = new Contract("Poxy Fuse Missile", Level.Two, ContractTypes.Weaponry, ConflictMissile);

        //Contract Railgun = new Contract("Rail Gun Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);
        //Contract Blaster = new Contract("Blaster Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);
        //Contract BLaser = new Contract("Beam Laser Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);
        //Contract Artillery = new Contract("Artillery Turrets", Level.One, ContractTypes.Weaponry, ConflictTurret);

        public Contract SingleBomb = new Contract("Void Bomb", Level.One, ContractTypes.Weaponry, ConflictTestBomb);
        public Contract TripleBomb = new Contract("3 * Void Bombs", Level.Two, ContractTypes.Weaponry, ConflictTestBomb);
        public Contract RapidBomb = new Contract("Rapid Void Bombs Deployment", Level.Three, ContractTypes.Weaponry, ConflictTestBomb);

        //Contract Drone = new Contract("Drones", Level.One, ContractTypes.Weaponry);

        //Contract PointDefenseBattery = new Contract("Point Defense Battery", Level.Two, ContractTypes.Weaponry);

        public Contract Webifier = new Contract("Stasis Webifier", Level.Three, ContractTypes.Electronic_Warfare);
        //Contract GravityField = new Contract("Gravity Field Generator", Level.Two, ContractTypes.Electronic_Warfare);
        //Contract ExorbitantSuppressor = new Contract("Exorbitant Suppressor", Level.One, ContractTypes.Electronic_Warfare);

        public override void SafeAwake()
        {
            base.SafeAwake();

            AddNewContract(TenPlate); // + 10%
            AddNewContract(TwoPlate); // + 100%
            AddNewContract(FivePlate); // + 400%
            //AddNewContract(DamaConOne); // Module Damage -50%
            //AddNewContract(DamaConTwo); // Module Damage -80%

            //AddNewContract(RAMissile);
            //AddNewContract(HMMissile);
            //AddNewContract(PFMissile);

            //AddNewContract(Railgun);
            //AddNewContract(Blaster);
            //AddNewContract(BLaser);
            //AddNewContract(Artillery);
            AddNewContract(SingleBomb);
            AddNewContract(TripleBomb);
            AddNewContract(RapidBomb);

            //AddNewContract(Drone);
            //AddNewContract(PointDefenseBattery);

            AddNewContract(Webifier);
            //AddNewContract(GravityField);
            //AddNewContract(ExorbitantSuppressor);

        }
    }
}
