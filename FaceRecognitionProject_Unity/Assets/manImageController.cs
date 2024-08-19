using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manImageController : MonoBehaviour
{
    public Image imageComponent; // Reference to the Image component
    public List<Sprite> imageList = new List<Sprite>(); // List of images
    public RectTransform rectTransform; // Reference to the RectTransform component
    public float frequency = 1f; // Frequency of the sine wave
    public float amplitude = 1f; // Amplitude of the sine wave
    private float initialY; // Initial y position

    // Start is called before the first frame update
    void Start()
    {
        if (imageComponent == null)
        {
            imageComponent = GetComponent<Image>(); // Get the Image component
        }

        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>(); // Get the RectTransform component
        }

        initialY = rectTransform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the position of the RectTransform to make it jump like a sine wave
        float newY = initialY + Mathf.Sin(Time.time * frequency) * amplitude;
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, newY, rectTransform.localPosition.z);
    }

    // Function to change the image
    public void ChangeImage(int index)
    {
        if (index >= 0 && index < imageList.Count)
        {
            imageComponent.sprite = imageList[index]; // Change the image to the specified index
        }
    }
    
    public void ChangeFrequnecyAndAmplitude(float frequency, float amplitude)
    {
        this.frequency = frequency;
        this.amplitude = amplitude;
    }
    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}