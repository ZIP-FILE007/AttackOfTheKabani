using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PatsanskiyMatematics
{
    /// <summary>
    /// Пацанская математика (кривые неоптимизированные функции)
    /// </summary>
    public static class PatsanskiyMatematics
    {
        /// <summary>
        /// Рукодельный рейкаст, версия для прямоугольников
        /// </summary>
        /// <param name="source">Точка источника; если размер луча > 0, точки источника будут сгенерированы по краям</param>
        /// <param name="direction">Направление луча</param>
        /// <param name="distance">Максимальная дистанция рейкаста</param>
        /// <param name="raySize">Размер луча; чтобы сделать обычный тонкий луч надо установить на 0</param>
        /// <param name="rectCenter">Центр квадрата, с которым мы ищем пересечение</param>
        /// <param name="rectSize">Размер сторон квадрата</param>
        /// <param name="castRateDistance">Дискетизация рейкаста</param>
        /// <returns>-1 если нет пересечения; иначе даёт дистанцию</returns>
        /// <remarks>
        /// Будет работать с лучами, у которых небольшая ширина
        /// </remarks>
        public static float RayCast(Vector2 source, Vector2 direction, float distance, Vector2 rectCenter, float rectSize, float raySize = 1, float castRateDistance = 0.2f)
        {
            List<Vector2> raySources = new() {
                source
            };

            if(raySize > 0) {
                // Получаем ещё 2 точки, обозначающих границы луча
                raySources.Add(source * new Vector2(-1, 0));
                raySources.Add(source * new Vector2(0, -1));
            }

            for(float currentDistance = 0; currentDistance <= distance; currentDistance = currentDistance + castRateDistance) {
                foreach(var raySource in raySources) {
                    Vector2 currentPoint = raySource * (direction * currentDistance);
                    if(IsPointInRect(rectCenter, rectSize, currentPoint))
                        return GetDistanceToRectangle(rectCenter, rectSize, source);
                }
            }
            return -1f;
        }

        public static Vector2 GetDirection(this Vector2 v, Vector2 other)
        {
            Vector2 direction = other - v;

            float x = direction.x == 0 ? 0 : direction.x / (Mathf.Abs(direction.x));
            float y = direction.y == 0 ? 0 : direction.y / (Mathf.Abs(direction.y));

            return new Vector2(x, y);
        }

        public static float GetDistanceToRectangle(Vector2 rectCenter, float rectSize, Vector2 point)
        {
            float minX = rectCenter.x - rectSize / 2;
            float minY = rectCenter.y - rectSize / 2;

            float maxX = rectCenter.x + rectSize / 2;
            float maxY = rectCenter.y + rectSize / 2;

            var dx = Math.Max(0, Math.Max(minX - point.x, point.x - maxX));
            var dy = Math.Max(0, Math.Max(minY - point.y, point.y - maxY));
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool IsPointInRect(Vector2 rectCenter, float rectSize, Vector2 point)
        {
            float minX = rectCenter.x - rectSize / 2;
            float minY = rectCenter.y - rectSize / 2;

            float maxX = rectCenter.x + rectSize / 2;
            float maxY = rectCenter.y + rectSize / 2;

            if(minX < point.x && maxX > point.x && minY < point.y && maxY > point.y)
                return true;
            return false;
        }

    }
}
