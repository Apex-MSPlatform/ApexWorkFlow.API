using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assemply = typeof(AssemblyReference).Assembly;
    }
}
