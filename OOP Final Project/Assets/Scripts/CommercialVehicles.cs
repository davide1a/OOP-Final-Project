using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITENCE - This class inherites everything from the VehicleMovement class
public class CommercialVehicles : VehicleMovement
{
    [SerializeField] private int snacksWanted;

    // Update is called once per frame
    void Update()
    {
        MoveVehicle();
    }

    void LateUpdate()
    {
        UpdateFuelText();
    }

    // POLYMORPHISM - this overrides the onTriggerEnter from the
    // VehicleMovement class to also take snacks when they refuel
    public override void OnTriggerEnter(Collider other)
    {
        // Each time vehicle passes the station
        if (other.gameObject.CompareTag("Station"))
        {
            CheckForRefuelling();
            if (carNeedsFuel)
            {
                TakeSnacks();
            }
        }
    }

    void TakeSnacks()
    {
        // Try to take full amount wanted regardless of what is available
        FuelStation.instance.P_snacksLevel -= snacksWanted;
    }
}
