using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelPerMeter;
    public TextMeshPro fuelText;

    // Start is called before the first frame update
    void Start()
    {
        fuelText = GameObject.Find("Red Car Fuel Text").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        Vector3 textPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z + 4);
        fuelText.transform.position = textPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            transform.Rotate(0,180,0);
        }
    }
}
