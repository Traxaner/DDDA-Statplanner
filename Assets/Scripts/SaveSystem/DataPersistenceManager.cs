using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour {

	public static DataPersistenceManager instance { get; private set; }
	private List<IDataPersistance> dataPersistanceObjects;
	[SerializeField] private MainMenu menu;
	private FileDataHandler dataHandler;
	private GameData gameData;

	[SerializeField] private string sFile = "";

	private void Awake() {
		if (instance != null) {
			Debug.LogError("Found more than one Data PersistanceManager in the scene.");
		}
		instance = this;
	}

	private void Start() {
		this.dataHandler = new FileDataHandler(Application.persistentDataPath);
		this.dataPersistanceObjects = FindAllDataPersistenceObjects();
		NewData();
		ChangeFile("File_0");
		this.gameData.L10.OrderBy(x => x.Key);
		this.gameData.L100.OrderBy(x => x.Key);
		this.gameData.L200.OrderBy(x => x.Key);
		SaveData();
		LoadData();
		ChangeFile("File_1");
	}

	private List<IDataPersistance> FindAllDataPersistenceObjects() {
		IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
		return new List<IDataPersistance>(dataPersistanceObjects);
	}

	public void ChangeFile(string sFile) { this.sFile = sFile; }

	public void NewData() {
		this.gameData = new GameData();
	}

	public void ResetData(bool bSave = false) {
		string pFile = sFile;
		ChangeFile("File_0");
		LoadData();
		ChangeFile(pFile);
		if (bSave) { SaveData(); }
	}

	public void SaveData() {
		if (this.gameData == null) {
			Debug.LogError("No data was found. Initializing data to defaults.");
			NewData();
		}
		//Push loaded data to other Scripts
		foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.SaveData(gameData);
		}
		//write data to file
		dataHandler.Save(gameData, sFile);
	}

	public void LoadData() {
		menu.Display(11);
		//fetch data from file
		dataHandler.Load(sFile);
		//pass the data to other scritps
		foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.LoadData(gameData);
		}
		menu.Display(10);
	}
}