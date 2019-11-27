using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Rkna_Project
{
    
    public class ReportBiningata
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();


        public DataTable GetCompanyInf()
        {
            return ToDataTable.LINQResultToDataTable(db.Company_Table.ToList());
        }

        public DataTable GetArea()
        {
            return ToDataTable.LINQResultToDataTable((from Are in db.Area_Table
                     join user in db.AspNetUsers
                     on Are.Area_Manger equals user.Id
                     join stat in db.States_Table
                     on Are.States_ID equals stat.States_ID
                     join gov in db.Governorate_Table
                     on stat.Gov_ID equals gov.Gov_ID 
                     select new { gov.Gov_Name,stat.States_Name,user.UserName,Are.Area_Desc,Are.Area_Name,Are.Area_Start_Time,Are.Area_End_Time
                     ,Are.Area_Hour_Rate} ).ToList());
            //return ToDataTable.LINQResultToDataTable(db.Area_Table.ToList());

           
        }

        public DataTable GetCars(string User_ID)
        {
            return ToDataTable.LINQResultToDataTable(db.Car_Specifications_Table.Where(car=>car.Car_Owner_ID==User_ID).ToList());
        }
        public DataTable GetCu_Slot(string User_ID)
        {
            return ToDataTable.LINQResultToDataTable(
                (from cu_sl in db.Customer_Slut_Table
                 join Slot in db.Slut_Table
                 on cu_sl.Slut_ID equals Slot.Slut_ID
                 join car in db.Car_Specifications_Table
                 on cu_sl.Car_Spe_ID equals car.Car_Spe_ID
                 join user in db.AspNetUsers
                 on cu_sl.Customer_ID equals user.Id
                 where user.Id == User_ID
                 select new { car.Care_Model, car.Car_plate_Number, cu_sl.Cus_Slut_Date, cu_sl.Cus_Slut_S_Time, cu_sl.Cus_Slut_E_Time, Slot.Name, Slot.Slut_Level }).ToList());
        }
        public DataTable Get_Cust(string User_ID)
        {
            return ToDataTable.LINQResultToDataTable(db.AspNetUsers.Where(use=>use.Id==User_ID).ToList());
        }

    }
}