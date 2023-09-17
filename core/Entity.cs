﻿namespace SpotEngine
{
    public class Entity
    {
        public Transform transform { get; set; }

        public List<Controller> controllers { get; set; }

        public string name;
        public string tag;

        public Entity() 
        {
            name = "entity";
            tag = "default";
            transform = new Transform();
            controllers = new List<Controller>();
        }

        public void Init()
        {
            foreach (Controller controller in controllers)
            {
                controller.InitializeOnce();
            }
        }

        public void Flow(float deltaTime)
        {
            foreach (Controller controller in controllers)
            {
                controller.Flow(deltaTime);

                if(controller.entity == null)
                {
                    controller.entity = this;
                }
            }
        }

        public static Entity SpawnEntity(Entity entity)
        {
            Entity spawnedEntity = new Entity();

            spawnedEntity.name = entity.name;
            spawnedEntity.tag = entity.tag;
            spawnedEntity.transform = entity.transform;
            spawnedEntity.controllers = entity.controllers;

            Spot.Instance.game.entities.Add(spawnedEntity);

            return spawnedEntity;
        }

        public void AddController(Controller controller)
        {
            controllers.Add(controller);

            controller.entity = this;

        }


    }
}
