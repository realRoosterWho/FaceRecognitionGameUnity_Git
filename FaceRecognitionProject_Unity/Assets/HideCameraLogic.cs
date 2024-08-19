using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image imageComponent; // Public reference to the Image component

    // Function to set the alpha value of the Image component
    public void SetAlphaToMax()
    {
        if (imageComponent != null)
        {
            Color color = imageComponent.color;
            color.a = 1f; // Set alpha to 1
            imageComponent.color = color;
        }
    }
}