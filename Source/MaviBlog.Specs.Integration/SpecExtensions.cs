using System.IO;
using Machine.Specifications;

namespace MaviBlog.Specs.Integration
{
    public static class SpecExtensions
    {
        public static void ShouldExist(this string filePath)
        {
            File.Exists(filePath).ShouldBeTrue();
        }
    }
}