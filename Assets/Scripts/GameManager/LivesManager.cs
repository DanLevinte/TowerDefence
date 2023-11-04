using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public int limit;

    public bool changes = false;

    public static LivesManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        livesText.SetText(limit.ToString());
    }

    private void Update()
    {
        if (changes) { changes = false; livesText.SetText((limit - 1).ToString()); }
    }
}
