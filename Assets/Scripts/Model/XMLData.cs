using Assets.Scripts.Interfaces;
using System;
using System.IO;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Model
{
	public sealed class XMLData : IData<SavedData>
	{
		public void Save(SavedData player, string path = "")
		{
			var xmlDoc = new XmlDocument();

			XmlNode rootNode = xmlDoc.CreateElement("Player");
			xmlDoc.AppendChild(rootNode);

			var element = xmlDoc.CreateElement("Name");
			element.SetAttribute("value", player.Name);
			rootNode.AppendChild(element);

			element = xmlDoc.CreateElement("PosX");
			element.SetAttribute("value", player.Position.X.ToString());
			rootNode.AppendChild(element);

			element = xmlDoc.CreateElement("PosY");
			element.SetAttribute("value", player.Position.Y.ToString());
			rootNode.AppendChild(element);

			element = xmlDoc.CreateElement("PosZ");
			element.SetAttribute("value", player.Position.Z.ToString());
			rootNode.AppendChild(element);

			element = xmlDoc.CreateElement("IsEnable");
			element.SetAttribute("value", player.IsEnabled.ToString());
			rootNode.AppendChild(element);

			XmlNode userNode = xmlDoc.CreateElement("Info");
			var attribute = xmlDoc.CreateAttribute("Unity");
			attribute.Value = Application.unityVersion;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = "System Language: " +
					Application.systemLanguage;

			rootNode.AppendChild(userNode);

			xmlDoc.Save(path);
		}

		public SavedData Load(string path = "")
		{
			var result = new SavedData();
			if (!File.Exists(path)) return result;
			using (var reader = new XmlTextReader(path))
			{
				while (reader.Read())
				{
					var key = "Name";
					if(reader.IsStartElement(key))
					{
						result.Name = reader.GetAttribute("value");
					}
					key = "PosX";
					if (reader.IsStartElement(key))
					{
						result.Position.X = Single.Parse(reader.GetAttribute("value"));
					}
					key = "PosY";
					if (reader.IsStartElement(key))
					{
						result.Position.Y = Single.Parse(reader.GetAttribute("value"));
					}
					key = "PosZ";
					if (reader.IsStartElement(key))
					{
						result.Position.Z = Single.Parse(reader.GetAttribute("value"));
					}
					key = "IsEnable";
					if (reader.IsStartElement(key))
					{
						result.IsEnabled = bool.Parse(reader.GetAttribute("value"));
					}
				}
			}
			return result;
		}
	}
}
