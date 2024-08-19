using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrentExpressionLogic : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
	public string m_CurrentExpression;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_CurrentExpression = FaceExpressionReaderManager.Instance.GetSampledEmotionLabel(0.5f);
		    textMeshProUGUI.text = "当前表情: " + m_CurrentExpression;
    }
}
