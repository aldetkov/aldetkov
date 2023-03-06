using UnityEngine;

namespace aldetkov.UI.Other
{
    public class AnimOffsetTexture : MonoBehaviour
    {
        [SerializeField] private Material textureMaterial;
        [SerializeField] private Vector2 speedScroll;

        private void Update()
        {
            var cur = textureMaterial.mainTextureOffset;

            textureMaterial.mainTextureOffset = new Vector2(CheckValue(cur.x += Time.deltaTime * speedScroll.x),
                CheckValue(cur.y += Time.deltaTime * speedScroll.y));
        }

        private float CheckValue(float value)
        {
            return value >= 1 || value <= -1 ? 0 : value;
        }
    }
}
