using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{
	// [Signal]
	// delegate void TurnQuestionsOnEventHandler(int optionsAmounts, string[] textOfOptions);
	public static int HoveredOption = 1;
    public TextMeshProUGUI speakerText;
	public TextMeshProUGUI dialougeText;
    public GameObject optionButtons;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Update()
	{
		dialougeText.text = DialougeTrigger.displayText;
		speakerText.text = DialougeTrigger.speakerNameText;

		if (Input.GetButton("MoveLeft") || Input.GetButton("MoveRight"))
    	{
			switch(HoveredOption)
			{
				case 1:
					Opt1Entered();
					break;
				case 2:
					Opt2Entered();
					break;
				case 3:
					Opt3Entered();
					break;
				case 4:
					Opt4Entered();
					break;
			}
    	}
	}

	public void ShowButtons(int optionsAmounts, string[] textOfOptions)
	{
        optionButtons.SetActive(true);
		for(int i = 0; i < optionsAmounts; i++)
		{
            optionButtons.transform.GetChild(i).gameObject.SetActive(true);
			optionButtons.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = textOfOptions[i];
			//GetParent().GetParent().GetNode<Label>("Opt" + (i + 1)).Position = new Vector2(1000 * ((float)i/optionsAmounts) + 250, 576);

		}	
        optionButtons.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
        optionButtons.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        optionButtons.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
		optionButtons.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
	}

	public void DeleteButtons()
	{
		for(int i = 0; i < 4; i++)
		{
			if(optionButtons.transform.GetChild(i).gameObject.activeSelf == false)
				optionButtons.transform.GetChild(i).gameObject.SetActive(false);
		}	
	}

	public void Opt1Entered()
	{
		HoveredOption = 1;
		optionButtons.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
		optionButtons.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        optionButtons.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
		optionButtons.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
	}

	public void Opt2Entered()
	{
		HoveredOption = 2;
		optionButtons.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
		optionButtons.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        optionButtons.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
		optionButtons.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
	}

	public void Opt3Entered()
	{
		HoveredOption = 3;
        optionButtons.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
		optionButtons.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        optionButtons.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
		optionButtons.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
	}

	public void Opt4Entered()
	{
		HoveredOption = 4;
        optionButtons.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
		optionButtons.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
        optionButtons.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
		optionButtons.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
	}

}
