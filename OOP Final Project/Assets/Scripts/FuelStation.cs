using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    private float fuelLevel = 100;
    public float P_fuelLevel
    {
        get { return fuelLevel; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You cannot take negative fuel!");
            }
            else
            {
                fuelLevel = value;
            }
        }
    }

    private float snacksLevel = 20;
    public float P_snacksLevel
    {
        get { return snacksLevel; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You cannot take negative fuel!");
            }
            else
            {
                snacksLevel = value;
            }
        }
    }

    public TextMeshProUGUI fuelText;
    [SerializeField] private TextMeshProUGUI snacksText;

    public void UpdateFuel()
    {
        fuelText.text = $"FUEL REMAINING: {fuelLevel}Ltrs";
    }

    public void UpdateSnacks()
    {
        snacksText.text = "SNACKS REMAINING: " + snacksLevel;
    }
    
    void Start()
    {
        UpdateFuel();
        UpdateSnacks();
    }
}
