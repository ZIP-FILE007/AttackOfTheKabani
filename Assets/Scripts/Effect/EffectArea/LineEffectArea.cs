using Assets.Scripts.PatsanskiyMatematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LineEffectArea : IEffectArea
{
    public LineEffectArea(int distance, int fatness)
    {
        Distance = distance;
        Fatness = fatness;
    }

    public int Distance { get; protected set; }
    public int Fatness { get; protected set; }

    public bool IsPenetratingEntity { get; protected set; }
    public bool IsPenetratingWall { get; protected set; }

    public string Name => "Луч";

    public List<IEntity> GetAffectedEntities(Vector2 sourcePosition, List<IEntity> possibleEnitites, Vector2? direction = null)
    {
        if(direction == null)
            throw new InvalidOperationException($"У луча из позиции ({sourcePosition.x};{sourcePosition.y}) нет направления");
        // Направление должно быть нормализировано, поэтому на всякий случай нормализируем
        direction.Value.Normalize();

        // Сначала определим, какие объекты вообще хитнуться могут, исходя из дистанции
        List<IDestroyable> linePossibleEnitites = new List<IDestroyable>();
        foreach (var entity in possibleEnitites) {
            // Луч работает только на уничтожимые объекты
            if(entity is IDestroyable destroyable) {
                float entityDistance = PatsanskiyMatematics.GetDistanceToRectangle(destroyable.Position, destroyable.RectangleSize, sourcePosition);

                if(entityDistance <= Distance)
                    linePossibleEnitites.Add(destroyable);
            }
        }

        // Сортируем их по дистанции
        linePossibleEnitites = linePossibleEnitites
            .OrderBy(pE => PatsanskiyMatematics.GetDistanceToRectangle(pE.Position, pE.RectangleSize, sourcePosition))
            .ToList();

        // Собственно, расчёт луча
        List<IEntity> resultList = new();
        foreach(var damageble in linePossibleEnitites) {
            float distance = PatsanskiyMatematics.RayCast(sourcePosition, direction.Value, Distance, damageble.Position, damageble.RectangleSize,
                raySize: Fatness);
            if(distance != -1) {
                resultList.Add(damageble);
                if (IsPenetratingEntity) {
                    continue;
                }
                else if (IsPenetratingWall && damageble is IWall) {
                    continue;
                }
                else {
                    break;
                }
            }
        }
        return resultList;
    }
}
