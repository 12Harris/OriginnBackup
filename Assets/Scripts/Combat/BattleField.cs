using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Originn.Game.Combat
{
    public class BattleField : MonoBehaviour
    {
        public GameObject[] enemies;
        public GameObject[] players;
        public GameObject[] NPCs;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;

            //positioning of enemies and allys
            for(int i = 0; i < enemies.Length; i++)
            {
                if(enemies.Length % 2 == 0)
                    enemies[i].transform.position = new Vector2(((1 + i) * 2) + (11 - enemies.Length) - 1, 8); //(2 - 20) is the area enemies can stay 11 is the middle 
                else
                    enemies[i].transform.position = new Vector2(((1 + i) * 2) + (11 - enemies.Length) - 1, 8);
            }

            for(int i = 0; i < players.Length; i++)
            {
                if(players.Length % 2 == 0)
                    players[i].transform.position = new Vector2(((1 + i) * 2) + (11 - players.Length) - 1, 0); 
                else
                    players[i].transform.position = new Vector2(((1 + i) * 2) + (11 - players.Length) - 1, 0);

            }

            //decide what bg to display with what vfx


            //display a message saying the battle has started
            StartCoroutine(battleStart());
        }

        public void Update()
        {

        }

        private IEnumerator battleStart()
        {
            Debug.Log("YOU HAVVE FOUND A BATTLE!");
            yield return new WaitForSecondsRealtime(1f);
            
            Time.timeScale = 1f;
        }
    }
}