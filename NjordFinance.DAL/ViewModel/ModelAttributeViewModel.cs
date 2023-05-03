﻿using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ViewModel
{
    public class ModelAttributeViewModel
    {
        private readonly ModelAttribute _entity;

        public ModelAttributeViewModel(ModelAttribute entity)
        {
            if (entity is null)
                throw new ArgumentNullException(paramName: nameof(entity));

            _entity = entity;
        }

        public string DisplayName
        {
            get { return _entity.DisplayName; }
            set 
            { 
                if (_entity.DisplayName != value)
                    _entity.DisplayName = value;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="ModelAttributeScope"/> records applied 
        /// to the <see cref="ModelAttribute"/> this model represents.
        /// </summary>
        public IReadOnlyCollection<ModelAttributeScope> AttributeScopes =>
            _entity.ModelAttributeScopes.ToList();

        /// <summary>
        /// Adds a new <see cref="ModelAttributeScope"/> to the model collection.
        /// </summary>
        public void AddNewAttributeScope() => _entity.ModelAttributeScopes.Add(
            new ModelAttributeScope()
            {
                AttributeId = _entity.AttributeId
            });

        /// <summary>
        /// Removes the given <see cref="ModelAttributeScope"/> instance from the model 
        /// collection.
        /// </summary>
        /// <param name="attributeScope"></param>
        /// <returns>True if the operation is successful, else false.</returns>
        public bool RemoveScope(ModelAttributeScope attributeScope) =>
            _entity.ModelAttributeScopes.Remove(attributeScope);
        
        /// <summary>
        /// Converts this instance into a <see cref="ModelAttribute"/> instance.
        /// </summary>
        /// <returns>The <see cref="ModelAttribute"/> instance mapped from this model.</returns>
        public ModelAttribute ToEntity() => _entity;
    }
}