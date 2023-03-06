using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace aldetkov.Components.SpriteCollection
{
    [CreateAssetMenu(fileName = "SpriteCollection", menuName = "SpriteCollection")]
    public class SpriteCollectionSimple : ASpriteCollection
    {
        [SerializeField] private List<Sprite> sprites = new List<Sprite>();

        public override Sprite GetSprite(int index) =>
            index >= 0 ? (index < sprites.Count ? sprites[index] : sprites[sprites.Count - 1]) : sprites[0];

        public override Sprite GetSprite(string spriteName, string defaultName = null)
        {
            Sprite sprite = sprites.FirstOrDefault(t => t.name == spriteName);
            if (sprite == null) sprite = sprites.FirstOrDefault(t => t.name == defaultName);
            return sprite;
        }
        public List<Sprite> GetCollection() => sprites;
    }
}
