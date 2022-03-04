using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBridge : MonoBehaviour
{
    
  public Color oncollisionColor;
  public Color offcollisionColor;
  public Renderer rendB;

    // Start is called before the first frame update
    void Start()
    {
       Renderer rendB = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
                   rendB.material.SetColor("_Color",oncollisionColor);

        }
    }
    void OnTriggerExit ()
    {
      rendB.material.SetColor("_Color",offcollisionColor);
    }
    
    
    
    
    
}
