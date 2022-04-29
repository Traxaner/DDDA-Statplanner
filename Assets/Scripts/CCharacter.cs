using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CCharacter : MonoBehaviour {
	int iLvl = 10, iHp = 0, iSp = 0, iAtk = 0, iDef = 0, iMAtk = 0, iMDef = 0;
	[SerializeField] private TextMeshProUGUI hpDisplay;
	[SerializeField] private TextMeshProUGUI spDisplay;
	[SerializeField] private TextMeshProUGUI lvlDisplay;
	[SerializeField] private TextMeshProUGUI atkDisplay;
	[SerializeField] private TextMeshProUGUI defDisplay;
	[SerializeField] private TextMeshProUGUI matkDisplay;
	[SerializeField] private TextMeshProUGUI mdefDisplay;

	void FixedUpdate() {
		hpDisplay.text = iHp.ToString();
		spDisplay.text = iSp.ToString();
		lvlDisplay.text = iLvl.ToString();
		atkDisplay.text = iAtk.ToString();
		defDisplay.text = iDef.ToString();
		matkDisplay.text = iMAtk.ToString();
		mdefDisplay.text = iMDef.ToString();
	}

	//Getters
	public int GetHp() { return iHp; }
	public int GetSp() { return iSp; }
	public int GetLvl() { return iLvl; }
	public int GetAtk() { return iAtk; }
	public int GetDef() { return iDef; }
	public int GetMAtk() { return iMAtk; }
	public int GetMDef() { return iMDef; }
	
	//Setters
	public void SetHp(int iHP) { this.iHp += iHP; }
	public void SetSp(int iSP) { this.iSp += iSP; }
	public void SetLvl(int iLvl) {
		if (iLvl < 0) { iLvl = 0; }
		else if (iLvl > 200) { iLvl = 200; }
		this.iLvl = iLvl;
	}
	public void SetAtk(int iAtk) { this.iAtk += iAtk; }
	public void SetDef(int iDef) { this.iDef += iDef; }
	public void SetMAtk(int iMAtk) { this.iMAtk += iMAtk; }
	public void SetMDef(int iMDef) { this.iMDef += iMDef; }
}