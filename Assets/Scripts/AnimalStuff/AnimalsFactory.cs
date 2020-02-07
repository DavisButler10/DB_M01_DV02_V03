using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalsFactory
{
    IAnimals Create(AnimalsRequirements requirements);
}

public class AnimalsFactory // : AbstractVehicleFactory
{
    private readonly IAnimalsFactory _factory;
    private readonly AnimalsRequirements _requirements;

    public AnimalsFactory(AnimalsRequirements requirements)
    {
        _factory = requirements.HasFourLegs ? (IAnimalsFactory)new FourLegsFactory() : new TwoLegsfactory();
        _requirements = requirements;
    }

    public IAnimals Create()
    {
        return _factory.Create(_requirements);
    }
}

public class FourLegsFactory : IAnimalsFactory
{
    public IAnimals Create(AnimalsRequirements requirements)
    {
        if (requirements.Feline)
        {
            if (requirements.Deadly)
            {
                return new Lion();
            }
            else
            {
                return new Catto();
            }
        }
        else
        {
            return new Doggo();
        }
    }
}

public class TwoLegsfactory : IAnimalsFactory
{
    public IAnimals Create(AnimalsRequirements requirements)
    {
        if (requirements.FarmAnimal)
        {
            return new Chicken();
        }
        else
        {
            return new Penguin();
        }
    }
}

