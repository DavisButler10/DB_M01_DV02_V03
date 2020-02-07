using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VClient : MonoBehaviour
{
    public GameObject Lion;
    public GameObject Dog;
    public GameObject Cat;
    public GameObject Penguin;
    public GameObject Chicken;
    public bool HasFourLegs;
    public bool Feline;
    public bool FarmAnimal;
    public bool Deadly;
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;


    void Start()
    {
        
        /*AnimalsRequirements requirements = new AnimalsRequirements();

        requirements.HasFourLegs = HasFourLegs;
        requirements.Feline = Feline;
        requirements.FarmAnimal = FarmAnimal;
        requirements.Deadly = Deadly;
        

        //IVehicle v = GetVehicle(requirements);
        AnimalsFactory factory = new AnimalsFactory(requirements);
        IAnimals v = factory.Create();
        Debug.Log(v);
        Instantiate(Resources.Load(v.ToString()));*/
    }

    public void createAnimal()
    {
        AnimalsRequirements requirements = new AnimalsRequirements();
        requirements.HasFourLegs = HasFourLegs;
        requirements.Feline = Feline;
        requirements.FarmAnimal = FarmAnimal;
        requirements.Deadly = Deadly;
        AnimalsFactory factory = new AnimalsFactory(requirements);
        IAnimals v = factory.Create();
        Debug.Log(v);
        if(v.ToString() == "Lion")
        {
            Instantiate(Lion); 
        }else if (v.ToString() == "Catto")
        {
            Instantiate(Cat);
        }
        else if (v.ToString() == "Doggo")
        {
            Instantiate(Dog);
        }
        else if (v.ToString() == "Chicken")
        {
            Instantiate(Chicken);
        }
        else if (v.ToString() == "Penguin")
        {
            Instantiate(Penguin);
        }


    }

    public void Update()
    {
        
        if (dropdown1.value == 0)
        {
            HasFourLegs = false;
        }
        else
        {
            HasFourLegs = true;
        }
        if (dropdown2.value == 0)
        {
            Feline = true;
        }
        else
        {
            Feline = false;
        }
        if (dropdown3.value == 0)
        {
            FarmAnimal = true;
        }
        else
        {
            FarmAnimal = false;
        }
        if (dropdown4.value == 0)
        {
            Deadly = true;
        }
        else
        {
            Deadly = false;
        }


    }
}
