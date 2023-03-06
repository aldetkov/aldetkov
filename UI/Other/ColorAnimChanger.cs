using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.Other
{
    public class ColorAnimChanger : MonoBehaviour
    {
        [SerializeField] private Graphic element;
        [SerializeField] private Color[] colors;
        [SerializeField] private float speed = 1;
        [SerializeField] private int indexCurrent = 0;
        [SerializeField] private int indexNext = 0;
        [SerializeField] private float progressCurrent;
    
        private void Start()
        {
            UpdateIndexes(0);
            UpdateColorGraphic();
        }

        private void Update()
        {
            UpdateColorGraphic();

            progressCurrent += Time.deltaTime * speed;
        
            if (progressCurrent >= 1)
            {
                progressCurrent = 0;
                UpdateIndexes(indexCurrent);
            }
        }

        private void UpdateColorGraphic()
        {
            element.color = Color.Lerp(colors[indexCurrent], colors[indexNext], progressCurrent);
        }
    
        private void UpdateIndexes(int current)
        {
            indexCurrent = AddIndex(current);
            indexNext = AddIndex(indexCurrent);
        }
    
        private int AddIndex(int current)
        {
            return current < colors.Length - 1 ? current+1 : 0;
        }

    }
}
