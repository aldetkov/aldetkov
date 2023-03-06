using UnityEngine;

namespace aldetkov.Components.SpriteCollection
{
    public abstract class ASpriteCollection : ScriptableObject
    {
        public abstract Sprite GetSprite(int index);
        public abstract Sprite GetSprite(string spriteName, string defaultName = null);
    }
}