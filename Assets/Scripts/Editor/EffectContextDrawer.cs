// using UnityEditor;
// using UnityEngine;

// [CustomPropertyDrawer(typeof(EffectContext))]
// public class EffectContextDrawer : PropertyDrawer
// {
//     private const string PayloadFieldName = "payload";

//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         EditorGUI.BeginProperty(position, label, property);

//         var effectProperty = property.FindPropertyRelative("effect");
//         var payloadProperty = property.FindPropertyRelative(PayloadFieldName);
//         var lineHeight = EditorGUIUtility.singleLineHeight;
//         var spacing = EditorGUIUtility.standardVerticalSpacing;

//         position.height = lineHeight;
//         EditorGUI.PropertyField(position, effectProperty);
//         position.y += lineHeight + spacing;

//         var payloadLabel = new GUIContent("Payload");
//         var typeName = payloadProperty.managedReferenceValue == null
//             ? "None"
//             : payloadProperty.managedReferenceValue.GetType().Name;
//         var buttonLabel = new GUIContent(typeName);

//         if (EditorGUI.DropdownButton(position, buttonLabel, FocusType.Passive))
//         {
//             ShowPayloadMenu(payloadProperty);
//         }

//         position.y += lineHeight + spacing;
//         if (payloadProperty.managedReferenceValue != null)
//         {
//             var payloadChildren = payloadProperty.Copy();
//             var endProperty = payloadChildren.GetEndProperty();
//             var enterChildren = true;

//             while (payloadChildren.NextVisible(enterChildren) && !SerializedProperty.EqualContents(payloadChildren, endProperty))
//             {
//                 if (payloadChildren.propertyPath == payloadProperty.propertyPath)
//                 {
//                     enterChildren = true;
//                     continue;
//                 }

//                 var childHeight = EditorGUI.GetPropertyHeight(payloadChildren, true);
//                 position.height = childHeight;
//                 EditorGUI.PropertyField(position, payloadChildren, true);
//                 position.y += childHeight + spacing;
//                 enterChildren = false;
//             }
//         }

//         EditorGUI.EndProperty();
//     }

//     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//     {
//         var height = (EditorGUIUtility.singleLineHeight * 2) + (EditorGUIUtility.standardVerticalSpacing * 2);
//         var payloadProperty = property.FindPropertyRelative(PayloadFieldName);

//         if (payloadProperty.managedReferenceValue != null)
//         {
//             var payloadChildren = payloadProperty.Copy();
//             var endProperty = payloadChildren.GetEndProperty();
//             var enterChildren = true;

//             while (payloadChildren.NextVisible(enterChildren) && !SerializedProperty.EqualContents(payloadChildren, endProperty))
//             {
//                 if (payloadChildren.propertyPath == payloadProperty.propertyPath)
//                 {
//                     enterChildren = true;
//                     continue;
//                 }

//                 height += EditorGUI.GetPropertyHeight(payloadChildren, true) + EditorGUIUtility.standardVerticalSpacing;
//                 enterChildren = false;
//             }
//         }

//         return height;
//     }

//     private static void ShowPayloadMenu(SerializedProperty payloadProperty)
//     {
//         var menu = new GenericMenu();
//         AddPayloadOption<DamagePayload>(menu, payloadProperty, "Damage");
//         AddPayloadOption<RestoreMPPayload>(menu, payloadProperty, "Restore MP");
//         AddPayloadOption<RestoreHPPayload>(menu, payloadProperty, "Restore HP");
//         menu.AddSeparator("");
//         menu.AddItem(new GUIContent("None"), payloadProperty.managedReferenceValue == null, () =>
//         {
//             payloadProperty.managedReferenceValue = null;
//             payloadProperty.serializedObject.ApplyModifiedProperties();
//         });
//         menu.ShowAsContext();
//     }

//     private static void AddPayloadOption<T>(GenericMenu menu, SerializedProperty payloadProperty, string label)
//         where T : EffectPayload, new()
//     {
//         var selected = payloadProperty.managedReferenceValue is T;
//         menu.AddItem(new GUIContent(label), selected, () =>
//         {
//             payloadProperty.managedReferenceValue = new T();
//             payloadProperty.serializedObject.ApplyModifiedProperties();
//         });
//     }
// }