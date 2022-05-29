Shader "Custom/BlackHole"
{
    Properties
    {
        _RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
        _Color("Color", Color) = (1,1,1,1)
        _SliderPunto("Slider Color", Range(0,5)) = 2.5
        _Slider("Slider",Range(0,19)) = 1

    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert alpha

        float _RimPower;
        half _SliderPunto;
        float3 _Color;
        half _Slider;


        struct Input
        {
            float3 viewDir;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            half rim = ddx(dot(normalize(IN.viewDir), o.Normal)) * _SliderPunto;
            o.Emission = float3(rim * _Slider, 0, rim);
        }
        ENDCG
    }
}
