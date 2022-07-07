using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour {

	[Header("File Storage Config")]
	[SerializeField] private int iFileSelector;

	public static DataPersistenceManager instance { get; private set; }
	private List<IDataPersistance> dataPersistanceObjects;
	[SerializeField] private MainMenu menu;
	private FileDataHandler dataHandler;
	private GameData gameData;

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
		SaveData();
		LoadData();
	}

	private List<IDataPersistance> FindAllDataPersistenceObjects() {
		IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
		return new List<IDataPersistance>(dataPersistanceObjects);
	}

	public void NewData() {
		this.gameData = new GameData();
	}

	public void SetFile(int iFile = 1) { this.iFileSelector = iFile; }

	public void SaveData() {
		if (this.gameData == null) {
			Debug.LogError("No data was found. Initializing data to defaults.");
			NewData();
			iFileSelector = 0;
		}
		//Push loaded data to other Scripts
		foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.SaveData(gameData);
		}
		//write data to file
		dataHandler.SetFullPath(iFileSelector);
		dataHandler.Save(gameData);
	}

	public void LoadData() {
		menu.Display(11);
		//fetch data from file
		dataHandler.Load();
		//pass the data to other scritps
		foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.LoadData(gameData);
		}
		menu.Display(10);
	}
}