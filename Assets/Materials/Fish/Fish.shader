Shader "Custom/Fish"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Gradient ("Gradient", 2D) = "white" {}
        _GradientFalloff ("Gradient Falloff", Float) = 2.
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Speed ("Speed", Float) = 1.0
        _Translate ("Translate Amount", Float) = 1.0
        _TranslateOff ("Translate Offset", Float) = 1.0
        _TranslateAmp ("Translate Amplitude", Float) = 1.0
        _Yaw ("Rotate Yaw", Float) = 1.0
        _YawOff ("Rotate Yaw Offset", Float) = 1.0
        _YawAmp ("Rotate Yaw Amplitude", Float) = 1.0
        _Twist ("Twist", Float) = 1.0
        _TwistOff ("Twist Offset", Float) = 0
        _TwistAmp ("Twist Amplitude", Float) = 1.0
        _Wave ("Wave", Float) = 1.0
        _WaveOff ("Wave Offset", Float) = 0
        _WaveAmp ("Wave Amplitude", Float) = 1.0
        _Offset ("Wave Amplitude", Vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert addshadow 

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float _Speed;

        float _Translate;
        float _TranslateOff;
        float _TranslateAmp;

        float _Yaw;
        float _YawOff;
        float _YawAmp;

        float _Twist;
        float _TwistOff;
        float _TwistAmp;

        float _Wave;
        float _WaveOff;
        float _WaveAmp;

        sampler2D _Gradient;
        float _GradientFalloff;

        float4 _Offset;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float4 RotateZ (float4 vertex, float angle)
        {
            float sina, cosa;
            sincos(angle, sina, cosa);
            float3x3 m = float3x3(
                cosa, -sina, 0,
                sina, cosa, 0,
                0, 0, 1);
            return float4(mul(m, vertex.xyz), vertex.w).xyzw;
        }

        float4 RotateY (float4 vertex, float angle)
        {
            float sina, cosa;
            sincos(angle, sina, cosa);
            float3x3 m = float3x3(
                cosa, 0, -sina,
                0, 1, 0,
                sina, 0, cosa);
            return float4(mul(m, vertex.xyz), vertex.w).xyzw;
        }
        
        void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            float g = pow(tex2Dlod(_Gradient, v.texcoord), _GradientFalloff);
            v.vertex = RotateY(v.vertex, g * _Twist * sin(_Time.w * _Speed + v.vertex.y));
            // v.vertex = RotateZ(v.vertex, g * _Yaw * sin(_Time.w * _Speed * _YawAmp + _YawOff));
            float yaw = g * _Yaw * sin(_Time.w * _Speed * _YawAmp + _YawOff);
            float sina, cosa;
            sincos(yaw, sina, cosa);
            v.vertex = mul(mul(mul(
                float4x4(
                    1, 0, 0, _Offset.x, 
                    0, 1, 0, _Offset.y, 
                    0, 0, 1, _Offset.z,
                    0, 0, 0, 1
                ),
                float4x4(
                    cosa, -sina, 0, 0,
                    sina, cosa, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                )),
                float4x4(
                    1, 0, 0, -_Offset.x, 
                    0, 1, 0, -_Offset.y, 
                    0, 0, 1, -_Offset.z,
                    0, 0, 0, 1
                )),
                v.vertex);
            v.vertex.x += g * _Translate * sin(_Time.w * _Speed * _TranslateAmp + _TranslateOff);
            v.vertex.x += g * _Wave * sin(_Time.w * _Speed * _WaveAmp + v.vertex.y + _WaveOff);
            
            // v.vertex.xyz += mul(YRotationMatrix(_Twist * sin(_Time.w * _Speed + v.vertex.y)), v.vertex.xyz);
            // v.vertex.xyz += mul(ZRotationMatrix(_Yaw * sin(_Time.w * _Speed)), v.vertex.xyz);

            // float3 yaw = mul(ZRotationMatrix(_Yaw * sin(_Time.w * _Speed * _YawAmp + _YawOff)), v.vertex.xyz);
            
            // float3 yaw = RotateZ(v.vertex, _Yaw * sin(_Time.w * _Speed * _YawAmp + _YawOff));
            // float3 twist = mul(YRotationMatrix(_Twist * sin(_Time.w * _Speed * _TwistAmp + _TwistOff)), v.vertex.xyz);
            // float wave = _Wave * sin(_Time.w * _Speed * _WaveAmp + v.vertex.y + _WaveOff);
            // v.vertex.xyz += twist + yaw;
            // v.vertex.x += _Translate * sin(_Time.w * _Speed * _TranslateAmp + _TranslateOff) + wave;
            
            // v.vertex.xz += rotate_z(v.vertex, _Twist * sin(_Time.w * _Speed + v.vertex.y));
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
