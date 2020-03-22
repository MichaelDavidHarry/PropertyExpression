using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace PropertyExpression.Tests
{
    [TestClass]
    public class FieldInfoExpressionExtensionTests
    {
        [TestMethod]
        public void GetFieldInfoShouldReturnAFieldInfo()
        {
            Expression<Func<TestClass, object>> propertySelector = t => t.StringField;
            var fieldInfo = propertySelector.GetFieldInfo();

            Assert.IsNotNull(fieldInfo);
        }

        [TestMethod]
        public void GetFieldInfoShouldGetCorrectFieldInfoForField()
        {
            Expression<Func<TestClass, object>> propertySelector = t => t.StringField;
            var fieldInfo = propertySelector.GetFieldInfo();

            const string testStringValue = "Hello, world!";
            var testClassInstance = new TestClass() { StringField = testStringValue, StringProperty = "Other value" };

            Assert.AreEqual(testStringValue, (string)fieldInfo.GetValue(testClassInstance));
        }

        [TestMethod]
        public void GetFieldInfoShouldThrowIfRetrievingProperty()
        {
            Expression<Func<TestClass, object>> propertySelector = t => t.StringProperty;

            Assert.ThrowsException<ArgumentException>(() => propertySelector.GetFieldInfo());
        }

        private class TestClass
        {
            public string StringProperty { get; set; }
            public string StringField;
        }
    }
}
