using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BankApp
{
    public class SerialDeserial
    {
        public static void SerialiseData(List<Account> account)
        {
          File.WriteAllText("AccountData.json",JsonConvert.SerializeObject(account));
            
        }

        public static List<Account> DeserialiseData()
        {
            List<Account> account;
            string fileName = "AccountData.json";

            if (File.Exists(fileName)) 
            {
                string json = File.ReadAllText(fileName);
                account = JsonConvert.DeserializeObject<List<Account>>(json);
                return account;
            }
            else
            {
                File.WriteAllText("AccountData.json","[]");
                string json = File.ReadAllText(fileName);
                account = JsonConvert.DeserializeObject<List<Account>>(json);
                return account;
            }

        }
    }
}
