﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareData;
using ENETCareModels;

namespace ENETCareBusinessLogic
{
    public class ClientManager
    {
        ClientGateway aClientGateway = new ClientGateway();
         
        public string AddNewClient(string clientName, string address, int districtID)
        {
            string message = "Client creation is unsuccessful.";

            //USer existance check
            if(IsUserNameExist(clientName))
                return message + "\n" + "This user already exists";

            // username password validity check
            string IsValidName = ValidateUserInput(clientName,"client name");
            string IsValidLocation = ValidateUserInput(address, "Location");
            if ((IsValidName.Equals("ValidInput")) && (IsValidLocation.Equals("ValidInput")))
            {
                int result = aClientGateway.AddNewClient(clientName, address, districtID);
                if (result > 0)
                {
                    message = "Client creation is successful.";
                }
                return message;
            }
            if (!(IsValidName.Equals("ValidInput")))
                return message + "\n" + IsValidName;
            else return message + "\n" + IsValidLocation;
        }

        // Check client name and client address
        public string ValidateUserInput(string input, string inputType)
        {
            //check Input is not integer
            if (input.Equals(""))
                return "Please insert " + inputType + ". " + inputType + " can not be blank.";
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z'. ]{1,50}$")))
                return "Invalid " + inputType + ". " + inputType + " only contains letters and has to be between 1 to 50 letters.";
             
            return "ValidInput";
        }

        public List<Client> GetClientListByDistrict(int districtID)
        {
            List<Client> aClientList = aClientGateway.GetClientListByDistrict(districtID);
            return aClientList;
        }

        public List<Client> GetClientList()
        {
            List<Client> aClientList = aClientGateway.GetClientList();
            return aClientList;
        }

        //public string GetClientNameByID(int clientID)
        //{
        //    return aClientGateway.GetClientNameByClientID(clientID);
        //}

        public bool IsUserNameExist(string clientName)
        {
            return aClientGateway.IsUserNameExist(clientName);
        }

        public string GetClientNameByClientID(int clientID)
        {
            return aClientGateway.GetClientNameByClientID(clientID);
        }
    }
}
