using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendWebService.Domain.UnitTests
{
    /// <summary>
    /// Helper class to fix common warning patterns in test files
    /// </summary>
    public static class WarningFixer
    {
        /// <summary>
        /// Fixes null! reference warnings by using null-forgiving operator where appropriate
        /// </summary>
        public static string FixNullReferenceWarnings(string content)
        {
            // Fix common patterns
            content = content.Replace("= null!;", "= null!;");
            content = content.Replace("null!,", "null!,");
            content = content.Replace("null!)", "null!)");
            content = content.Replace("null! ", "null! ");
            content = content.Replace("null;", "null!;");
            
            // Fix specific patterns
            content = content.Replace("TestEntity entity1 = null!;", "TestEntity? entity1 = null!;");
            content = content.Replace("TestEntity entity2 = null!;", "TestEntity? entity2 = null!;");
            
            return content;
        }
    }
}
