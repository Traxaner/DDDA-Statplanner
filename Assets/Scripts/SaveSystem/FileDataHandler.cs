using UnityEngine;
using System.IO;
using System;

public class FileDataHandler {
	private string sDirPath = "", fullPath = "";
	private readonly string sFile0="File_0";
	private readonly string sFile1="File_1";
	private readonly string sFile2="File_2";
	private readonly string sFile3="File_3";
	private readonly string sFile4="File_4";

	public FileDataHandler(string dataDirPath) {
		this.sDirPath = dataDirPath;
	}

	public void SetFullPath(int iFile=0) {
		string filePath = "";
		switch (iFile) {
			case 0:
				filePath = sFile0;
				break;
			case 1:
				filePath = sFile1;
				break;
			case 2:
				filePath = sFile2;
				break;
			case 3:
				filePath = sFile3;
				break;
			case 4:
				filePath = sFile4;
				break;
		}
		fullPath = Path.Combine(sDirPath, filePath);
	}

	public void Save(GameData data) {
		try {
			//create Directory
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			//serialize gamedata into JSON
			string dataToStore = JsonUtility.ToJson(data, true);
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
	public GameData Load() {
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
				//deserialize from JSON to data
				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
			}catch(Exception e) {
				Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
			}
		}
		return loadedData;
	}
}