using UnityEngine;
using Homebrew;
using TMPro;

public class VocationPanel : MonoBehaviour, IDataPersistance{
	//ID
	[SerializeField] private string id;
	[ContextMenu("Generate guid for id")]
	private void GenerateGUID() {
		if (id.Equals("")) { id = System.Guid.NewGuid().ToString(); }
	}

	[Foldout("Setup")] [SerializeField] private CCharacter chara;
	[Foldout("Setup")] [SerializeField] private VocationTools tools;
	[Foldout("Setup")] [SerializeField] private TextMeshProUGUI lvl1, lvl2;

	[Foldout("Stats")] [SerializeField] private int iHPGr1, iSPGr1, iATGr1, iDEGr1, iMAGr1, iMDGr1, iHPGr2, iSPGr2, iATGr2, iDEGr2, iMAGr2, iMDGr2;
	private int iMode, iLevel, iSteps, iCount1, iCount2, iCDis1 = 0, iCDis2 = 0;
	private bool bOverride = false;

	private void Awake() { GenerateGUID(); }

	private void UpdateInfo() {
		iLevel = chara.GetLvl();
		iMode = tools.GetMode();
		iSteps = tools.GetSteps();
		iCount1 = chara.GetICount1();
		iCount2 = chara.GetICount2();
	}

	private void UpdateVisuals() {
		lvl1.text = iCDis1.ToString();
		lvl2.text = iCDis2.ToString();
	}

	public void LvlUp() {
		if (!bOverride) { UpdateInfo(); }
		while (iSteps != 0) {
			if(iMode == 2 && iCount1 == 90) { break; }
			if (iMode != 0 && iCount1 < 90) {
				iCDis1++;
				chara.SetHp(iHPGr1);
				chara.SetSp(iSPGr1);
				chara.SetAtk(iATGr1);
				chara.SetDef(iDEGr1);
				chara.SetMAtk(iMAGr1);
				chara.SetMDef(iMDGr1);
				if (!bOverride) {
					chara.SetLvl(++iLevel);
					chara.SetICount1(++iCount1);
			}	} else {
				if(iMode != 2 && iCount2 == 100) { break; }
				if (iMode != 2 && iCount2 < 100) {
					iCDis2++;
					chara.SetHp(iHPGr2);
					chara.SetSp(iSPGr2);
					chara.SetAtk(iATGr2);
					chara.SetDef(iDEGr2);
					chara.SetMAtk(iMAGr2);
					chara.SetMDef(iMDGr2);
					if (!bOverride) {
						chara.SetLvl(++iLevel);
						chara.SetICount2(++iCount2);
			}	}	}
			iSteps--;
		}
		UpdateVisuals();
	}

	public void LvlDown() {
		if (!bOverride) { UpdateInfo(); }
		while (iSteps != 0) {
			if (iMode == 0 && iCDis2 == 0) { break; }
			if (iMode != 2 && iCDis2 != 0) {
				iCDis2--;
				chara.SetHp(-iHPGr2);
				chara.SetSp(-iSPGr2);
				chara.SetAtk(-iATGr2);
				chara.SetDef(-iDEGr2);
				chara.SetMAtk(-iMAGr2);
				chara.SetMDef(-iMDGr2);
				if (!bOverride) {
					chara.SetLvl(--iLevel);
					chara.SetICount2(iCount2 -= 1);
			}	} else {
				if (iMode != 0 && iCDis1 == 0) { break; }
				if (iMode != 0 && iCDis1 != 0) {
					iCDis1--;
					chara.SetHp(-iHPGr1);
					chara.SetSp(-iSPGr1);
					chara.SetAtk(-iATGr1);
					chara.SetDef(-iDEGr1);
					chara.SetMAtk(-iMAGr1);
					chara.SetMDef(-iMDGr1);
					if (!bOverride) {
						chara.SetLvl(--iLevel);
						chara.SetICount1(iCount1 -= 1);
			}	}	}
			iSteps--;
		}
		UpdateVisuals();
	}

	public void SaveData(GameData data) {
		if (data.L100.ContainsKey(id)) {
			data.L100.Remove(id);
		}
		data.L100.Add(id, iCDis1);
		if (data.L200.ContainsKey(id)) {
			data.L200.Remove(id);
		}
		data.L200.Add(id, iCDis2);
	}

	public void LoadData(GameData data) {
		//Activate Override and Setup
		bOverride = true;
		//Setting Levels 11-100
		data.L100.TryGetValue(id, out int iCSet);
		iMode = 2;
		if (iCSet > iCDis1) {
			iCount1 = 0;
			iSteps = iCSet - iCDis1;
			Debug.Log(iSteps);
			LvlUp();
		}
		if (iCSet < iCDis1) {
			iSteps = iCDis1 = iCDis1 - iCSet;
			Debug.Log(iSteps);
			LvlDown();
		}
		//Setting Levels 101-200
		data.L200.TryGetValue(id, out iCSet);
		iMode = 0;
		if (iCSet > iCDis2) {
			iCount2 = 0;
			iSteps = iCSet - iCDis2;
			Debug.Log(iSteps);
			LvlUp();
		}
		if (iCSet < iCDis2) {
			iSteps = iCDis2 = iCDis2 - iCSet;
			Debug.Log(iSteps);
			LvlDown();
		}
		//Deactivate Override
		bOverride = false;
	}
}