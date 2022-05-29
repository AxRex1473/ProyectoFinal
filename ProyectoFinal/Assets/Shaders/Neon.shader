Shader "Custom/Neon"
{
    Properties
    {
        _SliderB("Slider-B", Range(0,10)) = 1
        _RimColor("Rim", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;

        struct Input
        {
            float2 viewDir;
        };

        half _SliderB;
        float4 _RimColor;
        void surf (Input IN, inout SurfaceOutput o)
        {
            half dotp = dot(normalize(IN.viewDir), o.Normal);
            o.Albedo.b = float(_SliderB * dotp);
            o.Emission = _RimColor * pow(dotp, 300);
        }
        ENDCG
    }
}
