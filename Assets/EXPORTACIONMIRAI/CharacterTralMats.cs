using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTralMats : MonoBehaviour
{
    [Header("References")]
    public float meshRefresh = 0.1f;
    public bool trailActive;
    public float activeTime = 2f;
    public Transform spawnPos;
    public float destroyTime = 2f;

    [Header("Shader References")]
    public Material replacementMaterial;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRefresh = 0.05f;

    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    private Material[][] originalMaterials;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !trailActive)
        {
            trailActive = true;
            StartCoroutine(activateTrail(activeTime));
        }
    }

    IEnumerator activateTrail(float timeActive)
    {
        while (timeActive > 0)
        {
            timeActive -= meshRefresh;

            if (skinnedMeshRenderers == null)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

                // Guardar los materiales originales de cada sub-mesh
                originalMaterials = new Material[skinnedMeshRenderers.Length][];
                for (int i = 0; i < skinnedMeshRenderers.Length; i++)
                {
                    originalMaterials[i] = skinnedMeshRenderers[i].materials;
                }
            }

            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                GameObject gameObject = new GameObject();
                gameObject.transform.SetPositionAndRotation(spawnPos.position, spawnPos.rotation);

                MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
                MeshFilter mf = gameObject.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);

                mf.mesh = mesh;

                // Reemplazar los materiales originales por el nuevo material
                Material[] subMeshMaterials = new Material[mr.materials.Length];
                for (int j = 0; j < subMeshMaterials.Length; j++)
                {
                    subMeshMaterials[j] = replacementMaterial;
                }
                mr.materials = subMeshMaterials;

                for (int j = 0; j < mr.materials.Length; j++)
                {
                    StartCoroutine(AnimateMaterialFloat(mr.materials[j], 0, shaderVarRate, shaderVarRefresh));
                }

                Destroy(gameObject, destroyTime);
            }

            yield return new WaitForSeconds(meshRefresh);
        }

        trailActive = false;
    }

    IEnumerator AnimateMaterialFloat(Material mat, float goal, float rate, float refresh)
    {
        float valueAnimate = mat.GetFloat(shaderVarRef);

        while (valueAnimate > goal)
        {
            valueAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueAnimate);

            yield return new WaitForSeconds(refresh);
        }
    }
}
