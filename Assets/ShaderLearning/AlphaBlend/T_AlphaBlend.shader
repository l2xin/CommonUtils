Shader "Custom/l2xin/T_AlphaBlend"
{
    Properties 
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        
        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            
            Blend SrcAlpha OneMinusSrcAlpha
            //Blend Zero One
            
            //Blend One Zero
            
            CGPROGRAM

            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Lighting.cginc"
            
            sampler2D _MainTex;
            float4 _MainTex_ST;         
            
            struct a2v{
                float4 vertex : POSITION;
                float4 texcoord: TEXCOORD0;
            };
            
            struct v2f{
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            v2f vert(a2v v){
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }
            
            fixed4 frag(v2f i) :SV_Target{
                fixed4 texColor = tex2D(_MainTex, i.uv);
               
                return texColor;
            }
        
            ENDCG
        }
    }
    FallBack "Diffuse"
}