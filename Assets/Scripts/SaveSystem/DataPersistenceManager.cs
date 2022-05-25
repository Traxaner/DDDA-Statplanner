using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour {

	public static DataPersistenceManager instance { get; private set; }
	private List<IDataPersistance> dataPersistanceObjects;
	[SerializeField] private MainMenu menu;
	private GameData gameData;
	
	private void Awake() {
		if (instance != null) {
			Debug.LogError("Found more than one Data PersistanceManager in the scene.");
		}
		instance = this;
	}

	private void Start() {
		this.dataPersistanceObjects = FindAllDataPersistenceObjects();
	}

	private List<IDataPersistance> FindAllDataPersistenceObjects() {
		IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
		return new List<IDataPersistance>(dataPersistanceObjects);
	}

	public void NewData() {
		this.gameData = new GameData();
	}

	public void SaveData() {
		//TODO file data handler

		if (this.gameData == null) {
			Debug.LogError("No data was found. Initializing data to defaults.");
			NewData();
		}
		//Push loaded data to other Scripts
		foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.SaveData(gameData);

		}
	}

	public void LoadData() {
		menu.Display(11);
		//pass the data to other scritps
		foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects) {
			dataPersistanceObj.LoadData(gameData);
		}
		//TODO file data handler
		menu.Display(10);
	}
}