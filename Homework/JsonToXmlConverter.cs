using System;
using System.Text.Json;
using System.Xml;

namespace Homework;

public class JsonToXmlConverter {
    public string ConvertJsonToXml(string json) {
        using JsonDocument document = JsonDocument.Parse(json);
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        ProcessJsonElement(rootElement, document.RootElement);

        return xmlDoc.OuterXml;
    }

    private void ProcessJsonElement(XmlElement parentElement, JsonElement jsonElement) {
        switch (jsonElement.ValueKind) {
            case JsonValueKind.Object:
                foreach (JsonProperty property in jsonElement.EnumerateObject()) {
                    XmlElement childElement = parentElement.OwnerDocument.CreateElement(property.Name);
                    parentElement.AppendChild(childElement);
                    ProcessJsonElement(childElement, property.Value);
                }

                break;

            case JsonValueKind.Array:
                int index = 0;
                foreach (JsonElement element in jsonElement.EnumerateArray()) {
                    XmlElement childElement = parentElement.OwnerDocument.CreateElement("item" + index);
                    parentElement.AppendChild(childElement);
                    ProcessJsonElement(childElement, element);
                    index++;
                }

                break;

            case JsonValueKind.String:
                parentElement.InnerText = jsonElement.GetString();
                break;

            case JsonValueKind.Number:
                parentElement.InnerText = jsonElement.GetRawText();
                break;

            case JsonValueKind.True:
                parentElement.InnerText = "true";
                break;

            case JsonValueKind.False:
                parentElement.InnerText = "false";
                break;

            case JsonValueKind.Null:
                parentElement.InnerText = "null";
                break;
        }
    }
}