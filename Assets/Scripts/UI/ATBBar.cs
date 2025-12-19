using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Originn.Game.UI
{
    /// <summary>
    /// Handles functionality related to the ATB System
    /// </summary>
    public class ATBBar : MonoBehaviour
    {
        [SerializeField]
        private Image _progressBar;

        //The selectable character that owns this ATB bar
        [SerializeField]
        //private SelectableCharacter _ownerCharacter;

        public float FillAmount { get => _progressBar.fillAmount; set => _progressBar.fillAmount = value; }

        public void Reset()
        {
            _progressBar.fillAmount = 1f;
        }

    }
}