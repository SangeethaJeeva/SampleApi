using Inventoryservices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inventoryservices.Services
{
    public class Inventoryservices : IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;

        public Inventoryservices()
        {
            _inventoryItems = new Dictionary<string, InventoryItems>();
        }
        public InventoryItems AddInventoryItems(InventoryItems items)
        {
            _inventoryItems.Add(items.ItemName, items);
            return items;
        }

        public string GetInventoryItems()
        {
            var s1 = _inventoryItems.Count();
            using (StreamReader r = new StreamReader("samplejson.json"))
            {

                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<Object>(json);
                return items.ToString();
                //foreach (var item in items)
                //{
                //    // Console.WriteLine("{0} {1}", item.temp, item.vcc);
                //}
            }

            //throw new NotImplementedException();
        }

        public string PutInventoryItems()
        {
            //using (StreamReader r = new StreamReader("samplejson.json"))
            
                // Grab the JSON response as a string
                //string rawJson = r.ReadToEnd();

                // Parse the string into a JObject
                //var json = (dynamic)JObject.Parse(rawJson) as object;

                string jsonString = File.ReadAllText("samplejson.json");
                JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;

                // Select a nested property using a single string:
                 JToken jToken = jObject.SelectToken("language");
                 jToken.Replace("language");

                string UpdatedJsonString = jsonString.ToString();
                File.WriteAllText("samplejson.json", UpdatedJsonString);
                return UpdatedJsonString;

                // var book = (dynamic)json.GetValue("book");


                // var items = JsonConvert.DeserializeObject<List<InventoryItems>>(json.ToString());
                /* foreach (var item in items)
                 {
                     var s2 = item.Language;
                 }*/

                // var book = json.GetValue("book");
                //var s1 = book.Children();



                //char[] result = rawJson.ToArray();
                //string[] res = { "c", "c++" };

                // Get the JToken representing the ASP.NET "book" parameter
                /* var book = json.GetValue("book");
                 string match = result.find(book, b => b.Contains("c++"));
                 book.Replace("Python");*/
                //String[] value = Array.FindAll(myArr,  
                //element => element.StartsWith("S",
                //StringComparison.Ordinal));
                //return null;

            
        }
    }
}