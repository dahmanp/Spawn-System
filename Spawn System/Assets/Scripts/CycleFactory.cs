using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            default:
                return new Bicycle();
        }
    }
}
