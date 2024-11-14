using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxFuel;
    [SerializeField] private float currentFuel;
    [SerializeField] private float fuelPerMeter;
    [SerializeField] private float stationInterval = 100;
    public TextMeshPro fuelText;
    [SerializeField] private bool carNeedsFuel = false;
    private FuelStation fuelStation;

    // Start is called before the first frame update
    void Start()
    {
        fuelStation = GameObject.Find("Fuel Station").GetComponent<FuelStation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forwards, and make it's fuel text follow it.
        if (!carNeedsFuel)
        {
            // Get current position
            Vector3 lastLocation = transform.position;
            // Move to next position
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            // Calculate distance travelled
            float distanceTravelled = Vector3.Distance(lastLocation, transform.position);
            // Calculate remaining fuel
            currentFuel -= distanceTravelled * fuelPerMeter;
            // In case refilling doesn't work for some reason, stop the car if it runs out
            if (currentFuel <= 0)
            {
                carNeedsFuel = true;
            }
        }
    }

    void LateUpdate()
    {
        // Update fuel text and make text follow the vehicle
        fuelText.text = Math.Round(currentFuel, 2) + "L";
        fuelText.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z + 4);
    }

    void OnCollisionEnter(Collision collision)
    {
        // When the vehicle reaches the barrier, turn around so it comes back again.
        if (collision.gameObject.CompareTag("Barrier"))
        {
            transform.Rotate(0, 180, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Each time vehicle passes the station
        if (other.gameObject.CompareTag("Station"))
        {
            // Stop vehicle if it doesn't have enough fuel to reach the next station
            if (currentFuel < fuelPerMeter * stationInterval)
            {
                carNeedsFuel = true;
                StartCoroutine("RefillDelay");
            }
        }
    }

    IEnumerator RefillDelay()
    {
        // Pause as though vehicle is filling with fuel
        yield return new WaitForSeconds(5);
        // Calculate amount of fuel needed to fill the tank
        float fuelNeeded = maxFuel - currentFuel;
        // Check how much fuel is available at the station
        float fuelAvailable = fuelStation.P_stationFuelLevel;
        // Try to take a full take full regardless of what is available
        fuelStation.P_stationFuelLevel -= fuelNeeded;
        // If less than a full fill is available, fill what is available
        if (fuelAvailable < fuelNeeded)
        {
            currentFuel += fuelAvailable;
        }
        // Otherwise fill the tank
        else
        {
            currentFuel += fuelNeeded;
        }
        // Update fuel level text
        fuelText.text = Math.Round(currentFuel, 2) + "L";
        // Start the vehicle running again
        carNeedsFuel = false;
    }
}
