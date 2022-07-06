using UnityEngine;
using Homebrew;
using TMPro;

public class CCharacter : MonoBehaviour, IDataPersistance {
	[Foldout("Interaction")] [SerializeField] private EqPanel Equipment;
	[Foldout("Interaction")] [SerializeField] private GameObject Gender;
	[Foldout("Interaction")] [SerializeField] private TMP_InputField CName;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI Vocation;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI hpDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI spDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI lvlDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI atkDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI defDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI matkDisplay;
	[Foldout("Display")] [SerializeField] private TextMeshProUGUI mdefDisplay;

	private int iLvl = 1, iHp = 0, iSp = 0, iAtk = 0, iDef = 0, iMAtk = 0, iMDef = 0, iCount0 = 0, iCount1 = 0, iCount2 = 0;
	private bool bArisen, bFCheck, bFemale = false;
	private string sVocation;

	//Checking wether or not this Character is the Arisen using Tags
	private void Start() {
		if (this.CompareTag("Arisen")) { bArisen = true; } else { bArisen = false; }
	}

	//Constantly Updating all variables that are shown
	void FixedUpdate() {
		if (!Vocation.text.Equals(sVocation)) {
			Vocation.text = sVocation;
			Equipment.EquipReset();
		}
		hpDisplay.text = iHp.ToString();
		spDisplay.text = iSp.ToString();
		lvlDisplay.text = iLvl.ToString();
		atkDisplay.text = iAtk.ToString();
		defDisplay.text = iDef.ToString();
		matkDisplay.text = iMAtk.ToString();
		mdefDisplay.text = iMDef.ToString();
		if (bFCheck != bFemale) { Equipment.EquipReset(); bFCheck = bFemale; }
		if (bFemale) { Gender.SetActive(false); } else { Gender.SetActive(true); }
	}

	//Getters
	#region 
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
	public bool GetGender() { return bFemale; }
	public string GetVocation() { return sVocation; }
	#endregion
	//Setters
	#region
	public void SetHp(int iHP) { this.iHp += iHP; }
	public void SetSp(int iSP) { this.iSp += iSP; }
	public void SetLvl(int iLvl) {
		if (iLvl > 200) { iLvl = 200; }
		if (iLvl < 1) { iLvl = 1; } 
		this.iLvl = iLvl;
	}
	public void SetAtk(int iAtk) { this.iAtk += iAtk; }
	public void SetDef(int iDef) { this.iDef += iDef; }
	public void SetMAtk(int iMAtk) { this.iMAtk += iMAtk; }
	public void SetMDef(int iMDef) { this.iMDef += iMDef; }
	public void SetICount0(int iCount0) { this.iCount0 = iCount0; }
	public void SetICount1(int iCount1) { this.iCount1 = iCount1; }
	public void SetICount2(int iCount2) { this.iCount2 = iCount2; }
	public void SetVocation(string sVocation) { this.sVocation = sVocation; }
	public void SetGender() { if (bFemale) { bFemale = false; } else { bFemale = true; } }
	#endregion
	
	//Writing the variable to save, here the name, to the gamedata
	public void SaveData(GameData data) {
		if (bArisen) {
			data.aName = CName.GetComponentInChildren<TextMeshProUGUI>().text;
			data.aSex = GetGender();
			data.aC0 = GetICount0();
			data.aC1 = GetICount1();
			data.aC2 = GetICount2();
			data.aL = GetLvl();
		} else {
			data.pName = CName.GetComponentInChildren<TextMeshProUGUI>().text;
			data.pSex = GetGender();
			data.pC0 = GetICount0();
			data.pC1 = GetICount1();
			data.pC2 = GetICount2();
			data.pL = GetLvl();
		}
	}

	//retrieving the saved variable, here the name, from the gamedata
	public void LoadData(GameData data) {
		bool bSex;
		if (bArisen) {
			CName.text = data.aName;
			SetICount0(data.aC0);
			SetICount1(data.aC1);
			SetICount2(data.aC2);
			bSex = data.aSex;
			SetLvl(data.aL);
		} else {
			CName.text = data.pName;
			SetICount0(data.pC0);
			SetICount1(data.pC1);
			SetICount2(data.pC2);
			bSex = data.pSex;
			SetLvl(data.pL);
		}
		if (bSex == true) {
			if (!GetGender()) { SetGender(); }
		} else {
			if (GetGender()) { SetGender(); }
	}	}
}