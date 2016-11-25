using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Uri dataUri = new Uri("ms-appx:///DataSource/results.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArry = jsonObject["Pages"].GetArray();
            // resume on line 20. of http://www.c-sharpcorner.com/uploadfile/iersoy/autosuggestbox-control-in-universal-apps/
        }
    }
}
