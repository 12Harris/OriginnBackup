using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
	public static Item[] KeyItems = new Item[10];
    public static Item[] Equippables = new Item[10];
    public static Item[] Junk = new Item[10];
    public static Item[] Food = new Item[10];
    public static Item[] AnythingPouch = new Item[10];
	public GameObject KI;
	public GameObject E;
	public GameObject J;
	public GameObject F;
	public GameObject AP;
    public GameObject invButtons;

    public void Update()
	{	
		if(Input.GetButtonDown("EscapeKey") && invButtons.activeSelf == true)
		{
			invButtons.SetActive(false);
			//PlayerMovement.isActionable = true;
			if(AP.activeSelf)
				AP.SetActive(false);
			if(KI.activeSelf)
				KI.SetActive(false);
			if(E.activeSelf)
				E.SetActive(false);
			if(J.activeSelf)
				J.SetActive(false);
			if(F.activeSelf)
				F.SetActive(false);
		}
		else if(Input.GetButtonDown("OpenInventoryKey"))
		{
			if(!invButtons.activeSelf)
				invButtons.SetActive(true);
			//Controller.isActionable = false;
			if(AP.activeSelf)
				AP.SetActive(false);
			if(KI.activeSelf)
				KI.SetActive(false);
			if(E.activeSelf)
				E.SetActive(false);
			if(J.activeSelf)
				J.SetActive(false);
			if(F.activeSelf)
				F.SetActive(false);
		}
	}

	public void browzeKeyItems()
	{
		//KI.activeSelf = true;
	}

	public void browzeEquippables()
	{
		//E.activeSelf = true;
	}

	public void browzeJunk()
	{
		//J.activeSelf = true;
	}

	public void browzeFood()
	{
		//F.activeSelf = true;
	}

	public void browzeAnythingPouch()
	{
		//AP.activeSelf = true;
		Debug.Log(AnythingPouch);
	}
}