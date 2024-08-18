using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnityExample;
using System.Linq;

public class FaceExpressionReaderManager : MonosingletonTemp<FaceExpressionReaderManager>
{
    public FacialExpressionRecognitionExample facialExpressionRecognitionExample;
    public string currentEmotionLabel;
    public float currentEmotionValue;

    public List<string> emotionLabels = new List<string>();
    public int listLength = 100; // Increase the list length
    public float sampleInterval = 1f;
    private float lastSampleTime = 0f;
    public string SampledEmotionLabel { get; private set; }

    void Update()
    {
        currentEmotionLabel = facialExpressionRecognitionExample.GetCurrentEmotionLabel();
        currentEmotionValue = facialExpressionRecognitionExample.GetCurrentEmotionConfidence();

        // Do something with the emotion label and value
        //Debug.Log("Emotion: " + currentEmotionLabel + ", Confidence: " + currentEmotionValue);

        // Sample emotion label at intervals
        if (Time.time - lastSampleTime > sampleInterval)
        {
            lastSampleTime = Time.time;

            // If current emotion label is empty, set it to "neutral"
            if (string.IsNullOrEmpty(currentEmotionLabel))
            {
                currentEmotionLabel = "neutral";
            }

            // Add current emotion label to list
            emotionLabels.Add(currentEmotionLabel);

            // Limit the list to the last 'listLength' elements
            if (emotionLabels.Count > listLength)
            {
                emotionLabels.RemoveAt(0);
            }

            // Update the most common emotion label
            SampledEmotionLabel = emotionLabels.GroupBy(x => x)
                                               .OrderByDescending(x => x.Count())
                                               .First().Key;
        }

        Debug.Log(GetSampledEmotionLabel(2f));
    }

    public string GetEmotionLabel()
    {
        return currentEmotionLabel;
    }

    public float GetEmotionValue()
    {
        return currentEmotionValue;
    }

    public string GetSampledEmotionLabel()
    {
        return SampledEmotionLabel;
    }

    // New function to get the most common emotion label in the last 'time' seconds
    public string GetSampledEmotionLabel(float time)
    {
        int count = Mathf.RoundToInt(time / sampleInterval);
        if (count > emotionLabels.Count)
        {
            count = emotionLabels.Count;
        }

        var recentEmotionLabels = emotionLabels.Skip(emotionLabels.Count - count);
        return recentEmotionLabels.GroupBy(x => x)
                                  .OrderByDescending(x => x.Count())
                                  .First().Key;
    }
}