using System.Collections.Generic;
using UnityEngine;
using Homebrew;
using System;
using TMPro;

public class EqPanel : MonoBehaviour, IDataPersistance {
	//Some basic necesities for things to work well
	[SerializeField] private CCharacter chara;
	private int[] iCurrent = new int[9];
	//Debilitations
	#region
	private TextMeshProUGUI[] Debilitations = new TextMeshProUGUI[13];
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI petrify;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI possession;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI sleep;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI silence;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI skillStiff;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI torpor;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI poison;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI blind;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI curse;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI strLow;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI magLow;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI defLow;
	[Foldout("Debilitations")] [SerializeField] private TextMeshProUGUI mDefLow;
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
		//initializing the Dropdowns with content
		EquipmentSetup1();
		ListsOfPainAndSuffering();
		EquipmentSetup2();
		//
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
		for (int i = 0; i < 7; i++) {
			//Clearing Dropdowns
			Equipment[i].options.Clear();
			//Adding empty option
			Equipment[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			//Rings
			if (i < 2) {
				Rings[i].options.Clear();
				Rings[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			}
		}
	}

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
			}
		}
		Rings[0].onValueChanged.AddListener(delegate { SwitchRing(0); });
		Rings[1].onValueChanged.AddListener(delegate { SwitchRing(1); });
		#endregion
	}

	//Adding all the Armorparts to the Lists
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
		Head.Add("Grisly Skull");
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
		Head.Add("Red Leather Cap");
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
		Chest.Add("Adept's Robe");
		Chest.Add("Ancient Robe");
		Chest.Add("Animistic Robe");
		Chest.Add("Archer's Culottes");
		Chest.Add("Asura Armor");
		Chest.Add("BBI3 Coat of Shadow");
		Chest.Add("BBI3 Coat of Oblivion");
		Chest.Add("BBI3 Heavy Armor");
		Chest.Add("BBI3 Robes");
		Chest.Add("Berserkin");
		Chest.Add("Bone Armor");
		Chest.Add("Bone Plate Armor");
		Chest.Add("Bronze Cuirass");
		Chest.Add("Bronze Lorica");
		Chest.Add("Cardinal Surcoat");
		Chest.Add("Celestial Armor");
		Chest.Add("Chaos Armor");
		Chest.Add("Chestguard");
		Chest.Add("Chimeric Half Plate");
		Chest.Add("Crimson Plate");
		Chest.Add("Crimson Robe");
		Chest.Add("Cursed King's Belt");
		Chest.Add("Dalmatica");
		Chest.Add("Dark Lorica");
		Chest.Add("Divine Surcoat");
		Chest.Add("Emissary Armor");
		Chest.Add("Flutter Padding");
		Chest.Add("Framae Plate");
		Chest.Add("Golden Belt");
		Chest.Add("Golden Lion Padding");
		Chest.Add("Grand Surcoat");
		Chest.Add("Grisly Bone Armor");
		Chest.Add("Griphic Armor");
		Chest.Add("Healer's Robe");
		Chest.Add("Heresy Armor");
		Chest.Add("Hero's Surcoat");
		Chest.Add("Hide Armor");
		Chest.Add("Hunter's Jacket");
		Chest.Add("Immortal's Coat");
		Chest.Add("Iron Lorica");
		Chest.Add("Lamellar Jacket");
		Chest.Add("Leather Belts");
		Chest.Add("Leather Jacket");
		Chest.Add("Leather Protector");
		Chest.Add("Leather Waistwrap");
		Chest.Add("Magician's Surcoat");
		Chest.Add("Maiden's Petticoat");
		Chest.Add("Matte Robe");
		Chest.Add("Meloirean Plate");
		Chest.Add("Missionary's Robe");
		Chest.Add("Monomi Coat");
		Chest.Add("Mummer's Wear");
		Chest.Add("Novice's Coat");
		Chest.Add("Padded Armor");
		Chest.Add("Plebian Shirt");
		Chest.Add("Recluse's Robe");
		Chest.Add("Red Dragon Scale");
		Chest.Add("Red Leather Armor");
		Chest.Add("Rex Lion Padding");
		Chest.Add("Robe of Enlightenment");
		Chest.Add("Royal Surcaot");
		Chest.Add("Sage's Robe");
		Chest.Add("Scale Coat");
		Chest.Add("Scholar's Coat");
		Chest.Add("Sectional Armor");
		Chest.Add("Sectional Iron Plate");
		Chest.Add("Shabby Robe");
		Chest.Add("Skull Belt");
		Chest.Add("Solar Armor");
		Chest.Add("Steel Cuircass");
		Chest.Add("Sultry Pareo");
		Chest.Add("Summery Pareo");
		Chest.Add("Surcaot");
		Chest.Add("Traveler's Vest");
		Chest.Add("Trophy Jacket");
		Chest.Add("Vagabond Armor");
		Chest.Add("Votary's Robe");
		Chest.Add("Wavering Cloth");
		Chest.Add("Weak Guard");
		#endregion
		//Arm Armor
		#region
		Arms.Add("Abyssinal Bracers");
		Arms.Add("Alchemickal Bangles");
		Arms.Add("Ancient Bangles");
		Arms.Add("Arm Crest");
		Arms.Add("Assailant's Bracers");
		Arms.Add("Assassin's Armguards");
		Arms.Add("Assembled Sleeves");
		Arms.Add("Bandit's Gloves");
		Arms.Add("BBI3 Heavy");
		Arms.Add("BBI3 Light");
		Arms.Add("BBI3 Robes");
		Arms.Add("Black Leather Gloves");
		Arms.Add("Blessed Sleeves");
		Arms.Add("Bonds of the Dragon");
		Arms.Add("Bronze Bangles");
		Arms.Add("Bronze Gauntlets");
		Arms.Add("Burnished Braces");
		Arms.Add("Champion's Bangles");
		Arms.Add("Chaos Gauntlets");
		Arms.Add("Chimeric Gauntlets");
		Arms.Add("Crested Armguards");
		Arms.Add("Crimson Gauntlets");
		Arms.Add("Darkened Gloves");
		Arms.Add("Dragon Hide Bracers");
		Arms.Add("Dragonscale Arm");
		Arms.Add("Dragonwing Gloves");
		Arms.Add("Emissary Bracers");
		Arms.Add("Farewell Gloves");
		Arms.Add("Funnybone Guards");
		Arms.Add("Gleaming Bangles");
		Arms.Add("Gloves of Might");
		Arms.Add("Golden Wristband");
		Arms.Add("Grisly Bracers");
		Arms.Add("Gryphic Gauntlets");
		Arms.Add("Hand Covers");
		Arms.Add("Heresy Armguards");
		Arms.Add("Hero's Gauntlets");
		Arms.Add("Immortal's Bracers");
		Arms.Add("Iron Armguard");
		Arms.Add("Iron Bracers");
		Arms.Add("Iron Manice");
		Arms.Add("Jade Bangles");
		Arms.Add("Leather Gloves");
		Arms.Add("Master's Bracers");
		Arms.Add("Meloirean Armguard");
		Arms.Add("Monomi Bracers");
		Arms.Add("Navy Leather Gloves");
		Arms.Add("Novice's Bracers");
		Arms.Add("Red Leather Gloves");
		Arms.Add("Runic Bangles");
		Arms.Add("Scale Armguard");
		Arms.Add("Scarlet Hand Covers");
		Arms.Add("Scholar's Bangles");
		Arms.Add("Shadow Gauntlets");
		Arms.Add("Silver Bands");
		Arms.Add("Steel Gauntlets");
		Arms.Add("Talismanic Beads");
		Arms.Add("The Lion's Spine");
		Arms.Add("Tiger Bangle");
		Arms.Add("Trophy Bracers");
		Arms.Add("Twilight Manica");
		Arms.Add("Wizarding Gloves");
		Arms.Add("Wooden Bands");
		Arms.Add("Worker's Gloves");
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
		//Leg Armor
		#region
		Legs.Add("Abyssinal Greaves");
		Legs.Add("Ancient Greaves");
		Legs.Add("Apostate's Anklet");
		Legs.Add("Assassin's Breaches");
		Legs.Add("Assault Boots");
		Legs.Add("Assembled Breaches");
		Legs.Add("Battle Greaves");
		Legs.Add("BBI3 Boots of Shadows");
		Legs.Add("BBI3 Boots of Oblivion");
		Legs.Add("BBI3 Grave Greaves");
		Legs.Add("BBI3 Carrion Greaves");
		Legs.Add("BBI3 Heavy Armor");
		Legs.Add("Blue Longkilt");
		Legs.Add("Bronze Sabatons");
		Legs.Add("Budget Greaves");
		Legs.Add("Carmine Breeches");
		Legs.Add("Cassardi Greaves");
		Legs.Add("Chainmail Skirt");
		Legs.Add("Chaos Greaves");
		Legs.Add("Chimeric Sabatons");
		Legs.Add("Cloth Greaves");
		Legs.Add("Crimson Sabatons");
		Legs.Add("Dark Over-Knee Boots");
		Legs.Add("Downcuffs & Cuisses");
		Legs.Add("Dragonbeards");
		Legs.Add("Dragonwing Boots");
		Legs.Add("Dusk Shoes");
		Legs.Add("Emissary Greaves");
		Legs.Add("Exotic High Boots");
		Legs.Add("Extrinsic Waistguard");
		Legs.Add("Fine Over-Knee Boots");
		Legs.Add("Flame Skirt");
		Legs.Add("Foreign Waistguard");
		Legs.Add("Fur & Cuisses");
		Legs.Add("Fur Greaves");
		Legs.Add("Gloaming Shoes");
		Legs.Add("Grisly Greaves");
		Legs.Add("Gryphic Greaves");
		Legs.Add("Heresy Greaves");
		Legs.Add("Hero's Cuisses");
		Legs.Add("Hinterland Waistguard");
		Legs.Add("Holy Cuisses");
		Legs.Add("Immortal Sabatons");
		Legs.Add("Iron Boots");
		Legs.Add("Iron Cuisses");
		Legs.Add("Iron Leg Guards");
		Legs.Add("Leather Cuisses");
		Legs.Add("Leather Ocreae");
		Legs.Add("Leather Shoes");
		Legs.Add("Mage's Shoes");
		Legs.Add("Meloirean Greaves");
		Legs.Add("Mercenary Slogs");
		Legs.Add("Metal Greaves");
		Legs.Add("Molten Boots");
		Legs.Add("Monomi Greaves");
		Legs.Add("Nimble Cuisses");
		Legs.Add("Novice Breeches");
		Legs.Add("Over-Knee Boots");
		Legs.Add("Purple Longkilt");
		Legs.Add("Raptor Cuisses");
		Legs.Add("Red Leather Cuisses");
		Legs.Add("Red Longkilt");
		Legs.Add("Red Over-Knee Boots");
		Legs.Add("Riveted Boots");
		Legs.Add("Royal Cuisses");
		Legs.Add("Scale Greaves");
		Legs.Add("Scholar's Boots");
		Legs.Add("Shadow Greaves");
		Legs.Add("Steel Sabatons");
		Legs.Add("Steel-Toed Boots");
		Legs.Add("Striker's Greaves");
		Legs.Add("Superior Cuisses");
		Legs.Add("Thick Fur Greaves");
		Legs.Add("Trophy Boots");
		Legs.Add("Twilight Greaves");
		Legs.Add("Wizard's Boots");
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
		Cloak.Add("Magnanimous Cloak");
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

	private void SetDebilitationRes(int iPercent, int iDebilitation) {
		string s = Debilitations[iDebilitation].text;
		s = s.Remove(s.Length - 1);
		Debilitations[iDebilitation].text = (Int32.Parse(s) + iPercent).ToString() + "%";
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
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-60, 8);
				break;
			case 46:
				SetDebilitationRes(-48, 2);
				break;
			case 47:
				SetDebilitationRes(-40, 2);
				SetDebilitationRes(-18, 4);
				break;
			case 48:
				SetDebilitationRes(-32, 2);
				break;
			case 49:
				SetDebilitationRes(-28, 6);
				SetDebilitationRes(-28, 8);
				break;
			case 50:
				chara.SetMAtk(-7);
				SetDebilitationRes(-60, 3);
				SetDebilitationRes(-48, 8);
				break;
			case 51:
				SetDebilitationRes(-24, 6);
				break;
			case 52:
				SetDebilitationRes(-100, 2);
				SetDebilitationRes(-100, 5);
				SetDebilitationRes(-100, 6);
				break;
			case 53:
				SetDebilitationRes(-24, 5);
				break;
			case 54:
				SetDebilitationRes(-45, 4);
				SetDebilitationRes(-36, 9);
				break;
			case 55:
				SetDebilitationRes(-100, 7);
				break;
			case 56:
				SetDebilitationRes(-45, 2);
				SetDebilitationRes(-30, 0);
				break;
			case 57:
				SetDebilitationRes(-56, 1);
				SetDebilitationRes(-32, 4);
				break;
			case 58:
				SetDebilitationRes(-24, 7);
				break;
			case 59:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-60, 3);
				break;
			case 60:
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-30, 7);
				break;
			case 61:
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 7);
				break;
			case 62:
				SetDebilitationRes(-12, 4);
				SetDebilitationRes(-12, 7);
				break;
			case 63:
				SetDebilitationRes(-24, 5);
				break;
			case 64:
				SetDebilitationRes(-32, 5);
				break;
			case 65:
				SetDebilitationRes(-10, 4);
				break;
			case 66:
				SetDebilitationRes(-80, 12);
				SetDebilitationRes(-55, 8);
				break;
			case 67:
				SetDebilitationRes(-12, 5);
				SetDebilitationRes(-12, 7);
				break;
			case 68:
				SetDebilitationRes(-32, 6);
				break;
			case 69:
				SetDebilitationRes(-39, 10);
				SetDebilitationRes(-14, 0);
				break;
			case 70:
				SetDebilitationRes(-70, 5);
				SetDebilitationRes(-40, 0);
				break;
			case 71:
				SetDebilitationRes(-55, 2);
				SetDebilitationRes(-32, 8);
				break;
			case 72:
				SetDebilitationRes(-28, 3);
				SetDebilitationRes(-28, 4);
				break;
			case 73:
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 11);
				break;
			case 74:
				SetDebilitationRes(-24, 2);
				break;
			case 75:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-21, 8);
				break;
			case 76:
				SetDebilitationRes(-48, 5);
				SetDebilitationRes(-36, 7);
				SetDebilitationRes(-33, 8);
				break;
			case 77:
				SetDebilitationRes(-50, 8);
				SetDebilitationRes(-48, 0);
				break;
			case 78:
				SetDebilitationRes(-40, 6);
				SetDebilitationRes(-27, 3);
				break;
			case 79:
				SetDebilitationRes(-24, 5);
				break;
			case 80:
				SetDebilitationRes(-40, 3);
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
				SetDebilitationRes(60, 5);
				SetDebilitationRes(60, 8);
				break;
			case 46:
				SetDebilitationRes(48, 2);
				break;
			case 47:
				SetDebilitationRes(40, 2);
				SetDebilitationRes(18, 4);
				break;
			case 48:
				SetDebilitationRes(32, 2);
				break;
			case 49:
				SetDebilitationRes(28, 6);
				SetDebilitationRes(28, 8);
				break;
			case 50:
				chara.SetMAtk(7);
				SetDebilitationRes(60, 3);
				SetDebilitationRes(48, 8);
				break;
			case 51:
				SetDebilitationRes(24, 6);
				break;
			case 52:
				SetDebilitationRes(100, 2);
				SetDebilitationRes(100, 5);
				SetDebilitationRes(100, 6);
				break;
			case 53:
				SetDebilitationRes(24, 5);
				break;
			case 54:
				SetDebilitationRes(45, 4);
				SetDebilitationRes(36, 9);
				break;
			case 55:
				SetDebilitationRes(100, 7);
				break;
			case 56:
				SetDebilitationRes(45, 2);
				SetDebilitationRes(30, 0);
				break;
			case 57:
				SetDebilitationRes(56, 1);
				SetDebilitationRes(32, 4);
				break;
			case 58:
				SetDebilitationRes(24, 7);
				break;
			case 59:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(60, 3);
				break;
			case 60:
				SetDebilitationRes(32, 6);
				SetDebilitationRes(30, 7);
				break;
			case 61:
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 7);
				break;
			case 62:
				SetDebilitationRes(12, 4);
				SetDebilitationRes(12, 7);
				break;
			case 63:
				SetDebilitationRes(24, 5);
				break;
			case 64:
				SetDebilitationRes(32, 5);
				break;
			case 65:
				SetDebilitationRes(10, 4);
				break;
			case 66:
				SetDebilitationRes(80, 12);
				SetDebilitationRes(55, 8);
				break;
			case 67:
				SetDebilitationRes(12, 5);
				SetDebilitationRes(12, 7);
				break;
			case 68:
				SetDebilitationRes(32, 6);
				break;
			case 69:
				SetDebilitationRes(39, 10);
				SetDebilitationRes(14, 0);
				break;
			case 70:
				SetDebilitationRes(70, 5);
				SetDebilitationRes(40, 0);
				break;
			case 71:
				SetDebilitationRes(55, 2);
				SetDebilitationRes(32, 8);
				break;
			case 72:
				SetDebilitationRes(28, 3);
				SetDebilitationRes(28, 4);
				break;
			case 73:
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 11);
				break;
			case 74:
				SetDebilitationRes(24, 2);
				break;
			case 75:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(21, 8);
				break;
			case 76:
				SetDebilitationRes(48, 5);
				SetDebilitationRes(36, 7);
				SetDebilitationRes(33, 8);
				break;
			case 77:
				SetDebilitationRes(50, 8);
				SetDebilitationRes(48, 0);
				break;
			case 78:
				SetDebilitationRes(40, 6);
				SetDebilitationRes(27, 3);
				break;
			case 79:
				SetDebilitationRes(24, 5);
				break;
			case 80:
				SetDebilitationRes(40, 3);
				SetDebilitationRes(36, 10);
				break;
			case 83:
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
		switch (iCurrent[3]) {
			case 1:
				SetDebilitationRes(-84, 2);
				SetDebilitationRes(-84, 4);
				SetDebilitationRes(-84, 7);
				break;
			case 2:
				chara.SetMAtk(-5);
				SetDebilitationRes(-60, 4);
				break;
			case 3:
				SetDebilitationRes(-40, 0);
				SetDebilitationRes(-40, 1);
				SetDebilitationRes(-40, 3);
				SetDebilitationRes(-40, 4);
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-40, 8);
				SetDebilitationRes(-15, 2);
				SetDebilitationRes(-15, 6);
				break;
			case 4:
				SetDebilitationRes(-65, 4);
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-55, 8);
				break;
			case 5:
				chara.SetAtk(-5);
				SetDebilitationRes(-44, 4);
				SetDebilitationRes(-40, 9);
				break;
			case 6:
				SetDebilitationRes(-56, 6);
				SetDebilitationRes(-44, 7);
				break;
			case 7:
				SetDebilitationRes(-44, 6);
				break;
			case 8:
				chara.SetAtk(-3);
				SetDebilitationRes(-45, 6);
				SetDebilitationRes(-24, 7);
				break;
			case 9:
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-100, 9);
				SetDebilitationRes(-60, 10);
				break;
			case 10:
				SetDebilitationRes(-100, 0);
				SetDebilitationRes(-100, 6);
				SetDebilitationRes(-5, 9);
				SetDebilitationRes(-5, 10);
				SetDebilitationRes(-5, 11);
				SetDebilitationRes(-5, 12);
				break;
			case 11:
				SetDebilitationRes(-100, 1);
				SetDebilitationRes(-100, 2);
				SetDebilitationRes(-100, 10);
				break;
			case 12:
				SetDebilitationRes(-70, 5);
				SetDebilitationRes(-48, 9);
				break;
			case 13:
				SetDebilitationRes(-60, 11);
				SetDebilitationRes(-45, 12);
				SetDebilitationRes(-15, 10);
				break;
			case 14:
				SetDebilitationRes(-60, 7);
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 11);
				break;
			case 15:
				chara.SetMAtk(-1);
				SetDebilitationRes(-60, 2);
				break;
			case 16:
				SetDebilitationRes(-27, 4);
				break;
			case 17:
				SetDebilitationRes(-50, 4);
				SetDebilitationRes(-33, 0);
				break;
			case 18:
				chara.SetAtk(-4);
				SetDebilitationRes(-40, 0);
				SetDebilitationRes(-28, 9);
				SetDebilitationRes(-28, 11);
				break;
			case 19:
				SetDebilitationRes(-32, 7);
				SetDebilitationRes(-30, 0);
				break;
			case 20:
				chara.SetAtk(-2);
				chara.SetMAtk(-1);
				SetDebilitationRes(-35, 6);
				SetDebilitationRes(-32, 2);
				break;
			case 21:
				SetDebilitationRes(-60, 1);
				break;
			case 22:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-36, 9);
				break;
			case 23:
				SetDebilitationRes(-45, 8);
				SetDebilitationRes(-39, 7);
				break;
			case 24:
				SetDebilitationRes(-51, 8);
				break;
			case 25:
				SetDebilitationRes(-56, 4);
				SetDebilitationRes(-40, 0);
				SetDebilitationRes(-33, 8);
				break;
			case 26:
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-60, 10);
				break;
			case 27:
				SetDebilitationRes(-32, 5);
				SetDebilitationRes(-30, 4);
				break;
			case 28:
				SetDebilitationRes(-28, 6);
				break;
			case 29:
				SetDebilitationRes(-30, 5);
				break;
			case 30:
				chara.SetMAtk(-6);
				SetDebilitationRes(-64, 10);
				SetDebilitationRes(-64, 12);
				break;
			case 31:
				SetDebilitationRes(-40, 5);
				break;
			case 32:
				SetDebilitationRes(-70, 3);
				break;
			case 33:
				SetDebilitationRes(-28, 8);
				SetDebilitationRes(-24, 2);
				SetDebilitationRes(-24, 6);
				break;
			case 34:
				SetDebilitationRes(-36, 5);
				break;
			case 36:
				SetDebilitationRes(-32, 8);
				SetDebilitationRes(-30, 0);
				break;
			case 37:
				SetDebilitationRes(-32, 4);
				SetDebilitationRes(-30, 8);
				break;
			case 38:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-60, 7);
				break;
			case 39:
				SetDebilitationRes(-36, 2);
				break;
			case 40:
				SetDebilitationRes(-24, 7);
				break;
			case 41:
				SetDebilitationRes(-50, 2);
				SetDebilitationRes(-18, 4);
				break;
			case 42:
				chara.SetMAtk(-4);
				SetDebilitationRes(-60, 8);
				break;
			case 43:
				SetDebilitationRes(-35, 5);
				break;
			case 44:
				SetDebilitationRes(-35, 4);
				SetDebilitationRes(-32, 7);
				break;
			case 45:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-36, 4);
				break;
			case 46:
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-30, 7);
				break;
			case 47:
				SetDebilitationRes(-52, 1);
				break;
			case 48:
				SetDebilitationRes(-32, 2);
				break;
			case 49:
				SetDebilitationRes(-36, 5);
				break;
			case 50:
				chara.SetMAtk(-3);
				SetDebilitationRes(-60, 7);
				break;
			case 51:
				SetDebilitationRes(-60, 6);
				SetDebilitationRes(-39, 5);
				SetDebilitationRes(-33, 7);
				break;
			case 52:
				SetDebilitationRes(-40, 12);
				break;
			case 53:
				SetDebilitationRes(-40, 5);
				SetDebilitationRes(-33, 3);
				break;
			case 54:
				SetDebilitationRes(-39, 8);
				SetDebilitationRes(-36, 7);
				break;
			case 55:
				SetDebilitationRes(-45, 3);
				break;
			case 56:
				SetDebilitationRes(-45, 11);
				SetDebilitationRes(-16, 0);
				break;
			case 57:
				SetDebilitationRes(-72, 8);
				SetDebilitationRes(-25, 6);
				break;
			case 58:
				SetDebilitationRes(-10, 2);
				SetDebilitationRes(-10, 5);
				SetDebilitationRes(-10, 6);
				SetDebilitationRes(-10, 7);
				break;
			case 59:
				chara.SetMAtk(-2);
				SetDebilitationRes(-60, 5);
				break;
			case 60:
				chara.SetMAtk(-20);
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 8);
				break;
			case 61:
				SetDebilitationRes(-52, 5);
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-36, 8);
				break;
			case 62:
				SetDebilitationRes(-48, 12);
				break;
			case 63:
				SetDebilitationRes(-18, 2);
				break;
			case 64:
				SetDebilitationRes(-40, 7);
				break;
		}
		iCurrent[3] = Equipment[3].value;
		switch (iCurrent[3]) {
			case 1:
				SetDebilitationRes(84, 2);
				SetDebilitationRes(84, 4);
				SetDebilitationRes(84, 7);
				break;
			case 2:
				chara.SetMAtk(5);
				SetDebilitationRes(60, 4);
				break;
			case 3:
				SetDebilitationRes(40, 0);
				SetDebilitationRes(40, 1);
				SetDebilitationRes(40, 3);
				SetDebilitationRes(40, 4);
				SetDebilitationRes(40, 7);
				SetDebilitationRes(40, 8);
				SetDebilitationRes(15, 2);
				SetDebilitationRes(15, 6);
				break;
			case 4:
				SetDebilitationRes(65, 4);
				SetDebilitationRes(60, 1);
				SetDebilitationRes(55, 8);
				break;
			case 5:
				chara.SetAtk(5);
				SetDebilitationRes(44, 4);
				SetDebilitationRes(40, 9);
				break;
			case 6:
				SetDebilitationRes(56, 6);
				SetDebilitationRes(44, 7);
				break;
			case 7:
				SetDebilitationRes(44, 6);
				break;
			case 8:
				chara.SetAtk(3);
				SetDebilitationRes(45, 6);
				SetDebilitationRes(24, 7);
				break;
			case 9:
				SetDebilitationRes(100, 7);
				SetDebilitationRes(100, 9);
				SetDebilitationRes(60, 10);
				break;
			case 10:
				SetDebilitationRes(100, 0);
				SetDebilitationRes(100, 6);
				SetDebilitationRes(5, 9);
				SetDebilitationRes(5, 10);
				SetDebilitationRes(5, 11);
				SetDebilitationRes(5, 12);
				break;
			case 11:
				SetDebilitationRes(100, 1);
				SetDebilitationRes(100, 2);
				SetDebilitationRes(100, 10);
				break;
			case 12:
				SetDebilitationRes(70, 5);
				SetDebilitationRes(48, 9);
				break;
			case 13:
				SetDebilitationRes(60, 11);
				SetDebilitationRes(45, 12);
				SetDebilitationRes(15, 10);
				break;
			case 14:
				SetDebilitationRes(60, 7);
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 11);
				break;
			case 15:
				chara.SetMAtk(1);
				SetDebilitationRes(60, 2);
				break;
			case 16:
				SetDebilitationRes(27, 4);
				break;
			case 17:
				SetDebilitationRes(50, 4);
				SetDebilitationRes(33, 0);
				break;
			case 18:
				chara.SetAtk(4);
				SetDebilitationRes(40, 0);
				SetDebilitationRes(28, 9);
				SetDebilitationRes(28, 11);
				break;
			case 19:
				SetDebilitationRes(32, 7);
				SetDebilitationRes(30, 0);
				break;
			case 20:
				chara.SetAtk(2);
				chara.SetMAtk(1);
				SetDebilitationRes(35, 6);
				SetDebilitationRes(32, 2);
				break;
			case 21:
				SetDebilitationRes(60, 1);
				break;
			case 22:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(36, 9);
				break;
			case 23:
				SetDebilitationRes(45, 8);
				SetDebilitationRes(39, 7);
				break;
			case 24:
				SetDebilitationRes(51, 8);
				break;
			case 25:
				SetDebilitationRes(56, 4);
				SetDebilitationRes(40, 0);
				SetDebilitationRes(33, 8);
				break;
			case 26:
				SetDebilitationRes(60, 5);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(60, 10);
				break;
			case 27:
				SetDebilitationRes(32, 5);
				SetDebilitationRes(30, 4);
				break;
			case 28:
				SetDebilitationRes(28, 6);
				break;
			case 29:
				SetDebilitationRes(30, 5);
				break;
			case 30:
				chara.SetMAtk(6);
				SetDebilitationRes(64, 10);
				SetDebilitationRes(64, 12);
				break;
			case 31:
				SetDebilitationRes(40, 5);
				break;
			case 32:
				SetDebilitationRes(70, 3);
				break;
			case 33:
				SetDebilitationRes(28, 8);
				SetDebilitationRes(24, 2);
				SetDebilitationRes(24, 6);
				break;
			case 34:
				SetDebilitationRes(36, 5);
				break;
			case 36:
				SetDebilitationRes(32, 8);
				SetDebilitationRes(30, 0);
				break;
			case 37:
				SetDebilitationRes(32, 4);
				SetDebilitationRes(30, 8);
				break;
			case 38:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(60, 7);
				break;
			case 39:
				SetDebilitationRes(36, 2);
				break;
			case 40:
				SetDebilitationRes(24, 7);
				break;
			case 41:
				SetDebilitationRes(50, 2);
				SetDebilitationRes(18, 4);
				break;
			case 42:
				chara.SetMAtk(4);
				SetDebilitationRes(60, 8);
				break;
			case 43:
				SetDebilitationRes(35, 5);
				break;
			case 44:
				SetDebilitationRes(35, 4);
				SetDebilitationRes(32, 7);
				break;
			case 45:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(36, 4);
				break;
			case 46:
				SetDebilitationRes(32, 6);
				SetDebilitationRes(30, 7);
				break;
			case 47:
				SetDebilitationRes(52, 1);
				break;
			case 48:
				SetDebilitationRes(32, 2);
				break;
			case 49:
				SetDebilitationRes(36, 5);
				break;
			case 50:
				chara.SetMAtk(3);
				SetDebilitationRes(60, 7);
				break;
			case 51:
				SetDebilitationRes(60, 6);
				SetDebilitationRes(39, 5);
				SetDebilitationRes(33, 7);
				break;
			case 52:
				SetDebilitationRes(40, 12);
				break;
			case 53:
				SetDebilitationRes(40, 5);
				SetDebilitationRes(33, 3);
				break;
			case 54:
				SetDebilitationRes(39, 8);
				SetDebilitationRes(36, 7);
				break;
			case 55:
				SetDebilitationRes(45, 3);
				break;
			case 56:
				SetDebilitationRes(45, 11);
				SetDebilitationRes(16, 0);
				break;
			case 57:
				SetDebilitationRes(72, 8);
				SetDebilitationRes(25, 6);
				break;
			case 58:
				SetDebilitationRes(10, 2);
				SetDebilitationRes(10, 5);
				SetDebilitationRes(10, 6);
				SetDebilitationRes(10, 7);
				break;
			case 59:
				chara.SetMAtk(2);
				SetDebilitationRes(60, 5);
				break;
			case 60:
				chara.SetMAtk(20);
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 8);
				break;
			case 61:
				SetDebilitationRes(52, 5);
				SetDebilitationRes(40, 7);
				SetDebilitationRes(36, 8);
				break;
			case 62:
				SetDebilitationRes(48, 12);
				break;
			case 63:
				SetDebilitationRes(18, 2);
				break;
			case 64:
				SetDebilitationRes(40, 7);
				break;
		}
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
			case 27:
				SetDebilitationRes(-35, 1);
				break;
			case 28:
				SetDebilitationRes(-35, 7);
				break;
			case 29:
				SetDebilitationRes(-30, 3);
				break;
			case 30:
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
			case 27:
				SetDebilitationRes(35, 1);
				break;
			case 28:
				SetDebilitationRes(35, 7);
				break;
			case 29:
				SetDebilitationRes(30, 3);
				break;
			case 30:
				SetDebilitationRes(16, 2);
				break;
		}
	}
	private void SwitchLegs() {
		switch (iCurrent[5]) {
			case 1:
				SetDebilitationRes(-84, 0);
				SetDebilitationRes(-84, 1);
				SetDebilitationRes(-84, 5);
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
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 7);
				SetDebilitationRes(-60, 10);
				SetDebilitationRes(-60, 12);
				break;
			case 4:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-52, 7);
				break;
			case 5:
				chara.SetAtk(-30);
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 9);
				SetDebilitationRes(-15, 10);
				break;
			case 6:
				SetDebilitationRes(-44, 6);
				break;
			case 7:
				SetDebilitationRes(-35, 2);
				break;
			case 8:
				SetDebilitationRes(-100, 5);
				SetDebilitationRes(-20, 8);
				SetDebilitationRes(-10, 9);
				SetDebilitationRes(-10, 10);
				SetDebilitationRes(-10, 11);
				SetDebilitationRes(-10, 12);
				break;
			case 9:
				SetDebilitationRes(-100, 5);
				SetDebilitationRes(-20, 8);
				SetDebilitationRes(-15, 9);
				SetDebilitationRes(-15, 10);
				SetDebilitationRes(-15, 11);
				SetDebilitationRes(-15, 12);
				break;
			case 10:
				SetDebilitationRes(-100, 1);
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-100, 3);
				break;
			case 11:
				SetDebilitationRes(-100, 1);
				SetDebilitationRes(-100, 7);
				SetDebilitationRes(-20, 3);
				break;
			case 12:
				SetDebilitationRes(-100, 0);
				SetDebilitationRes(-100, 4);
				SetDebilitationRes(-100, 5);
				break;
			case 13:
				SetDebilitationRes(-55, 2);
				break;
			case 14:
				SetDebilitationRes(-30, 4);
				break;
			case 15:
				SetDebilitationRes(-24, 6);
				break;
			case 16:
				SetDebilitationRes(-32, 0);
				break;
			case 17:
				SetDebilitationRes(-39, 6);
				break;
			case 18:
				SetDebilitationRes(-35, 4);
				break;
			case 19:
				SetDebilitationRes(-32, 7);
				SetDebilitationRes(-30, 0);
				break;
			case 20:
				chara.SetAtk(-2);
				chara.SetMAtk(-1);
				SetDebilitationRes(-27, 2);
				SetDebilitationRes(-24, 6);
				break;
			case 21:
				SetDebilitationRes(-100, 1);
				break;
			case 22:
				SetDebilitationRes(-39, 9);
				SetDebilitationRes(-32, 7);
				break;
			case 23:
				SetDebilitationRes(-39, 10);
				SetDebilitationRes(-32, 7);
				break;
			case 24:
				SetDebilitationRes(-30, 6);
				SetDebilitationRes(-30, 7);
				break;
			case 25:
				SetDebilitationRes(-72, 4);
				SetDebilitationRes(-72, 11);
				SetDebilitationRes(-72, 12);
				break;
			case 26:
				SetDebilitationRes(-60, 0);
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-60, 8);
				break;
			case 27:
				SetDebilitationRes(-36, 7);
				break;
			case 28:
				SetDebilitationRes(-32, 5);
				SetDebilitationRes(-30, 4);
				break;
			case 29:
				SetDebilitationRes(-75, 1);
				SetDebilitationRes(-27, 5);
				break;
			case 30:
				SetDebilitationRes(-75, 1);
				break;
			case 31:
				SetDebilitationRes(-55, 5);
				SetDebilitationRes(-48, 11);
				break;
			case 32:
				chara.SetAtk(-8);
				chara.SetMAtk(-8);
				SetDebilitationRes(-64, 8);
				break;
			case 33:
				SetDebilitationRes(-25, 4);
				SetDebilitationRes(-25, 7);
				break;
			case 34:
				SetDebilitationRes(-40, 6);
				break;
			case 35:
				SetDebilitationRes(-32, 6);
				break;
			case 36:
				SetDebilitationRes(-45, 7);
				SetDebilitationRes(-39, 8);
				break;
			case 37:
				SetDebilitationRes(-24, 2);
				SetDebilitationRes(-24, 6);
				SetDebilitationRes(-7, 8);
				break;
			case 38:
				SetDebilitationRes(-40, 5);
				break;
			case 39:
				SetDebilitationRes(-32, 8);
				SetDebilitationRes(-30, 0);
				break;
			case 40:
				SetDebilitationRes(-32, 4);
				SetDebilitationRes(-30, 8);
				break;
			case 41:
				chara.SetAtk(-7);
				chara.SetMAtk(-7);
				SetDebilitationRes(-100, 9);
				SetDebilitationRes(-100, 10);
				SetDebilitationRes(-55, 0);
				break;
			case 42:
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 6);
				break;
			case 43:
				SetDebilitationRes(-28, 7);
				break;
			case 44:
				SetDebilitationRes(-36, 2);
				break;
			case 45:
				SetDebilitationRes(-72, 5);
				SetDebilitationRes(-70, 11);
				SetDebilitationRes(-70, 12);
				break;
			case 46:
				SetDebilitationRes(-28, 5);
				break;
			case 47:
				SetDebilitationRes(-45, 8);
				break;
			case 48:
				SetDebilitationRes(-28, 3);
				break;
			case 49:
				chara.SetMAtk(-3);
				SetDebilitationRes(-45, 3);
				break;
			case 50:
				SetDebilitationRes(-60, 1);
				SetDebilitationRes(-36, 4);
				break;
			case 51:
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 4);
				SetDebilitationRes(-60, 5);
				SetDebilitationRes(-15, 11);
				break;
			case 52:
				SetDebilitationRes(-24, 5);
				break;
			case 53:
				SetDebilitationRes(-33, 5);
				SetDebilitationRes(-28, 0);
				break;
			case 54:
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-30, 7);
				break;
			case 55:
				SetDebilitationRes(-70, 5);
				break;
			case 56:
				SetDebilitationRes(-32, 2);
				break;
			case 57:
				SetDebilitationRes(-42, 12);
				SetDebilitationRes(-35, 5);
				break;
			case 58:
				SetDebilitationRes(-55, 0);
				break;
			case 60:
				chara.SetAtk(-3);
				chara.SetMAtk(-3);
				SetDebilitationRes(-45, 9);
				SetDebilitationRes(-45, 10);
				SetDebilitationRes(-36, 4);
				break;
			case 61:
				SetDebilitationRes(-40, 5);
				break;
			case 62:
				SetDebilitationRes(-55, 8);
				break;
			case 63:
				SetDebilitationRes(-51, 12);
				SetDebilitationRes(-50, 5);
				break;
			case 64:
				SetDebilitationRes(-32, 5);
				break;
			case 65:
				chara.SetAtk(-5);
				chara.SetMAtk(-5);
				SetDebilitationRes(-56, 9);
				SetDebilitationRes(-44, 8);
				SetDebilitationRes(-23, 10);
				break;
			case 66:
				SetDebilitationRes(-64, 6);
				SetDebilitationRes(-39, 5);
				SetDebilitationRes(-33, 7);
				break;
			case 67:
				SetDebilitationRes(-25, 5);
				break;
			case 68:
				SetDebilitationRes(-39, 8);
				SetDebilitationRes(-36, 7);
				break;
			case 69:
				SetDebilitationRes(-45, 11);
				SetDebilitationRes(-16, 0);
				break;
			case 70:
				SetDebilitationRes(-24, 2);
				break;
			case 71:
				chara.SetAtk(-5);
				SetDebilitationRes(-48, 9);
				SetDebilitationRes(-45, 5);
				break;
			case 72:
				SetDebilitationRes(-70, 4);
				break;
			case 73:
				SetDebilitationRes(-44, 4);
				break;
			case 74:
				chara.SetMAtk(-30);
				SetDebilitationRes(-60, 2);
				SetDebilitationRes(-60, 7);
				break;
			case 75:
				SetDebilitationRes(-52, 5);
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-36, 8);
				break;
			case 76:
				chara.SetMAtk(-4);
				SetDebilitationRes(-60, 3);
				break;
		}
		iCurrent[5] = Equipment[5].value;
		switch (iCurrent[5]) {
			case 1:
				SetDebilitationRes(84, 0);
				SetDebilitationRes(84, 1);
				SetDebilitationRes(84, 5);
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
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 7);
				SetDebilitationRes(60, 10);
				SetDebilitationRes(60, 12);
				break;
			case 4:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(52, 7);
				break;
			case 5:
				chara.SetAtk(30);
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 9);
				SetDebilitationRes(15, 10);
				break;
			case 6:
				SetDebilitationRes(44, 6);
				break;
			case 7:
				SetDebilitationRes(35, 2);
				break;
			case 8:
				SetDebilitationRes(100, 5);
				SetDebilitationRes(20, 8);
				SetDebilitationRes(10, 9);
				SetDebilitationRes(10, 10);
				SetDebilitationRes(10, 11);
				SetDebilitationRes(10, 12);
				break;
			case 9:
				SetDebilitationRes(100, 5);
				SetDebilitationRes(20, 8);
				SetDebilitationRes(15, 9);
				SetDebilitationRes(15, 10);
				SetDebilitationRes(15, 11);
				SetDebilitationRes(15, 12);
				break;
			case 10:
				SetDebilitationRes(100, 1);
				SetDebilitationRes(100, 7);
				SetDebilitationRes(100, 3);
				break;
			case 11:
				SetDebilitationRes(100, 1);
				SetDebilitationRes(100, 7);
				SetDebilitationRes(20, 3);
				break;
			case 12:
				SetDebilitationRes(100, 0);
				SetDebilitationRes(100, 4);
				SetDebilitationRes(100, 5);
				break;
			case 13:
				SetDebilitationRes(55, 2);
				break;
			case 14:
				SetDebilitationRes(30, 4);
				break;
			case 15:
				SetDebilitationRes(24, 6);
				break;
			case 16:
				SetDebilitationRes(32, 0);
				break;
			case 17:
				SetDebilitationRes(39, 6);
				break;
			case 18:
				SetDebilitationRes(35, 4);
				break;
			case 19:
				SetDebilitationRes(32, 7);
				SetDebilitationRes(30, 0);
				break;
			case 20:
				chara.SetAtk(2);
				chara.SetMAtk(1);
				SetDebilitationRes(27, 2);
				SetDebilitationRes(24, 6);
				break;
			case 21:
				SetDebilitationRes(100, 1);
				break;
			case 22:
				SetDebilitationRes(39, 9);
				SetDebilitationRes(32, 7);
				break;
			case 23:
				SetDebilitationRes(39, 10);
				SetDebilitationRes(32, 7);
				break;
			case 24:
				SetDebilitationRes(30, 6);
				SetDebilitationRes(30, 7);
				break;
			case 25:
				SetDebilitationRes(72, 4);
				SetDebilitationRes(72, 11);
				SetDebilitationRes(72, 12);
				break;
			case 26:
				SetDebilitationRes(60, 0);
				SetDebilitationRes(60, 1);
				SetDebilitationRes(60, 8);
				break;
			case 27:
				SetDebilitationRes(36, 7);
				break;
			case 28:
				SetDebilitationRes(32, 5);
				SetDebilitationRes(30, 4);
				break;
			case 29:
				SetDebilitationRes(75, 1);
				SetDebilitationRes(27, 5);
				break;
			case 30:
				SetDebilitationRes(75, 1);
				break;
			case 31:
				SetDebilitationRes(55, 5);
				SetDebilitationRes(48, 11);
				break;
			case 32:
				chara.SetAtk(8);
				chara.SetMAtk(8);
				SetDebilitationRes(64, 8);
				break;
			case 33:
				SetDebilitationRes(25, 4);
				SetDebilitationRes(25, 7);
				break;
			case 34:
				SetDebilitationRes(40, 6);
				break;
			case 35:
				SetDebilitationRes(32, 6);
				break;
			case 36:
				SetDebilitationRes(45, 7);
				SetDebilitationRes(39, 8);
				break;
			case 37:
				SetDebilitationRes(24, 2);
				SetDebilitationRes(24, 6);
				SetDebilitationRes(7, 8);
				break;
			case 38:
				SetDebilitationRes(40, 5);
				break;
			case 39:
				SetDebilitationRes(32, 8);
				SetDebilitationRes(30, 0);
				break;
			case 40:
				SetDebilitationRes(32, 4);
				SetDebilitationRes(30, 8);
				break;
			case 41:
				chara.SetAtk(7);
				chara.SetMAtk(7);
				SetDebilitationRes(100, 9);
				SetDebilitationRes(100, 10);
				SetDebilitationRes(55, 0);
				break;
			case 42:
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 6);
				break;
			case 43:
				SetDebilitationRes(28, 7);
				break;
			case 44:
				SetDebilitationRes(36, 2);
				break;
			case 45:
				SetDebilitationRes(72, 5);
				SetDebilitationRes(70, 11);
				SetDebilitationRes(70, 12);
				break;
			case 46:
				SetDebilitationRes(28, 5);
				break;
			case 47:
				SetDebilitationRes(45, 8);
				break;
			case 48:
				SetDebilitationRes(28, 3);
				break;
			case 49:
				chara.SetMAtk(3);
				SetDebilitationRes(45, 3);
				break;
			case 50:
				SetDebilitationRes(60, 1);
				SetDebilitationRes(36, 4);
				break;
			case 51:
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 4);
				SetDebilitationRes(60, 5);
				SetDebilitationRes(15, 11);
				break;
			case 52:
				SetDebilitationRes(24, 5);
				break;
			case 53:
				SetDebilitationRes(33, 5);
				SetDebilitationRes(28, 0);
				break;
			case 54:
				SetDebilitationRes(32, 6);
				SetDebilitationRes(30, 7);
				break;
			case 55:
				SetDebilitationRes(70, 5);
				break;
			case 56:
				SetDebilitationRes(32, 2);
				break;
			case 57:
				SetDebilitationRes(42, 12);
				SetDebilitationRes(35, 5);
				break;
			case 58:
				SetDebilitationRes(55, 0);
				break;
			case 60:
				chara.SetAtk(3);
				chara.SetMAtk(3);
				SetDebilitationRes(45, 9);
				SetDebilitationRes(45, 10);
				SetDebilitationRes(36, 4);
				break;
			case 61:
				SetDebilitationRes(40, 5);
				break;
			case 62:
				SetDebilitationRes(55, 8);
				break;
			case 63:
				SetDebilitationRes(51, 12);
				SetDebilitationRes(50, 5);
				break;
			case 64:
				SetDebilitationRes(32, 5);
				break;
			case 65:
				chara.SetAtk(5);
				chara.SetMAtk(5);
				SetDebilitationRes(56, 9);
				SetDebilitationRes(44, 8);
				SetDebilitationRes(23, 10);
				break;
			case 66:
				SetDebilitationRes(64, 6);
				SetDebilitationRes(39, 5);
				SetDebilitationRes(33, 7);
				break;
			case 67:
				SetDebilitationRes(25, 5);
				break;
			case 68:
				SetDebilitationRes(39, 8);
				SetDebilitationRes(36, 7);
				break;
			case 69:
				SetDebilitationRes(45, 11);
				SetDebilitationRes(16, 0);
				break;
			case 70:
				SetDebilitationRes(24, 2);
				break;
			case 71:
				chara.SetAtk(5);
				SetDebilitationRes(48, 9);
				SetDebilitationRes(45, 5);
				break;
			case 72:
				SetDebilitationRes(70, 4);
				break;
			case 73:
				SetDebilitationRes(44, 4);
				break;
			case 74:
				chara.SetMAtk(30);
				SetDebilitationRes(60, 2);
				SetDebilitationRes(60, 7);
				break;
			case 75:
				SetDebilitationRes(52, 5);
				SetDebilitationRes(40, 7);
				SetDebilitationRes(36, 8);
				break;
			case 76:
				chara.SetMAtk(4);
				SetDebilitationRes(60, 3);
				break;
		}
	}
	private void SwitchCloak() {
		switch (iCurrent[6] - 1) {
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
		switch (iCurrent[iRing + 7] - 1) {
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
		iCurrent[iRing + 7] = Rings[iRing].value;
		switch (iCurrent[iRing + 7] - 1) {
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

	//Public Methods
	public void SetAll(int iPercent) {
		for (int i = 0; i < 13; i++) {
			SetDebilitationRes(iPercent, i);
		}
	}

	public void EquipReset() {
		for (int i = 0; i < 7; i++) {
			if (i < 2) { Rings[i].value = 0; }
			Equipment[i].value = 0;
		}
		SwitchHead();
		SwitchTClothing();
		SwitchChest();
		SwitchArms();
		SwitchLClothing();
		SwitchLegs();
		SwitchCloak();
		SwitchRing(0);
		SwitchRing(1);
	}

	public void OnPanelDisplay() {
		//Fighter based
		#region
		if (chara.GetVocation().Equals("Fighter") || chara.GetVocation().Equals("Warrior") ||
			 chara.GetVocation().Equals("Assassin") || chara.GetVocation().Equals("M. Knight")) {
			//Heavy Armor
			#region
			if (!chara.GetVocation().Equals("Assassin")) {
				//Head Armor
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
				EDD[0].EnableOption(57, true);
				EDD[0].EnableOption(61, true);
				EDD[0].EnableOption(69, true);
				EDD[0].EnableOption(73, true);
				#endregion
				//Chest Armor
				#region
				EDD[2].EnableOption(9, true);
				EDD[2].EnableOption(14, true);
				EDD[2].EnableOption(17, true);
				EDD[2].EnableOption(18, true);
				EDD[2].EnableOption(20, true);
				EDD[2].EnableOption(21, true);
				EDD[2].EnableOption(26, true);
				EDD[2].EnableOption(32, true);
				EDD[2].EnableOption(33, true);
				EDD[2].EnableOption(34, true);
				EDD[2].EnableOption(37, true);
				EDD[2].EnableOption(40, true);
				EDD[2].EnableOption(50, true);
				EDD[2].EnableOption(62, true);
				EDD[2].EnableOption(66, true);
				EDD[2].EnableOption(67, true);
				EDD[2].EnableOption(70, true);
				EDD[2].EnableOption(71, true);
				EDD[2].EnableOption(74, true);
				#endregion
				//Arm Armor
				#region
				EDD[3].EnableOption(9, true);
				EDD[3].EnableOption(16, true);
				EDD[3].EnableOption(19, true);
				EDD[3].EnableOption(20, true);
				EDD[3].EnableOption(22, true);
				EDD[3].EnableOption(34, true);
				EDD[3].EnableOption(37, true);
				EDD[3].EnableOption(38, true);
				EDD[3].EnableOption(39, true);
				EDD[3].EnableOption(45, true);
				EDD[3].EnableOption(54, true);
				EDD[3].EnableOption(56, true);
				#endregion
				//Leg Armor
				#region
				EDD[5].EnableOption(7, true);
				EDD[5].EnableOption(12, true);
				EDD[5].EnableOption(14, true);
				EDD[5].EnableOption(19, true);
				EDD[5].EnableOption(20, true);
				EDD[5].EnableOption(22, true);
				EDD[5].EnableOption(38, true);
				EDD[5].EnableOption(40, true);
				EDD[5].EnableOption(43, true);
				EDD[5].EnableOption(45, true);
				EDD[5].EnableOption(46, true);
				EDD[5].EnableOption(51, true);
				EDD[5].EnableOption(53, true);
				EDD[5].EnableOption(54, true);
				EDD[5].EnableOption(68, true);
				EDD[5].EnableOption(69, true);
				#endregion
			} else {
				//Head Armor
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
				EDD[0].EnableOption(57, false);
				EDD[0].EnableOption(61, false);
				EDD[0].EnableOption(69, false);
				EDD[0].EnableOption(73, false);
				#endregion
				//Chest Armor
				#region
				EDD[2].EnableOption(9, false);
				EDD[2].EnableOption(14, false);
				EDD[2].EnableOption(17, false);
				EDD[2].EnableOption(18, false);
				EDD[2].EnableOption(20, false);
				EDD[2].EnableOption(21, false);
				EDD[2].EnableOption(26, false);
				EDD[2].EnableOption(32, false);
				EDD[2].EnableOption(33, false);
				EDD[2].EnableOption(34, false);
				EDD[2].EnableOption(37, false);
				EDD[2].EnableOption(40, false);
				EDD[2].EnableOption(50, false);
				EDD[2].EnableOption(62, false);
				EDD[2].EnableOption(66, false);
				EDD[2].EnableOption(67, false);
				EDD[2].EnableOption(70, false);
				EDD[2].EnableOption(71, false);
				EDD[2].EnableOption(74, false);
				#endregion
				//Arm Armor
				#region
				EDD[3].EnableOption(9, false);
				EDD[3].EnableOption(16, false);
				EDD[3].EnableOption(19, false);
				EDD[3].EnableOption(20, false);
				EDD[3].EnableOption(22, false);
				EDD[3].EnableOption(34, false);
				EDD[3].EnableOption(37, false);
				EDD[3].EnableOption(38, false);
				EDD[3].EnableOption(39, false);
				EDD[3].EnableOption(45, false);
				EDD[3].EnableOption(54, false);
				EDD[3].EnableOption(56, false);
				#endregion
				//Leg Armor
				#region
				EDD[5].EnableOption(7, false);
				EDD[5].EnableOption(12, false);
				EDD[5].EnableOption(14, false);
				EDD[5].EnableOption(19, false);
				EDD[5].EnableOption(20, false);
				EDD[5].EnableOption(22, false);
				EDD[5].EnableOption(38, false);
				EDD[5].EnableOption(40, false);
				EDD[5].EnableOption(43, false);
				EDD[5].EnableOption(45, false);
				EDD[5].EnableOption(46, false);
				EDD[5].EnableOption(51, false);
				EDD[5].EnableOption(53, false);
				EDD[5].EnableOption(54, false);
				EDD[5].EnableOption(68, false);
				EDD[5].EnableOption(69, false);
				#endregion
			}
			#endregion
			//Warrior/M. Knight
			#region
			if (chara.GetVocation().Equals("Warrior") || chara.GetVocation().Equals("M. Knight")) {
				//Head Armor
				#region
				EDD[0].EnableOption(7, true);
				EDD[0].EnableOption(22, true);
				EDD[0].EnableOption(56, true);
				#endregion
				//Chest Armor
				EDD[2].EnableOption(58, true);
				//Arm Armor
				EDD[3].EnableOption(25, true);
				//Leg Armor
				EDD[2].EnableOption(25, true);
			} else {
				//Head Armor
				#region
				EDD[0].EnableOption(7, false);
				EDD[0].EnableOption(22, false);
				EDD[0].EnableOption(56, false);
				#endregion
				//Chest Armor
				EDD[2].EnableOption(58, false);
				//Arm Armor
				EDD[3].EnableOption(25, false);
				//Leg Armor
				EDD[5].EnableOption(25, false);
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
			//Arm Armor
			#region
			EDD[3].EnableOption(13, true);
			EDD[3].EnableOption(51, true);
			#endregion
			//Chest Armor
			#region
			EDD[2].EnableOption(38, true);
			EDD[2].EnableOption(46, true);
			EDD[2].EnableOption(64, true);
			#endregion
			//LegArmor
			EDD[5].EnableOption(15, true);
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
			EDD[0].EnableOption(56, false);
			EDD[0].EnableOption(57, false);
			EDD[0].EnableOption(61, false);
			EDD[0].EnableOption(69, false);
			EDD[0].EnableOption(73, false);
			#endregion
			//Chest Clothing
			#region
			EDD[1].EnableOption(16, false);
			EDD[1].EnableOption(23, false);
			EDD[1].EnableOption(32, false);
			EDD[1].EnableOption(37, false);
			#endregion
			//Chest Armor
			#region
			EDD[2].EnableOption(9, false);
			EDD[2].EnableOption(14, false);
			EDD[2].EnableOption(17, false);
			EDD[2].EnableOption(18, false);
			EDD[2].EnableOption(20, false);
			EDD[2].EnableOption(21, false);
			EDD[2].EnableOption(26, false);
			EDD[2].EnableOption(32, false);
			EDD[2].EnableOption(33, false);
			EDD[2].EnableOption(34, false);
			EDD[2].EnableOption(37, false);
			EDD[2].EnableOption(38, false);
			EDD[2].EnableOption(40, false);
			EDD[2].EnableOption(46, false);
			EDD[2].EnableOption(50, false);
			EDD[2].EnableOption(58, false);
			EDD[2].EnableOption(62, false);
			EDD[2].EnableOption(64, false);
			EDD[2].EnableOption(66, false);
			EDD[2].EnableOption(67, false);
			EDD[2].EnableOption(70, false);
			EDD[2].EnableOption(71, false);
			EDD[2].EnableOption(74, false);
			#endregion
			//Arm Armor
			#region
			EDD[3].EnableOption(9, false);
			EDD[3].EnableOption(16, false);
			EDD[3].EnableOption(13, false);
			EDD[3].EnableOption(19, false);
			EDD[3].EnableOption(20, false);
			EDD[3].EnableOption(22, false);
			EDD[3].EnableOption(25, false);
			EDD[3].EnableOption(34, false);
			EDD[3].EnableOption(37, false);
			EDD[3].EnableOption(38, false);
			EDD[3].EnableOption(39, false);
			EDD[3].EnableOption(45, false);
			EDD[3].EnableOption(51, false);
			EDD[3].EnableOption(54, false);
			EDD[3].EnableOption(56, false);
			#endregion
			//Leg Armor
			#region
			EDD[5].EnableOption(7, false);
			EDD[5].EnableOption(12, false);
			EDD[5].EnableOption(14, false);
			EDD[5].EnableOption(15, false);
			EDD[5].EnableOption(19, false);
			EDD[5].EnableOption(20, false);
			EDD[5].EnableOption(22, false);
			EDD[5].EnableOption(25, false);
			EDD[5].EnableOption(38, false);
			EDD[5].EnableOption(40, false);
			EDD[5].EnableOption(43, false);
			EDD[5].EnableOption(45, false);
			EDD[5].EnableOption(46, false);
			EDD[5].EnableOption(51, false);
			EDD[5].EnableOption(53, false);
			EDD[5].EnableOption(54, false);
			EDD[5].EnableOption(68, false);
			EDD[5].EnableOption(69, false);
			#endregion
		}
		#endregion
		//Strider based
		#region
		if (chara.GetVocation().Equals("Strider") || chara.GetVocation().Equals("Ranger") ||
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
				//Head Armor
				EDD[0].EnableOption(76, true);
				//Chest Armor
				EDD[2].EnableOption(25, true);
				//Arm Armor
				EDD[3].EnableOption(61, true);
				//Leg Armor
				EDD[5].EnableOption(75, true);
			} else {
				//Head Armor
				EDD[0].EnableOption(76, false);
				//Chest Armor
				EDD[2].EnableOption(25, false);
				//Arm Armor
				EDD[3].EnableOption(61, false);
				//Leg Armor
				EDD[5].EnableOption(75, false);
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
			EDD[0].EnableOption(60, true);
			EDD[0].EnableOption(64, true);
			EDD[0].EnableOption(68, true);
			#endregion
			//Chest Amor
			#region
			EDD[2].EnableOption(5, true);
			EDD[2].EnableOption(7, true);
			EDD[2].EnableOption(8, true);
			EDD[2].EnableOption(15, true);
			EDD[2].EnableOption(27, true);
			EDD[2].EnableOption(28, true);
			EDD[2].EnableOption(31, true);
			EDD[2].EnableOption(39, true);
			EDD[2].EnableOption(41, true);
			EDD[2].EnableOption(42, true);
			EDD[2].EnableOption(45, true);
			EDD[2].EnableOption(52, true);
			EDD[2].EnableOption(55, true);
			EDD[2].EnableOption(59, true);
			EDD[2].EnableOption(60, true);
			EDD[2].EnableOption(76, true);
			#endregion
			//Arm Armor
			#region
			EDD[3].EnableOption(7, true);
			EDD[3].EnableOption(10, true);
			EDD[3].EnableOption(24, true);
			EDD[3].EnableOption(46, true);
			EDD[3].EnableOption(60, true);
			#endregion
			//Leg Armor
			#region
			EDD[5].EnableOption(8, true);
			EDD[5].EnableOption(9, true);
			EDD[5].EnableOption(34, true);
			EDD[5].EnableOption(47, true);
			EDD[5].EnableOption(55, true);
			EDD[5].EnableOption(56, true);
			EDD[5].EnableOption(61, true);
			EDD[5].EnableOption(72, true);
			EDD[5].EnableOption(74, true);
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
			EDD[0].EnableOption(60, false);
			EDD[0].EnableOption(64, false);
			EDD[0].EnableOption(68, false);
			EDD[0].EnableOption(76, false);
			#endregion
			//Chest Amor
			#region
			EDD[2].EnableOption(5, false);
			EDD[2].EnableOption(7, false);
			EDD[2].EnableOption(8, false);
			EDD[2].EnableOption(15, false);
			EDD[2].EnableOption(25, false);
			EDD[2].EnableOption(27, false);
			EDD[2].EnableOption(28, false);
			EDD[2].EnableOption(31, false);
			EDD[2].EnableOption(39, false);
			EDD[2].EnableOption(41, false);
			EDD[2].EnableOption(42, false);
			EDD[2].EnableOption(45, false);
			EDD[2].EnableOption(52, false);
			EDD[2].EnableOption(55, false);
			EDD[2].EnableOption(59, false);
			EDD[2].EnableOption(60, false);
			EDD[2].EnableOption(76, false);
			#endregion
			//Arm Armor
			#region
			EDD[3].EnableOption(7, false);
			EDD[3].EnableOption(10, false);
			EDD[3].EnableOption(24, false);
			EDD[3].EnableOption(46, false);
			EDD[3].EnableOption(60, false);
			EDD[3].EnableOption(61, false);
			#endregion
			//Leg Armor
			#region
			EDD[5].EnableOption(8, false);
			EDD[5].EnableOption(9, false);
			EDD[5].EnableOption(34, false);
			EDD[5].EnableOption(47, false);
			EDD[5].EnableOption(55, false);
			EDD[5].EnableOption(56, false);
			EDD[5].EnableOption(61, false);
			EDD[5].EnableOption(72, false);
			EDD[5].EnableOption(74, false);
			EDD[5].EnableOption(75, false);
			#endregion
		}
		#endregion
		//Mage based
		#region
		//Mage|Sorcerer
		if (chara.GetVocation().Equals("Mage") || chara.GetVocation().Equals("Sorcerer") ||
			 chara.GetVocation().Equals("M. Archer") || chara.GetVocation().Equals("M. Knight")) {
			//Not for Mage/Sorc
			#region
			if (chara.GetVocation().Equals("Mage") || chara.GetVocation().Equals("Sorcerer")) {
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
				//Chest Armor
				#region
				EDD[2].EnableOption(12, false);
				EDD[2].EnableOption(13, false);
				EDD[2].EnableOption(19, false);
				EDD[2].EnableOption(43, false);
				EDD[2].EnableOption(44, false);
				EDD[2].EnableOption(69, false);
				EDD[2].EnableOption(80, false);
				#endregion
				//Arm Armor
				#region
				EDD[3].EnableOption(4, false);
				EDD[3].EnableOption(5, false);
				EDD[3].EnableOption(6, false);
				EDD[3].EnableOption(8, false);
				EDD[3].EnableOption(12, false);
				EDD[3].EnableOption(17, false);
				EDD[3].EnableOption(23, false);
				EDD[3].EnableOption(27, false);
				EDD[3].EnableOption(35, false);
				EDD[3].EnableOption(40, false);
				EDD[3].EnableOption(41, false);
				EDD[3].EnableOption(43, false);
				EDD[3].EnableOption(44, false);
				EDD[3].EnableOption(47, false);
				EDD[3].EnableOption(48, false);
				EDD[3].EnableOption(49, false);
				EDD[3].EnableOption(52, false);
				EDD[3].EnableOption(58, false);
				#endregion
				//Leg Clothing
				#region
				EDD[4].EnableOption(12, false);
				EDD[4].EnableOption(13, false);
				EDD[4].EnableOption(16, false);
				EDD[4].EnableOption(24, false);
				#endregion
				//Leg Amor
				#region
				//On
				EDD[5].EnableOption(13, true);
				EDD[5].EnableOption(59, true);
				EDD[5].EnableOption(62, true);
				//Off
				EDD[5].EnableOption(4, false);
				EDD[5].EnableOption(5, false);
				EDD[5].EnableOption(6, false);
				EDD[5].EnableOption(16, false);
				EDD[5].EnableOption(18, false);
				EDD[5].EnableOption(24, false);
				EDD[5].EnableOption(28, false);
				EDD[5].EnableOption(35, false);
				EDD[5].EnableOption(37, false);
				EDD[5].EnableOption(44, false);
				EDD[5].EnableOption(48, false);
				EDD[5].EnableOption(64, false);
				EDD[5].EnableOption(70, false);
				EDD[5].EnableOption(71, false);
				EDD[5].EnableOption(73, false);
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
				//Chest Armor
				#region
				EDD[2].EnableOption(12, true);
				EDD[2].EnableOption(13, true);
				EDD[2].EnableOption(19, true);
				EDD[2].EnableOption(43, true);
				EDD[2].EnableOption(44, true);
				EDD[2].EnableOption(69, true);
				EDD[2].EnableOption(80, true);
				#endregion
				//Arm Armor
				#region
				EDD[3].EnableOption(4, true);
				EDD[3].EnableOption(5, true);
				EDD[3].EnableOption(6, true);
				EDD[3].EnableOption(8, true);
				EDD[3].EnableOption(12, true);
				EDD[3].EnableOption(17, true);
				EDD[3].EnableOption(23, true);
				EDD[3].EnableOption(27, true);
				EDD[3].EnableOption(35, true);
				EDD[3].EnableOption(40, true);
				EDD[3].EnableOption(41, true);
				EDD[3].EnableOption(43, true);
				EDD[3].EnableOption(44, true);
				EDD[3].EnableOption(47, true);
				EDD[3].EnableOption(48, true);
				EDD[3].EnableOption(49, true);
				EDD[3].EnableOption(52, true);
				EDD[3].EnableOption(58, true);
				#endregion
				//Leg Clothing
				#region
				EDD[4].EnableOption(12, true);
				EDD[4].EnableOption(13, true);
				EDD[4].EnableOption(16, true);
				EDD[4].EnableOption(24, true);
				#endregion
				//Leg Amor
				#region
				//On
				EDD[5].EnableOption(13, false);
				EDD[5].EnableOption(59, false);
				EDD[5].EnableOption(62, false);
				//Off
				EDD[5].EnableOption(4, true);
				EDD[5].EnableOption(5, true);
				EDD[5].EnableOption(6, true);
				EDD[5].EnableOption(16, true);
				EDD[5].EnableOption(18, true);
				EDD[5].EnableOption(24, true);
				EDD[5].EnableOption(28, true);
				EDD[5].EnableOption(35, true);
				EDD[5].EnableOption(37, true);
				EDD[5].EnableOption(44, true);
				EDD[5].EnableOption(48, true);
				EDD[5].EnableOption(64, true);
				EDD[5].EnableOption(70, true);
				EDD[5].EnableOption(71, true);
				EDD[5].EnableOption(73, true);
				#endregion
			}
			#endregion
			//No Mystic Knight
			#region
			if (!chara.GetVocation().Equals("M. Knight")) {
				//Head Armor
				#region
				EDD[0].EnableOption(1, true);
				EDD[0].EnableOption(13, true);
				#endregion
				//Chest Armor
				#region
				EDD[2].EnableOption(2, true);
				EDD[2].EnableOption(10, true);
				EDD[2].EnableOption(16, true);
				EDD[2].EnableOption(22, true);
				EDD[2].EnableOption(24, true);
				EDD[2].EnableOption(47, true);
				EDD[2].EnableOption(49, true);
				EDD[2].EnableOption(51, true);
				EDD[2].EnableOption(54, true);
				EDD[2].EnableOption(61, true);
				EDD[2].EnableOption(63, true);
				EDD[2].EnableOption(65, true);
				EDD[2].EnableOption(68, true);
				EDD[2].EnableOption(75, true);
				#endregion
				//Arm Armor
				#region
				//On
				EDD[3].EnableOption(11, true);
				//Off
				EDD[3].EnableOption(21, false);
				EDD[3].EnableOption(33, false);
				#endregion
				//Leg Armor
				#region
				EDD[5].EnableOption(10, true);
				EDD[5].EnableOption(11, true);
				#endregion
			} else {
				//Head Armor
				#region
				EDD[0].EnableOption(1, false);
				EDD[0].EnableOption(13, false);
				#endregion
				//Chest Armor
				#region
				EDD[2].EnableOption(2, false);
				EDD[2].EnableOption(10, false);
				EDD[2].EnableOption(16, false);
				EDD[2].EnableOption(22, false);
				EDD[2].EnableOption(24, false);
				EDD[2].EnableOption(47, false);
				EDD[2].EnableOption(49, false);
				EDD[2].EnableOption(51, false);
				EDD[2].EnableOption(54, false);
				EDD[2].EnableOption(61, false);
				EDD[2].EnableOption(63, false);
				EDD[2].EnableOption(65, false);
				EDD[2].EnableOption(68, false);
				EDD[2].EnableOption(75, false);
				#endregion
				//Arm Armor
				#region
				//On
				EDD[3].EnableOption(11, false);
				//Off
				EDD[3].EnableOption(21, true);
				EDD[3].EnableOption(33, true);
				#endregion
				//Leg Armor
				#region
				EDD[5].EnableOption(10, false);
				EDD[5].EnableOption(11, false);
				#endregion
			}
			#endregion
			//Just Sorc/M. Archer
			#region
			if (chara.GetVocation().Equals("Sorcerer") || chara.GetVocation().Equals("M. Archer")) {
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
			EDD[0].EnableOption(66, true);
			EDD[0].EnableOption(75, true);
			EDD[0].EnableOption(78, true);
			EDD[0].EnableOption(80, true);
			#endregion
			//Chest Clothing
			EDD[1].EnableOption(6, true);
			//Chest Armor
			#region
			EDD[2].EnableOption(3, true);
			EDD[2].EnableOption(4, true);
			EDD[2].EnableOption(35, true);
			EDD[2].EnableOption(36, true);
			EDD[2].EnableOption(57, true);
			EDD[2].EnableOption(78, true);
			#endregion
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
			EDD[0].EnableOption(66, false);
			EDD[0].EnableOption(75, false);
			EDD[0].EnableOption(78, false);
			EDD[0].EnableOption(80, false);
			#endregion
			//Chest Clothing
			#region
			EDD[1].EnableOption(3, true);
			EDD[1].EnableOption(6, false);
			EDD[1].EnableOption(10, true);
			EDD[1].EnableOption(11, true);
			EDD[1].EnableOption(15, true);
			EDD[1].EnableOption(29, true);
			EDD[1].EnableOption(34, true);
			EDD[1].EnableOption(36, true);
			EDD[1].EnableOption(39, true);
			#endregion
			//Chest Armor
			#region
			EDD[2].EnableOption(2, false);
			EDD[2].EnableOption(3, false);
			EDD[2].EnableOption(4, false);
			EDD[2].EnableOption(10, false);
			EDD[2].EnableOption(12, true);
			EDD[2].EnableOption(13, true);
			EDD[2].EnableOption(16, false);
			EDD[2].EnableOption(19, true);
			EDD[2].EnableOption(22, false);
			EDD[2].EnableOption(24, false);
			EDD[2].EnableOption(35, false);
			EDD[2].EnableOption(36, false);
			EDD[2].EnableOption(43, true);
			EDD[2].EnableOption(44, true);
			EDD[2].EnableOption(47, false);
			EDD[2].EnableOption(49, false);
			EDD[2].EnableOption(51, false);
			EDD[2].EnableOption(54, false);
			EDD[2].EnableOption(57, false);
			EDD[2].EnableOption(61, false);
			EDD[2].EnableOption(63, false);
			EDD[2].EnableOption(65, false);
			EDD[2].EnableOption(68, false);
			EDD[2].EnableOption(69, true);
			EDD[2].EnableOption(75, false);
			EDD[2].EnableOption(78, false);
			EDD[2].EnableOption(80, true);
			#endregion
			//Arm Armor
			#region
			//On
			EDD[3].EnableOption(11, false);
			//Off
			EDD[3].EnableOption(4, true);
			EDD[3].EnableOption(5, true);
			EDD[3].EnableOption(6, true);
			EDD[3].EnableOption(8, true);
			EDD[3].EnableOption(12, true);
			EDD[3].EnableOption(17, true);
			EDD[3].EnableOption(21, true);
			EDD[3].EnableOption(23, true);
			EDD[3].EnableOption(27, true);
			EDD[3].EnableOption(33, true);
			EDD[3].EnableOption(35, true);
			EDD[3].EnableOption(40, true);
			EDD[3].EnableOption(41, true);
			EDD[3].EnableOption(43, true);
			EDD[3].EnableOption(44, true);
			EDD[3].EnableOption(47, true);
			EDD[3].EnableOption(48, true);
			EDD[3].EnableOption(49, true);
			EDD[3].EnableOption(52, true);
			EDD[3].EnableOption(58, true);
			#endregion
			//Leg Clothing
			#region
			EDD[4].EnableOption(12, true);
			EDD[4].EnableOption(13, true);
			EDD[4].EnableOption(16, true);
			EDD[4].EnableOption(24, true);
			#endregion
			//Leg Armor
			#region
			EDD[5].EnableOption(10, false);
			EDD[5].EnableOption(11, false);
			EDD[5].EnableOption(13, false);
			EDD[5].EnableOption(59, false);
			EDD[5].EnableOption(62, false);
			//Seperator
			EDD[5].EnableOption(4, true);
			EDD[5].EnableOption(5, true);
			EDD[5].EnableOption(6, true);
			EDD[5].EnableOption(16, true);
			EDD[5].EnableOption(18, true);
			EDD[5].EnableOption(24, true);
			EDD[5].EnableOption(28, true);
			EDD[5].EnableOption(35, true);
			EDD[5].EnableOption(37, true);
			EDD[5].EnableOption(44, true);
			EDD[5].EnableOption(48, true);
			EDD[5].EnableOption(64, true);
			EDD[5].EnableOption(70, true);
			EDD[5].EnableOption(71, true);
			EDD[5].EnableOption(73, true);
			#endregion
		}
		#endregion
		//Special Snowflakes
		#region
		//???
		#region
		if (chara.GetVocation().Equals("Warrior") || chara.GetVocation().Equals("Ranger") ||
			chara.GetVocation().Equals("M.Archer") || chara.GetVocation().Equals("M.Knight")) {
			//Head
			#region
			EDD[0].EnableOption(24, true);
			EDD[0].EnableOption(55, true);
			#endregion
		}
		else {
			//Head
			#region
			EDD[0].EnableOption(24, false);
			EDD[0].EnableOption(55, false);
			#endregion
		}
		#endregion
		//No Basic
		#region
		if (chara.GetVocation().Equals("Fighter") || chara.GetVocation().Equals("Strider") ||
			chara.GetVocation().Equals("Mage")) {
			EDD[5].EnableOption(42, false);
			EDD[5].EnableOption(60, false);
			EDD[5].EnableOption(65, false);
		}
		else {
			EDD[5].EnableOption(42, true);
			EDD[5].EnableOption(60, true);
			EDD[5].EnableOption(65, true);
		}
		#endregion
		//!?!?!?
		#region
		if (chara.GetVocation().Equals("Mage") || chara.GetVocation().Equals("Sorcerer") ||
			chara.GetVocation().Equals("M. Archer")) {
			EDD[5].EnableOption(52, false);
		}
		else { EDD[5].EnableOption(52, true); }
		#endregion
		#endregion
		//Gender
		#region
		if (!chara.GetGender()) {
			//Dissable all the female only options
			#region
			//Head Armor
			EDD[0].EnableOption(70, false);
			EDD[0].EnableOption(71, false);
			//Chest Clothing
			EDD[1].EnableOption(24, false);
			EDD[1].EnableOption(28, false);
			EDD[1].EnableOption(30, false);
			//Chest Armor
			EDD[2].EnableOption(11, false);
			EDD[2].EnableOption(29, false);
			EDD[2].EnableOption(48, false);
			EDD[2].EnableOption(72, false);
			EDD[2].EnableOption(73, false);
			//Leg Clothing
			EDD[4].EnableOption(9, false);
			EDD[4].EnableOption(23, false);
			EDD[4].EnableOption(29, false);
			//Leg Armor
			EDD[5].EnableOption(32, false);
			#endregion
		}
		else {
			//Enable all the female only options
			#region
			//Head Armor
			EDD[0].EnableOption(70, true);
			EDD[0].EnableOption(71, true);
			//Chest Clothing
			EDD[1].EnableOption(24, true);
			EDD[1].EnableOption(28, true);
			EDD[1].EnableOption(30, true);
			//Chest Armor
			EDD[2].EnableOption(29, true);
			EDD[2].EnableOption(48, true);
			EDD[2].EnableOption(72, true);
			EDD[2].EnableOption(73, true);
			//Leg Clothing
			EDD[4].EnableOption(9, true);
			EDD[4].EnableOption(23, true);
			EDD[4].EnableOption(29, true);
			//Other
			EDD[5].EnableOption(32, true);
			if (chara.GetVocation().Equals("Sorcerer") || chara.GetVocation().Equals("M.Archer")) {
				EDD[2].EnableOption(11, true);
			}
			else {
				EDD[2].EnableOption(11, false);
			}
			//Flame Skirt
			#endregion
		}
		#endregion
	}

	public void SaveData(GameData data) {
		for (int i = 0; i < 9; i++) {
			if (chara.CompareTag("Arisen")) {
				data.aEq[i] = iCurrent[i];
			} else { data.pEq[i] = iCurrent[i]; }
	}	}

	public void LoadData(GameData data) {
		for (int i = 0; i < 9; i++) {
			if (i > 6) {
				if (chara.CompareTag("Arisen")) {
					Rings[i - 7].value = data.aEq[i];
				} else { Rings[i - 7].value = data.pEq[i]; }
			} else {
				if (chara.CompareTag("Arisen")) {
					Equipment[i].value = data.aEq[i];
				} else { Equipment[i].value = data.pEq[i]; }
		}	}
		SwitchHead();
		SwitchTClothing();
		SwitchChest();
		SwitchArms();
		SwitchLClothing();
		SwitchLegs();
		SwitchCloak();
		SwitchRing(0);
		SwitchRing(1);
	}
}