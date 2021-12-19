using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarType
{
    helthBar,
    manaBar
}

public class PlayerBar : MonoBehaviour
{
    private Slider slider;
    public BarType type;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        switch (type)
        {
            case BarType.helthBar:
                slider.maxValue = PlayerController.MAX_HEALTH;
                break;
            case BarType.manaBar:
                slider.maxValue = PlayerController.MAX_MANA;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case BarType.helthBar:
                slider.maxValue = GameObject.Find("Player").GetComponent<PlayerController>().GetHealth();
                break;
            case BarType.manaBar:
                slider.maxValue = GameObject.Find("Player").GetComponent<PlayerController>().GetMana();
                break;
        }
    }
}
