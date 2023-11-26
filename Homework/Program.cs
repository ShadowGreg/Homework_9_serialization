// See https://aka.ms/new-console-template for more information

using Homework;

const string url = "https://my-json-server.typicode.com/ShadowGreg/JsonReqest/db";
Console.WriteLine("App starting ...");
Console.WriteLine("Send Get request: " + url);



JsonRequest request = new JsonRequest(url);
string json = await request.GetJsonAsync();

Console.WriteLine("Get Json: " + json);

JsonToXmlConverter converter = new JsonToXmlConverter();
string xml = converter.ConvertJsonToXml(json);

Console.WriteLine("Xml: " + xml);
