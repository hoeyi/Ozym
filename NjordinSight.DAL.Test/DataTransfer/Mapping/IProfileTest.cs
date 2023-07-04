﻿using AutoMapper;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    /// <summary>
    /// Represents the base requirements for a test class targetting a class derived from
    /// <see cref="Profile"/>.
    /// </summary>
    internal interface IProfileTest
    {
        /// <summary>
        /// Verify a configuration built with all required profiles in the dependency tree is valid.
        /// </summary>
        public void Configuration_IsValid();

        /// <summary>
        /// Verify an entity instance mapped from a DTO instance has all mapped properties equal 
        /// to the source.
        /// </summary>
        /// <returns>A task representing an asynchronous test operation.</returns>
        Task Entity_MapFrom_Dto_MappedProperties_AreEqual();

        /// <summary>
        /// Verify an DTO instance mapped from an entity instance has all mapped properties equal 
        /// to the source.
        /// </summary>
        /// <returns>A task representing an asynchronous test operation.</returns>
        Task Dto_MapFrom_Entity_MappedProperties_AreEqual();
    }
}