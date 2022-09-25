using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveSkillData
{
	public SaveSkillData(int _num, int _abilityId, bool _isUpgrade, int _skillLv)
    {
		num = _num;
		abilityId = _abilityId;
		isUpgrade = _isUpgrade;
		skillLv = _skillLv;
    }
	//public List<int> datanum = new List<int>();
	public int num;
    public int abilityId;
    public bool isUpgrade;
    public int skillLv;
}

public static class SaveSystem
{
	private static string SavePath => Application.persistentDataPath + "/saves/";

	public static void Save(SaveSkillData saveData, string saveFileName)
	{
		if (!Directory.Exists(SavePath))
		{
			Directory.CreateDirectory(SavePath);
		}

		string saveJson = JsonUtility.ToJson(saveData);

		string saveFilePath = SavePath + saveFileName + ".json";
		File.WriteAllText(saveFilePath, saveJson);
		Debug.Log("Save Success: " + saveFilePath);
	}

	public static SaveSkillData Load(string saveFileName)
	{
		string saveFilePath = SavePath + saveFileName + ".json";

		if (!File.Exists(saveFilePath))
		{
			Debug.LogError("No such saveFile exists");
			return null;
		}

		string saveFile = File.ReadAllText(saveFilePath);
		SaveSkillData saveData = JsonUtility.FromJson<SaveSkillData>(saveFile);
		return saveData;
	}
}

public class SaveData : MonoBehaviour
{
	public void PressSave()
    {
		for(int i = 0; i < Skilll.instance.skills.Length; i++)
        {
			SaveSkillData savedata = new SaveSkillData(i, Skilll.instance.skills[i].abilityId, Skilll.instance.skills[i].isUpgrade, Skilll.instance.skills[i].skillLv);

			SaveSystem.Save(savedata, "save_001");
		}
    }

	public void PressLoad()
    {
		SaveSkillData loaddata = SaveSystem.Load("save_001");
		for(int i = 0; i < Skilll.instance.skills.Length; i++)
        {
			i = loaddata.num;
			Skilll.instance.skills[i].abilityId = loaddata.abilityId;
			Skilll.instance.skills[i].isUpgrade = loaddata.isUpgrade;
			Skilll.instance.skills[i].skillLv = loaddata.skillLv;
		}
		Debug.Log("Load");
    }
}