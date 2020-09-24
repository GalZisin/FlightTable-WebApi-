using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Controllers
{
    [Route("api/Flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        //[HttpGet]
        [HttpGet("{destinationCountry}/{fromDepartureDate}/{toDepartureDate}")]
        public ActionResult<Flight> GetFlightList(string destinationCountry, string fromDepartureDate, string toDepartureDate)
        {
            List<Flight> flightList = new List<Flight>();
            StringBuilder sb = new StringBuilder();
            Flight flight = null;
            SqlDAO sd = new SqlDAO();
            try
            {
                if(destinationCountry == "-")
                {
                    destinationCountry = "";
                }
                if(fromDepartureDate == "-" || fromDepartureDate == "")
                {
                    DateTime dtm = DateTime.Now;
                    fromDepartureDate = $"{dtm.Year.ToString()}-{dtm.Month.ToString()}-30 00:00:59";
                }
                if (toDepartureDate == "-" || toDepartureDate == "")
                {
                    DateTime dtm = DateTime.Now.AddMonths(2);
                    toDepartureDate = $"{dtm.Year.ToString()}-{dtm.Month.ToString()}-{dtm.Day.ToString()} 00:00:59";
                }
                sb.Append("SELECT FlightNO, CompanyID, OriginCountry, DestinationCountry, DepartureDate, arrivalDate, Price, SeatAmount");
                sb.Append($" From Flights where OriginCountry LIKE '%' AND DestinationCountry LIKE '{destinationCountry}%' AND");
                sb.Append($" DepartureDate BETWEEN CONVERT(datetime, '{fromDepartureDate}') AND CONVERT(datetime, '{toDepartureDate}')");

                string query = sb.ToString();
                DataTable table = sd.GetSqlQueryDS(query, "Flights").Tables[0];
                foreach (DataRow dr in table.Rows)
                {
                    flight = new Flight();
                    flight.FlightNO = int.Parse(dr["FlightNO"].ToString());
                    flight.OriginCountry = dr["OriginCountry"].ToString();
                    flight.DestinationCountry = dr["DestinationCountry"].ToString();
                    flight.DepartureDate = (DateTime)dr["DepartureDate"];
                    flight.ArrivalDate = (DateTime)dr["ArrivalDate"];
                    flight.Price = int.Parse(dr["Price"].ToString());
                    flight.SeatAmount = int.Parse(dr["SeatAmount"].ToString());
                    flight.CompanyID = int.Parse(dr["CompanyID"].ToString());
                    flightList.Add(flight);
                }
                return Ok(flightList);
            }
            catch (Exception e1)
            {
                return BadRequest("something went wrong!");
            }

        }
    }
}
