using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel.Model;

namespace Spiel.System
{
    public class EntityManager
    {

        public List<Entity> entities = new List<Entity>();
        public Dictionary<string, List<Entity>> entitiesByTag = new Dictionary<string, List<Entity>>(); // <tag, entity
        

        public uint totalEntities = 0;

        public EntityManager() { }

        public void Update()
        {
            
            RemoveDeadEntities(entities);

            foreach (var tag in entitiesByTag)
            {
                RemoveDeadEntities(tag.Value);
            }
           
        }

        public void RemoveDeadEntities(List<Entity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i]._active == false)
                {
                    entities.RemoveAt(i);
                }
            }
        }

        public List<Entity> GetEntities() { return entities; }

        public List<Entity> GetEntitiesByTag(string tag)
        {
            return entitiesByTag[tag];
        }

        public Entity AddEntity(string tag)
        {
            Entity e = new Entity(totalEntities++, tag);
            entities.Add(e);
            if (!entitiesByTag.ContainsKey(tag))
            {
                entitiesByTag.Add(e._tag, new List<Entity> { e });
            }
            else
            {
                entitiesByTag[tag].Add(e);
            }
            return e;
        }
    }
}
