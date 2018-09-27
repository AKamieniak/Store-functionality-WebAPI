using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCore.Repository
{
    public abstract class StoredProcedures
    {
        //---procedures from SQL database---

        //---employees repository---
        public static string GetEmployeesByShopId = "dbo.GetEmployeeByShopId";
        public static string AddEmployee = "dbo.AddEmployee";
        public static string DeleteEmployee = "dbo.DeleteEmployee";
        public static string GetLastIndexOfEmployee = "dbo.GetLastIndexOfEmployee";
        public static string GetEmployeesByPositionId = "dbo.GetEmployeeByPositionId";

        //---positions repository---
        public static string GetPositionsAll = "dbo.GetPositionsAll";
        public static string AddPosition = "dbo.AddPosition";
        public static string DeletePosition = "dbo.DeletePosition";
        public static string GetLastIndexOfPosition = "dbo.GetLastIndexOfPosition";

        //---shops repository---
        public static string GetShopsAll = "dbo.GetShopsAll";
        public static string AddShop = "dbo.AddPShop";
        public static string DeleteShop = "dbo.DeleteShop";
        public static string GetLastIndexOfShop = "dbo.GetLastIndexOfShop";
        public static string GetShopsByCity = "dbo.GetShopsByCity";
    }
}
