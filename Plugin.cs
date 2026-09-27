using BepInEx;
using UnityEngine;

namespace NoLeavesMod
{
    [BepInPlugin("made.by.cytrixgt", "No Leaves", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            GameObject go = new GameObject("NoLeavesRemover");
            DontDestroyOnLoad(go);
            go.AddComponent<removeleaf>();
        }
    }
}
