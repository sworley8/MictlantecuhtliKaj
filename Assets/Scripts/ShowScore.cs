using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t.text = "Killed " + EnemyCollision.deaths.ToString() + " Fish";
    }
}
