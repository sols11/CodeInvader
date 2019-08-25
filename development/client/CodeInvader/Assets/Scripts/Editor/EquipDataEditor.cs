/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/13
Description:
    简介：给EquipData定制的编辑器类，暂时不用
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using ProjectScript;
using UnityEditor;
using UnityEngine.Serialization;

[CustomEditor(typeof(EquipDataEditor))]
public class EquipDataEditor : Editor
{
    public SerializedObject thisObject;
    public SerializedProperty type;
    public SerializedProperty name;
    public SerializedProperty attack;
    public SerializedProperty moveSpeed;
    public SerializedProperty atkRange;
    public SerializedProperty weaponType;
    public SerializedProperty breakDefense;
    public SerializedProperty slowDown;
    public SerializedProperty slowDownSpeed;
    public SerializedProperty beatBack;
    public SerializedProperty beatBackForce;
    public SerializedProperty isFly;

    public void OnEnable()
    {
        this.thisObject = new SerializedObject(target);
        this.type = this.thisObject.FindProperty("type");
        this.name = this.thisObject.FindProperty("name");
        this.attack = this.thisObject.FindProperty("attack");
        this.moveSpeed = this.thisObject.FindProperty("moveSpeed");
        this.atkRange = this.thisObject.FindProperty("atkRange");
        this.weaponType = this.thisObject.FindProperty("weaponType");
        this.breakDefense = this.thisObject.FindProperty("breakDefense");
        this.slowDown = this.thisObject.FindProperty("slowDown");
        this.slowDownSpeed = this.thisObject.FindProperty("slowDownSpeed");
        this.beatBack = this.thisObject.FindProperty("beatBack");
        this.beatBackForce = this.thisObject.FindProperty("beatBackForce");
        this.isFly = this.thisObject.FindProperty("isFly");
    }

    public override void OnInspectorGUI()
    {
        this.thisObject.Update();

        EditorGUILayout.PropertyField(this.type);

        switch (this.type.enumValueIndex)
        {
            case 0:
                EditorGUILayout.PropertyField(this.name);
                EditorGUILayout.PropertyField(this.attack);
                EditorGUILayout.PropertyField(this.atkRange);
                EditorGUILayout.PropertyField(this.weaponType);
                EditorGUILayout.PropertyField(this.breakDefense);
                EditorGUILayout.PropertyField(this.slowDown);
                EditorGUILayout.PropertyField(this.slowDownSpeed);
                EditorGUILayout.PropertyField(this.beatBack);
                EditorGUILayout.PropertyField(this.beatBackForce);
                break;
            case 1:
                EditorGUILayout.PropertyField(this.name);
                break;
            case 2:
                EditorGUILayout.PropertyField(this.name);
                EditorGUILayout.PropertyField(this.moveSpeed);
                EditorGUILayout.PropertyField(this.isFly);
                break;
        }

        this.thisObject.ApplyModifiedProperties();

    }
}