using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class UIS_Settings : ScriptableObject
{
    [SerializeField]
    private int _selectedProfileOption;
    public int selectedProfileOption
    {
        get { return _selectedProfileOption; }
        set
        {
            if (_selectedProfileOption != value)
            {
                _selectedProfileOption = value;
                Init();
                ReInitInputSystem();
            }
        }
    }

    [HideInInspector] private static UIS_Settings m_Instance;
    [HideInInspector] public static UIS_Settings Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = Resources.Load<UIS_Settings>("UIS_Settings");
            return m_Instance;
        }

        set
        {
            m_Instance = value;
        }
    }

    public void Init()
    {
        UniversalInputSystem.uis_Profiles.Init();
        UniversalInputSystem.uis_Profiles.SetProfile(UniversalInputSystem.Instance, UniversalInputSystem.uis_Profiles.jsonImportData[selectedProfileOption]);
    }

#if UNITY_EDITOR
    public void SaveData()
    {
        EditorUtility.SetDirty(m_Instance);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif

    private void ReInitInputSystem()
    {
        UniversalInputSystem.Instance.Init();
        //Debug.Log("Hello World!");
    }
}
