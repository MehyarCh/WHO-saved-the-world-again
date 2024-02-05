using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI textMesh;
    public int pointincrease;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        pointincrease = 10;
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = ((int) score).ToString();
        score += pointincrease * Time.deltaTime;
    }
}
