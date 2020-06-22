using System;
using Modding;
using UnityEngine;

namespace CitadelMod
{
    //public class Mod : ModEntryPoint
    //{
    //	public override void OnLoad()
    //	{
    //		// Called when the mod is loaded.
    //	}
    //}

    public enum ContractTypes
    {
        AI,
        Durability,
        Resilience,
        Weaponry,
        Electronic_Warfare,
        Objective
    };

    public enum Level : int
    {
        Easy=1, // ⚀
        Medium =2, // ⚁
        Hard =3, // ⚂
    }

    public class Contracts
    {
        string _ContractName;


        public string ContractName { get => _ContractName; }


    }
}
