using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraiCharacter : MonoBehaviour
{
    [Header("References")]
    public float meshRefresh = 0.1f;
    public bool trailActive;
    public float activeTime = 2f;
    public Transform spawnPos;
    public float destroyTime = 2f;

    [Header("Shader References")]
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRefresh = 0.05f;

    private SkinnedMeshRenderer[] skinnedMeshRenderers;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !trailActive)
        {
            trailActive = true;
            StartCoroutine(activateTrail(activeTime));
        }
    }

    IEnumerator activateTrail(float timeActive)
    {
        while(timeActive > 0)
        {
            timeActive -= meshRefresh;
            
            if(skinnedMeshRenderers == null)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }

            for(int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                GameObject gameObject = new GameObject();
                gameObject.transform.SetPositionAndRotation(spawnPos.position, spawnPos.rotation);

                MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
                MeshFilter mf = gameObject.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);

                mf.mesh = mesh;
                mr.material = mat;

                StartCoroutine(AnimateMaterialFloat(mr.material, 0, shaderVarRate, shaderVarRefresh));

                Destroy(gameObject, destroyTime);
            }

            yield return new WaitForSeconds(meshRefresh);
        }

        trailActive = false;
    }

    IEnumerator AnimateMaterialFloat(Material mat, float goal, float rate, float refresh)
    {
        float valueAnimate = mat.GetFloat(shaderVarRef);

        while(valueAnimate > goal)
        {
            valueAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueAnimate);

            yield return new WaitForSeconds(refresh);
        }
    }
}
