using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XmlClasses;

public class Container : IXmlSerializable
{
	public Item[] Items { get; set; } = [];

	public XmlSchema? GetSchema() => null;

	public void ReadXml(XmlReader reader)
	{
		var items = new List<Item>();
		
		// Skip to the start element if we're not already there
		if (reader.NodeType == XmlNodeType.None)
			reader.Read();
		
		// Skip the Container element start tag
		reader.ReadStartElement();
		
		// Read Item elements
		while (reader.NodeType == XmlNodeType.Element && reader.LocalName == "Item")
		{
			var item = new Item
			{
				Name = reader.GetAttribute("Name") ?? string.Empty,
				Description = reader.GetAttribute("Description") ?? string.Empty
			};
			items.Add(item);
			
			// Skip the empty Item element
			reader.Read();
		}
		
		// Skip the Container end element
		reader.ReadEndElement();
		
		Items = items.ToArray();
	}

	public void WriteXml(XmlWriter writer)
	{
		foreach (var item in Items)
		{
			writer.WriteStartElement("Item");
			writer.WriteAttributeString("Name", item.Name);
			writer.WriteAttributeString("Description", item.Description);
			writer.WriteEndElement();
		}
	}
}
