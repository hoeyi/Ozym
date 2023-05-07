using NjordFinance.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.DataTransfer
{
    /// <summary>
    /// Object wrapping a <see cref="ModelAttribute"/> instance for later conversion to a
    /// data transfer object.
    /// </summary>
    public class ModelAttributeDto
    {
        private readonly ModelAttribute _entity;

        public ModelAttributeDto(ModelAttribute entity)
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

        public IReadOnlyCollection<ModelAttributeMember> AttributeMembers =>
            _entity.ModelAttributeMembers.ToList();

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
        /// Adds a new entry to the <see cref="AttributeMembers"/> collection.
        /// </summary>
        public void AddAttributeMember() => _entity.ModelAttributeMembers.Add(
            new()
            {
                AttributeId = _entity.AttributeId
            });

        /// <summary>
        /// Removes the given <see cref="ModelAttributeMember"/> from the <see cref="AttributeMembers"/>
        /// collection.
        /// </summary>
        /// <param name="modelAttributeMember"></param>
        public void RemoveAttributeMember(ModelAttributeMember modelAttributeMember) =>
            _entity.ModelAttributeMembers.Remove(modelAttributeMember);

        /// <summary>
        /// Converts this instance into a <see cref="ModelAttribute"/> instance.
        /// </summary>
        /// <returns>The <see cref="ModelAttribute"/> instance mapped from this model.</returns>
        public ModelAttribute ToEntity() => _entity;
    }
}
