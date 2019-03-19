using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirdea_Denis_Alexandru_3133A
{
    class Property
    {
        #region Variables

        private string country;
        private string streetName;
        private string streetNumber;
        private string propertyType;
        private string propertyCost;
        private string propertyMeters;
        private string tvCable;
        private string pool;
        private string garden;
        private string electricity;
        private string fireplace;
        private string washer;
        private string wiFi;
        private string emptySpace;
        private string cityName;
        private int row = 0;
        #endregion

        SQLMenuOracle sqlMenu = new SQLMenuOracle();
        AddProperty addProperty = new AddProperty();

        public Property(string country, string streetName, string streetNumber, string propertyType, string propertyCost, string propertyMeters, string tvCable, string pool, string garden, string electricity, string fireplace, string washer, string wiFi, string emptySpace, string cityName)
        {
            this.country = country;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.propertyType = propertyType;
            this.propertyCost = propertyCost;
            this.propertyMeters = propertyMeters;
            this.tvCable = tvCable;
            this.pool = pool;
            this.garden = garden;
            this.electricity = electricity;
            this.fireplace = fireplace;
            this.washer = washer;
            this.wiFi = wiFi;
            this.emptySpace = emptySpace;
            this.cityName = cityName;
            row = sqlMenu.CountryRows() - 1;
            //AddClient();

        }

        public String AddLocation()
        {
            return $"INSERT INTO P_LOCATION (location_id, country_name,city_name, location_info) VALUES('{row}','{country}','{cityName}','{row}')";
        }

        public String AddCountry()
        {
            return $"INSERT INTO country_id (country_id, street_name, street_number) VALUES('{row}','{streetName}' ,'{streetNumber}')";

        }

        public String AddFacility()
        {
            return $"INSERT INTO P_FACILITY (facility_id, tv_cable, pool, garden,electricity,fireplace,washer,wi_fi,empty_space) VALUES('{row}','{tvCable}' ,'{pool}','{garden}','{electricity}','{fireplace}','{washer}','{wiFi}','{emptySpace}')";
        }

        public String AddType()
        {
            return $"INSERT INTO p_type (type_id, type_name, prop_cost, prop_meters) VALUES('{row}','{propertyType}' ,'{propertyCost}','{propertyMeters}')";
        }

        public String AddProperty()
        {
            return $"INSERT INTO property_info (prop_id, prop_location, prop_type, prop_facility, prop_status) VALUES('{row}','{row}' ,'{row}','{row}','{row}')";
        }

        public String UpdateProperty()
        {
            return  $"UPDATE country_id SET street_name = '{streetName}', street_number = '{streetNumber}' where street_number = '{streetNumber}' and country_id = P_LOCATION.location_info";
            //command += $"UPDATE P_LOCATION set country_name = '{country}'"
         
            //; UPDATE P_LOCATION set country_name = '{country}'; UPDATE P_FACILITY set tv_cable ='{tvCable}', pool='{pool}', garden='{garden}',electricity='{electricity}',fireplace='{fireplace}',washer='{washer}',wi_fi='{wiFi}',empty_space='{emptySpace}'; UPDATE p_type SET type_name='{propertyType}', prop_cost='{propertyCost}', prop_meters='{propertyMeters}' where street_number='{streetNumber}'";
        }

        public String AddStatus()
        {
            return $"INSERT INTO p_status (status_id, status_rent) VALUES('{row}','Avaible')";
        }
        public void DeleteProperty()
        {
            DataBaseConnection.InsertIntoDataBase($"Delete from country_id where country_id = '{country}'");
            DataBaseConnection.InsertIntoDataBase($"Delete from p_facility where facility_id = '{country}'");
            DataBaseConnection.InsertIntoDataBase($"Delete from p_type where type_id = '{country}'");
            DataBaseConnection.InsertIntoDataBase($"Delete from p_status where status_id = '{country}'");
            DataBaseConnection.InsertIntoDataBase($"Delete from p_location where location_id = '{country}'");
        }
    }
}
