// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
// Alejadro Escobedo:  
//                       09/30/2020
//                       Modified code from https://answers.unity.com/questions/616078/shader-blending-2-cubemaps.html
//                       Added Multiple CubeMap Blending


Shader "Skybox/SkyBox_Blend_CubeMap_3Blend"
{
    Properties{
             _Tint("Tint Color 1", Color) = (.5, .5, .5, 1)
             _Tint2("Tint Color 2", Color) = (.5, .5, .5, 1)
             _Tint3("Tint Color 3", Color) = (.5, .5, .5, 1)
             _Tint4("Tint Color 4", Color) = (.5, .5, .5, 1)
             [Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
             _Rotation("Rotation", Range(0, 360)) = 0
             _BlendCubemaps_1_2("Blend Cubemaps 1 to 2", Range(0, 1)) = 0.5  //  Morning
             _BlendCubemaps_2_3("Blend Cubemaps 2 to 3", Range(0, 1)) = 0.5  //  Midday
             _BlendCubemaps_3_4("Blend Cubemaps 3 to 4", Range(0, 1)) = 0.5  //  Sunset
             _BlendCubemaps_4_1("Blend Cubemaps 4 to 1", Range(0, 1)) = 0.5  //  Night
             [NoScaleOffset] _Tex("Cubemap (HDR) 1", Cube) = "grey" {}
             [NoScaleOffset] _Tex2("Cubemap (HDR) 2", Cube) = "grey" {}
             [NoScaleOffset] _Tex3("Cubemap (HDR) 3", Cube) = "grey" {}
             [NoScaleOffset] _Tex4("Cubemap (HDR) 4", Cube) = "grey" {}
             [MaterialToggle] _Checker1("Blend Cubemaps 1 to 2", Float) = 0
             [MaterialToggle] _Checker2("Blend Cubemaps 2 to 3", Float) = 0
             [MaterialToggle] _Checker3("Blend Cubemaps 3 to 4", Float) = 0
             [MaterialToggle] _Checker4("Blend Cubemaps 4 to 1", Float) = 0
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
                samplerCUBE _Tex4;
                float _BlendCubemaps_1_2;
                float _BlendCubemaps_2_3;
                float _BlendCubemaps_3_4;
                float _BlendCubemaps_4_1;
                half4 _Tex_HDR;
                half4 _Tint;
                half4 _Tint2;
                half4 _Tint3;
                half4 _Tint4;
                half _Exposure;
                float _Rotation;
                float _Checker1=0;
                float _Checker2=0;
                float _Checker3=0;
                float _Checker4=0;
                half4 c_out;

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
                                   float4 env4 = texCUBE(_Tex4, i.texcoord);
                                   float4 env_1_2 = lerp(env2, env1, _BlendCubemaps_1_2);
                                   float4 env_2_3 = lerp(env3, env2, _BlendCubemaps_2_3);
                                   float4 env_3_4 = lerp(env4, env3, _BlendCubemaps_3_4);
                                   float4 env_4_1 = lerp(env1, env4, _BlendCubemaps_4_1);
                                   float4 tint_1_2 = lerp(_Tint, _Tint2, _BlendCubemaps_1_2);
                                   float4 tint_2_3 = lerp(_Tint2, _Tint3, _BlendCubemaps_2_3);
                                   float4 tint_3_4 = lerp(_Tint3, _Tint4, _BlendCubemaps_3_4);
                                   float4 tint_4_1 = lerp(_Tint4, _Tint, _BlendCubemaps_4_1);

                                   half3 c = DecodeHDR(env_1_2, _Tex_HDR);
                                   c = c * tint_1_2.rgb * unity_ColorSpaceDouble;
                                   c *= _Exposure;

                                   half3 c1 = DecodeHDR(env_2_3, _Tex_HDR);
                                   c1 = c1 * tint_2_3.rgb * unity_ColorSpaceDouble;
                                   c1 *= _Exposure;

                                   half3 c2 = DecodeHDR(env_3_4, _Tex_HDR);
                                   c2 = c2 * tint_3_4.rgb * unity_ColorSpaceDouble;
                                   c2 *= _Exposure;

                                   half3 c3 = DecodeHDR(env_4_1, _Tex_HDR);
                                   c3 = c3 * tint_4_1.rgb * unity_ColorSpaceDouble;
                                   c3 *= _Exposure;


                                  if (_Checker1 == 1)
                                   {
                                       return half4(c, tint_1_2.a);
                                   }
                                   else if (_Checker2 == 1)
                                   {
                                       return half4(c1, tint_2_3.a);
                                   }
                                   else if (_Checker3 == 1)
                                   {
                                       return half4(c2, tint_3_4.a);
                                   }
                                   else if(_Checker4 == 1)
                                   {
                                     return half4(c3, tint_4_1.a);
                                   }
                                   else
                                   {
                                      return half4(c, tint_1_2.a);
                                   }


                                   //return c_out;

                               }
                               ENDCG
                           }
             }
                 Fallback Off
}