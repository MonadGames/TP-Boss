using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(TW_MultiStrings_Regular)), CanEditMultipleObjects]
[Serializable]
public class TW_MultiStrings_Regular_Editor : Editor
{
    private int indexOfString;
    private static string[] PointerSymbols = { "None", "<", "_", "|", ">" };
    private TW_MultiStrings_Regular TW_MS_RegularScript;


    private void Awake() {
        TW_MS_RegularScript = (TW_MultiStrings_Regular)target;
    }

    private void MakeArrayGUI(SerializedObject obj, string name)
    {
        int size = obj.FindProperty(name + ".Array.size").intValue;
        int newSize = size;
        if (newSize != size)
            obj.FindProperty(name + ".Array.size").intValue = newSize;
        int[] array_value = new int[newSize];
        for (int i = 1; i < newSize; i++)
        {
            array_value[i] = i;
        }
        string[] array_content = new string[newSize];
        for (int i = 1; i < newSize; i++)
        {
            array_content[i] = (array_value[i] + 1).ToString();
        }
        if (TW_MS_RegularScript.MultiStrings.Length == 0)
            EditorGUILayout.HelpBox("Number of Strings must be more than 0!", MessageType.Error);
        MakePopup(obj);
        EditorGUILayout.HelpBox("Chose number of string in PoPup and edit text in TextArea below", MessageType.Info, true);
        indexOfString = EditorGUILayout.IntPopup("Edit string №", indexOfString, array_content, array_value, EditorStyles.popup);
        TW_MS_RegularScript.MultiStrings[indexOfString] = EditorGUILayout.TextArea(TW_MS_RegularScript.MultiStrings[indexOfString], GUILayout.ExpandHeight(true));
    }

    private void MakePopup(SerializedObject obj)
    {
        TW_MS_RegularScript.pointer = EditorGUILayout.Popup("Pointer symbol", TW_MS_RegularScript.pointer, PointerSymbols, EditorStyles.popup);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SerializedObject SO = new SerializedObject(TW_MS_RegularScript);
        MakeArrayGUI(SO, "MultiStrings");
    }
}
#endif

public class TW_MultiStrings_Regular : MonoBehaviour {

    public bool LaunchOnStart = true;
	[Range (0, 0.5f)]
    public float timeOut = 0.1f;
    public string[] MultiStrings = new string[1];
    [HideInInspector]
    public int pointer=0;

    private string ORIGINAL_TEXT;
    private float time;
    private int сharIndex = 0;
    public int index_of_string = 0;
    private bool start;
    private List<int> n_l_list;
    private static string[] PointerSymbols = { "None", "<", "_", "|", ">" };

    void Start ()
    {
		ORIGINAL_TEXT = MultiStrings[0];
        gameObject.GetComponent<Text>().text = "";
        if (LaunchOnStart)
        {
            StartTypewriter();
        }
    }

	// update
	// write character if cooldown is 0 an charIndex <= string.length - 1
	// else charIndex = 0 and stringIndex++ 
	
	void Update () {
        if (start == true){
			MakeTypewriterText(ORIGINAL_TEXT, "");
			time -= Time.deltaTime;
        }
    }

    public void StartTypewriter()
    {
        start = true;
        сharIndex = 0;
		time = timeOut;
    }

	public void ResetCounters(){
		start = true;
		сharIndex = 0;
		time = timeOut;
		index_of_string = 0;
	}

    public void SkipTypewriter()
    {
        сharIndex = ORIGINAL_TEXT.Length - 1;
    }

    public void NextString()
    {
        start = true;
        сharIndex = 0;
		time = timeOut;
        if (index_of_string < MultiStrings.Length -1){
            index_of_string++;
        }
        else{
            index_of_string = 0;
        }
        ORIGINAL_TEXT = MultiStrings[index_of_string];
    }

    private void MakeTypewriterText(string ORIGINAL, string POINTER)
    {

		bool hasCharsLeft = сharIndex <= ORIGINAL.Length;
		start = hasCharsLeft;

		if (hasCharsLeft && time <= 0)
        {
            string emptyString = new string(' ', ORIGINAL.Length);
            string TEXT = ORIGINAL.Substring(0, сharIndex);
            TEXT = TEXT + emptyString.Substring(сharIndex);
            gameObject.GetComponent<Text>().text = TEXT;
            CharIndexPlus();
        }
    }

    private void CharIndexPlus()
    {
			time = timeOut;
            сharIndex++;
    }
}


