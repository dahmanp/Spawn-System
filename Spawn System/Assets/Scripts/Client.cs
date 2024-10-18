using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public TMP_Text vehicleName;
    public Toggle EngineToggle;
    public Toggle CargoToggle;
    public TMP_InputField wheelInput;
    public TMP_InputField peopleInput;

    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    public void VehicleButton()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
            Passengers = Mathf.Max(Passengers, 1);
            Engine = Cargo;

            VehicleRequirements requirements = new VehicleRequirements();
            requirements.NumberOfWheels = NumberOfWheels;
            requirements.Engine = Engine;
            requirements.Passengers = Passengers;

            IVehicle v = GetVehicle(requirements);
            Debug.Log(v);
        }*/
        int.TryParse(wheelInput.text, out NumberOfWheels);
        int.TryParse(peopleInput.text, out Passengers);

        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = EngineToggle.isOn;
        Cargo = CargoToggle.isOn;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);

        vehicleName.text = v.GetType().Name;
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}