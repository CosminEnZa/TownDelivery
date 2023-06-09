﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshCombineStudio
{
    [ExecuteInEditMode]
    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject[] objects;

        public float density = 0.5f;
        public Vector2 scaleRange = new Vector2(0.5f, 2f);
        public Vector3 rotationRange = new Vector3(5, 360, 5);
        public Vector2 heightRange = new Vector2(0, 1);

        public float scaleMulti = 1;

        public float resolutionPerMeter = 2;
        public bool spawnInRuntime;
        public bool spawn;
        public bool deleteChildren;


        Transform t;

        private void Awake()
        {
            t = transform;

            if (spawnInRuntime && Application.isPlaying)
            {
                Spawn();
            }
        }

        private void Update()
        {
            if (spawn)
            {
                spawn = false;
                Spawn();
            }
            if (deleteChildren)
            {
                deleteChildren = false;
                DeleteChildren();
            }
        }

        public void DeleteChildren()
        {
            Transform[] transforms = GetComponentsInChildren<Transform>();

            for (int i = 0; i < transforms.Length; i++)
            {
                if (t != transforms[i] && transforms[i] != null) DestroyImmediate(transforms[i].gameObject);
            }
        }

        public void Spawn()
        {
            Bounds bounds = new Bounds();
            bounds.center = transform.position;
            bounds.size = transform.lossyScale;

            float xStart = bounds.min.x;
            float xEnd = bounds.max.x;
            float yStart = bounds.min.y;
            float yEnd = bounds.max.y;
            float zStart = bounds.min.z;
            float zEnd = bounds.max.z;

            int objectCount = objects.Length;
            float halfRes = resolutionPerMeter * 0.5f;
            float heightOffset = transform.lossyScale.y * 0.5f;
            int count = 0;

            for (float z = zStart; z < zEnd; z += resolutionPerMeter)
            {
                for (float x = xStart; x < xEnd; x += resolutionPerMeter)
                {
                    for (float y = yStart; y < yEnd; y += resolutionPerMeter)
                    {
                        int index = Random.Range(0, objectCount);
                        float spawnValue = Random.value;
                        if (spawnValue < density)
                        {
                            Vector3 pos = new Vector3(x + Random.Range(-halfRes, halfRes), yStart + (Random.Range(0, bounds.size.y) * Random.Range(heightRange.x, heightRange.y)), z + Random.Range(-halfRes, halfRes));
                            if (pos.x < xStart || pos.x > xEnd || pos.y < yStart || pos.y > yEnd || pos.z < zStart || pos.z > zEnd) continue;
                            pos.y += heightOffset;
                            Vector3 eulerAngles = new Vector3(Random.Range(0, rotationRange.x), Random.Range(0, rotationRange.y), Random.Range(0, rotationRange.z));
                            GameObject go = (GameObject)Instantiate(objects[index], pos, Quaternion.Euler(eulerAngles));
                            float scale = Random.Range(scaleRange.x, scaleRange.y) * scaleMulti;
                            go.transform.localScale = new Vector3(scale, scale, scale);
                            go.transform.parent = t;
                            ++count;
                        }
                    }
                }
            }

            Debug.Log("Spawned " + count);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position + new Vector3(0, transform.lossyScale.y * 0.5f, 0), transform.lossyScale);
        }
    }
}