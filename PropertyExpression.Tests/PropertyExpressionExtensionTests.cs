using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace PropertyExpression.Tests
{
    [TestClass]
    public class PropertyExpressionExtensionTests
    {
        [TestMethod]
        public void GetPropertyInfoShouldReturnAPropertyInfo()
        {
            Expression<Func<TestClass, object>> propertySelector = t => t.StringProperty;
            var propertyInfo = propertySelector.GetPropertyInfo();

            Assert.IsNotNull(propertyInfo);
        }

        [TestMethod]
        public void GetPropertyInfoShouldGetCorrectPropertyInfoForProperty()
        {
            Expression<Func<TestClass, object>> propertySelector = t => t.StringProperty;
            var propertyInfo = propertySelector.GetPropertyInfo();

            const string testStringValue = "Hello, world!";
            var testClassInstance = new TestClass() { StringProperty = testStringValue, StringField = "Other value" };

            Assert.AreEqual(testStringValue, (string)propertyInfo.GetValue(testClassInstance));
        }

        [TestMethod]
        public void GetPropertyInfoShouldThrowIfRetrievingField()
        {
            Expression<Func<TestClass, object>> fieldSelector = t => t.StringField;

            Assert.ThrowsException<ArgumentException>(() => fieldSelector.GetPropertyInfo());
        }

        private class TestClass
        {
            public string StringProperty { get; set; }
            public string StringField;
        }
    }
}
