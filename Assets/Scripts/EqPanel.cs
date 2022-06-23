using System.Collections.Generic;
using UnityEngine;
using Homebrew;
using System;
using TMPro;

public class EqPanel : MonoBehaviour {
	//Some basic necesities for things to work well
	[SerializeField] private CCharacter chara;
	private int[] iCurrent = new int[9];
	//Debilitations
	#region
	private TextMeshProUGUI[] Debilitations = new TextMeshProUGUI[13];
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI petrify;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI possession;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI sleep;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI silence;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI skillStiff;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI torpor;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI poison;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI blind;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI curse;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI strLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI magLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI defLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI mDefLow;
	#endregion
	//Dropdowns of pain and suffering
	#region
	private TMP_Dropdown[] Equipment;
	[Foldout("Equipment")] [SerializeField] public GameObject hArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject tClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject tArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject aArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject lClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject lArmor;
	[Foldout("Equipment")] [SerializeField] public TMP_Dropdown cloak;
	//Rings get special treatment
	private TMP_Dropdown[] Rings = new TMP_Dropdown[2];
	[Foldout("Equipment")] [SerializeField] private TMP_Dropdown Ring1;
	[Foldout("Equipment")] [SerializeField] private TMP_Dropdown Ring2;
	#endregion
	//Lists of pain and suffering
	#region
	List<string> Head = new List<string>();
	List<string> TCloth = new List<string>();
	List<string> Chest = new List<string>();
	List<string> Arms = new List<string>();
	List<string> LCloth = new List<string>();
	List<string> Legs = new List<string>();
	List<string> Cloak = new List<string>();
	List<string> Ringz = new List<string>();
	#endregion

	void Start() {
		//filling debilitationsarray
		#region
		Debilitations[0] = petrify;
		Debilitations[1] = possession;
		Debilitations[2] = sleep;
		Debilitations[3] = silence;
		Debilitations[4] = skillStiff;
		Debilitations[5] = torpor;
		Debilitations[6] = poison;
		Debilitations[7] = blind;
		Debilitations[8] = curse;
		Debilitations[9] = strLow;
		Debilitations[10] = magLow;
		Debilitations[11] = defLow;
		Debilitations[12] = mDefLow;
		#endregion
		EquipmentSetup1();
		ListsOfPainAndSuffering();
		EquipmentSetup2();
	}

