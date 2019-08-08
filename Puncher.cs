using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncher : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        Punchable punchable = collider.GetComponent<Punchable>() ?? collider.GetComponentInParent<Punchable>();
        if (punchable == null) return;
        //the value determens the power of the vibration
        //scale from 0 to 255 
        byte[] noize = { 50, 55, 100, 110, 200, 220, 220 };
        if (gameObject.name == "RightPuncher")
            OVRHaptics.RightChannel.Preempt(new OVRHapticsClip(noize, noize.Length));
        else if(gameObject.name == "LeftPuncher")
            OVRHaptics.LeftChannel.Preempt(new OVRHapticsClip(noize, noize.Length));
        punchable.Punch(this);

    }

}
