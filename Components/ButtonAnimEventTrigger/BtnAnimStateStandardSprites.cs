using System;
using aldetkov.Components.SpriteCollection;
using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.Components.ButtonAnimEventTrigger
{
    public class BtnAnimStateStandardSprites : BtnAnimStateStandard
    {
        [Header("Графика кнопки")]
        [SerializeField] private Image icon = null;
        
        [Header("normal, press, disable")]
        [SerializeField] private SpriteCollectionSimple sprites = null;
        
        public void SetNewSprites(SpriteCollectionSimple collection)
        {
            sprites = collection;
        }
        
        protected override void ApplyState()
        {
            base.ApplyState();
            switch (State)
            {
                case BtnStateAnimType.Normal:
                    icon.sprite = sprites.GetSprite(0);
                    break;
                case BtnStateAnimType.Pressed:
                    icon.sprite = sprites.GetSprite(1);
                    break;
                case BtnStateAnimType.Disable:
                    icon.sprite = sprites.GetSprite(2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}