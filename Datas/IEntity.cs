﻿namespace Datas
{
    
        public interface IEntity<TId> : IEntity
        {
            TId Id { get; set; }
        }

        public interface IEntity
        {
        }
    
}