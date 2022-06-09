using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameData {
	//CCharacter
	public string aName, pName;
	//Weight
	public int aWeight, pWeight;
	//StarterPanel
	public int aVoc, pVoc, aSVoc, pSVoc;
	//AugmentsPanel
	public int[] aAug, pAug;
	//Vocations
	public SerializeableDictionary<string, int> L10, L100, L200;
	//SkillPanel
	public int[] aSkills, pSkills;

	public GameData() {
		aName = "Arisen";
		pName = "Main Pawn";
		aWeight = pWeight = 75;
		aVoc = aSVoc = 1;
		pVoc = pSVoc = 2;
		aAug = pAug = new int[6];
		aSkills = new int[63];
		pSkills = new int[33];
		L10 = L100 = L200 = new SerializeableDictionary<string, int>();
	}
}