using System.Collections;
using System.Collections.Generic;
using ON.synth;
using UnityEngine;

public class AddOscillator : MonoBehaviour
{
    public GameObject target;
    Oscillator_LFO lfo;
    Plug_XFormMulti xform;

    public Vector2 minMax;

    // Start is called before the first frame update
    void Start()
    {
        lfo = target.AddComponent<Oscillator_LFO>();
        xform = target.AddComponent<Plug_XFormMulti>();
        xform.oscillator = lfo;
        xform.target = target;
        xform.TX = true;
    }

    // Update is called once per frame
    void Update()
    {
        lfo.trough = minMax.x;
        lfo.crest = minMax.y;
    }
}
