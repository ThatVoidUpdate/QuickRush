using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;

    [Space]
    public Image HeartPrefab;
    private List<Image> Hearts = new List<Image>();

    [Space]
    [Header("Graphics")]
    public List<Sprite> HeartLevels;

    private float CurrentHealth;
    private float MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        //get the players max health, work out percentage of health per heart
        MaxHealth = player.MaxHealth;
        for (int i = 0; i < MaxHealth; i++)
        {
            Image temp = Instantiate(HeartPrefab, Vector3.zero, Quaternion.identity, this.transform);
            temp.rectTransform.anchoredPosition = new Vector2(-550 + i * 80, 125);
            temp.sprite = HeartLevels[0];
            Hearts.Add(temp);
        }
    }

    public void UpdateBar()
    {
        CurrentHealth = player.Health;
        for (int i = 0; i < CurrentHealth; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = HeartLevels[0];
        }
        for (int i = (int)CurrentHealth; i < MaxHealth; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = HeartLevels[2];
        }
    }
}
