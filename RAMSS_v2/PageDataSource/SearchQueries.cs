﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Json;
using Windows.Storage;

namespace RAMSS_v2.PageDataSource
{
    public class SearchQueries
    {
        List<Pages> list = new List<Pages>();

        public List<Pages> getResults(string query)
        {
            return list;
        }

        public async void setResults()
        {
            list.Clear();

            if (File.Exists("PageDataSource/results.json"))
            {
                Uri dataUri = new Uri("PageDataSource/results.json");
                System.Diagnostics.Debug.WriteLine("Something happened");

                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                string jsonText = await FileIO.ReadTextAsync(file);
                JsonObject jsonObject = JsonObject.Parse(jsonText);
                JsonArray jsonArray = jsonObject["Pages"].GetArray();

                foreach (JsonValue groupValue in jsonArray)
                {
                    JsonObject groupObject = groupValue.GetObject();
                    list.Add(new Pages() { name = groupObject.GetNamedString("name") });
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nope not happening, FIX");
            }
           
        }

        public SearchQueries()
        {
            setResults();
        }

        public IEnumerable<Pages> getMatchingPages(string query)
        {
            return list
                .Where(c => c.name.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1)
                .OrderByDescending(c => c.name.StartsWith(query, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
