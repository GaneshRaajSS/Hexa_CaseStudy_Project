using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Exceptions;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    public class VehicleRepo : IVehicleRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public VehicleRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }

        public List<Vehicles> GetAllVehicles()
        {
            List<Vehicles> vehicles = new List<Vehicles>();
            cmd.Connection.Open();
            cmd.CommandText = "Select * from Vehicles";

                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicles vehicle = new Vehicles();
                    vehicle.VehicleId = (int)reader["VehicleID"];
                    vehicle.VehicleModel = (string)reader["Model"];
                    vehicle.Capacity = (decimal)reader["Capacity"];
                    vehicle.VehicleType = (string)reader["Type"];
                    vehicle.Status = (string)reader["Status"];

                    vehicles.Add(vehicle);
                }
            cmd.Connection.Close();
            return vehicles;
        }
        public List<Vehicles> GetAllAvailableVehicles()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            cmd.CommandText = "Select * from Vehicles where Status = 'Available'";
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicles vehicle = new Vehicles();
                vehicle.VehicleId = (int)reader["VehicleID"];
                vehicle.VehicleModel = (string)reader["Model"];
                vehicle.Capacity = (decimal)reader["Capacity"];
                vehicle.VehicleType = (string)reader["Type"];
                vehicle.Status = (string)reader["Status"];
                vehicles.Add(vehicle);
            }
            cmd.Connection.Close();
            return vehicles;
        }
        public bool AddVehicle(Vehicles vehicles)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Insert into Vehicles values(@Model,@Capacity,@Type,@Status)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Model", vehicles.VehicleModel);
                cmd.Parameters.AddWithValue("@Capacity", vehicles.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicles.VehicleType);
                cmd.Parameters.AddWithValue("@Status", "Available");


                int addVehicleStatus = cmd.ExecuteNonQuery();
                
                return addVehicleStatus > 0 ;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch(VehcileNotFoundException ex)
            {
                Console.WriteLine("Vehicle Id not found");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public bool UpdateVehicle(Vehicles vehicles)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = @"Update Vehicles Set Model = @Model, Capacity = @Capacity, 
                    Type = @Type, Status = @Status Where VehicleId = @VehicleId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleId", vehicles.VehicleId);
                cmd.Parameters.AddWithValue("@Model", vehicles.VehicleModel);
                cmd.Parameters.AddWithValue("@Capacity", vehicles.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicles.VehicleType);
                cmd.Parameters.AddWithValue("@Status", vehicles.Status);
                
                int updateVehicleStatus = cmd.ExecuteNonQuery();
                if (updateVehicleStatus == 0)
                {
                    throw new VehcileNotFoundException();
                }
                return updateVehicleStatus > 0 ;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (VehcileNotFoundException ex)
            {
                Console.WriteLine("Vehicle Id not found");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Delete from Vehicles Where VehicleID  = @VehicleId";
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                int deleteVehicleStatus = cmd.ExecuteNonQuery();
                if (deleteVehicleStatus == 0)
                {
                    throw new VehcileNotFoundException("Vehicle Id not found");
                }

                return deleteVehicleStatus > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (VehcileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
