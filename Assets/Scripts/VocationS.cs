using UnityEngine;
using Homebrew;
using TMPro;

public class VocationS : MonoBehaviour, IDataPersistance{
	//ID
	[SerializeField] private string id;
	[ContextMenu("Generate guid for id")]
	private void GenerateGUID() {
		if (id.Equals("")) { id = System.Guid.NewGuid().ToString(); }
	}

	[SerializeField] private CCharacter chara;
	[SerializeField] private TextMeshProUGUI lvl;
	[Foldout("Stats")] [SerializeField] private int iHPGr, iSPGr, iATGr, iDEGr, iMAGr, iMDGr;
	private int iLevel, iCount, iCDis = 0;
	private bool bOverride = false;

	private void Awake() { GenerateGUID(); }

	private void UpdateInfo() {
		iLevel = chara.GetLvl();
		iCount = chara.GetICount0();
	}

	public void LvlUp() {
		if (!bOverride) { UpdateInfo(); } else { iCount = 0; }
		if (iCount < 9) {
			iCDis++;
			chara.SetHp(iHPGr);
			chara.SetSp(iSPGr);
			chara.SetAtk(iATGr);
			chara.SetDef(iDEGr);
			chara.SetMAtk(iMAGr);
			chara.SetMDef(iMDGr);
			if (!bOverride) {
				chara.SetLvl(iLevel + 1);
				chara.SetICount0(iCount += 1);
		}	}
		lvl.text = iCDis.ToString();
	}

	public void LvlDown() {
		if (!bOverride) { UpdateInfo(); } else { iCount = 9; }
		if (iCount > 0) {
			iCDis--;
			chara.SetHp(-iHPGr);
			chara.SetSp(-iSPGr);
			chara.SetAtk(-iATGr);
			chara.SetDef(-iDEGr);
			chara.SetMAtk(-iMAGr);
			chara.SetMDef(-iMDGr);
			if (!bOverride) {
				chara.SetLvl(iLevel - 1);
				chara.SetICount0(iCount -= 1);
		}	}
		lvl.text = iCDis.ToString();
	}

	public void SaveData(GameData data) {
		if (data.L10.ContainsKey(id)) {
			data.L10.Remove(id);
		}
		data.L10.Add(id, iCDis);
	}

	public void LoadData(GameData data) {
		int i, iCap;
		//Activate Override
		bOverride = true;
		//Read out value
		data.L10.TryGetValue(id, out int iCSet);
		//Looping level ups/downs
		if (iCSet < iCDis) {
			iCap = iCDis - iCSet;
			for (i = 0; i < iCap; i++) { LvlDown(); }
		}
		if (iCSet > iCDis) {
			iCap = iCSet - iCDis;
			for (i = 0; i < iCap; i++) { LvlUp(); }
		}
		//Deactivate Override
		bOverride = false;
	}
}