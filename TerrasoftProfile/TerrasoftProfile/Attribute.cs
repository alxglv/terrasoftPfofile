namespace TerrasoftProfile
{
	using System;

	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface)]
	public class MyCustomAttribute : Attribute
	{
		#region Constructors: Public

		public MyCustomAttribute(string description) {
			Description = description;
		}

		#endregion

		#region Properties: Public

		public string Description { get; set; }

		#endregion
	}

	public static class MyCustomAttributeHelper
	{
		public static T GetAttributeObject<T>(Type objectType) where T : class {
			var attribute = Attribute.GetCustomAttribute(objectType, typeof(T)) as T;
			return attribute;
		}
	}


	[MyCustom("AttributeName")]
	public class MyCustomClassWithAttribute
	{

	}

	[MyCustom("AttributeName")]
	public interface IMyCustomInterfaceWithAttribute
	{

	}

	public class MyCustomClassWithoutAttribute
	{

	}

}