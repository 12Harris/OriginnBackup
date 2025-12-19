using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
	//[ExportGroup("Dialouge Settings")]//settings for this specific trigger to be set
	public int LengthOfDisccusion;
	public string[] WordsSaid = new string[3];	
	public string[] WhoSaidWhatHow = new string[3];	
    public GameObject[] OptionsInDial = new GameObject[0];	
	private string text;
	//static text to display during dialouges
	public static string displayText = "";
	public static string speakerNameText = "";
	//private DialogueSystem cs; 
	private int optionsAmount = 0;
	private bool playerTouchingTrigger = false;
	public bool onTouchTrigger = true;
	private float delay = 0.05f;
	public static bool optionsShowing = false;
	public GameObject DialougeGUI;
	//[ExportGroup("Item Given Information")]//used if this trigger should give an item
	//[Export] 
	public string itemName;
	//[Export] 
	public string description;
	//[Export] 
	public Item.Type itemType;
	//[Export] 
	public int amount;

	// Called when the node enters the scene tree for the first time.
	public void Start()
	{
		LengthOfDisccusion = WordsSaid.Length;
	}	
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Update()
	{
		if(playerTouchingTrigger && (Input.GetButtonDown("Submit") || onTouchTrigger))
		{
			Debug.Log("Pause.");
			StartCoroutine(DisplayText());
			playerTouchingTrigger = false;
		}
		//if(!PlayerMovement.isActionable)
		{
			if(Input.GetButtonDown("MoveRight"))
			{
				TextComponent.HoveredOption += 1;
				if(optionsAmount < TextComponent.HoveredOption)
				{
					TextComponent.HoveredOption = optionsAmount;
				}
			}
			else if(Input.GetButtonDown("MoveLeft"))
			{
				TextComponent.HoveredOption -= 1;
				if(1 > TextComponent.HoveredOption)
				{
					TextComponent.HoveredOption = 1;
				}
			}
			else if(Input.GetButton("SkipButton"))
			{
				delay = 0.05f;
			}
			else
			{
				delay = 0.1f;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D body)
	{
		//GD.Print(body.Name);
		if(body.name.Equals("Player"))
		{
			body.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			playerTouchingTrigger = true;
			//DisplayText();
		}
	}

	//play animations of who is talking and dispay text of who is talking
	public void WhoTalking()
	{
		
	}

	public IEnumerator PersonMove(string who, Vector2 howFar)
	{
		displayText += "\n";
		displayText += "\n";
		int magnitude = (int)math.sqrt(math.pow(howFar.x, 2) + math.pow(howFar.y, 2)) / 1;
		for(int i = 0; i < magnitude; i++)
		{
			//GetParent().GetNode("TileMap").GetNode<Node2D>(who).Position += 1 * (howFar / magnitude);
			
			yield return new WaitForSeconds(0.001f);
		}
	}

	public IEnumerator ShowMessageArea()
	{
		DialougeGUI.SetActive(true);
		yield return new WaitForSeconds(0.01f);
	}

	//displays proper text and skipping
	public IEnumerator DisplayText()
	{
		//GetParent().GetNode("TileMap").GetNode<Node2D>("Player").GetNode<CanvasLayer>("DialougeUI").Visible = true;
		StartCoroutine(ShowMessageArea());
		//Controller.isActionable = false;
		optionsAmount = 0;
		for(int i = 0; i < LengthOfDisccusion; i++)
		{
			speakerNameText = WhoSaidWhatHow[i];
			Debug.Log(WordsSaid[i]);
			switch(WordsSaid[i].Substring(0, 1))
			{
				case "!"://skip
					i++;
					break;
				case "(": //Ask Question pops up Ex: (2(Yes,No,Other))
					WhoTalking();
					displayText += "\n";	
					displayText += "\n";	
					optionsAmount = int.Parse(WordsSaid[i].Substring(1, 1));
					//GD.Print("Displaying " + optionsAmount + " Option's'");
					//instaiate buttons with size based on options amount 
					string[] temp = new string[optionsAmount];
					//converts options into words on buttons
					for(int c = 0; c < optionsAmount; c++)
					{
						if(c == 0)
						{
							temp[c] = WordsSaid[i].Substring(WordsSaid[i].IndexOf("(", 1) + 1, WordsSaid[i].IndexOf(",", 1) - WordsSaid[i].IndexOf("(", 1) - 1);
							WordsSaid[i].Remove(WordsSaid[i].IndexOf("(", 1), WordsSaid[i].Substring(WordsSaid[i].IndexOf("(", 1), WordsSaid[i].IndexOf(",", 1)).Length);
						}
						else if(c + 1 == optionsAmount)
						{
							temp[c] = WordsSaid[i].Substring(WordsSaid[i].IndexOf(",", 1) + 1, WordsSaid[i].IndexOf(")", 1) - WordsSaid[i].IndexOf(",", 1) - 1);
						}
						else
						{
							temp[c] = WordsSaid[i].Substring(WordsSaid[i].IndexOf(",", 1) + 1, WordsSaid[i].IndexOf(",", 1) - WordsSaid[i].IndexOf(",", 1) - 1);
							WordsSaid[i].Remove(WordsSaid[i].IndexOf(",", 1), WordsSaid[i].Substring(WordsSaid[i].IndexOf(",", 1), WordsSaid[i].IndexOf(",", 1)).Length);
						}
					}
					//cs.EmitSignal("TurnQuestionsOn", optionsAmount, temp);
					optionsShowing = true;
					//await answer and have answer remove item from array
					yield return new WaitUntil(() => Input.GetButtonDown("InteractKey"));
					//replace this with spawn OptionsInDial Options Dialo
					//OptionsInDial[TextComponent.HoveredOption - 1].GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
					OptionsInDial[TextComponent.HoveredOption - 1].SetActive(true);
					//OptionsInDial[TextComponent.HoveredOption - 1].ProcessMode = ProcessModeEnum.Always;

					//WordsSaid[i] = OptionsInDial[TextComponent.HoveredOption + optionsUsed - 1];
					//i--;
					optionsAmount = 0;
					break;
				case "[": //Stage Direction (Used for pauses and animation changes)
					//Check for if input is cam mov ex: [123, 423]
					//Check for if input is AnimationPlay ex: [Travis, "AnimationName"]
					//Check for if input is Pause for time ex: [2.5]
					//Check for if input is Player move ex: [Travis, 10, 0]
					int count = 0;
    				int n = 0;
					while ((n = WordsSaid[i].IndexOf(',', n) + 1) != 0)
    				{
        				n++;
        				count++;
					}
					if(count >= 2)//["Player", 50, 0]
					{
						// GD.Print("2 found ");
						string personToMove = WordsSaid[i].Substring(2, WordsSaid[i].IndexOf(',') - 3);
						Vector2 toWhere = new Vector2(
							float.Parse(WordsSaid[i].Substring(WordsSaid[i].IndexOf(",") + 2, WordsSaid[i].IndexOf(",", WordsSaid[i].IndexOf(",") + 1) - (WordsSaid[i].IndexOf(",") + 2))),
							float.Parse(WordsSaid[i].Substring(WordsSaid[i].IndexOf(",", WordsSaid[i].IndexOf(",") + 1) + 2, (WordsSaid[i].IndexOf("]") - WordsSaid[i].IndexOf(",", WordsSaid[i].IndexOf(",") + 1)) - 2))
							);
						//GD.Print(personToMove + " to move " + toWhere);
						StartCoroutine(PersonMove(personToMove, toWhere));
					}
					else if(count == 1)
					{
						// GD.Print("1 found ");
					}
					else
					{
						displayText += "\n\n";	
						displayText += "\n\n";
						displayText += "\n\n";
						delay = float.Parse(WordsSaid[i].Substring(1, WordsSaid[i].Length - 2));
						yield return new WaitForSeconds(delay);
					}
					break;
				case "*":
					//play camera transitions 
					break;
				case "&":
					//Recieve Item
					Item itemGetting = new Item(itemName, description, itemType, amount); 
					itemGetting.AddItem();
					break;
				default:
					displayText += "\n";//moves old text outside of mask so it isn't seen anymore
					WhoTalking();//update who is talking an such
					if(WordsSaid[i].Contains("Player"))
					{
						WordsSaid[i] = WordsSaid[i].Substring(0, WordsSaid[i].IndexOf("Player")) + "Player Name was called" + WordsSaid[i].Substring(WordsSaid[i].IndexOf("Player ") + 0);//replace 0 with player name . length
					}
					for(int a = 0; a < WordsSaid[i].Length; a++)
					{
						displayText += WordsSaid[i].Substring(a, 1);
						yield return new WaitForSeconds(delay);
					}
					//spawn in carrot bottom right of box
					yield return new WaitUntil(() => Input.GetButtonDown("SkipButton") == true);
					break;
			}
		}
		displayText = "";
		//Controller.isActionable = true;
		//GetParent().GetNode("TileMap").GetNode<Node2D>("Player").GetNode<CanvasLayer>("DialougeUI").Visible = false;
		DialougeGUI.SetActive(false);
		Destroy(this.gameObject);
	}
}
