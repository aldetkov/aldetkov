using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace aldetkov.Components.SpriteCollection
{
    [CreateAssetMenu(fileName = "SpriteNameCollection", menuName = "SpriteNameCollection")]
    public class SpriteCollectionNamed : ASpriteCollection
    {
        public List<SpriteNameData> sprites = new List<SpriteNameData>();

        public override Sprite GetSprite(int index) => index >= 0 
            ? (index < sprites.Count 
                ? sprites[index].Sprite 
                : sprites[sprites.Count - 1].Sprite) 
            : sprites[0].Sprite;

        public override Sprite GetSprite(string spriteName, string defaultName = null)
        {
           Sprite sprite = sprites.FirstOrDefault(t => t.SpriteName == spriteName)?.Sprite;
           if (sprite == null) sprite = sprites.FirstOrDefault(t => t.SpriteName == defaultName)?.Sprite;
           return sprite;
        }
        
        [Serializable]
        public class SpriteNameData
        {
            [SerializeField] private string spriteName = String.Empty;
            [SerializeField] private Sprite sprite = null;

            public string SpriteName => spriteName;

            public Sprite Sprite => sprite;
        }
    }
}