using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchable : MonoBehaviour
{
    public string tag;
    public delegate void OnPunched(Puncher puncher, Punchable punchable);

    public event OnPunched onPunch;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Punch(Puncher puncher)
    {
        GameObject.Find("Log").GetComponent<InSceneLogger>().Log(tag);
        onPunch(puncher, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
