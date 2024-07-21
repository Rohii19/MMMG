using UnityEngine;
using UnityEditor;

public class WallDuplicator : MonoBehaviour
{
    public Vector3 wallOffset = new Vector3(1, 0, 0); // Offset between each duplicated wall
    public int numberOfDuplicates = 1; // Number of times to duplicate the wall

    // Function to duplicate the wall
    public void DuplicateWall()
    {
        if (Selection.activeGameObject == null)
        {
            Debug.LogWarning("No GameObject selected to duplicate.");
            return;
        }

        GameObject selectedObject = Selection.activeGameObject;

        for (int i = 0; i < numberOfDuplicates; i++)
        {
            // Calculate the new position
            Vector3 newPosition = selectedObject.transform.position + wallOffset * (i + 1);

            // Duplicate the object
            GameObject duplicatedObject = Instantiate(selectedObject, newPosition, selectedObject.transform.rotation);
            duplicatedObject.transform.parent = selectedObject.transform.parent;

            // Select the newly duplicated object
            Selection.activeGameObject = duplicatedObject;

            // Update the reference to the last duplicated object for the next iteration
            selectedObject = duplicatedObject;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(WallDuplicator))]
public class WallDuplicatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WallDuplicator wallDuplicator = (WallDuplicator)target;

        if (GUILayout.Button("Duplicate Wall"))
        {
            wallDuplicator.DuplicateWall();
        }
    }
}
#endif
