using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Homebrew;
using TMPro;

public class VocationS : MonoBehaviour {
	//ID
	[SerializeField] private string id;
	[ContextMenu("Generate guid for id")]
	private void GenerateGUID() {
		id = System.Guid.NewGuid().ToString();
	}

	[SerializeField] private CCharacter chara;
	[SerializeField] private TextMeshProUGUI lvl;
	[Foldout("Stats")] [SerializeField] private int iHPGr, iSPGr, iATGr, iDEGr, iMAGr, iMDGr;
	private int iLevel, iCount, iCDis = 0;

	private void UpdateInfo() {
		iLevel = chara.GetLvl();
		iCount = chara.GetICount0();
	}

	public void LvlUp() {
		UpdateInfo();
		if (iCount < 9) {
			iCDis++;
			chara.SetHp(iHPGr);
			chara.SetSp(iSPGr);
			chara.SetAtk(iATGr);
			chara.SetDef(iDEGr);
			chara.SetMAtk(iMAGr);
			chara.SetMDef(iMDGr);
			chara.SetLvl(iLevel + 1);
			chara.SetICount0(iCount += 1);
		}
		lvl.text = iCDis.ToString();
	}

	public void LvlDown() {
		UpdateInfo();
		if (iCount > 0) {
			iCDis--;
			chara.SetHp(-iHPGr);
			chara.SetSp(-iSPGr);
			chara.SetAtk(-iATGr);
			chara.SetDef(-iDEGr);
			chara.SetMAtk(-iMAGr);
			chara.SetMDef(-iMDGr);
			chara.SetLvl(iLevel - 1);
			chara.SetICount0(iCount -= 1);
		}
		lvl.text = iCDis.ToString();
	}
}