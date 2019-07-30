using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_life : MonoBehaviour
{
    public GameObject partner;
    public TextMesh _text_mesh;
    void OnCollisionEnter(Collision info)
    {
        Debug.Log("collision");
        if (info.gameObject.Equals(partner))
            _text_mesh.text = "Not that hard";
        else
            Debug.Log(info.gameObject.name);
    }
}
