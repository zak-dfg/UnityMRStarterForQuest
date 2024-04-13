using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshToCSV : MonoBehaviour
{
    public MeshFilter meshFilter;

    public void ExportToCSV(string path)
    {
        if(meshFilter == null)
        {
            Debug.LogError("No mesh filter assigned!");
            return;
        }

        Mesh mesh = meshFilter.sharedMesh;

        if(mesh == null)
        {
            Debug.LogError("Mesh is null.");
            return;
        }

        StreamWriter writer = new StreamWriter(path);

        //Header
        writer.WriteLine("Point_ID, Vertex_X, Vertex_Y, Vertex_Z");

        Vector3[] vertices = mesh.vertices;
        for(int i = 0; i < vertices.Length; i++) 
        {
            writer.WriteLine($"{vertices[i].x},{vertices[i].y},{vertices[i].z}");
        }

        writer.Close();

        Debug.Log("Mesh export complete!");
    }

    [ContextMenu("Export CSV")]
    private void ExportCSV()
    {
        string destinationPath = "Assets/mesh_data.csv";
        ExportToCSV(destinationPath);
    }
}
