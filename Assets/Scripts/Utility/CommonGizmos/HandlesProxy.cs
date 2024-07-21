using UnityEngine;

namespace BaraGames.Utility.CommonGizmos {
    public static class HandlesProxy {
        public static void DrawArrow(Vector3 position, Vector3 direction, Quaternion worldSpace, float size, Color color) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            direction = worldSpace * direction;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            UnityEditor.Handles.ArrowHandleCap(0, position, rotation, size, EventType.Repaint);
#endif
        }
        
        public static void DrawDisc(Vector3 position, Vector3 normal, float radius, bool wire, Color color) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            if (wire) {
                UnityEditor.Handles.DrawWireDisc(position, normal, radius);
            } 
            else {
                UnityEditor.Handles.DrawSolidDisc(position, normal, radius);
            }
#endif
        }

        public static void DrawSphere(Vector3 position, float radius, bool wire, Color color) {
#if UNITY_EDITOR
            Gizmos.color = color;

            if (wire) {
                Gizmos.DrawWireSphere(position, radius);
            } 
            else {
                Gizmos.DrawSphere(position, radius);
            }
#endif
        }

        public static void DrawLine(Vector3 from, Vector3 to, float thickness, bool dotted, Color color) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            if (dotted) {
                UnityEditor.Handles.DrawDottedLine(from, to, thickness);
            } 
            else {
                UnityEditor.Handles.DrawLine(from, to, thickness);
            }
#endif
        }
    }
}
