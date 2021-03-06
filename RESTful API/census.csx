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

/// <summary>
/// Get census of neighbourhood.
/// </summary>
/// <param name="neighbourhoodID"></param>
/// <returns></returns>
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{   try
    {

            string neighbourhoodID;

   neighbourhoodID = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "neighbourhoodID", true) == 0)
        .Value;

        string appConfiguration = ConfigurationManager.AppSettings["CLOUD_STORAGE_ENDPOINT"];

        CloudStorageAccount storageAccount =
         CloudStorageAccount.Parse(appConfiguration);

        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        CloudTable table = tableClient.GetTableReference("census");
        TableOperation retrieveOperation = TableOperation.Retrieve<Demographic2010DTO>("Denver", neighbourhoodID);
        TableResult retrievedResult = table.Execute(retrieveOperation);
        Demographic2010DTO dto = new Demographic2010DTO();

        if (retrievedResult.Result != null)
        {

            dto.AGE_0_TO_9 = ((Demographic2010DTO)retrievedResult.Result).AGE_0_TO_9;
            dto.AGE_10_TO_14 = ((Demographic2010DTO)retrievedResult.Result).AGE_10_TO_14;
            dto.AGE_10_TO_19 = ((Demographic2010DTO)retrievedResult.Result).AGE_10_TO_19;
            dto.AGE_15_TO_17 = ((Demographic2010DTO)retrievedResult.Result).AGE_15_TO_17;
            dto.AGE_18_AND_19 = ((Demographic2010DTO)retrievedResult.Result).AGE_18_AND_19;
            dto.AGE_20 = ((Demographic2010DTO)retrievedResult.Result).AGE_20;
            dto.AGE_20_TO_29 = ((Demographic2010DTO)retrievedResult.Result).AGE_20_TO_29;
            dto.AGE_21 = ((Demographic2010DTO)retrievedResult.Result).AGE_21;
            dto.AGE_22_TO_24 = ((Demographic2010DTO)retrievedResult.Result).AGE_22_TO_24;
            dto.AGE_25_TO_29 = ((Demographic2010DTO)retrievedResult.Result).AGE_25_TO_29;
            dto.AGE_30_TO_34 = ((Demographic2010DTO)retrievedResult.Result).AGE_30_TO_34;
            dto.AGE_30_TO_39 = ((Demographic2010DTO)retrievedResult.Result).AGE_30_TO_39;
            dto.AGE_35_TO_39 = ((Demographic2010DTO)retrievedResult.Result).AGE_35_TO_39;
            dto.AGE_40_TO_44 = ((Demographic2010DTO)retrievedResult.Result).AGE_40_TO_44;
            dto.AGE_40_TO_49 = ((Demographic2010DTO)retrievedResult.Result).AGE_40_TO_49;
            dto.AGE_45_TO_49 = ((Demographic2010DTO)retrievedResult.Result).AGE_45_TO_49;
            dto.AGE_50_TO_54 = ((Demographic2010DTO)retrievedResult.Result).AGE_50_TO_54;
            dto.AGE_50_TO_59 = ((Demographic2010DTO)retrievedResult.Result).AGE_50_TO_59;
            dto.AGE_55_TO_59 = ((Demographic2010DTO)retrievedResult.Result).AGE_55_TO_59;
            dto.AGE_5_TO_9 = ((Demographic2010DTO)retrievedResult.Result).AGE_5_TO_9;
            dto.AGE_60_AND_61 = ((Demographic2010DTO)retrievedResult.Result).AGE_60_AND_61;
            dto.AGE_60_TO_69 = ((Demographic2010DTO)retrievedResult.Result).AGE_60_TO_69;
            dto.AGE_62_TO_64 = ((Demographic2010DTO)retrievedResult.Result).AGE_62_TO_64;
            dto.AGE_65_AND_66 = ((Demographic2010DTO)retrievedResult.Result).AGE_65_AND_66;
            dto.AGE_65_PLUS = ((Demographic2010DTO)retrievedResult.Result).AGE_65_PLUS;
            dto.AGE_67_TO_69 = ((Demographic2010DTO)retrievedResult.Result).AGE_67_TO_69;
            dto.AGE_67_TO_69 = ((Demographic2010DTO)retrievedResult.Result).AGE_67_TO_69;
            dto.AGE_70_TO_74 = ((Demographic2010DTO)retrievedResult.Result).AGE_70_TO_74;
            dto.AGE_70_TO_79 = ((Demographic2010DTO)retrievedResult.Result).AGE_70_TO_79;
            dto.AGE_75_TO_79 = ((Demographic2010DTO)retrievedResult.Result).AGE_75_TO_79;
            dto.AGE_80_PLUS = ((Demographic2010DTO)retrievedResult.Result).AGE_80_PLUS;
            dto.AGE_80_TO_84 = ((Demographic2010DTO)retrievedResult.Result).AGE_80_TO_84;
            dto.AGE_85_PLUS = ((Demographic2010DTO)retrievedResult.Result).AGE_85_PLUS;
            dto.AGE_LESS_18 = ((Demographic2010DTO)retrievedResult.Result).AGE_LESS_18;
            dto.AGE_LESS_5 = ((Demographic2010DTO)retrievedResult.Result).AGE_LESS_5;
            dto.ASIAN_2010 = ((Demographic2010DTO)retrievedResult.Result).ASIAN_2010;
            dto.BLACK_2010 = ((Demographic2010DTO)retrievedResult.Result).BLACK_2010;
            dto.FAMILIES = ((Demographic2010DTO)retrievedResult.Result).FAMILIES;
            dto.FAMILY_HHLD = ((Demographic2010DTO)retrievedResult.Result).FAMILY_HHLD;
            dto.FEMALE = ((Demographic2010DTO)retrievedResult.Result).FEMALE;
            dto.FEMALE_HHLDR_NO_CHILDR = ((Demographic2010DTO)retrievedResult.Result).FEMALE_HHLDR_NO_CHILDR;
            dto.FEMALE_HHLDR_NO_HUSB = ((Demographic2010DTO)retrievedResult.Result).FEMALE_HHLDR_NO_HUSB;
            dto.FEMALE_HHLDR_W_CHILDR = ((Demographic2010DTO)retrievedResult.Result).FEMALE_HHLDR_W_CHILDR;
            dto.GQ_COLLEGEHOUSING = ((Demographic2010DTO)retrievedResult.Result).GQ_COLLEGEHOUSING;
            dto.GQ_CORRECTIONAL_FAC = ((Demographic2010DTO)retrievedResult.Result).GQ_CORRECTIONAL_FAC;
            dto.GQ_INSTITUTIONALIZED = ((Demographic2010DTO)retrievedResult.Result).GQ_INSTITUTIONALIZED;
            dto.GQ_JUVENILE_FAC = ((Demographic2010DTO)retrievedResult.Result).GQ_JUVENILE_FAC;
            dto.GQ_MILITARYQUARTERS = ((Demographic2010DTO)retrievedResult.Result).GQ_MILITARYQUARTERS;
            dto.GQ_NONINSTITUTIONAL = ((Demographic2010DTO)retrievedResult.Result).GQ_NONINSTITUTIONAL;
            dto.GQ_NURSING_FAC = ((Demographic2010DTO)retrievedResult.Result).GQ_NURSING_FAC;
            dto.GQ_OTHER_INST_FAC = ((Demographic2010DTO)retrievedResult.Result).GQ_OTHER_INST_FAC;
            dto.GQ_OTHER_NONINST = ((Demographic2010DTO)retrievedResult.Result).GQ_OTHER_NONINST;
            dto.HAWPACIS_2010 = ((Demographic2010DTO)retrievedResult.Result).HAWPACIS_2010;
            dto.HH_NO_NONRELATIVES = ((Demographic2010DTO)retrievedResult.Result).HH_NO_NONRELATIVES;
            dto.HH_W_NONRELATIVES = ((Demographic2010DTO)retrievedResult.Result).HH_W_NONRELATIVES;
            dto.HISPANIC_2010 = ((Demographic2010DTO)retrievedResult.Result).HISPANIC_2010;
            dto.HOUSINGUNITS_2010 = ((Demographic2010DTO)retrievedResult.Result).HOUSINGUNITS_2010;
            dto.HOUSING_UNITS = ((Demographic2010DTO)retrievedResult.Result).HOUSING_UNITS;
            dto.HUSB_WIFE_FAM = ((Demographic2010DTO)retrievedResult.Result).HUSB_WIFE_FAM;
            dto.HUSB_WIFE_NO_CHILD = ((Demographic2010DTO)retrievedResult.Result).HUSB_WIFE_NO_CHILD;
            dto.HUSB_WIFE_W_CHLDR = ((Demographic2010DTO)retrievedResult.Result).HUSB_WIFE_W_CHLDR;
            dto.HU_OWNED = ((Demographic2010DTO)retrievedResult.Result).HU_OWNED;
            dto.HU_RENTED = ((Demographic2010DTO)retrievedResult.Result).HU_RENTED;
            dto.MALE = ((Demographic2010DTO)retrievedResult.Result).MALE;
            dto.MALE_HHLDR_NO_CHILDR = ((Demographic2010DTO)retrievedResult.Result).MALE_HHLDR_NO_CHILDR;
            dto.MALE_HHLDR_NO_WIFE = ((Demographic2010DTO)retrievedResult.Result).MALE_HHLDR_NO_WIFE;
            dto.MALE_HHLDR_W_CHLDR = ((Demographic2010DTO)retrievedResult.Result).MALE_HHLDR_W_CHLDR;
            dto.NATIVEAM_2010 = ((Demographic2010DTO)retrievedResult.Result).NATIVEAM_2010;
            dto.NBHD_ID = ((Demographic2010DTO)retrievedResult.Result).NBHD_ID;
            dto.NBRHD_NAME = ((Demographic2010DTO)retrievedResult.Result).NBRHD_NAME;
            dto.NEIGHBORHOOD_ID = ((Demographic2010DTO)retrievedResult.Result).NEIGHBORHOOD_ID;
            dto.NON_FAMILY_FEMALE_HHLDR = ((Demographic2010DTO)retrievedResult.Result).NON_FAMILY_FEMALE_HHLDR;
            dto.NON_FAMILY_HH = ((Demographic2010DTO)retrievedResult.Result).NON_FAMILY_HH;
            dto.NON_FAMILY_MALE_HHLDR = ((Demographic2010DTO)retrievedResult.Result).NON_FAMILY_MALE_HHLDR;
            dto.NUM_HOUSEHOLDS = ((Demographic2010DTO)retrievedResult.Result).NUM_HOUSEHOLDS;
            dto.OCCUPIEDUNITS_2010 = ((Demographic2010DTO)retrievedResult.Result).OCCUPIEDUNITS_2010;
            dto.OCCUPIED_HU = ((Demographic2010DTO)retrievedResult.Result).OCCUPIED_HU;
            dto.ONE_PERSON_HH = ((Demographic2010DTO)retrievedResult.Result).ONE_PERSON_HH;
            dto.ONE_PERSON_HH_FEMALE = ((Demographic2010DTO)retrievedResult.Result).ONE_PERSON_HH_FEMALE;
            dto.ONE_PERSON_HH_MALE = ((Demographic2010DTO)retrievedResult.Result).ONE_PERSON_HH_MALE;
            dto.OTHER_2010 = ((Demographic2010DTO)retrievedResult.Result).OTHER_2010;
            dto.OTHER_FAMILY = ((Demographic2010DTO)retrievedResult.Result).OTHER_FAMILY;
            dto.OWNED_AGE_15_TO_24 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_15_TO_24;
            dto.OWNED_AGE_25_TO_34 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_25_TO_34;
            dto.OWNED_AGE_35_TO_44 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_35_TO_44;
            dto.OWNED_AGE_45_TO_54 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_45_TO_54;
            dto.OWNED_AGE_55_TO_59 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_55_TO_59;
            dto.OWNED_AGE_60_TO_64 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_60_TO_64;
            dto.OWNED_AGE_65_TO_74 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_65_TO_74;
            dto.OWNED_AGE_75_TO_84 = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_75_TO_84;
            dto.OWNED_AGE_85_PLUS = ((Demographic2010DTO)retrievedResult.Result).OWNED_AGE_85_PLUS;
            dto.OWNED_FREE_CLEAR = ((Demographic2010DTO)retrievedResult.Result).OWNED_FREE_CLEAR;
            dto.OWNED_W_MORTG_LOAN = ((Demographic2010DTO)retrievedResult.Result).OWNED_W_MORTG_LOAN;
            dto.PCT_65_PLUS = ((Demographic2010DTO)retrievedResult.Result).PCT_65_PLUS;
            dto.PCT_AMERIND = ((Demographic2010DTO)retrievedResult.Result).PCT_AMERIND;
            dto.PCT_ASIAN = ((Demographic2010DTO)retrievedResult.Result).PCT_ASIAN;
            dto.PCT_BLACK = ((Demographic2010DTO)retrievedResult.Result).PCT_BLACK;
            dto.PCT_HAW_PACIS = ((Demographic2010DTO)retrievedResult.Result).PCT_HAW_PACIS;
            dto.PCT_HISPANIC = ((Demographic2010DTO)retrievedResult.Result).PCT_HISPANIC;
            dto.PCT_LESS_18 = ((Demographic2010DTO)retrievedResult.Result).PCT_LESS_18;
            dto.PCT_OTHER_RACE = ((Demographic2010DTO)retrievedResult.Result).PCT_OTHER_RACE;
            dto.PCT_TWO_OR_MORE_RACES = ((Demographic2010DTO)retrievedResult.Result).PCT_TWO_OR_MORE_RACES;
            dto.PCT_WHITE = ((Demographic2010DTO)retrievedResult.Result).PCT_WHITE;
            dto.POPULATION_2010 = ((Demographic2010DTO)retrievedResult.Result).POPULATION_2010;
            dto.POP_GROUP_QRTRS = ((Demographic2010DTO)retrievedResult.Result).POP_GROUP_QRTRS;
            dto.RENTED = ((Demographic2010DTO)retrievedResult.Result).RENTED;
            dto.RENTED_AGE_15_TO_24 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_15_TO_24;
            dto.RENTED_AGE_25_TO_34 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_25_TO_34;
            dto.RENTED_AGE_35_TO_44 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_35_TO_44;
            dto.RENTED_AGE_45_TO_54 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_45_TO_54;
            dto.RENTED_AGE_55_TO_59 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_55_TO_59;
            dto.RENTED_AGE_60_TO_64 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_60_TO_64;
            dto.RENTED_AGE_65_TO_74 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_65_TO_74;
            dto.RENTED_AGE_75_TO_84 = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_75_TO_84;
            dto.RENTED_AGE_85_PLUS = ((Demographic2010DTO)retrievedResult.Result).RENTED_AGE_85_PLUS;
            dto.SHAPE_Area = ((Demographic2010DTO)retrievedResult.Result).SHAPE_Area;
            dto.SHAPE_Length = ((Demographic2010DTO)retrievedResult.Result).SHAPE_Length;
            dto.TWO_OR_MORE_2010 = ((Demographic2010DTO)retrievedResult.Result).TWO_OR_MORE_2010;
            dto.TWO_OR_MORE_PERSON_HH = ((Demographic2010DTO)retrievedResult.Result).TWO_OR_MORE_PERSON_HH;
            dto.VACANTUNITS_2010 = ((Demographic2010DTO)retrievedResult.Result).VACANTUNITS_2010;
            dto.VACANT_FOR_RENT = ((Demographic2010DTO)retrievedResult.Result).VACANT_FOR_RENT;
            dto.VACANT_FOR_SALE = ((Demographic2010DTO)retrievedResult.Result).VACANT_FOR_SALE;
            dto.VACANT_HU = ((Demographic2010DTO)retrievedResult.Result).VACANT_HU;
            dto.VACANT_MIGRANT_WRKR = ((Demographic2010DTO)retrievedResult.Result).VACANT_MIGRANT_WRKR;
            dto.VACANT_OTHER = ((Demographic2010DTO)retrievedResult.Result).VACANT_OTHER;
            dto.VACANT_RENTED_NOT_OCC = ((Demographic2010DTO)retrievedResult.Result).VACANT_RENTED_NOT_OCC;
            dto.VACANT_SEASONAL = ((Demographic2010DTO)retrievedResult.Result).VACANT_SEASONAL;
            dto.VACANT_SOLD_NOT_OCC = ((Demographic2010DTO)retrievedResult.Result).VACANT_SOLD_NOT_OCC;
            dto.WHITE_2010 = ((Demographic2010DTO)retrievedResult.Result).WHITE_2010;

        }

      if (retrievedResult.Result != null)
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
        return new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent(ex.Message, Encoding.UTF8, "application/json")
        };
    }
}

