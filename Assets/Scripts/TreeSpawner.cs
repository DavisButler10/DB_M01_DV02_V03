using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject treeSmall;
    public GameObject treeBig;
    public GameObject flower;

    float treeHeight = 0f;
    int numberOfTrees = 5000;
    int numFlowInGroup = 20;
    float spawnRadius = 500f;
    float flowerGroupRadius = 10f;

    void Start()
    {

        PlaceTree();
    }

    void PlaceFlower(Vector3 position)
    {
        for (int i = 0; i < numFlowInGroup; i++)
        {
            Instantiate(flower, position + GeneratedPosition(flowerGroupRadius) , Quaternion.identity);
        }
    }

    void PlaceTree()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            int decider = Random.Range(1, 4);
            
            switch (decider)
            {
                case 1: Instantiate(treeSmall, GeneratedPosition(spawnRadius), Quaternion.identity);
                    break;
                case 2: Instantiate(treeBig, GeneratedPosition(spawnRadius), Quaternion.identity);
                    break;
                case 3: PlaceFlower(GeneratedPosition(spawnRadius - (flowerGroupRadius / 2)));
                    break;
            }
        }
        
    }


    Vector3 GeneratedPosition(float radius)
    {
        Vector3 sphere = Random.insideUnitSphere * radius;
        

        return new Vector3(sphere.x, treeHeight, sphere.z);
    }

}
