using UnityEditor;
using UnityEngine;

public class TestSO : ScriptableObject {
    public string TestName;

    // Equivalent of an object constructor.
    public static TestSO Create(string name) {
        TestSO newSO = ScriptableObject.CreateInstance<TestSO>();
        AssetDatabase.CreateAsset(newSO, AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/TestSO.asset"));
        newSO.Init(name);

        AssetDatabase.SaveAssetIfDirty(newSO);
        //AssetDatabase.SaveAssets();

        return newSO;
    }

    // Value assignment part of constructor.
    void Init(string name) {
        this.TestName = name;
    }
}