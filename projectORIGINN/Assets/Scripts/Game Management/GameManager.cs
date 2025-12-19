using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Harris.GPC;
using Originn.Game.UI;

namespace Originn.Game
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        [SerializeField]
        private List<GameObject> _selectableCharacters;

        public List<GameObject> SelectableCharacters { get => _selectableCharacters;}


        [SerializeField]
        private List<GameObject> _enemies;

        public List<GameObject> Enemies => _enemies;

        [SerializeField]
        private List<GameObject> _allies;
        
        
        public List<GameObject> Allies => _allies;

        [SerializeField]
        private List<GameObject> _attackMenus;

        [SerializeField]
        private GameObject _mainPlayer;

        public static event Action _onGameStarted;

        private void Awake()
        {
            Debug.Log("game manager => awake");
            _onGameStarted?.Invoke();
            foreach(var menu in _attackMenus)
            {
                menu.GetComponent<AttackMenu>().HandleGameStarted();
            }
        }

        void Start()
        {

            _sessionStartTime = DateTime.Now;
            Debug.Log(
                "Game session start @: " + DateTime.Now);

        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;

            TimeSpan timeDifference =
                _sessionEndTime.Subtract(_sessionStartTime);

            Debug.Log(
                "Game session ended @: " + DateTime.Now);
            Debug.Log(
                "Game session lasted: " + timeDifference);
        }

        void OnGUI()
        {
            if (GUILayout.Button("Next Scene"))
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}