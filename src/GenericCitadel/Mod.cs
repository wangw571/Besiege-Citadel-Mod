using System;
using JetBrains.Annotations;
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
    public static class d
    {
        public static void l(System.Object anything)
        {
            BesiegeConsoleController.ShowMessage(anything.ToString());
        }
    }
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
        One=1, // ⚀
        Two =2, // ⚁
        Three =3, // ⚂
    }

    public class Contract
    {
        string _ContractName;
        string _ConflictTag;
        Level _difficultyLevel;
        ContractTypes _MyType;

        public string ContractName { get => _ContractName; }
        public Level DifficultyLevel { get => _difficultyLevel; }
        public ContractTypes MyType { get => _MyType; }
        public string ConflictTag { get => _ConflictTag; }

        public Contract(string theContractName, Level diffcLevel, ContractTypes theType, string conflict = null)
        {
            _ContractName = theContractName;
            _difficultyLevel = diffcLevel;
            _MyType = theType;
            if (conflict == null)
            {
                _ConflictTag = theContractName;
            }
            else
            {
                _ConflictTag = conflict;
            }
        }

        public string getMatchingDice()
        {
            return (_difficultyLevel == Level.One ? "\\" : (_difficultyLevel == Level.Two ? "+" : "✲"));
        }

        public bool ConflictWith(string target)
        {
            return ConflictTag == target;
        }

        public override string ToString()
        {
            return string.Concat(_MyType.ToString(), " - ", ContractName, " - ", getMatchingDice()); ;
        }
    }
}
