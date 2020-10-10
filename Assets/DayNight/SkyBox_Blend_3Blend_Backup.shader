// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
// Alejadro Escobedo:  
//                       09/30/2020
//                       Modified code from https://answers.unity.com/questions/616078/shader-blending-2-cubemaps.html
//                       Added Multiple CubeMap Blending
                          

Shader "Skybox/SkyBox_Blend_CubeMap_3Blend"
{
    Properties{
             _Tint("Tint Color", Color) = (.5, .5, .5, 1)
             _Tint2("Tint Color 2", Color) = (.5, .5, .5, 1)
             _Tint3("Tint Color 3", Color) = (.5, .5, .5, 1)
             [Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
             _Rotation("Rotation", Range(0, 360)) = 0
             _BlendCubemaps_1_2("Blend Cubemaps 1 to 2", Range(0, 1)) = 0.5  //  Morning
             _BlendCubemaps_2_3("Blend Cubemaps 2 to 3", Range(0, 1)) = 0.5  //  Midday
           //  _BlendCubemaps_1_2("Blend Cubemaps 1 to 2", Range(0, 1)) = 0.5  //  Sunset
          //   _BlendCubemaps_2_3("Blend Cubemaps 2 to 3", Range(0, 1)) = 0.5  //  Night
             [NoScaleOffset] _Tex("Cubemap (HDR)", Cube) = "grey" {}
             [NoScaleOffset] _Tex2("Cubemap (HDR) 2", Cube) = "grey" {}
             [NoScaleOffset] _Tex3("Cubemap (HDR) 3", Cube) = "grey" {}
             [MaterialToggle] _Checker1("Blend Cubemaps 1 to 2", Float) = 0
             [MaterialToggle] _Checker2("Blend Cubemaps 2 to 3", Float) = 0
    }
        SubShader{
            Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
            Cull Off ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            Pass {

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                samplerCUBE _Tex;
                samplerCUBE _Tex2;
                samplerCUBE _Tex3;
                float _BlendCubemaps_1_2;
                float _BlendCubemaps_2_3;
                half4 _Tex_HDR;
                half4 _Tex_HDR_2;
                half4 _Tint;
                half4 _Tint2;
                half4 _Tint3;
                half _Exposure;
                float _Rotation;
                float _Checker1;
                float _Checker2;

                float4 RotateAroundYInDegrees(float4 vertex, float degrees)
                {
                   float alpha = degrees * UNITY_PI / 180.0;
                    float sina, cosa;
                   sincos(alpha, sina, cosa);
                    float2x2 m = float2x2(cosa, -sina, sina, cosa);
                    return float4(mul(m, vertex.xz), vertex.yw).xzyw;
                }

                struct appdata_t {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                    float3 texcoord : TEXCOORD0;
                };

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(RotateAroundYInDegrees(v.vertex, _Rotation));
                    o.texcoord = v.vertex;
                   return o;
                }

 /*               fixed4 frag(v2f i) : SV_Target
                {
                    float4 env1 = texCUBE(_Tex, i.texcoord);
                    float4 env2 = texCUBE(_Tex2, i.texcoord);
                    float4 env = lerp(env2, env1, _BlendCubemaps);
                    float4 tint = lerp(_Tint, _Tint2, _BlendCubemaps);
                    half3 c = DecodeHDR(env, _Tex_HDR);
                    c = c * tint.rgb * unity_ColorSpaceDouble;
                    c *= _Exposure;
                    return half4(c, tint.a);
                }*/

                fixed4 frag(v2f i) : SV_Target
                {
                    float4 env1 = texCUBE(_Tex, i.texcoord);
                    float4 env2 = texCUBE(_Tex2, i.texcoord);
                    float4 env3 = texCUBE(_Tex3, i.texcoord);
                    float4 env_1_2 = lerp(env2, env1, _BlendCubemaps_1_2);
                    float4 env_2_3 = lerp(env3, env2, _BlendCubemaps_2_3);
                    float4 tint_1_2 = lerp(_Tint, _Tint2, _BlendCubemaps_1_2);
                    float4 tint_2_3 = lerp(_Tint2, _Tint3, _BlendCubemaps_2_3);
                    half3 c = DecodeHDR(env_1_2, _Tex_HDR);
                    c = c * tint_1_2.rgb * unity_ColorSpaceDouble;
                    c *= _Exposure;
                   
                    half3 c1 = DecodeHDR(env_2_3, _Tex_HDR);
                    c1 = c1 * tint_2_3.rgb * unity_ColorSpaceDouble;
                    c1 *= _Exposure;

                    
                    if (_Checker1 == 1)
                    {
                        return half4(c, tint_1_2.a);
                    }
                    else if(_Checker2 == 1);
                    {
                        return half4(c1, tint_2_3.a);
                    }
                   
                    

                }
                ENDCG
            }
    }
        Fallback Off
}