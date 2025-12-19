using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Originn.Game.SaveSystem
{
	public class SaveComponent : MonoBehaviour
	{
		public enum objType 
		{Player, NPC, DialougeTrigger, Other};
		public objType saveType = objType.Player;
		// Called when the node enters the scene tree for the first time.
		public void Start()
		{
			//PauseButtons.objectsToSave.Add(this);
			//Debug.Log(PauseButtons.objectsToSave.Count);
		}

		//public void onDestroy .Remove

		public void Save()
		{
			Debug.Log("One Save Comp Called!");
			switch(saveType)
			{
				case objType.Player:
					//save playerMovement
					SaveSystem.currentData["playerPos"] = transform.position.ToString();
					SaveSystem.SaveTheGame("data" + SaveSystem.currentSave);
					break;
			}
		}

		public void Load()
		{
			Debug.Log("One Load Comp Called!");
			switch(saveType)
			{
				case objType.Player:
					//load playerMovement
					if(File.Exists("data"  + SaveSystem.currentSave))
					{
						SaveSystem.LoadTheGame("data"  + SaveSystem.currentSave);
						if(SaveSystem.currentData.ContainsKey("playerPos"))
						{
							string parseToVector2 = SaveSystem.currentData["playerPos"];
							//GD.Print(parseToVector2.Substring(parseToVector2.IndexOf(",") + 1, parseToVector2.Length - parseToVector2.IndexOf(",") - 2).ToFloat());
							transform.position = new Vector2(float.Parse(parseToVector2.Substring(1, parseToVector2.IndexOf(",") - 1)), float.Parse(parseToVector2.Substring(parseToVector2.IndexOf(",") + 1, parseToVector2.Length - parseToVector2.IndexOf(",") - 2)));
						}
					}
					break;
				case objType.NPC:
					//load npcs
					if(File.Exists("data"  + SaveSystem.currentSave))
					{
						SaveSystem.LoadTheGame("data"  + SaveSystem.currentSave);
						if(SaveSystem.currentData.ContainsKey(transform.name + "Pos"))
						{
							string parseToVector2 = SaveSystem.currentData[transform.name + "Pos"];
							//GD.Print(parseToVector2.Substring(parseToVector2.IndexOf(",") + 1, parseToVector2.Length - parseToVector2.IndexOf(",") - 2).ToFloat());
							transform.position = new Vector2(float.Parse(parseToVector2.Substring(1, parseToVector2.IndexOf(",") - 1)), float.Parse(parseToVector2.Substring(parseToVector2.IndexOf(",") + 1, parseToVector2.Length - parseToVector2.IndexOf(",") - 2)));
						}
					}
					break;
				case objType.DialougeTrigger:
					//load dialouge Trigger
					if(File.Exists("data"  + SaveSystem.currentSave))
					{
						SaveSystem.LoadTheGame("data"  + SaveSystem.currentSave);
						if(SaveSystem.currentData.ContainsKey(transform.name))
						{
							string parseToVector2 = SaveSystem.currentData["playerPos"];
							//GD.Print(parseToVector2.Substring(parseToVector2.IndexOf(",") + 1, parseToVector2.Length - parseToVector2.IndexOf(",") - 2).ToFloat());
						}
					}
					break;
			}
		}
	}
}