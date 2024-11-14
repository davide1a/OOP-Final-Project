using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    private float stationFuelLevel = 100;
    public float P_stationFuelLevel
    {
        get { return stationFuelLevel; }
        set
        {
            if (value <= 0.0f)
            {
                stationFuelLevel = 0;
                fuelText.text = "FUEL REMAINING: SOLD OUT!";
            }
            else
            {
                stationFuelLevel = value;
                UpdateFuel();
            }
        }
    }

    private int snacksLevel = 20;
    public int P_snacksLevel
    {
        get { return snacksLevel; }
        set
        {
            if (value <= 0)
            {
                snacksText.text = "SNACKS REMAINING: SOLD OUT!";
            }
            else
            {
                snacksLevel = value;
                UpdateSnacks();
            }
        }
    }

    public TextMeshProUGUI fuelText;
    [SerializeField] private TextMeshProUGUI snacksText;

    public void UpdateFuel()
    {
        fuelText.text = $"FUEL REMAINING: {Math.Round(stationFuelLevel, 2)}Ltrs";
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
