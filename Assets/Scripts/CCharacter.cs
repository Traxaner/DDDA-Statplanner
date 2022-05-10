using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CCharacter : MonoBehaviour {
	private int iLvl = 1, iHp = 0, iSp = 0, iAtk = 0, iDef = 0, iMAtk = 0, iMDef = 0, iCount0 = 0, iCount1 = 0, iCount2 = 0;
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
	public int GetICount0() { return iCount0; }
	public int GetICount1() { return iCount1; }
	public int GetICount2() { return iCount2; }
	
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
	public void SetICount0(int iCount0) { this.iCount0 = iCount0; }
	public void SetICount1(int iCount1) { this.iCount1 = iCount1; }
	public void SetICount2(int iCount2) { this.iCount2 = iCount2; }
}