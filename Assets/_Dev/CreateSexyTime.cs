using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ON.synth;
using Unity.VisualScripting;

public class CreateSexyTime : MonoBehaviour
{
    public GameObject Ring_01;
    public GameObject Ring_02;
    public Vector2 ringSizeMinMax;
    public float ringOscillateSpeed;
    Oscillator_LFO ringOscillator;
    Oscillator_Remap ringRemap;
    Oscillator_Remap ringRemap2;
    Plug_ShaderVariable ringShaderVariable;
    Plug_ShaderVariable ringShaderVariable2;
    public string ringShaderChannel;
    public bool rebuild;
    GameObject root;

    Plug_AudioSynth synth;
    public float[] synthFrequencies;
    public float[] synthVolumes;
    public float[] synthPans;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    void Build(){
        
        if(root == null)
            root = new GameObject("SexyTime");
        ringOscillator = MakeOscillator("Ring Oscillator");
        ringOscillator.transform.parent = root.transform;
        ringOscillator.speed = ringOscillateSpeed;

        ringRemap = ringOscillator.AddComponent<Oscillator_Remap>();
        ringRemap.oscillator = ringOscillator;
        ringRemap.lowValue = 0;
        ringRemap.highValue = 1;

        ringRemap2 = ringOscillator.AddComponent<Oscillator_Remap>();
        ringRemap2.oscillator = ringOscillator;
        ringRemap.lowValue = 0;
        ringRemap.highValue = 1;

        ringShaderVariable = ringOscillator.AddComponent<Plug_ShaderVariable>();
        ringShaderVariable.oscillator = ringRemap;
        ringShaderVariable.channel = ringShaderChannel;
        ringShaderVariable.target = Ring_01;
        ringShaderVariable.minFloat = ringSizeMinMax.x;
        ringShaderVariable.maxFloat = ringSizeMinMax.y;

        ringShaderVariable2 = ringOscillator.AddComponent<Plug_ShaderVariable>();
        ringShaderVariable2.oscillator = ringRemap;
        ringShaderVariable2.channel = ringShaderChannel;
        ringShaderVariable2.target = Ring_02;
        ringShaderVariable2.minFloat = ringSizeMinMax.y;
        ringShaderVariable2.maxFloat = ringSizeMinMax.x;

        GameObject s = new GameObject("Synth");
        s.transform.parent = root.transform;
        synth = s.AddComponent<Plug_AudioSynth>();
        synth.tones = new Plug_AudioSynth.tone[synthFrequencies.Length];
        for(int i = 0; i < synthFrequencies.Length; i++){
            synth.tones[i].frequency = synthFrequencies[i];
            synth.tones[i].volume = synthVolumes[i];
            synth.tones[i].pan = synthPans[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rebuild){
            if(root!=null)
                Destroy(root);
            Build();
            rebuild = false;
        }
    }

    Oscillator_LFO MakeOscillator(string name){
        GameObject newOscillator = new GameObject();
        newOscillator.name = name;
        newOscillator.transform.parent = transform;
        Oscillator_LFO lfo = newOscillator.AddComponent<Oscillator_LFO>();
        return lfo;
    }
}
