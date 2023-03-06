using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.Components.ButtonAnimEventTrigger
{
    public class BtnAnimStateStandard : ABtnAnimState
    {
        [Header("Элементы на кнопке")]
        [SerializeField] private List<Graphic> graphics = new List<Graphic>();
        [SerializeField] private List<GameObject> offsetObjects = new List<GameObject>();
        [SerializeField] private bool addGraphicsToOffsetObjects = true;
        
        [Header("Изменения")]
        [SerializeField] private Vector3 offsetPressed = new Vector3(0, -5f, 0.0f);
        [SerializeField] private Color colorPressed = new Color(0.85f,0.85f,0.85f,0.95f);
        [SerializeField] private Color colorDisable = new Color(0.8f,0.8f,0.8f,0.8f);

        private Vector3[] _startCord;
        private Color[] _startColors;

        protected override void StartThis()
        {
            if (addGraphicsToOffsetObjects) 
                offsetObjects.AddRange(graphics.Select(t => t.gameObject).ToList());
            
            _startCord = offsetObjects.Select(t => t.transform.localPosition).ToArray();
            _startColors = graphics.Select(t => t.color).ToArray();
        }
        
        protected override void ApplyState()
        {
            switch (State)
            {
                case BtnStateAnimType.Normal:
                    SetPos(Vector3.zero);
                    SetColor(null);
                    break;
                case BtnStateAnimType.Pressed:
                    SetPos(offsetPressed);
                    SetColor(colorPressed);
                    break;
                case BtnStateAnimType.Disable:
                    SetPos(Vector3.zero);
                    SetColor(colorDisable);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void SetPos(Vector3 offset)
        {
            for (int i = 0; i < offsetObjects.Count; i++)
            {
                offsetObjects[i].transform.localPosition = _startCord[i] + offset;
            }
        }

        private void SetColor(Color? colorNew = null)
        {
            for (int i = 0; i < graphics.Count; i++)
            {
                graphics[i].color = colorNew ?? _startColors[i];
            }
        }
    }
}