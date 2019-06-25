using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Inventoryservices.Models;

namespace Inventoryservices.Controller
{
    [Route("api/v1")]
    [ApiController]
    public class CompanyManagementController : ControllerAttribute
    {
        public string jsonFile = @"C:\Users\user1\Documents\visual studio 2017\Projects\JsonAddAndUpdate\user.json";

        [HttpGet]
        [Route("GetCompanyManagementInfo")]
        public string GetCompanyManagementInfo()
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);

            if (jObject != null)
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, output);
                return jObject.ToString();
            }
            return null;
        }
        [HttpPost]
        [Route("AddCompanyManagementInfo")]
        public string AddCompanyManagementInfo(CompanyDetails companyDetails)
        {
            
            var newCompanyMember = "{ 'companyid': " + companyDetails.companyId + ", 'companyname': '" + companyDetails.companyName + "'}";
            string json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            var experienceArrary = jsonObj.GetValue("experiences") as JArray;
            var newCompany = JObject.Parse(newCompanyMember);
            experienceArrary.Add(newCompany);

            jsonObj["experiences"] = experienceArrary;
            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);
            return jsonObj.ToString();
        }
        [HttpPut]
        [Route("UpdateCompanyManagementInfo")]
        public string UpdateCompanyManagementInfo(CompanyDetails companyDetails)
        {
            //CompanyDetails companyDetails = new CompanyDetails();
            string json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray experiencesArrary = (JArray)jObject["experiences"];
            JObject addressArray = (JObject)jObject["address"];
            var s1=addressArray["zipcode"];
            JToken jArray =jObject["id"];
            if ((int)jArray > 0)
            {
                
                addressArray["street"] = !string.IsNullOrEmpty(companyDetails.street) ? companyDetails.street : "";
                addressArray["city"] = !string.IsNullOrEmpty(companyDetails.city) ? companyDetails.city : "";
                addressArray["zipcode"] = !string.IsNullOrEmpty(companyDetails.zipcode) ? companyDetails.zipcode : "";
                
            }

            if (companyDetails.companyId > 0)
            {
                
                foreach (var company in experiencesArrary.Where(obj => obj["companyid"].Value<int>() == companyDetails.companyId))
                {
                    company["companyname"] = !string.IsNullOrEmpty(companyDetails.companyName) ? companyDetails.companyName : "";
                }

                jObject["experiences"] = experiencesArrary;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, output);
                return jObject.ToString();
            }

            return null;
        }
        [HttpDelete]
        [Route("DeleteCompanyManagementInfo")]
        public string DeleteCompanyManagementInfo(CompanyDetails companyDetails)
        {
                var json = File.ReadAllText(jsonFile);
                var jObject = JObject.Parse(json);
                JArray experiencesArrary = (JArray)jObject["experiences"];

                JToken empId = jObject["id"];               //assign id to empId
                JToken employeeName = jObject["name"];      //assign name to employeeName
                JToken number = jObject["phoneNumber"];     //assign phoneNumber to number
                JToken jobRole = jObject["role"];           //assign role to jobRole

            if (jObject !=null)
            {
                empId.Replace(companyDetails.id);

                employeeName.Replace(companyDetails.name);

                number.Replace(companyDetails.phoneNumber);

                jobRole.Replace(companyDetails.role);

            }

                if (companyDetails.companyId > 0)
                {
                    var companyName = string.Empty;
                    var companyToDeleted = experiencesArrary.FirstOrDefault(obj => obj["companyid"].Value<int>() == companyDetails.companyId);

                    experiencesArrary.Remove(companyToDeleted);

                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, output);
                    return jObject.ToString();

                }
            return null;
        }

    }

}
   


