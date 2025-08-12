using PolicyCheck.src.module;

namespace PolicyCheck.src.utilities
{
    public static class PolicyKeyValueEnumExtensions
    {
        /// <summary>
        /// PolicyKyeValueEnum ToInt
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this PolicyKeyValueEnum value)
        {
            return (int)value;
        }
    }
}
