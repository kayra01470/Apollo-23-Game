using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper : MonoBehaviour
{
    float yValue = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(yValue,0,0);
        
    }
}
