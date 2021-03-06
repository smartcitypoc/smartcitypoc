#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{   try
    {

        string startDate;
        string endDate;
        string neighbourhoodID;
        string[] dateFormats = {"yyyy-MM-dd"};

        neighbourhoodID = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "neighbourhoodID", true) == 0)
        .Value;
          startDate = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "startDate", true) == 0)
        .Value;
          endDate = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "endDate", true) == 0)
        .Value;

        DateTime startDateTime;

        if(DateTime.TryParseExact(startDate, dateFormats, CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out startDateTime)){
                               log.Info("Start Date: " + startDateTime);
                          }
        else {
            log.Info("Start Date: " + startDateTime);
            return new HttpResponseMessage(HttpStatusCode.OK)
             {
                 Content = new StringContent(JsonConvert.SerializeObject("Invalid Date Format it should be in yyyy-MM-dd format"), Encoding.UTF8, "application/json")
             };
        }


         DateTime endDateTime;

        if(DateTime.TryParseExact(endDate, dateFormats, CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out endDateTime)){
                              log.Info("Start Date: " + endDateTime);
                          }
        else {
            log.Info("End Date: " + endDateTime);
            return new HttpResponseMessage(HttpStatusCode.OK)
             {
                 Content = new StringContent(JsonConvert.SerializeObject("Invalid Date Format it should be in yyyy-MM-dd format"), Encoding.UTF8, "application/json")
             };
        }

		 if((endDateTime - startDateTime).TotalDays >= 7)
         {
             endDateTime = startDateTime.AddDays(6);
         }

         startDate = startDateTime.ToString("yyyy-MM-dd") + "T00:00:00Z";
         endDate = endDateTime.ToString("yyyy-MM-dd") + "T00:00:00Z";


      string appConfiguration = ConfigurationManager.AppSettings["CLOUD_STORAGE_ENDPOINT"];

        CloudStorageAccount storageAccount =
         CloudStorageAccount.Parse(appConfiguration);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("crimedata");
            string filter = string.Empty;
            if (!string.IsNullOrEmpty(neighbourhoodID))
            {
                filter = "(PartitionKey  eq '" + neighbourhoodID + "') and (REPORTED_DATE ge datetime'" + startDate + "' and REPORTED_DATE le datetime'" + endDate + "') ";
            }
            else
            {

                filter = "(REPORTED_DATE ge datetime'" + startDate + "' and REPORTED_DATE lt datetime'" + endDate + "')";
            }
            TableQuery<CrimeDTO> query = new TableQuery<CrimeDTO>().Where(filter);
            log.Info("FILTER: " + filter);
            List<CrimeDTO> dto = new List<CrimeDTO>();

            foreach (CrimeDTO entity in table.ExecuteQuery(query))
            {
                CrimeDTO item = new CrimeDTO();
                item.DISTRICT_ID = entity.DISTRICT_ID;
                item.FIRST_OCCURRENCE_DATE = entity.FIRST_OCCURRENCE_DATE;
                item.GEO_LAT = entity.GEO_LAT;
                item.GEO_LON = entity.GEO_LON;
                item.GEO_X = entity.GEO_X;
                item.GEO_Y = entity.GEO_Y;
                item.INCIDENT_ADDRESS = entity.INCIDENT_ADDRESS;
                item.INCIDENT_ID = entity.INCIDENT_ID;
                item.IS_CRIME = entity.IS_CRIME;
                item.IS_TRAFFIC = entity.IS_TRAFFIC;
                item.LAST_OCCURRENCE_DATE = entity.LAST_OCCURRENCE_DATE;
                item.NEIGHBORHOOD_ID = entity.NEIGHBORHOOD_ID;
                item.OFFENSE_CATEGORY_ID = entity.OFFENSE_CATEGORY_ID;
                item.OFFENSE_CODE = entity.OFFENSE_CODE;
                item.OFFENSE_CODE_EXTENSION = entity.OFFENSE_CODE_EXTENSION;
                item.OFFENSE_ID = entity.OFFENSE_ID;
                item.OFFENSE_TYPE_ID = entity.OFFENSE_TYPE_ID;
                item.PRECINCT_ID = entity.PRECINCT_ID;
                item.REPORTED_DATE = entity.REPORTED_DATE;
                dto.Add(item);
            }


        if (dto != null && dto.Count > 0)
        {
            var jsonToReturn = JsonConvert.SerializeObject(dto);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
        else
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject("No Data Available"), Encoding.UTF8, "application/json")
            };
        }
    }
    catch (Exception ex)
    {
		if (ex.HResult == -2146233033)
         {
             return new HttpResponseMessage(HttpStatusCode.OK)
             {
                 Content = new StringContent(JsonConvert.SerializeObject("Invalid Date Format it should be in yyyy-MM-dd format"), Encoding.UTF8, "application/json")
             };
         }
         else
         {
             return new HttpResponseMessage(HttpStatusCode.InternalServerError)
             {
                 Content = new StringContent(ex.Message, Encoding.UTF8, "application/json")
             };
         }
    }
}



 public class CrimeDTO : TableEntity
    {
        public int DISTRICT_ID { get; set; }
        public DateTime FIRST_OCCURRENCE_DATE { get; set; }
        public double GEO_LAT { get; set; }
        public double GEO_LON { get; set; }
        public int GEO_X { get; set; }
        public int GEO_Y { get; set; }
        public string INCIDENT_ADDRESS { get; set; }
        public int INCIDENT_ID { get; set; }
        public int IS_CRIME { get; set; }
        public int IS_TRAFFIC { get; set; }
        public DateTime LAST_OCCURRENCE_DATE { get; set; }
        public string NEIGHBORHOOD_ID { get; set; }
        public string OFFENSE_CATEGORY_ID { get; set; }
        public int OFFENSE_CODE { get; set; }
        public int OFFENSE_CODE_EXTENSION { get; set; }
        public int OFFENSE_ID { get; set; }
        public string OFFENSE_TYPE_ID { get; set; }
        public int PRECINCT_ID { get; set; }
        public DateTime REPORTED_DATE { get; set; }
    }
