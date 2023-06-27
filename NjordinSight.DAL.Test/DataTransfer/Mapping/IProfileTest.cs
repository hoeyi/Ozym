namespace NjordinSight.Test.DataTransfer.Mapping
{
    public interface IProfileTest
    {
        /// <summary>
        /// Verify a configuration built with all required profiles in the dependency tree
        /// is valid.
        /// </summary>
        public void Configuration_WithProfileDependencies_IsValid();
    }
}
