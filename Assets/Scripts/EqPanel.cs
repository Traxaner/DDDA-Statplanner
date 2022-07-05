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
	private DropDownController[] EDD;
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
		EDD = new DropDownController[] {
			hArmor.GetComponent<DropDownController>(),tClothing.GetComponent<DropDownController>(),
			tArmor.GetComponent<DropDownController>(),aArmor.GetComponent<DropDownController>(),
			lClothing.GetComponent<DropDownController>(),lArmor.GetComponent<DropDownController>()
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
		//Headarmor
		#region
		foreach (string Head in Head) {
			Equipment[0].options.Add(new TMP_Dropdown.OptionData() { text = Head });
		}
		Equipment[0].onValueChanged.AddListener(delegate { SwitchHead(); });
		#endregion
		//Chestclothing
		#region
		foreach (string TCloth in TCloth) {
			Equipment[1].options.Add(new TMP_Dropdown.OptionData() { text = TCloth });
		}
		Equipment[1].onValueChanged.AddListener(delegate { SwitchTClothing(); });
		#endregion
		//Chestarmor
		#region
		foreach (string Chest in Chest) {
			Equipment[2].options.Add(new TMP_Dropdown.OptionData() { text = Chest });
		}
		Equipment[2].onValueChanged.AddListener(delegate { SwitchChest(); });
		#endregion
		//Armarmor
		#region
		foreach (string Arms in Arms) {
			Equipment[3].options.Add(new TMP_Dropdown.OptionData() { text = Arms });
		}
		Equipment[3].onValueChanged.AddListener(delegate { SwitchArms(); });
		#endregion
		//Legclothing
		#region
		foreach (string LCloth in LCloth) {
			Equipment[4].options.Add(new TMP_Dropdown.OptionData() { text = LCloth });
		}
		Equipment[4].onValueChanged.AddListener(delegate { SwitchLClothing(); });
		#endregion
		//Legarmor
		#region
		foreach (string Legs in Legs) {
				Equipment[5].options.Add(new TMP_Dropdown.OptionData() { text = Legs });
		}
		Equipment[5].onValueChanged.AddListener(delegate { SwitchLegs(); });
		#endregion
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
		//Head Armor
		#region
		Head.Add("Adept's Hat");
		Head.Add("Ancient Circlet");
		Head.Add("Archwizard's Helm");
		Head.Add("Assassin's Mask");
		Head.Add("Autumn Hood");
		Head.Add("Bandit's Mask");
		Head.Add("Babarian Chief's Helm");
		Head.Add("Barreled Helm");
		Head.Add("Black Eyeglasses");
		Head.Add("Bronze Sallet");
		Head.Add("BBI3 Heavy Armor");
		Head.Add("BBI3 Light Armor");
		Head.Add("BBI3 Robes");
		Head.Add("Chain Coif");
		Head.Add("Chaos Helm");
		Head.Add("Chimeric Armet");
		Head.Add("Circlet");
		Head.Add("Clerical Cap");
		Head.Add("Coupled Headgear");
		Head.Add("Crimson Armet");
		Head.Add("Crowned Hood");
		Head.Add("Cyclops Veil");
		Head.Add("Diadem");
		Head.Add("Direwolf Veil");
		Head.Add("Dragon Band");
		Head.Add("Dragon Knight's Helm");
		Head.Add("Dragonroar");
		Head.Add("Dragonseye Band");
		Head.Add("Dragonpulse Circlet");
		Head.Add("Dragonwing Circlet");
		Head.Add("Emissiary Hood");
		Head.Add("Faerie Hood");
		Head.Add("Farewell Hood");
		Head.Add("Farseer's Cap");
		Head.Add("Feather Hood");
		Head.Add("Gold Eyeglasses");
		Head.Add("Golden Lion Helm");
		Head.Add("Gossip's Mask");
		Head.Add("Grissly Skull");
		Head.Add("Griphic Helm");
		Head.Add("Guardian's Hood");
		Head.Add("Heresy Hood");
		Head.Add("Hero's Hood");
		Head.Add("Horned Helm");
		Head.Add("Immortal's Helm");
		Head.Add("Incognito Mask");
		Head.Add("Iron Headgear");
		Head.Add("Iron Helm");
		Head.Add("Jester's Cap");
		Head.Add("Laurel Circlet");
		Head.Add("Leather Cap");
		Head.Add("Leather Circlet");
		Head.Add("Leather Hood");
		Head.Add("Lion-Lord's Helm");
		Head.Add("Lupine Veil");
		Head.Add("Meloirean Cyclops Veil");
		Head.Add("Meloirean Helm");
		Head.Add("Minstrel Band");
		Head.Add("Misteltoe Circlet");
		Head.Add("Monomi Mask");
		Head.Add("Persecutor's Mask");
		Head.Add("Red Eyeglasses");
		Head.Add("Red Cap");
		Head.Add("Red Leather Hood");
		Head.Add("Ruminator's Monocle");
		Head.Add("Sage's hood");
		Head.Add("Silver Eyeglasses");
		Head.Add("Shulker's Mask");
		Head.Add("Steel Sallet");
		Head.Add("Sultry Cowl");
		Head.Add("Summery Cowl");
		Head.Add("Tiara of Enlightenment");
		Head.Add("Tormenter's Mask");
		Head.Add("Traveler's Hood");
		Head.Add("Twilight Hood");
		Head.Add("Twilight Mask");
		Head.Add("Ur-Dragon Masks");
		Head.Add("Verdant Hood");
		Head.Add("White Cap");
		Head.Add("Wizard's Helm");
		Head.Add("Wyrmfire Wizard");
		#endregion
		//Chest Clothing
		#region
		TCloth.Add("Abyssinal Outfit");
		TCloth.Add("Alchemick Vest");
		TCloth.Add("Assembled Vest");
		TCloth.Add("Bandages");
		TCloth.Add("Blessed Vest");
		TCloth.Add("Bilaut");
		TCloth.Add("Braided Shirt");
		TCloth.Add("Brigandine Jerkin");
		TCloth.Add("Cassardi Shirt");
		TCloth.Add("Chain Mail");
		TCloth.Add("Chainmail Bracers");
		TCloth.Add("Cotton Tunic");
		TCloth.Add("Crimson Jerkin");
		TCloth.Add("Doublet");
		TCloth.Add("Dragonleather Vest");
		TCloth.Add("Faded Vest");
		TCloth.Add("Fine Cassardi Shirt");
		TCloth.Add("Forest Tunic");
		TCloth.Add("Gambeson");
		TCloth.Add("Hard Leather Plate");
		TCloth.Add("Hemp Shirt");
		TCloth.Add("Hunter's Shirt");
		TCloth.Add("Iron Vest");
		TCloth.Add("Lady's Corset");
		TCloth.Add("Leather Chestguard");
		TCloth.Add("Light Outfit");
		TCloth.Add("Linen Shirt");
		TCloth.Add("Maiden's Camisole");
		TCloth.Add("Marshal's Bracers");
		TCloth.Add("Noblewomen's Corset");
		TCloth.Add("Patterned Gamberson");
		TCloth.Add("Plated Coat");
		TCloth.Add("Quilted Jerkin");
		TCloth.Add("Riveted Coat");
		TCloth.Add("Silver Chestplate");
		TCloth.Add("Silver Cuircas");
		TCloth.Add("Silver Vest");
		TCloth.Add("Traveler's Shirt");
		TCloth.Add("Trooper Outfit");
		TCloth.Add("Tunic");
		#endregion
		//Chest Armor
		#region
		Chest.Add("Abyssinal Coat");
		//Chest[2] Mage Sorc M. Archer
		Chest.Add("Adept's Robe");
		//Chest[3] Mage based
		Chest.Add("Ancient Robe");
		//Chest[4] Mage based
		Chest.Add("Animistic Robe");
		//Chest[5] Strider based
		Chest.Add("Archer's Culottes");
		Chest.Add("Asura Armor");
		//Chest[7] Strider based
		Chest.Add("BBI3 Coat of Shadow");
		//Chest[8] Strider based
		Chest.Add("BBI3 Coat of Oblivion");
		//Chest[9] Fighter Warrior M. Knight
		Chest.Add("BBI3 Heavy Armor");
		//Chest[10] Mage Sorc M. Archer
		Chest.Add("BBI3 Robes");
		//Chest[11] Female Sorc M. Archer
		Chest.Add("Berserkin");
		//Chest[12] No Mage/Sorc
		Chest.Add("Bone Armor");
		//Chest[13] No Mage/Sorc
		Chest.Add("Bone Plate Armor");
		//Chest[14] Heavy
		Chest.Add("Bronze Cuirass");
		//Chest[15] Strider based
		Chest.Add("Bronze Lorica");
		//Chest[16] Mage Sorc M. Archer
		Chest.Add("Cardinal Surcoat");
		//Chest[17] Heavy
		Chest.Add("Celestial Armor");
		//Chest[18] Heavy
		Chest.Add("Chaos Armor");
		//Chest[19] No Mage/Sorc
		Chest.Add("Chestguard");
		//Chest[20] Heavy
		Chest.Add("Chimeric Half Plate");
		//Chest[21] Heavy
		Chest.Add("Crimson Plate");
		//Chest[22] Mage Sorc M. Archer
		Chest.Add("Crimson Robe");
		Chest.Add("Cursed King's Belt");
		//Chest[24] Mage Sorc M. Archer
		Chest.Add("Dalmatica");
		//Chest[25] Ranger Assassin
		Chest.Add("Dark Lorica");
		//Chest[26] Heavy
		Chest.Add("Divine Surcoat");
		//Chest[27] Strider based
		Chest.Add("Emissary Armor");
		//Chest[28] Strider based
		Chest.Add("Flutter Padding");
		//Chest[29] Female
		Chest.Add("Framae Plate");
		Chest.Add("Golden Belt");
		//Chest[31] Strider based
		Chest.Add("Golden Lion Padding");
		//Chest[32] Heavy
		Chest.Add("Grand Surcoat");
		//Chest[33] Heavy
		Chest.Add("Grisly Bone Armor");
		//Chest[34] Heavy
		Chest.Add("Griphic Armor");
		//Chest[35] Mage based
		Chest.Add("Healer's Robe");
		//Chest[36] Mage based
		Chest.Add("Heresy Armor");
		//Chest[37] Heavy
		Chest.Add("Hero's Surcoat");
		//Chest[38] Fighter based
		Chest.Add("Hide Armor");
		//Chest[39] Strider based
		Chest.Add("Hunter's Jacket");
		//Chest[40] Heavy
		Chest.Add("Immortal's Coat");
		//Chest[41] Strider based
		Chest.Add("Iron Lorica");
		//Chest[42] Strider based
		Chest.Add("Lamellar Jacket");
		//Chest[43] No Mage/Sorc
		Chest.Add("Leather Belts");
		//Chest[44] No Mage/Sorc
		Chest.Add("Leather Jacket");
		//Chest[45] Strider based
		Chest.Add("Leather Protector");
		//Chest[46] Fighter based
		Chest.Add("Leather Waistwrap");
		//Chest[47] Mage Sorc M. Archer
		Chest.Add("Magician's Surcoat");
		//Chest[48] Female
		Chest.Add("Maiden's Petticoat");
		//Chest[49] Mage Sorc M. Archer
		Chest.Add("Matte Robe");
		//Chest[50] Heavy
		Chest.Add("Meloirean Plate");
		//Chest[51] Mage Sorc M. Archer
		Chest.Add("Missionary's Robe");
		//Chest[52] Strider based
		Chest.Add("Monomi Coat");
		Chest.Add("Mummer's Wear");
		//Chest[54] Mage Sorc M. Archer
		Chest.Add("Novice's Coat");
		//Chest[55] Strider based
		Chest.Add("Padded Armor");
		Chest.Add("Plebian Shirt");
		//Chest[57] Mage based
		Chest.Add("Recluse's Robe");
		//Chest[58] Warrior M. Knight
		Chest.Add("Red Dragon Scale");
		//Chest[59] Strider based
		Chest.Add("Red Leather Armor");
		//Chest[60] Strider based
		Chest.Add("Rex Lion Padding");
		//Chest[61] Mage Sorc M. Archer
		Chest.Add("Robe of Enlightenment");
		//Chest[62] Heavy
		Chest.Add("Royal Surcaot");
		//Chest[63] Mage Sorc M. Archer
		Chest.Add("Sage's Robe");
		//Chest[64] Fighter based
		Chest.Add("Scale Coat");
		//Chest[65] Mage Sorc M. Archer
		Chest.Add("Scholar's Coat");
		//Chest[66] Heavy
		Chest.Add("Sectional Armor");
		//Chest[67] Heavy
		Chest.Add("Sectional Iron Plate");
		//Chest[68] Mage Sorc M. Archer
		Chest.Add("Shabby Robe");
		//Chest[69] No Mage/Sorc
		Chest.Add("Skull Belt");
		//Chest[70] Heavy
		Chest.Add("Solar Armor");
		//Chest[71] Heavy
		Chest.Add("Steel Cuircass");
		//Chest[72] Female
		Chest.Add("Sultry Pareo");
		//Chest[73] Female
		Chest.Add("Summery Pareo");
		//Chest[74] Heavy
		Chest.Add("Surcaot");
		//Chest[75] Mage Sorc M. Archer
		Chest.Add("Traveler's Vest");
		//Chest[76] Strider based
		Chest.Add("Trophy Jacket");
		Chest.Add("Vagabond Armor");
		//Chest[78] Mage based
		Chest.Add("Votary's Robe");
		Chest.Add("Wavering Cloth");
		//Chest[80] No Mage/Sorc
		Chest.Add("Weak Guard");
		#endregion
		//Leg Clothing
		#region
		LCloth.Add("Alchemickal Hosen");
		LCloth.Add("Bandit Stalkers");
		LCloth.Add("Black Gaiters");
		LCloth.Add("Braided Hosen");
		LCloth.Add("Brown Laced Leggings");
		LCloth.Add("Brown Leathers");
		LCloth.Add("Cassardi Trousers");
		LCloth.Add("Cotton Hosen");
		LCloth.Add("Delta Guard");
		LCloth.Add("Denim Hosen");
		LCloth.Add("Evening Tights");
		LCloth.Add("Fine Cassadri Hosen");
		LCloth.Add("Full Chain Hosen");
		LCloth.Add("Half Chain Hosen");
		LCloth.Add("Hemp Hosen");
		LCloth.Add("Huntsman's Trousers");
		LCloth.Add("Iron Bandings");
		LCloth.Add("Laborer's Breeches");
		LCloth.Add("Laced Leggings");
		LCloth.Add("Leather Bandings");
		LCloth.Add("Seeker Thights");
		LCloth.Add("Short Pants");
		LCloth.Add("Silk Lingerie");
		LCloth.Add("Silk Tights");
		LCloth.Add("Silver Hosen");
		LCloth.Add("Traveler's Tights");
		LCloth.Add("Twisted Leathers");
		LCloth.Add("Urban Hosen");
		LCloth.Add("White Stockings");
		LCloth.Add("Worker's Pants");
		LCloth.Add("Yellow Gaiters");
		#endregion
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
		//Fighter based
		#region
		if (chara.GetVocation().Equals("Fighter") || chara.GetVocation().Equals("Warrior")||
			 chara.GetVocation().Equals("Assassin") || chara.GetVocation().Equals("M. Knight")) {
			//Heavy Armor
			#region
			if (!chara.GetVocation().Equals("Assassin")) {
				//Head
				#region
				EDD[0].EnableOption(8, true);
				EDD[0].EnableOption(10, true);
				EDD[0].EnableOption(11, true);
				EDD[0].EnableOption(15, true);
				EDD[0].EnableOption(16, true);
				EDD[0].EnableOption(20, true);
				EDD[0].EnableOption(26, true);
				EDD[0].EnableOption(39, true);
				EDD[0].EnableOption(40, true);
				EDD[0].EnableOption(43, true);
				EDD[0].EnableOption(44, true);
				EDD[0].EnableOption(48, true);
				EDD[0].EnableOption(58, true);
				EDD[0].EnableOption(62, true);
				EDD[0].EnableOption(70, true);
				EDD[0].EnableOption(74, true);
				#endregion
			} else {
				//Head
				#region
				EDD[0].EnableOption(8, false);
				EDD[0].EnableOption(10, false);
				EDD[0].EnableOption(11, false);
				EDD[0].EnableOption(15, false);
				EDD[0].EnableOption(16, false);
				EDD[0].EnableOption(20, false);
				EDD[0].EnableOption(26, false);
				EDD[0].EnableOption(39, false);
				EDD[0].EnableOption(40, false);
				EDD[0].EnableOption(43, false);
				EDD[0].EnableOption(44, false);
				EDD[0].EnableOption(48, false);
				EDD[0].EnableOption(58, false);
				EDD[0].EnableOption(62, false);
				EDD[0].EnableOption(70, false);
				EDD[0].EnableOption(74, false);
				#endregion
			}
			#endregion
			//Warrior/M. Knight
			#region
			if (chara.GetVocation().Equals("Warrior")|| chara.GetVocation().Equals("M. Knight")) {
				//Head
				#region
				EDD[0].EnableOption(7, true);
				EDD[0].EnableOption(22, true);
				EDD[0].EnableOption(57, true);
				#endregion
			} else {
				//Head
				#region
				EDD[0].EnableOption(7, false);
				EDD[0].EnableOption(22, false);
				EDD[0].EnableOption(57, false);
				#endregion
			}
			#endregion
			//Head Armor
			#region
			EDD[0].EnableOption(14, true);
			EDD[0].EnableOption(45, true);
			#endregion
			//Chest Clothing
			#region
			EDD[1].EnableOption(16, true);
			EDD[1].EnableOption(23, true);
			EDD[1].EnableOption(32, true);
			EDD[1].EnableOption(37, true);
			#endregion
		} else {
			//Head Armor
			#region
			EDD[0].EnableOption(7, false);
			EDD[0].EnableOption(8, false);
			EDD[0].EnableOption(10, false);
			EDD[0].EnableOption(11, false);
			EDD[0].EnableOption(14, false);
			EDD[0].EnableOption(15, false);
			EDD[0].EnableOption(16, false);
			EDD[0].EnableOption(20, false);
			EDD[0].EnableOption(22, false);
			EDD[0].EnableOption(26, false);
			EDD[0].EnableOption(39, false);
			EDD[0].EnableOption(40, false);
			EDD[0].EnableOption(43, false);
			EDD[0].EnableOption(44, false);
			EDD[0].EnableOption(45, false);
			EDD[0].EnableOption(48, false);
			EDD[0].EnableOption(57, false);
			EDD[0].EnableOption(58, false);
			EDD[0].EnableOption(62, false);
			EDD[0].EnableOption(70, false);
			EDD[0].EnableOption(74, false);
			#endregion
			//Chest Clothing
			#region
			EDD[1].EnableOption(16, false);
			EDD[1].EnableOption(23, false);
			EDD[1].EnableOption(32, false);
			EDD[1].EnableOption(37, false);
			#endregion

		}
		#endregion
		//Strider based
		#region
		if(chara.GetVocation().Equals("Strider") || chara.GetVocation().Equals("Ranger") ||
			chara.GetVocation().Equals("Assassin") || chara.GetVocation().Equals("M. Archer")) {
			//No Magick Archer
			#region
			if (!chara.GetVocation().Equals("M. Archer")) {
				//Head
				EDD[0].EnableOption(34, true);
			} else {
				//Head
				EDD[0].EnableOption(34, false);
			}
			#endregion
			//More Specialized things
			#region
			if (chara.GetVocation().Equals("Assassin") || chara.GetVocation().Equals("Ranger")) {
				//Head
				EDD[0].EnableOption(77, true);
			} else {
				//Head
				EDD[0].EnableOption(77, false);
			}
			#endregion
			//Head Armor
			#region
			EDD[0].EnableOption(4, true);
			EDD[0].EnableOption(12, true);
			EDD[0].EnableOption(19, true);
			EDD[0].EnableOption(37, true);
			EDD[0].EnableOption(47, true);
			EDD[0].EnableOption(53, true);
			EDD[0].EnableOption(54, true);
			EDD[0].EnableOption(61, true);
			EDD[0].EnableOption(65, true);
			EDD[0].EnableOption(69, true);
			#endregion
		} else {
			//Head Armor
			#region
			EDD[0].EnableOption(4, false);
			EDD[0].EnableOption(12, false);
			EDD[0].EnableOption(19, false);
			EDD[0].EnableOption(34, false);
			EDD[0].EnableOption(37, false);
			EDD[0].EnableOption(47, false);
			EDD[0].EnableOption(53, false);
			EDD[0].EnableOption(54, false);
			EDD[0].EnableOption(61, false);
			EDD[0].EnableOption(65, false);
			EDD[0].EnableOption(69, false);
			EDD[0].EnableOption(77, false);
			#endregion
		}
		#endregion
		//Mage based
		#region
		//Mage|Sorcerer
		if (chara.GetVocation().Equals("Mage") || chara.GetVocation().Equals("Sorcerer")||
			 chara.GetVocation().Equals("M. Archer") || chara.GetVocation().Equals("M. Knight")) {
			//Not for Mage/Sorc
			#region
			if (!chara.GetVocation().Equals("Mage") || !chara.GetVocation().Equals("Sorcerer")) {
				//Chest Clothing
				#region
				EDD[1].EnableOption(3, false);
				EDD[1].EnableOption(10, false);
				EDD[1].EnableOption(11, false);
				EDD[1].EnableOption(15, false);
				EDD[1].EnableOption(29, false);
				EDD[1].EnableOption(34, false);
				EDD[1].EnableOption(36, false);
				EDD[1].EnableOption(39, false);
				#endregion
				//Leg Clothing
				#region
				EDD[4].EnableOption(12, false);
				EDD[4].EnableOption(13, false);
				EDD[4].EnableOption(16, false);
				EDD[4].EnableOption(24, false);
				#endregion
			} else {
				//Chest Clothing
				#region
				EDD[1].EnableOption(3, true);
				EDD[1].EnableOption(10, true);
				EDD[1].EnableOption(11, true);
				EDD[1].EnableOption(15, true);
				EDD[1].EnableOption(29, true);
				EDD[1].EnableOption(34, true);
				EDD[1].EnableOption(36, true);
				EDD[1].EnableOption(39, true);
				#endregion
				//Leg Clothing
				#region
				EDD[4].EnableOption(12, true);
				EDD[4].EnableOption(13, true);
				EDD[4].EnableOption(16, true);
				EDD[4].EnableOption(24, true);
				#endregion
			}
			#endregion
			//No Mystic Knight
			#region
			if(!chara.GetVocation().Equals("M. Knight")) {
				//Head
				#region
				EDD[0].EnableOption(1, true);
				EDD[0].EnableOption(13, true);
				#endregion
			} else {
				//Head
				#region
				EDD[0].EnableOption(1, false);
				EDD[0].EnableOption(13, false);
				#endregion
			}
			#endregion
			//Just Sorc/M. Archer
			#region
			if (chara.GetVocation().Equals("Sorcerer")|| chara.GetVocation().Equals("M. Archer")) {
				//Head
				EDD[0].EnableOption(23, true);
			} else {
				//Head
				EDD[0].EnableOption(23, false);
			}
			#endregion
			//Head Armor
			#region
			EDD[0].EnableOption(3, true);
			EDD[0].EnableOption(5, true);
			EDD[0].EnableOption(21, true);
			EDD[0].EnableOption(32, true);
			EDD[0].EnableOption(35, true);
			EDD[0].EnableOption(42, true);
			EDD[0].EnableOption(67, true);
			EDD[0].EnableOption(76, true);
			EDD[0].EnableOption(79, true);
			EDD[0].EnableOption(81, true);
			#endregion
			//Chest Clothing
			EDD[1].EnableOption(6, true);
		} else {
			//Head Armor
			#region
			EDD[0].EnableOption(1, false);
			EDD[0].EnableOption(3, false);
			EDD[0].EnableOption(5, false);
			EDD[0].EnableOption(13, false);
			EDD[0].EnableOption(21, false);
			EDD[0].EnableOption(23, false);
			EDD[0].EnableOption(32, false);
			EDD[0].EnableOption(35, false);
			EDD[0].EnableOption(42, false);
			EDD[0].EnableOption(67, false);
			EDD[0].EnableOption(76, false);
			EDD[0].EnableOption(79, false);
			EDD[0].EnableOption(81, false);
			#endregion
			//Chest Clothing
			EDD[1].EnableOption(6, false);
		}
		#endregion
		//Special Snowflakes
		#region
		if(chara.GetVocation().Equals("Warrior") || chara.GetVocation().Equals("Ranger") ||
			chara.GetVocation().Equals("M.Archer") || chara.GetVocation().Equals("M.Knight")) {
			//Head
			#region
			EDD[0].EnableOption(24, true);
			EDD[0].EnableOption(55, true);
			#endregion
		} else {
			//Head
			#region
			EDD[0].EnableOption(24, false);
			EDD[0].EnableOption(55, false);
			#endregion
		}
		#endregion
		//Gender
		#region
			if (!chara.GetGender()) {
			//Dissable all the female only options
			#region
			//Head Armor
			EDD[0].EnableOption(71, false);
			EDD[0].EnableOption(72, false);
			//Chest Clothing
			EDD[1].EnableOption(24, false);
			EDD[1].EnableOption(28, false);
			EDD[1].EnableOption(30, false);
			//Chest Armor

			//Leg Clothing
			EDD[4].EnableOption(9, false);
			EDD[4].EnableOption(22, false);
			EDD[4].EnableOption(28, false);
			//Maiden's Petticoat
			//Berserkin
			//Flame Skirt
			//Framae Plate
			//Sultry Pareo
			//Summery Pareo
			#endregion
		} else {
			//Enable all the female only options
			#region
			//Head Armor
			EDD[0].EnableOption(71, true);
			EDD[0].EnableOption(72, true);
			//Chest Clothing
			EDD[1].EnableOption(24, true);
			EDD[1].EnableOption(28, true);
			EDD[1].EnableOption(30, true);
			//Leg Clothing
			EDD[4].EnableOption(9, true);
			EDD[4].EnableOption(22, true);
			EDD[4].EnableOption(28, true);
			#endregion
		}
		#endregion
	}

	//Functions for switching equipmentpieces
	#region
	private void SwitchHead() {
		switch (iCurrent[0]) {
			case 1:
				SetDebilitationRes(-60, 3);
				SetDebilitationRes(-60, 10);
				break;
			case 2:
				SetDebilitationRes(-40, 0);
				SetDebilitationRes(-40, 1);
				SetDebilitationRes(-40, 3);
				SetDebilitationRes(-40, 4);
				SetDebilitationRes(-40, 5);
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-40, 8);
				SetDebilitationRes(-15, 2);
				SetDebilitationRes(-15, 6);
				break;
			case 3:
				SetDebilitationRes(-80, 10);
				SetDebilitationRes(-56, 12);
				break;
			case 4:
				SetDebilitationRes(-36, 6);
				SetDebilitationRes(-27, 7);
				break;
			case 5:
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-48, 4);
				break;
			case 6:
				SetDebilitationRes(-40, 6);
				SetDebilitationRes(-28, 7);
				break;
			case 7:
				chara.SetAtk(-10);
				SetDebilitationRes(-100, 9);
				SetDebilitationRes(-100, 11);
				SetDebilitationRes(-36, 8);
				break;
			case 8:
				SetDebilitationRes(-32, 1);
				SetDebilitationRes(-27, 0);
				break;
			case 9:
				SetDebilitationRes(-12, 2);
				SetDebilitationRes(-12, 7);
				break;
			case 10:
				SetDebilitationRes(-24, 4);
				break;
			case 11:
				SetDebilitationRes(-100, 3);
				SetDebilitationRes(-100, 6);
				SetDebilitationRes(-60, 8);
				break;
			case 12:
				SetDebilitationRes(-100, 1);
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-5, 9);
				SetDebilitationRes(-5, 10);
				SetDebilitationRes(-5, 11);
				SetDebilitationRes(-5, 12);
				break;
			case 13:
				SetDebilitationRes(-100, 6);
				SetDebilitationRes(-100, 10);
				SetDebilitationRes(-100, 12);
				break;
			case 14:
				SetDebilitationRes(-24, 6);
				break;
			case 15:
				SetDebilitationRes(-32, 7);
				SetDebilitationRes(-30, 0);
				break;
			case 16:
				chara.SetAtk(-2);
				chara.SetMAtk(-1);
				SetDebilitationRes(-30, 6);
				SetDebilitationRes(-28, 2);
				break;
			case 17:
				chara.SetMAtk(-4);
				SetDebilitationRes(-60, 6);
				break;
			case 18:
				SetDebilitationRes(-48, 12);
				SetDebilitationRes(-32, 0);
				break;
			case 19:
				SetDebilitationRes(-36, 9);
				SetDebilitationRes(-36, 10);
				break;
			case 20:
				SetDebilitationRes(-35, 7);
				SetDebilitationRes(-24, 9);
				break;
			case 21:
				SetDebilitationRes(-70, 5);
				SetDebilitationRes(-33, 0);
				break;
			case 22:
				chara.SetAtk(-6);
				SetDebilitationRes(-35, 2);
				SetDebilitationRes(-30, 8);
				break;
			case 23:
				chara.SetMAtk(-10);
				SetDebilitationRes(-80, 0);
				SetDebilitationRes(-26, 10);
				SetDebilitationRes(-26, 12);
				break;
			case 24:
				chara.SetAtk(-5);
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-52, 9);
				break;
			case 25:
				SetDebilitationRes(-50, 4);
				break;
			case 26:
				SetDebilitationRes(-60, 4);
				break;
			case 27:
				SetDebilitationRes(-100, 4);
				SetDebilitationRes(-54, 9);
				SetDebilitationRes(-54, 10);
				break;
			case 28:
				SetDebilitationRes(-35, 4);
				break;
			case 29:
				SetDebilitationRes(-35, 8);
				break;
			case 30:
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 8);
				break;
			case 31:
				SetDebilitationRes(-32, 5);
				SetDebilitationRes(-30, 4);
				break;
			case 32:
				SetDebilitationRes(-40, 2);
				break;
			case 33:
				SetDebilitationRes(-28, 6);
				break;
			case 34:
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 11);
				break;
			case 35:
				SetDebilitationRes(-36, 5);
				break;
			case 36:
				SetDebilitationRes(-12, 6);
				SetDebilitationRes(-12, 7);
				break;
			case 37:
				SetDebilitationRes(-35, 4);
				SetDebilitationRes(-27, 0);
				break;
			case 38:
				SetDebilitationRes(-100, 3);
				SetDebilitationRes(-80, 4);
				break;
			case 39:
				SetDebilitationRes(-28, 8);
				SetDebilitationRes(-24, 6);
				SetDebilitationRes(-20, 2);
				break;
			case 40:
				SetDebilitationRes(-32, 5);
				break;
			case 41:
				SetDebilitationRes(-44, 7);
				break;
			case 42:
				SetDebilitationRes(-32, 8);
				SetDebilitationRes(-30, 0);
				break;
			case 43:
				SetDebilitationRes(-32, 4);
				SetDebilitationRes(-30, 8);
				break;
			case 44:
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-30, 6);
				break;
			case 45:
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-30, 6);
				break;
			case 46:
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-60, 8);
				break;
			case 47:
				SetDebilitationRes(-48, 2);
				break;
			case 48:
				SetDebilitationRes(-40, 2);
				SetDebilitationRes(-18, 4);
				break;
			case 49:
				SetDebilitationRes(-32, 2);
				break;
			case 50:
				SetDebilitationRes(-28, 6);
				SetDebilitationRes(-28, 8);
				break;
			case 51:
				chara.SetMAtk(-7);
				SetDebilitationRes(-60, 3);
				SetDebilitationRes(-48, 8);
				break;
			case 52:
				SetDebilitationRes(-24, 6);
				break;
			case 53:
				SetDebilitationRes(-100, 2);
				SetDebilitationRes(-100, 5);
				SetDebilitationRes(-100, 6);
				break;
			case 54:
				SetDebilitationRes(-24, 5);
				break;
			case 55:
				SetDebilitationRes(-45, 4);
				SetDebilitationRes(-36, 9);
				break;
			case 56:
				SetDebilitationRes(-100, 7);
				break;
			case 57:
				SetDebilitationRes(-45, 2);
				SetDebilitationRes(-30, 0);
				break;
			case 58:
				SetDebilitationRes(-56, 1);
				SetDebilitationRes(-32, 4);
				break;
			case 59:
				SetDebilitationRes(-24, 7);
				break;
			case 60:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-60, 3);
				break;
			case 61:
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-30, 7);
				break;
			case 62:
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 7);
				break;
			case 63:
				SetDebilitationRes(-12, 4);
				SetDebilitationRes(-12, 7);
				break;
			case 64:
				SetDebilitationRes(-24, 5);
				break;
			case 65:
				SetDebilitationRes(-32, 5);
				break;
			case 66:
				SetDebilitationRes(-10, 4);
				break;
			case 67:
				SetDebilitationRes(-80, 12);
				SetDebilitationRes(-55, 8);
				break;
			case 68:
				SetDebilitationRes(-12, 5);
				SetDebilitationRes(-12, 7);
				break;
			case 69:
				SetDebilitationRes(-32, 6);
				break;
			case 70:
				SetDebilitationRes(-39, 10);
				SetDebilitationRes(-14, 0);
				break;
			case 71:
				SetDebilitationRes(-70, 5);
				SetDebilitationRes(-40, 0);
				break;
			case 72:
				SetDebilitationRes(-55, 2);
				SetDebilitationRes(-32, 8);
				break;
			case 73:
				SetDebilitationRes(-28, 3);
				SetDebilitationRes(-28, 4);
				break;
			case 74:
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 11);
				break;
			case 75:
				SetDebilitationRes(-24, 2);
				break;
			case 76:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-21, 8);
				break;
			case 77:
				SetDebilitationRes(-48, 5);
				SetDebilitationRes(-36, 7);
				SetDebilitationRes(-33, 8);
				break;
			case 78:
				SetDebilitationRes(-50, 8);
				SetDebilitationRes(-48, 0);
				break;
			case 79:
				SetDebilitationRes(-40, 6);
				SetDebilitationRes(-27, 3);
				break;
			case 80:
				SetDebilitationRes(-24, 5);
				break;
			case 81:
				SetDebilitationRes(-40, 2);
				SetDebilitationRes(-36, 10);
				break;
			case 82:
				SetDebilitationRes(-35, 7);
				break;
		}
		iCurrent[0] = Equipment[0].value;
		switch (iCurrent[0]) {
			case 1:
				SetDebilitationRes(60, 3);
				SetDebilitationRes(60, 10);
				break;
			case 2:
				SetDebilitationRes(40, 0);
				SetDebilitationRes(40, 1);
				SetDebilitationRes(40, 3);
				SetDebilitationRes(40, 4);
				SetDebilitationRes(40, 5);
				SetDebilitationRes(40, 7);
				SetDebilitationRes(40, 8);
				SetDebilitationRes(15, 2);
				SetDebilitationRes(15, 6);
				break;
			case 3:
				SetDebilitationRes(80, 10);
				SetDebilitationRes(56, 12);
				break;
			case 4:
				SetDebilitationRes(36, 6);
				SetDebilitationRes(27, 7);
				break;
			case 5:
				SetDebilitationRes(60, 2);
				SetDebilitationRes(48, 4);
				break;
			case 6:
				SetDebilitationRes(40, 6);
				SetDebilitationRes(28, 7);
				break;
			case 7:
				chara.SetAtk(10);
				SetDebilitationRes(100, 9);
				SetDebilitationRes(100, 11);
				SetDebilitationRes(36, 8);
				break;
			case 8:
				SetDebilitationRes(32, 1);
				SetDebilitationRes(27, 0);
				break;
			case 9:
				SetDebilitationRes(12, 2);
				SetDebilitationRes(12, 7);
				break;
			case 10:
				SetDebilitationRes(24, 4);
				break;
			case 11:
				SetDebilitationRes(100, 3);
				SetDebilitationRes(100, 6);
				SetDebilitationRes(60, 8);
				break;
			case 12:
				SetDebilitationRes(100, 1);
				SetDebilitationRes(100, 7);
				SetDebilitationRes(5, 9);
				SetDebilitationRes(5, 10);
				SetDebilitationRes(5, 11);
				SetDebilitationRes(5, 12);
				break;
			case 13:
				SetDebilitationRes(100, 6);
				SetDebilitationRes(100, 10);
				SetDebilitationRes(100, 12);
				break;
			case 14:
				SetDebilitationRes(24, 6);
				break;
			case 15:
				SetDebilitationRes(32, 7);
				SetDebilitationRes(30, 0);
				break;
			case 16:
				chara.SetAtk(2);
				chara.SetMAtk(1);
				SetDebilitationRes(30, 6);
				SetDebilitationRes(28, 2);
				break;
			case 17:
				chara.SetMAtk(4);
				SetDebilitationRes(60, 6);
				break;
			case 18:
				SetDebilitationRes(48, 12);
				SetDebilitationRes(32, 0);
				break;
			case 19:
				SetDebilitationRes(36, 9);
				SetDebilitationRes(36, 10);
				break;
			case 20:
				SetDebilitationRes(35, 7);
				SetDebilitationRes(24, 9);
				break;
			case 21:
				SetDebilitationRes(70, 5);
				SetDebilitationRes(33, 0);
				break;
			case 22:
				chara.SetAtk(6);
				SetDebilitationRes(35, 2);
				SetDebilitationRes(30, 8);
				break;
			case 23:
				chara.SetMAtk(10);
				SetDebilitationRes(80, 0);
				SetDebilitationRes(26, 10);
				SetDebilitationRes(26, 12);
				break;
			case 24:
				chara.SetAtk(5);
				SetDebilitationRes(100, 7);
				SetDebilitationRes(52, 9);
				break;
			case 25:
				SetDebilitationRes(50, 4);
				break;
			case 26:
				SetDebilitationRes(60, 4);
				break;
			case 27:
				SetDebilitationRes(100, 4);
				SetDebilitationRes(54, 9);
				SetDebilitationRes(54, 10);
				break;
			case 28:
				SetDebilitationRes(35, 4);
				break;
			case 29:
				SetDebilitationRes(35, 8);
				break;
			case 30:
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 8);
				break;
			case 31:
				SetDebilitationRes(32, 5);
				SetDebilitationRes(30, 4);
				break;
			case 32:
				SetDebilitationRes(40, 2);
				break;
			case 33:
				SetDebilitationRes(28, 6);
				break;
			case 34:
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 11);
				break;
			case 35:
				SetDebilitationRes(36, 5);
				break;
			case 36:
				SetDebilitationRes(12, 6);
				SetDebilitationRes(12, 7);
				break;
			case 37:
				SetDebilitationRes(35, 4);
				SetDebilitationRes(27, 0);
				break;
			case 38:
				SetDebilitationRes(100, 3);
				SetDebilitationRes(80, 4);
				break;
			case 39:
				SetDebilitationRes(28, 8);
				SetDebilitationRes(24, 6);
				SetDebilitationRes(20, 2);
				break;
			case 40:
				SetDebilitationRes(32, 5);
				break;
			case 41:
				SetDebilitationRes(44, 7);
				break;
			case 42:
				SetDebilitationRes(32, 8);
				SetDebilitationRes(30, 0);
				break;
			case 43:
				SetDebilitationRes(32, 4);
				SetDebilitationRes(30, 8);
				break;
			case 44:
				SetDebilitationRes(60, 9);
				SetDebilitationRes(30, 6);
				break;
			case 45:
				SetDebilitationRes(60, 9);
				SetDebilitationRes(30, 6);
				break;
			case 46:
				SetDebilitationRes(60, 5);
				SetDebilitationRes(60, 8);
				break;
			case 47:
				SetDebilitationRes(48, 2);
				break;
			case 48:
				SetDebilitationRes(40, 2);
				SetDebilitationRes(18, 4);
				break;
			case 49:
				SetDebilitationRes(32, 2);
				break;
			case 50:
				SetDebilitationRes(28, 6);
				SetDebilitationRes(28, 8);
				break;
			case 51:
				chara.SetMAtk(7);
				SetDebilitationRes(60, 3);
				SetDebilitationRes(48, 8);
				break;
			case 52:
				SetDebilitationRes(24, 6);
				break;
			case 53:
				SetDebilitationRes(100, 2);
				SetDebilitationRes(100, 5);
				SetDebilitationRes(100, 6);
				break;
			case 54:
				SetDebilitationRes(24, 5);
				break;
			case 55:
				SetDebilitationRes(45, 4);
				SetDebilitationRes(36, 9);
				break;
			case 56:
				SetDebilitationRes(100, 7);
				break;
			case 57:
				SetDebilitationRes(45, 2);
				SetDebilitationRes(30, 0);
				break;
			case 58:
				SetDebilitationRes(56, 1);
				SetDebilitationRes(32, 4);
				break;
			case 59:
				SetDebilitationRes(24, 7);
				break;
			case 60:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(60, 3);
				break;
			case 61:
				SetDebilitationRes(32, 6);
				SetDebilitationRes(30, 7);
				break;
			case 62:
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 7);
				break;
			case 63:
				SetDebilitationRes(12, 4);
				SetDebilitationRes(12, 7);
				break;
			case 64:
				SetDebilitationRes(24, 5);
				break;
			case 65:
				SetDebilitationRes(32, 5);
				break;
			case 66:
				SetDebilitationRes(10, 4);
				break;
			case 67:
				SetDebilitationRes(80, 12);
				SetDebilitationRes(55, 8);
				break;
			case 68:
				SetDebilitationRes(12, 5);
				SetDebilitationRes(12, 7);
				break;
			case 69:
				SetDebilitationRes(32, 6);
				break;
			case 70:
				SetDebilitationRes(39, 10);
				SetDebilitationRes(14, 0);
				break;
			case 71:
				SetDebilitationRes(70, 5);
				SetDebilitationRes(40, 0);
				break;
			case 72:
				SetDebilitationRes(55, 2);
				SetDebilitationRes(32, 8);
				break;
			case 73:
				SetDebilitationRes(28, 3);
				SetDebilitationRes(28, 4);
				break;
			case 74:
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 11);
				break;
			case 75:
				SetDebilitationRes(24, 2);
				break;
			case 76:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(21, 8);
				break;
			case 77:
				SetDebilitationRes(48, 5);
				SetDebilitationRes(36, 7);
				SetDebilitationRes(33, 8);
				break;
			case 78:
				SetDebilitationRes(50, 8);
				SetDebilitationRes(48, 0);
				break;
			case 79:
				SetDebilitationRes(40, 6);
				SetDebilitationRes(27, 3);
				break;
			case 80:
				SetDebilitationRes(24, 5);
				break;
			case 81:
				SetDebilitationRes(40, 2);
				SetDebilitationRes(36, 10);
				break;
			case 82:
				SetDebilitationRes(35, 7);
				break;
		}
	}
	private void SwitchTClothing() {
		switch (iCurrent[1]) {
			case 1:
				SetDebilitationRes(-36, 0);
				SetDebilitationRes(-33, 8);
				break;
			case 2:
				SetDebilitationRes(-35, 6);
				break;
			case 3:
				SetDebilitationRes(-24, 6);
				break;
			case 4:
				SetDebilitationRes(-15, 5);
				SetDebilitationRes(-15, 11);
				break;
			case 5:
				SetDebilitationRes(-24, 8);
				break;
			case 6:
				SetDebilitationRes(-20, 3);
				break;
			case 7:
				SetDebilitationRes(-35, 11);
				break;
			case 8:
				SetDebilitationRes(-30, 2);
				break;
			case 11:
				chara.SetAtk(-3);
				SetDebilitationRes(-28, 4);
				break;
			case 13:
				SetDebilitationRes(-30, 7);
				break;
			case 15:
				SetDebilitationRes(-36, 8);
				break;
			case 22:
				SetDebilitationRes(-40, 4);
				break;
			case 23:
				SetDebilitationRes(-21, 2);
				break;
			case 24:
				SetDebilitationRes(-30, 3);
				break;
			case 25:
				SetDebilitationRes(-20, 5);
				break;
			case 27:
				SetDebilitationRes(-15, 2);
				break;
			case 28:
				SetDebilitationRes(-40, 0);
				break;
			case 29:
				chara.SetAtk(-5);
				SetDebilitationRes(-25, 4);
				break;
			case 30:
				SetDebilitationRes(-24, 3);
				SetDebilitationRes(-24, 8);
				break;
			case 31:
				SetDebilitationRes(-24, 2);
				SetDebilitationRes(-24, 4);
				SetDebilitationRes(-6, 9);
				break;
			case 32:
				SetDebilitationRes(-35, 7);
				break;
			case 35:
				SetDebilitationRes(-20, 8);
				break;
			case 36:
				SetDebilitationRes(-21, 8);
				break;
			case 37:
				SetDebilitationRes(-32, 1);
				break;
			case 39:
				SetDebilitationRes(-35, 5);
				break;
		}
		iCurrent[1] = Equipment[1].value;
		switch (iCurrent[1]) {
			case 1:
				SetDebilitationRes(36, 0);
				SetDebilitationRes(33, 8);
				break;
			case 2:
				SetDebilitationRes(35, 6);
				break;
			case 3:
				SetDebilitationRes(24, 6);
				break;
			case 4:
				SetDebilitationRes(15, 5);
				SetDebilitationRes(15, 11);
				break;
			case 5:
				SetDebilitationRes(24, 8);
				break;
			case 6:
				SetDebilitationRes(20, 3);
				break;
			case 7:
				SetDebilitationRes(35, 11);
				break;
			case 8:
				SetDebilitationRes(30, 2);
				break;
			case 11:
				chara.SetAtk(3);
				SetDebilitationRes(28, 4);
				break;
			case 13:
				SetDebilitationRes(30, 7);
				break;
			case 15:
				SetDebilitationRes(36, 8);
				break;
			case 22:
				SetDebilitationRes(40, 4);
				break;
			case 23:
				SetDebilitationRes(21, 2);
				break;
			case 24:
				SetDebilitationRes(30, 3);
				break;
			case 25:
				SetDebilitationRes(20, 5);
				break;
			case 27:
				SetDebilitationRes(15, 2);
				break;
			case 28:
				SetDebilitationRes(40, 0);
				break;
			case 29:
				chara.SetAtk(5);
				SetDebilitationRes(25, 4);
				break;
			case 30:
				SetDebilitationRes(24, 3);
				SetDebilitationRes(24, 8);
				break;
			case 31:
				SetDebilitationRes(24, 2);
				SetDebilitationRes(24, 4);
				SetDebilitationRes(6, 9);
				break;
			case 32:
				SetDebilitationRes(35, 7);
				break;
			case 35:
				SetDebilitationRes(20, 8);
				break;
			case 36:
				SetDebilitationRes(21, 8);
				break;
			case 37:
				SetDebilitationRes(32, 1);
				break;
			case 39:
				SetDebilitationRes(35, 5);
				break;
		}
	}
	private void SwitchChest() {
		switch (iCurrent[2]) {
			case 1:
				SetDebilitationRes(-84, 3);
				SetDebilitationRes(-84, 6);
				SetDebilitationRes(-84, 8);
				break;
			case 2:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-60, 3);
				SetDebilitationRes(-60, 10);
				break;
			case 3:
				SetDebilitationRes(-48, 0);
				SetDebilitationRes(-48, 1);
				SetDebilitationRes(-48, 3);
				SetDebilitationRes(-48, 4);
				SetDebilitationRes(-48, 5);
				SetDebilitationRes(-48, 8);
				SetDebilitationRes(-18, 2);
				SetDebilitationRes(-18, 6);
				break;
			case 4:
				SetDebilitationRes(-66, 10);
				SetDebilitationRes(-52, 6);
				SetDebilitationRes(-50, 8);
				break;
			case 5:
				SetDebilitationRes(-70, 7);
				SetDebilitationRes(-57, 4);
				break;
			case 7:
				SetDebilitationRes(-100, 3);
				SetDebilitationRes(-100, 4);
				SetDebilitationRes(-5, 9);
				SetDebilitationRes(-5, 10);
				SetDebilitationRes(-5, 11);
				SetDebilitationRes(-5, 12);
				break;
			case 8:
				SetDebilitationRes(-100, 3);
				SetDebilitationRes(-100, 4);
				SetDebilitationRes(-10, 9);
				SetDebilitationRes(-10, 10);
				SetDebilitationRes(-10, 11);
				SetDebilitationRes(-10, 12);
				break;
			case 9:
				SetDebilitationRes(-100, 2);
				SetDebilitationRes(-100, 9);
				SetDebilitationRes(-60, 12);
				break;
			case 10:
				SetDebilitationRes(-100, 3);
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-100, 8);
				break;
			case 11:
				SetDebilitationRes(-92, 3);
				SetDebilitationRes(-84, 10);
				SetDebilitationRes(-84, 12);
				break;
			case 12:
				SetDebilitationRes(-65, 8);
				SetDebilitationRes(-63, 11);
				break;
			case 13:
				SetDebilitationRes(-48, 11);
				SetDebilitationRes(-35, 8);
				break;
			case 14:
				SetDebilitationRes(-33, 4);
				break;
			case 15:
				SetDebilitationRes(-45, 2);
				break;
			case 16:
				SetDebilitationRes(-72, 2);
				SetDebilitationRes(-33, 0);
				break;
			case 17:
				SetDebilitationRes(-60, 6);
				SetDebilitationRes(-60, 7);
				SetDebilitationRes(-60, 8);
				break;
			case 18:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-36, 0);
				break;
			case 19:
				SetDebilitationRes(-28, 6);
				break;
			case 20:
				chara.SetAtk(-3);
				chara.SetMAtk(-2);
				SetDebilitationRes(-40, 6);
				SetDebilitationRes(-36, 2);
				break;
			case 21:
				SetDebilitationRes(-45, 7);
				SetDebilitationRes(-39, 9);
				break;
			case 22:
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-56, 4);
				break;
			case 23:
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 10);
				break;
			case 24:
				SetDebilitationRes(-48, 5);
				SetDebilitationRes(-36, 8);
				SetDebilitationRes(-32, 10);
				break;
			case 25:
				SetDebilitationRes(-56, 5);
				SetDebilitationRes(-48, 7);
				SetDebilitationRes(-39, 8);
				break;
			case 26:
				SetDebilitationRes(-70, 8);
				break;
			case 27:
				SetDebilitationRes(-40, 5);
				SetDebilitationRes(-36, 4);
				break;
			case 28:
				SetDebilitationRes(-70, 6);
				SetDebilitationRes(-45, 8);
				break;
			case 29:
				SetDebilitationRes(-38, 5);
				SetDebilitationRes(-27, 4);
				break;
			case 30:
				chara.SetAtk(-20);
				SetDebilitationRes(-100, 9);
				SetDebilitationRes(-94, 4);
				SetDebilitationRes(-80, 10);
				SetDebilitationRes(-72, 0);
				break;
			case 31:
				SetDebilitationRes(-44, 4);
				SetDebilitationRes(-26, 0);
				break;
			case 32:
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-48, 7);
				break;
			case 33:
				SetDebilitationRes(-32, 8);
				SetDebilitationRes(-28, 6);
				SetDebilitationRes(-24, 2);
				break;
			case 34:
				SetDebilitationRes(-44, 5);
				break;
			case 35:
				SetDebilitationRes(-50, 2);
				break;
			case 36:
				SetDebilitationRes(-40, 8);
				SetDebilitationRes(-36, 0);
				break;
			case 37:
				SetDebilitationRes(-40, 4);
				SetDebilitationRes(-36, 8);
				break;
			case 38:
				SetDebilitationRes(-42, 6);
				break;
			case 39:
				SetDebilitationRes(-55, 7);
				break;
			case 40:
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 2);
				break;
			case 41:
				SetDebilitationRes(-55, 2);
				SetDebilitationRes(-21, 4);
				break;
			case 42:
				SetDebilitationRes(-55, 5);
				SetDebilitationRes(-24, 0);
				break;
			case 43:
				SetDebilitationRes(-36, 5);
				break;
			case 44:
			case 46:
				SetDebilitationRes(-32, 5);
				break;
			case 45:
				SetDebilitationRes(-35, 5);
				break;
			case 47:
				SetDebilitationRes(-70, 2);
				break;
			case 48:
				SetDebilitationRes(-80, 0);
				break;
			case 49:
				SetDebilitationRes(-55, 6);
				SetDebilitationRes(-52, 0);
				break;
			case 50:
				SetDebilitationRes(-68, 0);
				SetDebilitationRes(-44, 4);
				break;
			case 51:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-30, 3);
				break;
			case 52:
				SetDebilitationRes(-40, 6);
				SetDebilitationRes(-36, 7);
				break;
			case 53:
				SetDebilitationRes(-80, 1);
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-56, 5);
				SetDebilitationRes(-54, 7);
				SetDebilitationRes(-52, 4);
				break;
			case 54:
				SetDebilitationRes(-50, 6);
				SetDebilitationRes(-50, 10);
				break;
			case 55:
				SetDebilitationRes(-48, 6);
				break;
			case 56:
				SetDebilitationRes(-100, 1);
				break;
			case 57:
				SetDebilitationRes(-99, 7);
				SetDebilitationRes(-90, 10);
				SetDebilitationRes(-90, 12);
				break;
			case 58:
				SetDebilitationRes(-72, 4);
				SetDebilitationRes(-56, 0);
				SetDebilitationRes(-32, 8);
				break;
			case 59:
				SetDebilitationRes(-65, 5);
				break;
			case 60:
				SetDebilitationRes(-65, 4);
				SetDebilitationRes(-45, 9);
				break;
			case 61:
				SetDebilitationRes(-24, 1);
				SetDebilitationRes(-20, 2);
				SetDebilitationRes(-20, 5);
				SetDebilitationRes(-20, 6);
				SetDebilitationRes(-20, 7);
				break;
			case 62:
				SetDebilitationRes(-84, 5);
				SetDebilitationRes(-54, 12);
				SetDebilitationRes(-44, 7);
				break;
			case 63:
				SetDebilitationRes(-69, 12);
				SetDebilitationRes(-68, 3);
				SetDebilitationRes(-36, 7);
				break;
			case 64:
				SetDebilitationRes(-72, 6);
				SetDebilitationRes(-45, 5);
				SetDebilitationRes(-36, 7);
				break;
			case 65:
				SetDebilitationRes(-45, 5);
				SetDebilitationRes(-36, 3);
				break;
			case 66:
				SetDebilitationRes(-24, 2);
				break;
			case 67:
				SetDebilitationRes(-40, 2);
				break;
			case 68:
				SetDebilitationRes(-48, 6);
				SetDebilitationRes(-27, 2);
				break;
			case 69:
				SetDebilitationRes(-24, 6);
				break;
			case 70:
				SetDebilitationRes(-51, 7);
				break;
			case 71:
				SetDebilitationRes(-51, 10);
				SetDebilitationRes(-18, 0);
				break;
			case 72:
				SetDebilitationRes(-64, 2);
				SetDebilitationRes(-45, 0);
				break;
			case 73:
				SetDebilitationRes(-55, 8);
				SetDebilitationRes(-48, 2);
				break;
			case 74:
				SetDebilitationRes(-40, 4);
				break;
			case 75:
				SetDebilitationRes(-35, 3);
				SetDebilitationRes(-35, 7);
				break;
			case 76:
				chara.SetMAtk(-20);
				SetDebilitationRes(-60, 11);
				SetDebilitationRes(-60, 12);
				break;
			case 77:
				SetDebilitationRes(-56, 12);
				SetDebilitationRes(-50, 2);
				break;
			case 78:
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 6);
				break;
			case 79:
				SetDebilitationRes(-45, 0);
				SetDebilitationRes(-45, 4);
				break;
			case 80:
				SetDebilitationRes(-45, 4);
				break;
		}
		iCurrent[2] = Equipment[2].value;
		switch (iCurrent[2]) {
			case 1:
				SetDebilitationRes(84, 3);
				SetDebilitationRes(84, 6);
				SetDebilitationRes(84, 8);
				break;
			case 2:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(60, 3);
				SetDebilitationRes(60, 10);
				break;
			case 3:
				SetDebilitationRes(48, 0);
				SetDebilitationRes(48, 1);
				SetDebilitationRes(48, 3);
				SetDebilitationRes(48, 4);
				SetDebilitationRes(48, 5);
				SetDebilitationRes(48, 8);
				SetDebilitationRes(18, 2);
				SetDebilitationRes(18, 6);
				break;
			case 4:
				SetDebilitationRes(66, 10);
				SetDebilitationRes(52, 6);
				SetDebilitationRes(50, 8);
				break;
			case 5:
				SetDebilitationRes(70, 7);
				SetDebilitationRes(57, 4);
				break;
			case 7:
				SetDebilitationRes(100, 3);
				SetDebilitationRes(100, 4);
				SetDebilitationRes(5, 9);
				SetDebilitationRes(5, 10);
				SetDebilitationRes(5, 11);
				SetDebilitationRes(5, 12);
				break;
			case 8:
				SetDebilitationRes(100, 3);
				SetDebilitationRes(100, 4);
				SetDebilitationRes(10, 9);
				SetDebilitationRes(10, 10);
				SetDebilitationRes(10, 11);
				SetDebilitationRes(10, 12);
				break;
			case 9:
				SetDebilitationRes(100, 2);
				SetDebilitationRes(100, 9);
				SetDebilitationRes(60, 12);
				break;
			case 10:
				SetDebilitationRes(100, 3);
				SetDebilitationRes(100, 7);
				SetDebilitationRes(100, 8);
				break;
			case 11:
				SetDebilitationRes(92, 3);
				SetDebilitationRes(84, 10);
				SetDebilitationRes(84, 12);
				break;
			case 12:
				SetDebilitationRes(65, 8);
				SetDebilitationRes(63, 11);
				break;
			case 13:
				SetDebilitationRes(48, 11);
				SetDebilitationRes(35, 8);
				break;
			case 14:
				SetDebilitationRes(33, 4);
				break;
			case 15:
				SetDebilitationRes(45, 2);
				break;
			case 16:
				SetDebilitationRes(72, 2);
				SetDebilitationRes(33, 0);
				break;
			case 17:
				SetDebilitationRes(60, 6);
				SetDebilitationRes(60, 7);
				SetDebilitationRes(60, 8);
				break;
			case 18:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(36, 0);
				break;
			case 19:
				SetDebilitationRes(28, 6);
				break;
			case 20:
				chara.SetAtk(3);
				chara.SetMAtk(2);
				SetDebilitationRes(40, 6);
				SetDebilitationRes(36, 2);
				break;
			case 21:
				SetDebilitationRes(45, 7);
				SetDebilitationRes(39, 9);
				break;
			case 22:
				SetDebilitationRes(60, 5);
				SetDebilitationRes(56, 4);
				break;
			case 23:
				SetDebilitationRes(60, 5);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 10);
				break;
			case 24:
				SetDebilitationRes(48, 5);
				SetDebilitationRes(36, 8);
				SetDebilitationRes(32, 10);
				break;
			case 25:
				SetDebilitationRes(56, 5);
				SetDebilitationRes(48, 7);
				SetDebilitationRes(39, 8);
				break;
			case 26:
				SetDebilitationRes(70, 8);
				break;
			case 27:
				SetDebilitationRes(40, 5);
				SetDebilitationRes(36, 4);
				break;
			case 28:
				SetDebilitationRes(70, 6);
				SetDebilitationRes(45, 8);
				break;
			case 29:
				SetDebilitationRes(38, 5);
				SetDebilitationRes(27, 4);
				break;
			case 30:
				chara.SetAtk(20);
				SetDebilitationRes(100, 9);
				SetDebilitationRes(94, 4);
				SetDebilitationRes(80, 10);
				SetDebilitationRes(72, 0);
				break;
			case 31:
				SetDebilitationRes(44, 4);
				SetDebilitationRes(26, 0);
				break;
			case 32:
				SetDebilitationRes(60, 4);
				SetDebilitationRes(48, 7);
				break;
			case 33:
				SetDebilitationRes(32, 8);
				SetDebilitationRes(28, 6);
				SetDebilitationRes(24, 2);
				break;
			case 34:
				SetDebilitationRes(44, 5);
				break;
			case 35:
				SetDebilitationRes(50, 2);
				break;
			case 36:
				SetDebilitationRes(40, 8);
				SetDebilitationRes(36, 0);
				break;
			case 37:
				SetDebilitationRes(40, 4);
				SetDebilitationRes(36, 8);
				break;
			case 38:
				SetDebilitationRes(42, 6);
				break;
			case 39:
				SetDebilitationRes(55, 7);
				break;
			case 40:
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 2);
				break;
			case 41:
				SetDebilitationRes(55, 2);
				SetDebilitationRes(21, 4);
				break;
			case 42:
				SetDebilitationRes(55, 5);
				SetDebilitationRes(24, 0);
				break;
			case 43:
				SetDebilitationRes(36, 5);
				break;
			case 44:
			case 46:
				SetDebilitationRes(32, 5);
				break;
			case 45:
				SetDebilitationRes(35, 5);
				break;
			case 47:
				SetDebilitationRes(70, 2);
				break;
			case 48:
				SetDebilitationRes(80, 0);
				break;
			case 49:
				SetDebilitationRes(55, 6);
				SetDebilitationRes(52, 0);
				break;
			case 50:
				SetDebilitationRes(68, 0);
				SetDebilitationRes(44, 4);
				break;
			case 51:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(30, 3);
				break;
			case 52:
				SetDebilitationRes(40, 6);
				SetDebilitationRes(36, 7);
				break;
			case 53:
				SetDebilitationRes(80, 1);
				SetDebilitationRes(60, 2);
				SetDebilitationRes(56, 5);
				SetDebilitationRes(54, 7);
				SetDebilitationRes(52, 4);
				break;
			case 54:
				SetDebilitationRes(50, 6);
				SetDebilitationRes(50, 10);
				break;
			case 55:
				SetDebilitationRes(48, 6);
				break;
			case 56:
				SetDebilitationRes(100, 1);
				break;
			case 57:
				SetDebilitationRes(99, 7);
				SetDebilitationRes(90, 10);
				SetDebilitationRes(90, 12);
				break;
			case 58:
				SetDebilitationRes(72, 4);
				SetDebilitationRes(56, 0);
				SetDebilitationRes(32, 8);
				break;
			case 59:
				SetDebilitationRes(65, 5);
				break;
			case 60:
				SetDebilitationRes(65, 4);
				SetDebilitationRes(45, 9);
				break;
			case 61:
				SetDebilitationRes(24, 1);
				SetDebilitationRes(20, 2);
				SetDebilitationRes(20, 5);
				SetDebilitationRes(20, 6);
				SetDebilitationRes(20, 7);
				break;
			case 62:
				SetDebilitationRes(84, 5);
				SetDebilitationRes(54, 12);
				SetDebilitationRes(44, 7);
				break;
			case 63:
				SetDebilitationRes(69, 12);
				SetDebilitationRes(68, 3);
				SetDebilitationRes(36, 7);
				break;
			case 64:
				SetDebilitationRes(72, 6);
				SetDebilitationRes(45, 5);
				SetDebilitationRes(36, 7);
				break;
			case 65:
				SetDebilitationRes(45, 5);
				SetDebilitationRes(36, 3);
				break;
			case 66:
				SetDebilitationRes(24, 2);
				break;
			case 67:
				SetDebilitationRes(40, 2);
				break;
			case 68:
				SetDebilitationRes(48, 6);
				SetDebilitationRes(27, 2);
				break;
			case 69:
				SetDebilitationRes(24, 6);
				break;
			case 70:
				SetDebilitationRes(51, 7);
				break;
			case 71:
				SetDebilitationRes(51, 10);
				SetDebilitationRes(18, 0);
				break;
			case 72:
				SetDebilitationRes(64, 2);
				SetDebilitationRes(45, 0);
				break;
			case 73:
				SetDebilitationRes(55, 8);
				SetDebilitationRes(48, 2);
				break;
			case 74:
				SetDebilitationRes(40, 4);
				break;
			case 75:
				SetDebilitationRes(35, 3);
				SetDebilitationRes(35, 7);
				break;
			case 76:
				chara.SetMAtk(20);
				SetDebilitationRes(60, 11);
				SetDebilitationRes(60, 12);
				break;
			case 77:
				SetDebilitationRes(56, 12);
				SetDebilitationRes(50, 2);
				break;
			case 78:
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 6);
				break;
			case 79:
				SetDebilitationRes(45, 0);
				SetDebilitationRes(45, 4);
				break;
			case 80:
				SetDebilitationRes(45, 4);
				break;
		}
	}
	private void SwitchArms() {
	}
	private void SwitchLClothing() {
		switch (iCurrent[4]) {
			case 1:
				SetDebilitationRes(-30, 6);
				break;
			case 2:
				SetDebilitationRes(-30, 4);
				break;
			case 3:
				SetDebilitationRes(-25, 7);
				break;
			case 4:
				SetDebilitationRes(-30, 11);
				break;
			case 5:
				SetDebilitationRes(-25, 5);
				break;
			case 6:
				SetDebilitationRes(-30, 6);
				break;
			case 9:
				SetDebilitationRes(-45, 0);
				SetDebilitationRes(-45, 1);
				break;
			case 10:
				SetDebilitationRes(-20, 5);
				break;
			case 11:
				SetDebilitationRes(-35, 2);
				break;
			case 16:
				SetDebilitationRes(-35, 4);
				break;
			case 17:
				SetDebilitationRes(-30, 2);
				break;
			case 18:
				SetDebilitationRes(-25, 4);
				SetDebilitationRes(-20, 2);
				break;
			case 19:
				SetDebilitationRes(-16, 5);
				break;
			case 20:
				SetDebilitationRes(-30, 5);
				SetDebilitationRes(-24, 4);
				break;
			case 21:
				SetDebilitationRes(-20, 4);
				break;
			case 23:
				SetDebilitationRes(-45, 10);
				SetDebilitationRes(-45, 12);
				break;
			case 24:
				SetDebilitationRes(-45, 3);
				SetDebilitationRes(-45, 4);
				break;
			case 25:
				SetDebilitationRes(-18, 8);
				break;
			case 26:
				SetDebilitationRes(-24, 9);
				SetDebilitationRes(-15, 4);
				break;
			case 28:
				SetDebilitationRes(-35, 0);
				break;
			case 29:
				SetDebilitationRes(-35, 7);
				break;
			case 30:
				SetDebilitationRes(-30, 3);
				break;
			case 31:
				SetDebilitationRes(-16, 2);
				break;
		}
		iCurrent[4] = Equipment[4].value;
		switch (iCurrent[4]) {
			case 1:
				SetDebilitationRes(30, 6);
				break;
			case 2:
				SetDebilitationRes(30, 4);
				break;
			case 3:
				SetDebilitationRes(25, 7);
				break;
			case 4:
				SetDebilitationRes(30, 11);
				break;
			case 5:
				SetDebilitationRes(25, 5);
				break;
			case 6:
				SetDebilitationRes(30, 6);
				break;
			case 9:
				SetDebilitationRes(45, 0);
				SetDebilitationRes(45, 1);
				break;
			case 10:
				SetDebilitationRes(20, 5);
				break;
			case 11:
				SetDebilitationRes(35, 2);
				break;
			case 16:
				SetDebilitationRes(35, 4);
				break;
			case 17:
				SetDebilitationRes(30, 2);
				break;
			case 18:
				SetDebilitationRes(25, 4);
				SetDebilitationRes(20, 2);
				break;
			case 19:
				SetDebilitationRes(16, 5);
				break;
			case 20:
				SetDebilitationRes(30, 5);
				SetDebilitationRes(24, 4);
				break;
			case 21:
				SetDebilitationRes(20, 4);
				break;
			case 23:
				SetDebilitationRes(45, 10);
				SetDebilitationRes(45, 12);
				break;
			case 24:
				SetDebilitationRes(45, 3);
				SetDebilitationRes(45, 4);
				break;
			case 25:
				SetDebilitationRes(18, 8);
				break;
			case 26:
				SetDebilitationRes(24, 9);
				SetDebilitationRes(15, 4);
				break;
			case 28:
				SetDebilitationRes(35, 0);
				break;
			case 29:
				SetDebilitationRes(35, 7);
				break;
			case 30:
				SetDebilitationRes(30, 3);
				break;
			case 31:
				SetDebilitationRes(16, 2);
				break;
		}
	}
	private void SwitchLegs() {
	}
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
