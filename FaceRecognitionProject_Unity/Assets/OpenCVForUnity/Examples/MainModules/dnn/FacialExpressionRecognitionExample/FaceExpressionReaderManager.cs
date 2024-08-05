using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnityExample;

public class FaceExpressionReaderManager : MonosingletonTemp<FaceExpressionReaderManager>
{
    public FacialExpressionRecognitionExample facialExpressionRecognitionExample;
    public string currentEmotionLabel;
    public float currentEmotionValue;

    void Update()
    {
        currentEmotionLabel = facialExpressionRecognitionExample.GetCurrentEmotionLabel();
        currentEmotionValue = facialExpressionRecognitionExample.GetCurrentEmotionConfidence();

        // Do something with the emotion label and value
        Debug.Log("Emotion: " + currentEmotionLabel + ", Confidence: " + currentEmotionValue);
    }
    
    public string GetEmotionLabel()
    {
        return currentEmotionLabel;
    }

    public float GetEmotionValue()
    {
        return currentEmotionValue;
    }
}