using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VocationN : MonoBehaviour {
	public CCharacter chara;
	[SerializeField] private TextMeshProUGUI lvl1, lvl2;
	[SerializeField] private int iHPGr1, iSPGr1, iATGr1, iDEGr1, iMAGr1, iMDGr1, iHPGr2, iSPGr2, iATGr2, iDEGr2, iMAGr2, iMDGr2;
	private int iLevel, iCount1, iCount2, iCDis1 = 0, iCDis2 = 0;

	private void UpdateInfo() {
		iLevel = chara.GetLvl();
		iCount1 = chara.GetICount1();
		iCount2 = chara.GetICount2();
	}

	public void LvlUp() {
		UpdateInfo();
        if (iLevel >= 10 && iLevel < 200) {
			chara.SetLvl(iLevel + 1);
			if (iLevel >= 100) {
				iCDis2++;
				chara.SetHp(iHPGr2);
				chara.SetSp(iSPGr2);
				chara.SetAtk(iATGr2);
				chara.SetDef(iDEGr2);
				chara.SetMAtk(iMAGr2);
				chara.SetMDef(iMDGr2);
				chara.SetICount2(iCount2 += 1);
			} else {
				iCDis1++;
				chara.SetHp(iHPGr1);
				chara.SetSp(iSPGr1);
				chara.SetAtk(iATGr1);
				chara.SetDef(iDEGr1);
				chara.SetMAtk(iMAGr1);
				chara.SetMDef(iMDGr1);
				chara.SetICount1(iCount1 += 1);
			}	}
		lvl1.text = iCDis1.ToString();
		lvl2.text = iCDis2.ToString();
	}

	public void LvlDown() {
		UpdateInfo();
		if (iLevel > 10) {
			if (iLevel > 100) {
                if (iCDis2 != 0) {
					iCDis2--;
					chara.SetHp(-iHPGr2);
					chara.SetSp(-iSPGr2);
					chara.SetAtk(-iATGr2);
					chara.SetDef(-iDEGr2);
					chara.SetMAtk(-iMAGr2);
					chara.SetMDef(-iMDGr2);
					chara.SetLvl(iLevel - 1);
					chara.SetICount2(iCount2 -= 1);
			} } else {
                if (iCDis1 != 0) {
					iCDis1--;
					chara.SetHp(-iHPGr1);
					chara.SetSp(-iSPGr1);
					chara.SetAtk(-iATGr1);
					chara.SetDef(-iDEGr1);
					chara.SetMAtk(-iMAGr1);
					chara.SetMDef(-iMDGr1);
					chara.SetLvl(iLevel - 1);
					chara.SetICount1(iCount1 -= 1);
		}	}	}
		lvl1.text = iCDis1.ToString();
		lvl2.text = iCDis2.ToString();
	}
}