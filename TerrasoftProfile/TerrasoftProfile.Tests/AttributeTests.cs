using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TerrasoftProfile.Tests
{
	using FluentAssertions;

	[TestClass]
	public class AttributeTests
	{

		[TestMethod]
		public void AttributeTest() {
			var c = new MyCustomClassWithAttribute();
			var attribute = MyCustomAttributeHelper.GetAttributeObject<MyCustomAttribute>(c.GetType());
			attribute.Should().NotBeNull();
			attribute.Description.ShouldBeEquivalentTo("AttributeName");
		}

		[TestMethod]
		public void MyCustomAttribute_ctor() {
			var controlValue = "controlValue";
			var mca =new MyCustomAttribute(controlValue);
			mca.Description.ShouldBeEquivalentTo(controlValue);
		}

		[TestMethod]
		public void MyCustomAttribute_ctor_null() {
			var mca = new MyCustomAttribute(null);
			mca.Description.ShouldBeEquivalentTo(null);
		}

		[TestMethod]
		public void MyCustomAttributeHelper_GetAttributeObject_ShouldBeNotNull() {
			var attribureObject = MyCustomAttributeHelper.GetAttributeObject<MyCustomAttribute>(typeof(MyCustomClassWithAttribute));
			attribureObject.Should().NotBeNull();
		}

		[TestMethod]
		public void MyCustomAttributeHelper_GetAttributeObject_ShouldBeNotNull_Interface() {
			var attribureObject = MyCustomAttributeHelper.GetAttributeObject<MyCustomAttribute>(typeof(IMyCustomInterfaceWithAttribute));
			attribureObject.Should().NotBeNull();
		}

		[TestMethod]
		public void MyCustomAttributeHelper_GetAttributeObject_ShouldBeNull() {
			var attribureObject = MyCustomAttributeHelper.GetAttributeObject<MyCustomAttribute>(typeof(MyCustomClassWithoutAttribute));
			attribureObject.Should().BeNull();
		}

	}
}
