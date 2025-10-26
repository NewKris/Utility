using NewKris.Utility.Extensions;
using UnityEngine;

namespace NewKris.Utility {
    public static class HandlesProxy {
        public static void DrawArrow(Vector3 position, Vector3 direction, Quaternion worldSpace, float size, Color color) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            direction = worldSpace * direction;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            UnityEditor.Handles.ArrowHandleCap(0, position, rotation, size, EventType.Repaint);
#endif
        }
        
        public static void DrawDisc(Vector3 position, Vector3 normal, float radius, bool wire, Color color, float thickness = 0) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            if (wire) {
                UnityEditor.Handles.DrawWireDisc(position, normal, radius, thickness);
            } 
            else {
                UnityEditor.Handles.DrawSolidDisc(position, normal, radius);
            }
#endif
        }

        public static void DrawSphere(Vector3 position, float radius, bool wire, Color color, float thickness = 1) {
#if UNITY_EDITOR
            Gizmos.color = color;

            if (wire) {
                DrawDisc(position, Vector3.up, radius, true, color, thickness);
                DrawDisc(position, Vector3.forward, radius, true, color, thickness);
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
        
        public static void DrawBezier(
            Vector3 from, 
            Vector3 to,
            Vector3 t1,
            Vector3 t2,
            float thickness, 
            Color color
        ) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;

            UnityEditor.Handles.DrawBezier(from, to, t1, t2, color, Texture2D.whiteTexture, thickness);
#endif
        }
        
        public static void DrawCube(
            Vector3 position,
            Vector3 size,
            Quaternion rotation,
            Color color,
            bool wired = false,
            float thickness = 1
        ) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;
            
            Vector3 p1 = position + rotation * size.Scale(-0.5f, 0.5f, 0.5f);
            Vector3 p2 = position +  rotation * size.Scale(0.5f, 0.5f, 0.5f);
            Vector3 p3 = position + rotation * size.Scale(0.5f, -0.5f, 0.5f);
            Vector3 p4 = position + rotation * size.Scale(-0.5f, -0.5f, 0.5f);
            
            Vector3 p5 = position + rotation * size.Scale(-0.5f, 0.5f, -0.5f);
            Vector3 p6 = position +  rotation * size.Scale(0.5f, 0.5f, -0.5f);
            Vector3 p7 = position + rotation * size.Scale(0.5f, -0.5f, -0.5f);
            Vector3 p8 = position + rotation * size.Scale(-0.5f, -0.5f, -0.5f);

            if (wired) {
                DrawLine(p1, p2, thickness, false, color);
                DrawLine(p2, p3, thickness, false, color);
                DrawLine(p3, p4, thickness, false, color);
                DrawLine(p4, p1, thickness, false, color);
                
                DrawLine(p5, p6, thickness, false, color);
                DrawLine(p6, p7, thickness, false, color);
                DrawLine(p7, p8, thickness, false, color);
                DrawLine(p8, p5, thickness, false, color);
                
                DrawLine(p1, p5, thickness, false, color);
                DrawLine(p2, p6, thickness, false, color);
                DrawLine(p3, p7, thickness, false, color);
                DrawLine(p4, p8, thickness, false, color);
            }
#endif
        }
        
        public static void DrawPlane(
            Vector3 position,
            Vector2 size,
            Quaternion rotation,
            Color color,
            bool wired = false,
            float thickness = 1
        ) {
#if UNITY_EDITOR
            Vector3 p1 = position + rotation * size.Scale(-0.5f, 0.5f);
            Vector3 p2 = position +  rotation * size.Scale(0.5f, 0.5f);
            Vector3 p3 = position + rotation * size.Scale(0.5f, -0.5f);
            Vector3 p4 = position + rotation * size.Scale(-0.5f, -0.5f);
            
            if (wired) {
                DrawLine(p1, p2, thickness, false, color);
                DrawLine(p2, p3, thickness, false, color);
                DrawLine(p3, p4, thickness, false, color);
                DrawLine(p4, p1, thickness, false, color);
            }
#endif
        }

        public static void DrawCapsule2D(
            Vector3 position, 
            float height, 
            float radius, 
            float thickness, 
            Color color
        ) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;
            height = Mathf.Max(height, radius * 2);
            
            if (radius <= 0) {
                return;
            }

            Vector3 top = position + Vector3.up * (height * 0.5f);
            Vector3 bottom = position - Vector3.up * (height * 0.5f);

            Vector3 p1 = top - Vector3.up * radius;
            Vector3 p2 = bottom + Vector3.up * radius;
            
            for (int x = -1; x <= 1; x++) {
                if (x == 0) {
                    continue;
                }
                    
                Vector3 offset = new Vector3(x, 0, 0).normalized * radius;
                    
                Vector3 c1 = p1 + offset;
                Vector3 c2 = p2 + offset;

                DrawLine(c1, c2, thickness, false, color);

                Vector3 t1 = c1 + Vector3.up * (radius * 0.5f);
                Vector3 t2 = top + offset * 0.5f;
                    
                Vector3 t3 = c2 - Vector3.up * (radius * 0.5f);
                Vector3 t4 = bottom + offset * 0.5f;

                DrawBezier(c1, top, t1, t2, thickness, color);
                DrawBezier(c2, bottom, t3, t4, thickness, color);
            }
#endif
        }
        
        public static void DrawCapsule(
            Vector3 position,
            float height,
            float radius,
            float thickness,
            Color color
        ) {
#if UNITY_EDITOR
            UnityEditor.Handles.color = color;
            height = Mathf.Max(height, radius * 2);
            
            if (radius <= 0) {
                return;
            }

            Vector3 top = position + Vector3.up * (height * 0.5f);
            Vector3 bottom = position - Vector3.up * (height * 0.5f);

            Vector3 p1 = top - Vector3.up * radius;
            Vector3 p2 = bottom + Vector3.up * radius;
            
            UnityEditor.Handles.DrawWireDisc(p1, Vector3.up, radius, thickness);
            UnityEditor.Handles.DrawWireDisc(p2, Vector3.up, radius, thickness);

            for (int x = -1; x <= 1; x++) {
                for (int z = -1; z <= 1; z++) {
                    if ((z != 0 && x != 0) || (z == 0 && x == 0)) {
                        continue;
                    }
                    
                    Vector3 offset = new Vector3(x, 0, z).normalized * radius;
                    
                    Vector3 c1 = p1 + offset;
                    Vector3 c2 = p2 + offset;

                    DrawLine(c1, c2, thickness, false, color);

                    Vector3 t1 = c1 + Vector3.up * (radius * 0.5f);
                    Vector3 t2 = top + offset * 0.5f;
                    
                    Vector3 t3 = c2 - Vector3.up * (radius * 0.5f);
                    Vector3 t4 = bottom + offset * 0.5f;

                    DrawBezier(c1, top, t1, t2, thickness, color);
                    DrawBezier(c2, bottom, t3, t4, thickness, color);
                }
            }
#endif
        }
    }
}
