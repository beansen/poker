using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestDeckCreator))]
public class TestDeckCreatorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		TestDeckCreator myScript = (TestDeckCreator)target;
		if (GUILayout.Button("Create Deck"))
		{
			myScript.CreateDeck();
		}
	}
}
