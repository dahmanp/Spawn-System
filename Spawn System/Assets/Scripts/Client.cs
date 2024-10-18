using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
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
        }
        /*
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);*/
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}