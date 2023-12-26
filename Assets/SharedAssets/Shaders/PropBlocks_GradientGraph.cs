using UnityEngine;

[ExecuteAlways]
public class PropBlocks_GradientGraph : MonoBehaviour
{
    public Renderer renderer;
    public float Multiply = 1.0f;
    public float Gamma = 1.0f;
    public float Add = 0.0f;
    public Color ColorInner = Color.white;
    public Color ColorOuter = Color.white;
    public float StrobeSpeed = 1.0f;
    [Range(0.0f, 1.0f)]
    public float RingMix = 1.0f;
    [Range(0.0f, 1.0f)]
    public float RingThickness = 0.2f;
    public float RingBrightness = 1.0f;
    public float RingSize = 1.0f;
    public float RingEdgeFade = 0.5f;
    private MaterialPropertyBlock propBlock;

    void Start()
    {
        propBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        if (renderer == null)
            return;
        if(propBlock == null)
            propBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Multiply", Multiply);
        propBlock.SetFloat("_Gamma", Gamma);
        propBlock.SetFloat("_Add", Add);
        propBlock.SetColor("_ColorInner", ColorInner);
        propBlock.SetColor("_ColorOuter", ColorOuter);
        propBlock.SetFloat("_StrobeSpeed", StrobeSpeed);
        propBlock.SetFloat("_RingMix", RingMix);
        propBlock.SetFloat("_RingThickness", 1/RingThickness);
        propBlock.SetFloat("_RingBrightness", RingBrightness);
        propBlock.SetFloat("_RingSize", RingSize);
        propBlock.SetFloat("_RingEdgeFade", RingEdgeFade);
        renderer.SetPropertyBlock(propBlock);
    }
}
