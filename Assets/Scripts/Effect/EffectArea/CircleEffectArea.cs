using Assets.Scripts.PatsanskiyMatematics;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CircleEffectArea : IEffectArea
{
    public CircleEffectArea(int distance)
    {
        Distance = distance;
    }

    public int Distance { get; protected set; }

    public string Name => "Круговой";

    public List<IEntity> GetAffectedEntities(Vector2 sourcePosition, List<IEntity> possibleEnitites, Vector2? direction = null)
    {
        // Если радиус эффекта 0 - следовательно применяем только к источнику
        if(Distance == 0){
            // Если на входе 1 возможный объект - это и есть источник
            if(possibleEnitites.Count == 1)
                return possibleEnitites;
            // Иначе ищем по позиции
            return possibleEnitites.Where(pE => pE.Position == sourcePosition).ToList();
        }

        List<IEntity> affectedEntities = new();
        foreach(var entity in possibleEnitites) {
            
            float entityDistance = Vector2.Distance(entity.Position, sourcePosition);
            if(entity is IDestroyable destroyable) {
                // Если объект уничтожим, у него есть размер хитбокса, и его учитываем
                entityDistance = PatsanskiyMatematics.GetDistanceToRectangle(destroyable.Position, destroyable.RectangleSize, sourcePosition);
            }
            if(entityDistance <= Distance)
                    affectedEntities.Add(entity);
        }

        return affectedEntities;
    }
}
