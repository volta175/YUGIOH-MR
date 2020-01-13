
using UnityEngine;
using UnityEditor;

static class CharUnityIntegration
{

    [MenuItem("Assets/Create/CharacterAsset")]
    public static void CreateYourScriptableObject()
    {
        SOUtility2.CreateAsset<CharacterAsset>();
    }

}
