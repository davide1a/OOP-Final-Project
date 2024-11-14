using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    public static FuelStation instance;

    // ENCAPSULATION EXAMPLE - 
    // Vehicles can take fuel from the station, but it won't go into negative
    [SerializeField] private float stationFuelLevel = 100;
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

    // ENCAPSULATION EXAMPLE - 
    // Vehicles can take snacks from the station, but it won't go into negative
    private int snacksLevel = 20;
    public int P_snacksLevel
    {
        get { return snacksLevel; }
        set
        {
            if (value <= 0)
            {
                snacksLevel = 0;
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

    void Awake()
    {
        instance = this;
    }

    public void UpdateFuel()
    {
        // Display the current amount of fuel left
        fuelText.text = $"FUEL REMAINING: {Math.Round(stationFuelLevel, 2)}Ltrs";
    }

    public void UpdateSnacks()
    {
        // Display the current amount of snacks left
        snacksText.text = "SNACKS REMAINING: " + snacksLevel;
    }
    
    void Start()
    {
        // Call the fuel and snack updates to populate the displays
        UpdateFuel();
        UpdateSnacks();
    }
}