	//Basic Setup
	private void EquipmentSetup1() {
		//Ringarray
		Rings[0] = Ring1;
		Rings[1] = Ring2;
		Equipment = new TMP_Dropdown[]{
			hArmor.GetComponent<TMP_Dropdown>(),tClothing.GetComponent<TMP_Dropdown>(),
			tArmor.GetComponent<TMP_Dropdown>(),aArmor.GetComponent<TMP_Dropdown>(),
			lClothing.GetComponent<TMP_Dropdown>(),lArmor.GetComponent<TMP_Dropdown>(), cloak
		};
		//Getting the Dropdowns
		for(int i = 0; i < 7; i++) {
			//Clearing Dropdowns
			Equipment[i].options.Clear();
			//Adding empty option
			Equipment[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			//Rings
			if (i < 2) {
				Rings[i].options.Clear();
				Rings[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
	}	}	}

	//Putting the Lists to use
	private void EquipmentSetup2() {
		//Cloaks
		#region
		foreach (string Cloak in Cloak) {
				Equipment[6].options.Add(new TMP_Dropdown.OptionData() { text = Cloak });
		}
		Equipment[6].onValueChanged.AddListener(delegate { SwitchCloak(); });
		#endregion
		//Rings
		#region
		foreach (string Ringz in Ringz) {
			for (int i = 0; i < 2; i++) {
				Rings[i].options.Add(new TMP_Dropdown.OptionData() { text = Ringz });
		}	}
		Rings[0].onValueChanged.AddListener(delegate { SwitchRing(0); });
		Rings[1].onValueChanged.AddListener(delegate { SwitchRing(1); });
		#endregion
	}

	private void ListsOfPainAndSuffering() {
		//Cloaks
		#region
		Cloak.Add("Adept's Mantle");
		Cloak.Add("Adventurer's Cloak");
		Cloak.Add("Alchemickal Cloak");
		Cloak.Add("Ancient Cape");
		Cloak.Add("BBI3 Cloak");
		Cloak.Add("Beastly Mantle");
		Cloak.Add("Conquerer's Mantle");
		Cloak.Add("Dignified Cape");
		Cloak.Add("Direwolf Cape");
		Cloak.Add("Divine Embrace");
		Cloak.Add("Dragon Knight's Cloak");
		Cloak.Add("Ebon Neck Wrap");
		Cloak.Add("Farewell Cloak");
		Cloak.Add("Feather Cape");
		Cloak.Add("Feral Cape");
		Cloak.Add("Gryphic Cloak");
		Cloak.Add("Harpy Cloak");
		Cloak.Add("Heresy Cloak");
		Cloak.Add("Hero's Cape");
		Cloak.Add("Knight's Mantle");
		Cloak.Add("Leather Cape");
		Cloak.Add("Lordly Cloak");
		Cloak.Add("Mahagony Cape");
		Cloak.Add("Monomi Neck Wrap");
		Cloak.Add("Nebula Cape");
		Cloak.Add("Nomad's Cloak");
		Cloak.Add("Paladin's Mantle");
		Cloak.Add("Pauldron");
		Cloak.Add("Royal Mantle");
		Cloak.Add("Scarlet Cape");
		Cloak.Add("Scholar's Cape");
		Cloak.Add("Shed Cape");
		Cloak.Add("Shoulder Cape");
		Cloak.Add("Sovereign's Mantle");
		Cloak.Add("Tattered Mantle");
		Cloak.Add("Violet Neck Wrap");
		Cloak.Add("Wyrm Hunt Mantle");
		#endregion
		//Rings
		#region
		Ringz.Add("Baleful Nails");
		Ringz.Add("Barbed Nails");
		Ringz.Add("Benevolent Earring");
		Ringz.Add("Bloody Knuckle");
		Ringz.Add("Blue Star Earring");
		Ringz.Add("Blue Star Ring");
		Ringz.Add("Cleansing Earring");
		Ringz.Add("Dignified Earring");
		Ringz.Add("Dragonblood");
		Ringz.Add("Exurbant Earring");
		Ringz.Add("Faithfull Earring");
		Ringz.Add("Free-Spoken Earring");
		Ringz.Add("Golden Ring");
		Ringz.Add("Green Star Earring");
		Ringz.Add("Green Star Ring");
		Ringz.Add("Harmonious Earring");
		Ringz.Add("Indomitable Earring");
		Ringz.Add("Iris Ring");
		Ringz.Add("Nimble Earring");
		Ringz.Add("Noble Earring");
		Ringz.Add("Ogrebone");
		Ringz.Add("Platinum Ring");
		Ringz.Add("Premium Earring");
		Ringz.Add("Premium Ring");
		Ringz.Add("Red Star Earring");
		Ringz.Add("Red Star Ring");
		Ringz.Add("Restless Earring");
		Ringz.Add("Ring of Amethyst");
		Ringz.Add("Ring of Argent");
		Ringz.Add("Ring of Azure");
		Ringz.Add("Ring of Desiccation");
		Ringz.Add("Ring of Gules");
		Ringz.Add("Ring of Onyx");
		Ringz.Add("Ring of Pearl");
		Ringz.Add("Ring of Perseverance");
		Ringz.Add("Ring of Purpose");
		Ringz.Add("Ring of Ruby");
		Ringz.Add("Ring of Sable");
		Ringz.Add("Ring of Saphire");
		Ringz.Add("Rose Ring");
		Ringz.Add("Savior Ring");
		Ringz.Add("Sight Earring");
		Ringz.Add("Silver Ring");
		Ringz.Add("Stalwart Earring");
		Ringz.Add("Stonewall Ring");
		Ringz.Add("Vandal's Ring");
		Ringz.Add("Violet Ring");
		Ringz.Add("Wanderlust Ring");
		#endregion
	}

	private void SetDebilitationRes(int iPercent,int iDebilitation) {
		 string s = Debilitations[iDebilitation].text;
		s = s.Remove(s.Length - 1);
		Debilitations[iDebilitation].text = (Int32.Parse(s) + iPercent).ToString() + "%";
	}

	public void SetAll(int iPercent) {
		for(int i = 0; i < 13; i++) {
			SetDebilitationRes(iPercent, i);
		}
	}

	public void OnPanelDisplay() {
		//help
		switch (chara.GetVocation()) {
			case "Warrior":
			case "M. Knight":
				// Dragonscale Arm
			case "Fighter":
				break;
			case "Ranger":
				//Twilight Manicae
			case "Strider":
				//Crested Armguards
				//Grisly Bracers
				break;
			case "M.Archer":
				//copy uncommented from strider and sorc
				break;
			case "Assassin":
				//Copy Ranger
				//Blessed Sleeves
				//scale Armguard
				break;
			case "Sorcerer":
			case "Mage":
				//no burnished bracers
				//no black leather gloves
				//no darkened Gloves
				//no Assassin's armguards
				//no Lion's spire
				//no masters bracers
				//no scarlet handcovers
				//no assailants bracers
				//no emissiary Bracers
				//no Iron manicae
				//no Red Leather Gloves
				//no Navy Leather Gloves
				//no Arm Crest
				//no iron bracers
				//no bandits glove
				//no lether gloves
				//no hand covers
				//no novice Bracers
				break;
		}
		if (chara.GetGender()) {
			//Dissable all the female only options
		}
	}

	//Functions for switching equipmentpieces
	#region
	private void SwitchCloak() {
		//Remove
		switch (iCurrent[6]-1) {
			case 0:
				SetDebilitationRes(-56, 3);
				SetDebilitationRes(-56, 7);
				break;
			case 1:
				SetDebilitationRes(-35, 6);
				break;
			case 2:
				SetDebilitationRes(-40, 6);
				break;
			case 3:
				SetDebilitationRes(-45, 8);
				SetDebilitationRes(-40, 10);
				SetDebilitationRes(-40, 12);
				break;
			case 4:
				SetDebilitationRes(-100, 1);
				break;
			case 5:
				SetDebilitationRes(-32, 5);
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-32, 2);
				break;
			case 6:
				SetDebilitationRes(-32, 0);
				SetDebilitationRes(-32, 4);
				SetDebilitationRes(-32, 8);
				break;
			case 7:
				SetDebilitationRes(-45, 0);
				break;
			case 8:
				SetDebilitationRes(-35, 5);
				break;
			case 9:
				SetDebilitationRes(-56, 0);
				SetDebilitationRes(-56, 8);
				SetDebilitationRes(-40, 9);
				SetDebilitationRes(-40, 11);
				break;
			case 10:
				SetDebilitationRes(-48, 4);
				SetDebilitationRes(-45, 9);
				break;
			case 11:
				SetDebilitationRes(-35, 7);
				break;
			case 12:
				SetDebilitationRes(-36, 6);
				SetDebilitationRes(-36, 9);
				SetDebilitationRes(-36, 10);
				break;
			case 13:
				SetDebilitationRes(-35, 3);
				break;
			case 14:
				SetDebilitationRes(-45, 5);
				break;
			case 15:
				SetDebilitationRes(-40, 7);
				break;
			case 16:
				SetDebilitationRes(-40, 2);
				break;
			case 17:
				SetDebilitationRes(-40, 8);
				SetDebilitationRes(-32, 0);
				break;
			case 18:
				SetDebilitationRes(-40, 4);
				SetDebilitationRes(-32, 8);
				break;
			case 19:
				SetDebilitationRes(-84, 8);
				SetDebilitationRes(-42, 0);
				break;
			case 20:
				SetDebilitationRes(-36, 6);
				SetDebilitationRes(-36, 10);
				SetDebilitationRes(-36, 12);
				break;
			case 21:
				SetDebilitationRes(-48, 10);
				SetDebilitationRes(-45, 7);
				break;
			case 22:
				SetDebilitationRes(-36, 10);
				SetDebilitationRes(-36, 12);
				SetDebilitationRes(-24, 9);
				SetDebilitationRes(-24, 11);
				break;
			case 23:
				SetDebilitationRes(-35, 2);
				break;
			case 24:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-32, 6);
				break;
			case 25:
				SetDebilitationRes(-56, 1);
				break;
			case 26:
				SetDebilitationRes(-56, 5);
				SetDebilitationRes(-56, 6);
				break;
			case 27:
				SetDebilitationRes(-64, 1);
				SetDebilitationRes(-40, 8);
				break;
			case 28:
				SetDebilitationRes(-40, 4);
				break;
			case 29:
				SetDebilitationRes(-45, 8);
				break;
			case 30:
				SetDebilitationRes(-40, 5);
				break;
			case 31:
				chara.SetHp(-30);
				break;
			case 32:
				SetDebilitationRes(-48, 11);
				SetDebilitationRes(-48, 12);
				break;
			case 33:
				chara.SetSp(-30);
				break;
			case 34:
				chara.SetAtk(-10);
				SetDebilitationRes(-56, 1);
				SetDebilitationRes(-56, 4);
				break;
			case 35:
				SetAll(-15);
				SetDebilitationRes(15, 9);
				SetDebilitationRes(15, 10);
				SetDebilitationRes(15, 11);
				SetDebilitationRes(15, 12);
				break;
			case 36:
				SetDebilitationRes(-40, 4);
				break;
			case 37:
				SetDebilitationRes(-60, 7);
				SetDebilitationRes(-60, 4);
				break;
		}
		iCurrent[6] = Equipment[6].value;
		//Add
		switch (iCurrent[6] - 1) {
			case 0:
				SetDebilitationRes(56, 3);
				SetDebilitationRes(56, 7);
				break;
			case 1:
				SetDebilitationRes(35, 6);
				break;
			case 2:
				SetDebilitationRes(40, 6);
				break;
			case 3:
				SetDebilitationRes(45, 8);
				SetDebilitationRes(40, 10);
				SetDebilitationRes(40, 12);
				break;
			case 4:
				SetDebilitationRes(100, 1);
				break;
			case 5:
				SetDebilitationRes(32, 5);
				SetDebilitationRes(32, 6);
				SetDebilitationRes(32, 2);
				break;
			case 6:
				SetDebilitationRes(32, 0);
				SetDebilitationRes(32, 4);
				SetDebilitationRes(32, 8);
				break;
			case 7:
				SetDebilitationRes(45, 0);
				break;
			case 8:
				SetDebilitationRes(35, 5);
				break;
			case 9:
				SetDebilitationRes(56, 0);
				SetDebilitationRes(56, 8);
				SetDebilitationRes(40, 9);
				SetDebilitationRes(40, 11);
				break;
			case 10:
				SetDebilitationRes(48, 4);
				SetDebilitationRes(45, 9);
				break;
			case 11:
				SetDebilitationRes(35, 7);
				break;
			case 12:
				SetDebilitationRes(36, 6);
				SetDebilitationRes(36, 9);
				SetDebilitationRes(36, 10);
				break;
			case 13:
				SetDebilitationRes(35, 3);
				break;
			case 14:
				SetDebilitationRes(45, 5);
				break;
			case 15:
				SetDebilitationRes(40, 7);
				break;
			case 16:
				SetDebilitationRes(40, 2);
				break;
			case 17:
				SetDebilitationRes(40, 8);
				SetDebilitationRes(32, 0);
				break;
			case 18:
				SetDebilitationRes(40, 4);
				SetDebilitationRes(32, 8);
				break;
			case 19:
				SetDebilitationRes(84, 8);
				SetDebilitationRes(42, 0);
				break;
			case 20:
				SetDebilitationRes(36, 6);
				SetDebilitationRes(36, 10);
				SetDebilitationRes(36, 12);
				break;
			case 21:
				SetDebilitationRes(48, 10);
				SetDebilitationRes(45, 7);
				break;
			case 22:
				SetDebilitationRes(36, 10);
				SetDebilitationRes(36, 12);
				SetDebilitationRes(24, 9);
				SetDebilitationRes(24, 11);
				break;
			case 23:
				SetDebilitationRes(35, 2);
				break;
			case 24:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(32, 6);
				break;
			case 25:
				SetDebilitationRes(56, 1);
				break;
			case 26:
				SetDebilitationRes(56, 5);
				SetDebilitationRes(56, 6);
				break;
			case 27:
				SetDebilitationRes(64, 1);
				SetDebilitationRes(40, 8);
				break;
			case 28:
				SetDebilitationRes(40, 4);
				break;
			case 29:
				SetDebilitationRes(45, 8);
				break;
			case 30:
				SetDebilitationRes(40, 5);
				break;
			case 31:
				chara.SetHp(30);
				break;
			case 32:
				SetDebilitationRes(48, 11);
				SetDebilitationRes(48, 12);
				break;
			case 33:
				chara.SetSp(30);
				break;
			case 34:
				chara.SetAtk(10);
				SetDebilitationRes(56, 1);
				SetDebilitationRes(56, 4);
				break;
			case 35:
				SetAll(15);
				SetDebilitationRes(-15, 9);
				SetDebilitationRes(-15, 10);
				SetDebilitationRes(-15, 11);
				SetDebilitationRes(-15, 12);
				break;
			case 36:
				SetDebilitationRes(40, 4);
				break;
			case 37:
				SetDebilitationRes(60, 7);
				SetDebilitationRes(60, 4);
				break;
		}
	}
	private void SwitchRing(int iRing) {
		//Subtract here
		switch (iCurrent[iRing + 7]-1) {
			case 2:
				SetDebilitationRes(-60, 8);
				break;
			case 6:
				SetDebilitationRes(-60, 6);
				break;
			case 7:
				SetDebilitationRes(-60, 0);
				break;
			case 8:
				SetAll(-25);
				break;
			case 9:
				SetDebilitationRes(-60, 4);
				break;
			case 10:
				SetDebilitationRes(-60, 1);
				break;
			case 11:
				SetDebilitationRes(-60, 3);
				break;
			case 15:
				SetDebilitationRes(-60, 10);
				break;
			case 16:
				SetDebilitationRes(-60, 9);
				break;
			case 18:
				SetDebilitationRes(-60, 5);
				break;
			case 19:
				SetDebilitationRes(-60, 12);
				break;
			case 26:
				SetDebilitationRes(-60, 2);
				break;
			case 40:
				chara.SetHp(-500);
				chara.SetSp(-500);
				break;
			case 41:
				SetDebilitationRes(-60, 7);
				break;
			case 43:
				SetDebilitationRes(-60, 11);
				break;
		}
		//Maths
		iCurrent[iRing + 7] = Rings[iRing].value;
		//Add here
		switch (iCurrent[iRing + 7]-1) {
			case 2:
				SetDebilitationRes(60, 8);
				break;
			case 6:
				SetDebilitationRes(60, 6);
				break;
			case 7:
				SetDebilitationRes(60, 0);
				break;
			case 8:
				SetAll(25);
				break;
			case 9:
				SetDebilitationRes(60, 4);
				break;
			case 10:
				SetDebilitationRes(60, 1);
				break;
			case 11:
				SetDebilitationRes(60, 3);
				break;
			case 15:
				SetDebilitationRes(60, 10);
				break;
			case 16:
				SetDebilitationRes(60, 9);
				break;
			case 18:
				SetDebilitationRes(60, 5);
				break;
			case 19:
				SetDebilitationRes(60, 12);
				break;
			case 26:
				SetDebilitationRes(60, 2);
				break;
			case 40:
				chara.SetHp(500);
				chara.SetSp(500);
				break;
			case 41:
				SetDebilitationRes(60, 7);
				break;
			case 43:
				SetDebilitationRes(60, 11);
				break;
		}
	}
	#endregion
}
