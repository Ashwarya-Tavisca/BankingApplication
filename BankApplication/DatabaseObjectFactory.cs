using System;
using DatabaseConnectivity;
using System.Configuration; 

namespace BankApplication
{
    public class DatabaseObjectFactory
    {
        internal static IDbInterface GetConnectivityObject()
        {
            string databaseConnectivityType = ConfigurationManager.AppSettings[Constants.DatabaseConnectivityType].ToString();
            IDbInterface dbInterface;
            switch(databaseConnectivityType.ToUpper())
            {
                case "ENTITYFRAMEWORK":
                    dbInterface = new Entity();
                    break;

                case "ADO":
                    dbInterface = new DatabaseConnect();
                    break;

                default:
                    dbInterface = new Entity();
                    break;
            }
            return dbInterface;
        }
    }
}