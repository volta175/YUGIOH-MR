using UnityEngine;
using UnityEditor;

static class CardUnutyIntegration
{
   [MenuItem("Assets/Create/CardAsset")]
   public static void CreateYourSO()
    {
        SOUtility2.CreateAsset<CardAsset>();
    }
}
