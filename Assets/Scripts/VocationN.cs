using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VocationN : MonoBehaviour {
	public CCharacter chara;
	[SerializeField] private TextMeshProUGUI lvl1, lvl2;
	[SerializeField] private int iHPGr1, iSPGr1, iATGr1, iDEGr1, iMAGr1, iMDGr1, iHPGr2, iSPGr2, iATGr2, iDEGr2, iMAGr2, iMDGr2;
	private int iLevel, iCount1 = 0, iCount2 = 0;

	private void UpdateLevel() { iLevel = chara.GetLvl(); }

	public void LvlUp() {
		UpdateLevel();
        if (iLevel >= 10 && iLevel < 200) {
			chara.SetLvl(iLevel + 1);
			if (iLevel >= 100) {
				chara.SetHp(iHPGr2);
				chara.SetSp(iSPGr2);
				chara.SetAtk(iATGr2);
				chara.SetDef(iDEGr2);
				chara.SetMAtk(iMAGr2);
				chara.SetMDef(iMDGr2);
				iCount2 += 1;
			} else {
				chara.SetHp(iHPGr1);
				chara.SetSp(iSPGr1);
				chara.SetAtk(iATGr1);
				chara.SetDef(iDEGr1);
				chara.SetMAtk(iMAGr1);
				chara.SetMDef(iMDGr1);
				iCount1 += 1;
		}	}
		lvl1.text = iCount1.ToString();
		lvl2.text = iCount2.ToString();
	}

	public void LvlDown() {
		UpdateLevel();
		if (iLevel > 10) {
			if (iLevel > 100) {
                if (iCount2 != 0) {
					iCount2 -= 1;
					chara.SetHp(-iHPGr2);
					chara.SetSp(-iSPGr2);
					chara.SetAtk(-iATGr2);
					chara.SetDef(-iDEGr2);
					chara.SetMAtk(-iMAGr2);
					chara.SetMDef(-iMDGr2);
					chara.SetLvl(iLevel - 1);
			} } else {
                if (iCount1 != 0) {
					iCount1 -= 1;
					chara.SetHp(-iHPGr1);
					chara.SetSp(-iSPGr1);
					chara.SetAtk(-iATGr1);
					chara.SetDef(-iDEGr1);
					chara.SetMAtk(-iMAGr1);
					chara.SetMDef(-iMDGr1);
					chara.SetLvl(iLevel - 1);
		}	}	}
		lvl1.text = iCount1.ToString();
		lvl2.text = iCount2.ToString();
	}
}