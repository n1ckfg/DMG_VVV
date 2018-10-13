/************************************************************************************

Depthkit Unity SDK License v1
Copyright 2016-2018 Simile Inc. All Rights reserved.  

Licensed under the Simile Inc. Software Development Kit License Agreement (the "License"); 
you may not use this SDK except in compliance with the License, 
which is provided at the time of installation or download, 
or which otherwise accompanies this software in either electronic or hard copy form.  

You may obtain a copy of the License at http://www.depthkit.tv/license-agreement-v1

Unless required by applicable law or agreed to in writing, 
the SDK distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and limitations under the License. 

************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Depthkit
{

    [CustomEditor(typeof(Depthkit_HologramLook))]
    [CanEditMultipleObjects]
    public class Depthkit_HologramLookEditor : Editor
    {
        SerializedProperty _meshDensityProp;
        SerializedProperty _selfOcclusionProp;

        void OnEnable()
        {

            //set the property types
            _meshDensityProp = serializedObject.FindProperty("_meshDensity");
            _selfOcclusionProp = serializedObject.FindProperty("_selfOcclusion");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();


            Depthkit_HologramLook renderer = (Depthkit_HologramLook)target;

            EditorGUILayout.PropertyField(_selfOcclusionProp);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_meshDensityProp);
            if (EditorGUI.EndChangeCheck())
            {
                renderer.SetGeometryDirty();
            }


            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Line Layer"))
            {
                renderer.AddLineLayer();
            }
            if (GUILayout.Button("Add Point Layer"))
            {
                renderer.AddPointLayer();
            }
            GUILayout.EndHorizontal();

            //APPLY PROPERTY MODIFICATIONS
            serializedObject.ApplyModifiedProperties();

        }
    }
}