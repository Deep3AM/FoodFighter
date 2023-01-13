using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_DateTime : ES3Type
	{
		public static ES3Type Instance = null;

		public ES3UserType_DateTime() : base(typeof(System.DateTime)){ Instance = this; priority = 1;}


		public override void Write(object obj, ES3Writer writer)
		{
			var instance = (System.DateTime)obj;
			
		}

		public override object Read<T>(ES3Reader reader)
		{
			var instance = new System.DateTime();
			string propertyName;
			while((propertyName = reader.ReadPropertyName()) != null)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
			return instance;
		}
	}


	public class ES3UserType_DateTimeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DateTimeArray() : base(typeof(System.DateTime[]), ES3UserType_DateTime.Instance)
		{
			Instance = this;
		}
	}
}