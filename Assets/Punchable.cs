using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchable : MonoBehaviour
{
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPunched(Puncher puncher)
    {
        GameObject.Find("Log").GetComponent<InSceneLogger>().Log(tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
