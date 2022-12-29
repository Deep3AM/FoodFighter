using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("width", "height", "nodes")]
	public class ES3UserType_SavableMapData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SavableMapData() : base(typeof(SavableMapData)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (SavableMapData)obj;
			
			writer.WriteProperty("width", instance.width, ES3Type_int.Instance);
			writer.WriteProperty("height", instance.height, ES3Type_int.Instance);
			writer.WriteProperty("nodes", instance.nodes, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<EssentialNodeData>)));
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (SavableMapData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "width":
						instance.width = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "height":
						instance.height = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "nodes":
						instance.nodes = reader.Read<System.Collections.Generic.List<EssentialNodeData>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new SavableMapData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_SavableMapDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SavableMapDataArray() : base(typeof(SavableMapData[]), ES3UserType_SavableMapData.Instance)
		{
			Instance = this;
		}
	}
}