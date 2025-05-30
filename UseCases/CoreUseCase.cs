using System.Reflection;
using System.Xml.Serialization;

namespace UseCases;

[TestClass]
public sealed class CoreUseCase
{
	[TestMethod]
	public void GetSample()
	{		
		var serializer = new XmlSerializer(typeof(XmlClasses.Container));
		var container = (XmlClasses.Container)serializer.Deserialize(GetStream("Sample.xml")) ?? throw new Exception("Deserialization failed");

		var itemNames = container.Items.Select(i => i.Name).ToArray();
		Assert.IsTrue(itemNames.SequenceEqual(["This", "That", "Hello"]));
	}

	private static Stream GetStream(string resourceName) => Assembly.GetExecutingAssembly().GetManifestResourceStream($"UseCases.Resources.{resourceName}") ?? throw new Exception("stream not found");
}
