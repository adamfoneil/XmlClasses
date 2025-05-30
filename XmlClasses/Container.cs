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
		throw new NotImplementedException();
	}

	public void WriteXml(XmlWriter writer)
	{
		throw new NotImplementedException();
	}
}
