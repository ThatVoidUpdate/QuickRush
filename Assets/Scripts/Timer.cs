using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float currentTime = 0;
    private TextMeshProUGUI text;
    private bool IsTiming = true;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTiming)
        {
            currentTime += Time.deltaTime;
            text.text = currentTime.ToString("F2").PadLeft(5, '0');
        }
    }

    public void Stop()
    {
        IsTiming = false;
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(FindObjectOfType<Player>().Die());
    }
}