public class Demographic2010DTO : TableEntity
    {
        public int AGE_0_TO_9 { get; set; }
        public int AGE_10_TO_14 { get; set; }
        public int AGE_10_TO_19 { get; set; }
        public int AGE_15_TO_17 { get; set; }
        public int AGE_18_AND_19 { get; set; }
        public int AGE_20 { get; set; }
        public int AGE_20_TO_29 { get; set; }
        public int AGE_21 { get; set; }
        public int AGE_22_TO_24 { get; set; }
        public int AGE_25_TO_29 { get; set; }
        public int AGE_30_TO_34 { get; set; }
        public int AGE_30_TO_39 { get; set; }
        public int AGE_35_TO_39 { get; set; }
        public int AGE_40_TO_44 { get; set; }
        public int AGE_40_TO_49 { get; set; }
        public int AGE_45_TO_49 { get; set; }
        public int AGE_50_TO_54 { get; set; }
        public int AGE_50_TO_59 { get; set; }
        public int AGE_55_TO_59 { get; set; }
        public int AGE_5_TO_9 { get; set; }
        public int AGE_60_AND_61 { get; set; }
        public int AGE_60_TO_69 { get; set; }
        public int AGE_62_TO_64 { get; set; }
        public int AGE_65_AND_66 { get; set; }
        public int AGE_65_PLUS { get; set; }
        public int AGE_67_TO_69 { get; set; }
        public int AGE_70_TO_74 { get; set; }
        public int AGE_70_TO_79 { get; set; }
        public int AGE_75_TO_79 { get; set; }
        public int AGE_80_PLUS { get; set; }
        public int AGE_80_TO_84 { get; set; }
        public int AGE_85_PLUS { get; set; }
        public int AGE_LESS_18 { get; set; }
        public int AGE_LESS_5 { get; set; }
        public int ASIAN_2010 { get; set; }
        public int BLACK_2010 { get; set; }
        public int FAMILIES { get; set; }
        public int FAMILY_HHLD { get; set; }
        public int FEMALE { get; set; }
        public int FEMALE_HHLDR_NO_CHILDR { get; set; }
        public int FEMALE_HHLDR_NO_HUSB { get; set; }
        public int FEMALE_HHLDR_W_CHILDR { get; set; }
        public int GQ_COLLEGEHOUSING { get; set; }
        public int GQ_CORRECTIONAL_FAC { get; set; }
        public int GQ_INSTITUTIONALIZED { get; set; }
        public int GQ_JUVENILE_FAC { get; set; }
        public int GQ_MILITARYQUARTERS { get; set; }
        public int GQ_NONINSTITUTIONAL { get; set; }
        public int GQ_NURSING_FAC { get; set; }
        public int GQ_OTHER_INST_FAC { get; set; }
        public int GQ_OTHER_NONINST { get; set; }
        public int HAWPACIS_2010 { get; set; }
        public int HH_NO_NONRELATIVES { get; set; }
        public int HH_W_NONRELATIVES { get; set; }
        public int HISPANIC_2010 { get; set; }
        public int HOUSINGUNITS_2010 { get; set; }
        public int HOUSING_UNITS { get; set; }
        public int HUSB_WIFE_FAM { get; set; }
        public int HUSB_WIFE_NO_CHILD { get; set; }
        public int HUSB_WIFE_W_CHLDR { get; set; }
        public int HU_OWNED { get; set; }
        public int HU_RENTED { get; set; }
        public int MALE { get; set; }
        public int MALE_HHLDR_NO_CHILDR { get; set; }
        public int MALE_HHLDR_NO_WIFE { get; set; }
        public int MALE_HHLDR_W_CHLDR { get; set; }
        public int NATIVEAM_2010 { get; set; }
        public string NBHD_ID { get; set; }
        public string NBRHD_NAME { get; set; }
        public string NEIGHBORHOOD_ID { get; set; }
        public int NON_FAMILY_FEMALE_HHLDR { get; set; }
        public int NON_FAMILY_HH { get; set; }
        public int NON_FAMILY_MALE_HHLDR { get; set; }
        public int NUM_HOUSEHOLDS { get; set; }
        public int OCCUPIEDUNITS_2010 { get; set; }
        public int OCCUPIED_HU { get; set; }
        public int ONE_PERSON_HH { get; set; }
        public int ONE_PERSON_HH_FEMALE { get; set; }
        public int ONE_PERSON_HH_MALE { get; set; }
        public int OTHER_2010 { get; set; }
        public int OTHER_FAMILY { get; set; }
        public int OWNED_AGE_15_TO_24 { get; set; }
        public int OWNED_AGE_25_TO_34 { get; set; }
        public int OWNED_AGE_35_TO_44 { get; set; }
        public int OWNED_AGE_45_TO_54 { get; set; }
        public int OWNED_AGE_55_TO_59 { get; set; }
        public int OWNED_AGE_60_TO_64 { get; set; }
        public int OWNED_AGE_65_TO_74 { get; set; }
        public int OWNED_AGE_75_TO_84 { get; set; }
        public int OWNED_AGE_85_PLUS { get; set; }
        public int OWNED_FREE_CLEAR { get; set; }
        public int OWNED_W_MORTG_LOAN { get; set; }
        public double PCT_65_PLUS { get; set; }
        public double PCT_AMERIND { get; set; }
        public double PCT_ASIAN { get; set; }
        public double PCT_BLACK { get; set; }
        public double PCT_HAW_PACIS { get; set; }
        public double PCT_HISPANIC { get; set; }
        public double PCT_LESS_18 { get; set; }
        public double PCT_OTHER_RACE { get; set; }
        public double PCT_TWO_OR_MORE_RACES { get; set; }
        public double PCT_WHITE { get; set; }
        public int POPULATION_2010 { get; set; }
        public int POP_GROUP_QRTRS { get; set; }
        public int RENTED { get; set; }
        public int RENTED_AGE_15_TO_24 { get; set; }
        public int RENTED_AGE_25_TO_34 { get; set; }
        public int RENTED_AGE_35_TO_44 { get; set; }
        public int RENTED_AGE_45_TO_54 { get; set; }
        public int RENTED_AGE_55_TO_59 { get; set; }
        public int RENTED_AGE_60_TO_64 { get; set; }
        public int RENTED_AGE_65_TO_74 { get; set; }
        public int RENTED_AGE_75_TO_84 { get; set; }
        public int RENTED_AGE_85_PLUS { get; set; }
        public double SHAPE_Area { get; set; }
        public double SHAPE_Length { get; set; }
        public int TWO_OR_MORE_2010 { get; set; }
        public int TWO_OR_MORE_PERSON_HH { get; set; }
        public int VACANTUNITS_2010 { get; set; }
        public int VACANT_FOR_RENT { get; set; }
        public int VACANT_FOR_SALE { get; set; }
        public int VACANT_HU { get; set; }
        public int VACANT_MIGRANT_WRKR { get; set; }
        public int VACANT_OTHER { get; set; }
        public int VACANT_RENTED_NOT_OCC { get; set; }
        public int VACANT_SEASONAL { get; set; }
        public int VACANT_SOLD_NOT_OCC { get; set; }
        public int WHITE_2010 { get; set; }
    }
