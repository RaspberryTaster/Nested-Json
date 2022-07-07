using System;
using System.Collections.Generic;
using System.IO;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nested_Json
{
	class Program
	{
		private static string _path = "C:/Users/Anon/source/repos/Nested Json/Nested Json/TestJson.json";
		static void Main(string[] args)
		{
			//https://stackoverflow.com/questions/6935343/deserialize-json-arrayor-list-in-c-sharp
			dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText(_path));

			List<TestClass> testClasses = new List<TestClass>();
			for(int i = 0; i < jsonfile.results.Count; i++)
			{
				//TestClass item = new TestClass(jsonfile.results[i]);
				//testClasses.Add(item);
				string jsonString = Convert.ToString(jsonfile.results[i]);
				TestClass item = JsonConvert.DeserializeObject<TestClass>(jsonString);
				Console.WriteLine(item.name);

			}

			//JObject jsonResults = JsonConvert.SerializeObject(jsonfile);
			//Console.WriteLine(jsonResults);
			/*
			List<TestClass> people = System.Text.Json.JsonSerializer.Deserialize<List<TestClass>>(jsonResults.ToString());
			foreach(var person in people)
			{
				Console.WriteLine(person.name);
			}
			*/

		}
	}

	public class TestClass
	{
		public string name { get; set; }
	}

}
