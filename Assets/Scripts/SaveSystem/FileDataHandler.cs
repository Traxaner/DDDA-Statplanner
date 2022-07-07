using UnityEngine;
using System.IO;
using System;

public class FileDataHandler {
	private string sDirPath = "", fullPath = "";
	//Encryption
	private bool bEncrypt = false;
	private readonly string sCode = "Zangoku wa tenshi no yono ni, shounen yoshinunari naru";


	public FileDataHandler(string dataDirPath) {
		this.sDirPath = dataDirPath;
	}

	private string DeEncrypt(string data) {
		string modifiedData = "";
		for(int i = 0; i < data.Length; i++) {
			modifiedData += (char)(data[i] ^ sCode[i % sCode.Length]);
		}
		return modifiedData;
	}

	public void Save(GameData data, string sFile) {
		fullPath = Path.Combine(sDirPath, "Saves", sFile);
		try {
			//create Directory
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			//serialize gamedata into JSON
			string dataToStore = JsonUtility.ToJson(data, true);
			//encryption
			if (bEncrypt) { dataToStore = DeEncrypt(dataToStore); }
			//write serialized data to file
			using(FileStream stream=new FileStream(fullPath, FileMode.Create)) {
				using(StreamWriter writer =new StreamWriter(stream)) {
					writer.Write(dataToStore);
				}
			}
		} catch (Exception e) {
			Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
		}
	}
	public GameData Load(string sFile) {
		fullPath = Path.Combine(sDirPath, "Saves", sFile);
		GameData loadedData = null;
		if (File.Exists(fullPath)) {
			try {
				//load serialized data from file
				string dataToLoad = "";
				using (FileStream stream =new FileStream(fullPath, FileMode.Open)) {
					using (StreamReader reader=new StreamReader(stream)) {
						dataToLoad = reader.ReadToEnd();
					}
				}
				//encryption
				if (bEncrypt) { dataToLoad = DeEncrypt(dataToLoad); }
				//deserialize from JSON to data
				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
			}catch(Exception e) {
				Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
			}
		}
		return loadedData;
	}
}