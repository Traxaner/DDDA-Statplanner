using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class VocationPanel : MonoBehaviour {
	[SerializeField] private CCharacter chara;
	[SerializeField] private VocationTools tools;
	[SerializeField] private TextMeshProUGUI lvl1, lvl2;

	[SerializeField] private int iHPGr1, iSPGr1, iATGr1, iDEGr1, iMAGr1, iMDGr1, iHPGr2, iSPGr2, iATGr2, iDEGr2, iMAGr2, iMDGr2;
	private int iMode, iLevel, iSteps, iCount1, iCount2, iCDis1 = 0, iCDis2 = 0;

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
		UpdateInfo();
		while (iSteps != 0) {
			if(iMode == 2 && iCount1 == 90|| iMode != 2 && iCount2 == 100) {
				break;
			} else { iSteps--; }
			if (iMode != 0 && iCount1 < 90) {
				iCDis1++;
				chara.SetHp(iHPGr1);
				chara.SetSp(iSPGr1);
				chara.SetLvl(++iLevel);
				chara.SetAtk(iATGr1);
				chara.SetDef(iDEGr1);
				chara.SetMAtk(iMAGr1);
				chara.SetMDef(iMDGr1);
				chara.SetICount1(++iCount1);
			} else if (iMode != 2 && iCount2 < 100) {
				iCDis2++;
				chara.SetHp(iHPGr2);
				chara.SetSp(iSPGr2);
				chara.SetLvl(++iLevel);
				chara.SetAtk(iATGr2);
				chara.SetDef(iDEGr2);
				chara.SetMAtk(iMAGr2);
				chara.SetMDef(iMDGr2);
				chara.SetICount2(++iCount2);
		}	}
		UpdateVisuals();
	}

	public void LvlDown() {
		UpdateInfo();
		while (iSteps != 0) {
			if(iMode == 0 && iCDis2 == 0|| iMode != 0 && iCDis1 == 0) {
				break;
			} else { iSteps--; }
			if (iMode != 2 && iCDis2 != 0) {
				iCDis2--;
				chara.SetHp(-iHPGr2);
				chara.SetSp(-iSPGr2);
				chara.SetLvl(--iLevel);
				chara.SetAtk(-iATGr2);
				chara.SetDef(-iDEGr2);
				chara.SetMAtk(-iMAGr2);
				chara.SetMDef(-iMDGr2);
				chara.SetICount2(iCount2 -= 1);
			} else if (iMode != 0 && iCDis1 != 0) {
				iCDis1--;
				chara.SetHp(-iHPGr1);
				chara.SetSp(-iSPGr1);
				chara.SetLvl(--iLevel);
				chara.SetAtk(-iATGr1);
				chara.SetDef(-iDEGr1);
				chara.SetMAtk(-iMAGr1);
				chara.SetMDef(-iMDGr1);
				chara.SetICount1(iCount1 -= 1);
		}	}
		UpdateVisuals();
	}
}