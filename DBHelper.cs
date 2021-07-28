using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Contains functions for accessing the database
    /// </summary>
    class DBHelper
    {
        #region Global Class Variables
        // Keeps track of user ID
        static int currentUserID = 0;

        // SQL database connection object.
        static MySqlConnection conn;

        // Holds current user information for documentation purposes
        static string currentUsername;
        #endregion

        #region SQL Server Connection
        /// <summary>
        /// Constructor for accessing the database
        /// </summary>
        public DBHelper()
        {
            ConnectionString();
        }
        /// <summary>
        /// Contains string for connecting to the database
        /// </summary>
        static public MySqlConnection ConnectionString()
        {
            // Formation of the connection string
            var serverName = "wgudb.ucertify.com";
            var port = "3306";
            var databaseName = "U06IIc";
            var userName = "U06IIc";
            var password = "53688772239";
            var connectionString = $"SERVER={serverName};PORT={port};DATABASE={databaseName};UID={userName};PASSWORD={password};";
            // Passing connectio string into MySQL Database
            conn = new MySqlConnection(connectionString);
            // Returns connection object to caller
            return conn;
        }
        #endregion

        #region User Login
        /// <summary>
        /// Checks user information against database
        /// </summary>
        /// <param name="userName">User input</param>
        /// <param name="password">User input</param>
        /// <returns></returns>
        public bool UserLogin(string userName, string password)
        {
            // Variable to count rows in table
            var rows = 0;

            // Sets current user information
            currentUsername = userName;

            try
            {
                // Opens connection with database
                conn.Open();
                // Queries user input against users in database
                MySqlCommand getUser = new MySqlCommand($"SELECT userName FROM user WHERE userName='{userName}' AND password='{password}';", conn);
                // Stream for database rows
                MySqlDataReader reader = getUser.ExecuteReader();
                // Increments row count for each matching row in database table
                while (reader.Read())
                {
                    rows++;
                }
                // Returns true if a row matches user input
                if (rows > 0)
                {
                    reader.Close();
                    conn.Close();
                    currentUserID = rows;
                    return true;
                }
                // Returns false if no row matches user input
                else
                {
                    reader.Close();
                    conn.Close();
                    return false;
                }
            }
            // Catches any exception for query with database and closes the connection
            catch (Exception)
            {
                conn.Close();
                // Returns false if a problem occurs
                return false;
            }
        }
        #endregion

        #region ID Functions
        /// <summary>
        /// Creates ID for a new entry into a table
        /// </summary>
        /// <param name="table">Database table</param>
        /// <returns></returns>
        static public int createNewID(string table)
        {
            // Queries ID column in table
            MySqlCommand cmd = new MySqlCommand($"SELECT {table + "Id"} FROM {table}", conn);
            MySqlDataReader read = cmd.ExecuteReader();
            // Stores IDs
            List<int> l = new List<int>();
            // Converts and adds IDs to the list
            while (read.Read())
            {
                l.Add(Convert.ToInt32(read[0]));
            }
            read.Close();
            // Returns function call to incrementnew ID
            return newID(l);
        }
        /// <summary>
        /// Increments a new ID after the highest number in the list
        /// </summary>
        /// <param name="l">ID list</param>
        /// <returns></returns>
        static public int newID(List<int> l)
        {
            int ID = 0;
            // Steps through list to find highest number
            foreach (int id in l)
            {
                if (id > ID)
                {
                    ID = id;
                }
            }
            // Increments high number and returns as new ID
            return ID + 1;
        }
        #endregion

        #region Customer Functions
        /// <summary>
        /// Adds new customer into database
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="cityId"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="address2"></param>
        /// <param name="activity"></param>
        /// <param name="postalCode"></param>
        static public void AddCustomer(string customerName, int cityId, string phone, string address, string address2, bool activity, string postalCode)
        {
            // Variable for activity status
            int binaryActvity;
            // Get current date and time 
            DateTime currentDate = DateTime.Now;
            string sqlFormattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Open connection to database
            conn.Open();
            // Condition to set activity status if active
            if (activity == true)
            {
                binaryActvity = 1;
            }
            // Activity status defaults to false otherwise
            else
            {
                binaryActvity = 0;
            }
            // SQL string for customer with nested function call for addresss information
            string addCustomer = $"INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{createNewID("customer")}', '{customerName}', '{AddAddress(address, address2, phone, postalCode, cityId)}', '{binaryActvity}', '{sqlFormattedDate}', '{currentUsername}', '{sqlFormattedDate}', '{currentUsername}')";
            // Creates and executes SQL command 
            MySqlCommand cmd = new MySqlCommand(addCustomer, conn);
            cmd.ExecuteNonQuery();
            // Closes connection to database
            conn.Close();
        }
        /// <summary>
        /// Adds new address into database
        /// </summary>
        /// <param name="address"></param>
        /// <param name="address2"></param>
        /// <param name="phone"></param>
        /// <param name="postalCode"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        static public int AddAddress(string address, string address2, string phone, string postalCode, int cityId)
        {
            // Call to set for ID
            int id = createNewID("address");
            // Get current date and time 
            DateTime currentDate = DateTime.Now;
            string sqlFormattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Condition to handle second address field being empty
            if (String.IsNullOrEmpty(address2))
            {
                address2 = "N/A";
            }
            // SQL string for addresss information
            string addAddress = $"INSERT INTO address(addressId, address, address2, postalCode, phone, createDate, createdBy, cityId, lastUpdateBy, lastUpdate) VALUES ('{id}', '{address}', '{address2}', '{postalCode}', '{phone}', '{sqlFormattedDate}', '{currentUsername}', '{cityId}', '{currentUsername}', '{sqlFormattedDate}')";
            // Creates and executes SQL command 
            MySqlCommand cmd = new MySqlCommand(addAddress, conn);
            cmd.ExecuteNonQuery();
            // Returns address ID to caller
            return id;
        }
        /// <summary>
        /// Updates information for an existing customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerName"></param>
        /// <param name="addressId"></param>
        /// <param name="address"></param>
        /// <param name="address2"></param>
        /// <param name="phone"></param>
        /// <param name="activity"></param>
        /// <param name="postalCode"></param>
        /// <param name="cityId"></param>
        static public void UpdateCustomer(int customerId, string customerName, int addressId, string address, string address2, string phone, bool activity, string postalCode, int cityId)
        {
            // Variable to keep track of return rows
            var rows = 0;
            // Boolean for customer check
            bool customerExists = false;
            // Variable for activity status
            int binaryActvity;
            // opens connection to database
            conn.Open();
            // Get current date and time 
            DateTime currentDate = DateTime.Now;
            string sqlFormattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Command to query IDs against the database
            MySqlCommand findCustomer = new MySqlCommand($"SELECT customerId FROM customer WHERE customerId='{customerId}' AND addressId='{addressId}';", conn);
            // Stream for database rows
            MySqlDataReader reader = findCustomer.ExecuteReader();
            // Increments row count for each row in database table
            while (reader.Read())
            {
                rows++;
            }
            // Returns true if a row matches user input
            if (rows > 0)
            {
                reader.Close();
                customerExists = true;
            }
            // Returns false if no row matches user input
            else
            {
                reader.Close();
                customerExists = false;
            }
            // Condition to execute if the customer exists
            if (customerExists)
            {
                // Sets activity status if active
                if (activity == true)
                {
                    binaryActvity = 1;
                }
                // Defaults to not active
                else
                {
                    binaryActvity = 0;
                }
                // Condition to handle second address field being empty
                if (String.IsNullOrEmpty(address2))
                {
                    address2 = "N/A";
                }
                // SQL query that joins to customer and address tables based on IDs
                string update = $"UPDATE customer AS c INNER JOIN address  AS a ON c.addressId = a.addressId SET c.customerName = '{customerName}', c.active = '{binaryActvity}', c.lastUpdate = '{sqlFormattedDate}', c.lastUpdateBy = '{currentUsername}', a.address = '{address}', a.address2 = '{address2}', a.phone = '{phone}', a.postalCode = '{postalCode}', a.cityId = '{cityId}' WHERE c.customerId = '{customerId}' AND a.addressId = '{addressId}'";
                // Creates and executes SQL command 
                MySqlCommand cmd = new MySqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                // Closes connection to database
                conn.Close();
            }
            // Informs user if no rows contain given customer ID
            else
            {
                MessageBox.Show("A customer by that ID and address does not exist.");
                conn.Close();
            }
        }
        /// <summary>
        /// Deletes a customer record from the database
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        static public bool DeleteCustomer(int customerId)
        {
            // Communicates if a customer was deleted
            bool success = false;
            // Counts the number of rows return by a query
            var rows = 0;
            // Communicates if the given customer exists
            bool customerExists = false;
            // Get current date and time 
            DateTime currentDate = DateTime.Now;
            string sqlFormattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Opens connection to the database
            conn.Open();
            // Command to query IDs against the database
            MySqlCommand findCustomer = new MySqlCommand($"SELECT customerId FROM customer WHERE customerId='{customerId}';", conn);
            //Stream for database rows
            MySqlDataReader reader = findCustomer.ExecuteReader();
            //Increments row count for each row in database table
            while (reader.Read())
            {
                rows++;
            }
            //Returns true if a row matches user input
            if (rows > 0)
            {
                reader.Close();
                customerExists = true;
            }
            //Returns false if no row matches user input
            else
            {
                reader.Close();
                customerExists = false;
            }
            // Condition to execute if the customer exists
            if (customerExists)
            {
                // Retrieves address information from given customer
                MySqlCommand getAddress = new MySqlCommand($"SELECT addressId FROM customer WHERE customerId='{customerId}';", conn);
                int addressValue = (int)getAddress.ExecuteScalar();
                // Attemps to delete customer
                try
                {
                    // Query to delete customer
                    string deleteCustomer = $"DELETE FROM customer WHERE customerId = '{customerId}'";
                    MySqlCommand cmd = new MySqlCommand(deleteCustomer, conn);
                    cmd.ExecuteNonQuery();
                    // Query to delete customer address
                    string deleteCustomerAddress = $"DELETE FROM address WHERE addressId = '{addressValue}'";
                    MySqlCommand cmd2 = new MySqlCommand(deleteCustomerAddress, conn);
                    cmd2.ExecuteNonQuery();
                }
                // Catches foerign key exception
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("Cannot delete a customer who has an existing appointment.");
                }
                
                // Closes connection to the database
                conn.Close();
                // Sets to true to communicate success
                success = true;
            }
            // Informs user that the entered IDs did not match an existing row
            else 
            {
                MessageBox.Show("A customer by that ID and/or address does not exist.");
                conn.Close();
                // Sets to false to communicate failure
                success = false;
            }
            // Communicates success or failure 
            return success;
        }
        /// <summary>
        /// Populates the customer table
        /// </summary>
        static public DataTable CustomerTable()
        {
            // Table to hold customer data
            DataTable customerTable = new DataTable();
            // Opens connection to the database
            conn.Open();
            // SQL query for the customer table
            string query = $"SELECT c.customerId, c.customerName, c.active, a.address, a.address2, a.addressId, a.cityId, a.postalCode, a.phone FROM customer AS c INNER JOIN address AS a ON c.addressId = a.addressId ORDER BY c.customerId, c.customerName, c.active, a.address, a.address2, a.addressId, a.cityId, a.postalCode, a.phone";
            // Runs SQL query
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            // Populates tabel with query results
            adapter.Fill(customerTable);
            // Closes connection to the database
            conn.Close();
            // Return filled table
            return customerTable;
        }
        #endregion

        #region Appointment Functions
        /// <summary>
        /// Adds new appointment to the database
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="location"></param>
        /// <param name="contact"></param>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static public void AddAppointment(int customerId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end)
        {
            // Stores row count return by query
            var rows = 0;
            // Boolean for whether a customer exists
            var customerExists = false;
            // Stores current date/time
            DateTime dateToAdd = DateTime.Now;
            // Stores the starting and ending appointment times
            DateTime startTime = start.ToUniversalTime();
            DateTime endTime = end.ToUniversalTime();
            // Formats times
            string sqlFormattedDateAdd = dateToAdd.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFormattedDateEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFormattedDateStart = startTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Opens connection to the database
            conn.Open();
            // Command to query customer ID against the database
            MySqlCommand findCustomer = new MySqlCommand($"SELECT customerId FROM customer WHERE customerId='{customerId}';", conn);
            // Stream for database rows
            MySqlDataReader reader = findCustomer.ExecuteReader();
            // Increments row count for each row in database table
            while (reader.Read())
            {
                rows++;
            }
            // Returns true if a row matches user input
            if (rows > 0)
            {
                reader.Close();
                customerExists = true;
            }
            // Returns false if no row matches user input
            else
            {
                reader.Close();
                customerExists = false;
            }
            // Adds appointment if customer exists
            if (customerExists)
            {
                // SQL query to add appointment
                string addAppointment = $"INSERT INTO appointment(appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{createNewID("appointment")}', '{customerId}', '{currentUserID}', '{title}', '{description}', '{location}', '{contact}', '{type}', '{url}', '{sqlFormattedDateStart}', '{sqlFormattedDateEnd}', '{sqlFormattedDateAdd}', '{currentUsername}', '{sqlFormattedDateAdd}', '{currentUsername}')";
                // Executes query
                MySqlCommand cmd = new MySqlCommand(addAppointment, conn);
                cmd.ExecuteNonQuery();
                // Closes connection to database
                conn.Close();
            }
            // Informs the user that the customer ID was not valid
            else
            {
                MessageBox.Show("The given customer ID does not match any existing customers.");
            }
        }
        /// <summary>
        /// Updates an existing appointment in the database
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="location"></param>
        /// <param name="contact"></param>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static public void UpdateAppointment(int appointmentId, int customerId, string customerName, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end)
        {
            // Stores row counts returned by query
            var rows = 0;
            var rows2 = 0;
            // Boolean for whether an items exists
            var appointmentExists = false;
            var customerExists = false;
            // Stores current time
            DateTime dateToAdd = DateTime.Now;
            // Stores appointment starting and ending times
            DateTime startTime = start.ToUniversalTime();
            DateTime endTime = end.ToUniversalTime();
            // Formats times
            string sqlFormattedDateAdd = dateToAdd.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFormattedDateEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFormattedDateStart = startTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Opens connection to the database
            conn.Open();
            // Command to query appointment ID against the database
            MySqlCommand findAppointment = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE appointmentId='{appointmentId}';", conn);
            // Stream for database rows
            MySqlDataReader reader = findAppointment.ExecuteReader();
            // Increments row count for each row in database table
            while (reader.Read())
            {
                rows++;
            }
            // Returns true if a row matches user input
            if (rows > 0)
            {
                reader.Close();
                appointmentExists = true;
            }
            // Returns false if no row matches user input
            else
            {
                reader.Close();
                appointmentExists = false;
            }
            // Command to query customer ID and name against the database
            MySqlCommand findCustomer = new MySqlCommand($"SELECT customerId FROM customer WHERE customerId = '{customerId}' AND customerName = '{customerName}';", conn);
            // Stream for database rows
            reader = findCustomer.ExecuteReader();
            while (reader.Read())
            {
                rows2++;
            }
            // Returns true if a row matches user input
            if (rows2 > 0)
            {
                reader.Close();
                customerExists = true;
            }
            // Returns false if no row matches user input
            else
            {
                reader.Close();
                customerExists = false;
            }
            // Adds appointment if both appointment and customer exists
            if (appointmentExists && customerExists)
            {
                rows = 0;
                MySqlCommand matchCustomer = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE appointmentId = '{appointmentId}' AND customerId = '{customerId}';", conn);
                // Stream for database rows
                reader = matchCustomer.ExecuteReader();
                // Increments row count for each row in database table
                while (reader.Read())
                {
                    rows++;
                }
                // Returns true if a row matches user input
                if (rows > 0)
                {
                    reader.Close();
                    string updateAppointment = $"UPDATE appointment SET title = '{title}', description = '{description}', location = '{location}', contact = '{contact}', url = '{url}', start = '{sqlFormattedDateStart}', end = '{sqlFormattedDateEnd}', lastUpdate = '{sqlFormattedDateAdd}', lastUpdateBy = '{currentUsername}', type = '{type}' WHERE appointmentId = '{appointmentId}'";
                    // Executes query
                    MySqlCommand cmd = new MySqlCommand(updateAppointment, conn);
                    cmd.ExecuteNonQuery();
                    // Closes connection to database
                    conn.Close();
                }
                // Returns false if no row matches user input
                else
                {
                    reader.Close();
                    string updateAppointment = $"UPDATE appointment SET customerId = '{customerId}', title = '{title}', description = '{description}', location = '{location}', contact = '{contact}', url = '{url}', start = '{sqlFormattedDateStart}', end = '{sqlFormattedDateEnd}', lastUpdate = '{sqlFormattedDateAdd}', lastUpdateBy = '{currentUsername}', type = '{type}' WHERE appointmentId = '{appointmentId}'";
                    // Executes query
                    MySqlCommand cmd = new MySqlCommand(updateAppointment, conn);
                    cmd.ExecuteNonQuery();
                    // Closes connection to database
                    conn.Close();
                }
            }
            // Informs the user that the appointment ID was not valid
            else
            {
                MessageBox.Show("The given appointment ID and/or customer does not match any existing records.");
            }
        }
        /// <summary>
        /// Deletes an existing appointment from the database
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        static public bool DeleteAppointment(int appointmentId)
        {
            // Boolean to store whether operation completed
            var success = false;
            // Stores row count return by query
            var rows = 0;
            // Stores whether appointment exists
            bool appointmentExists = false;
            // Opens connection to the database
            conn.Open();
            // Stores current date/time
            DateTime currentDate = DateTime.Now;
            // Formats date/time
            string sqlFormattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Queriues appointment IDs
            MySqlCommand findAppointment = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE appointmentId='{appointmentId}';", conn);
            // Stream for database rows
            MySqlDataReader reader = findAppointment.ExecuteReader();
            // Increments row count for each row in database table
            while (reader.Read())
            {
                rows++;
            }
            // Returns true if a row matches user input
            if (rows > 0)
            {
                reader.Close();
                appointmentExists = true;
            }
            // Returns false if no row matches user input
            else
            {
                reader.Close();
                appointmentExists = false;
            }
            // Delets the appointment if it exists
            if (appointmentExists)
            {
                string deleteAppointment = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}'";
                MySqlCommand cmd = new MySqlCommand(deleteAppointment, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                success = true;
            }
            // Informs the user that the appointment doesn't exist
            else
            {
                MessageBox.Show("An appointment by that ID does not exist.");
                conn.Close();
                success = false;
            }
            return success;
        }
        /// <summary>
        /// Returns a query on customer table
        /// </summary>
        /// <returns></returns>
        static public DataTable AvailableCustomers()
        {
            // Opens connection to the database
            conn.Open();
            // Creates datatable to hold query results
            DataTable dt = new DataTable();
            // Reads query
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT customerId, customerName FROM customer;", conn);
            // Fills data table
            da.Fill(dt);
            // Closes connection to the database
            conn.Close();
            return dt;
        }
        /// <summary>
        /// Returns a query on appointment table
        /// </summary>
        /// <returns></returns>
        static public DataTable AvailableAppointments()
        {
            // Opens connection to the database
            conn.Open();
            // Creates datatable to hold query results
            DataTable dt = new DataTable();
            // Reads query
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT a.appointmentId, c.customerId, c.customerName, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end FROM appointment AS a INNER JOIN customer AS c ON a.customerId = c.customerId ORDER BY a.appointmentId, c.customerId, c.customerName, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end;", conn);
            // Fills data table
            da.Fill(dt);
            // Closes connection to the database
            conn.Close();
            return dt;
        }
        #endregion

        #region Calender Functions
        /// <summary>
        /// Checks to make sure that entered appointment times do not overlap with existing ones
        /// </summary>
        /// <param name="overlapCheckStart"></param>
        /// <param name="overlapCheckEnd"></param>
        /// <returns></returns>
        static public bool CheckCalender(DateTime overlapCheckStart, DateTime overlapCheckEnd, int appointmentId)
        {
            // Format appointment start and end times to UTC
            DateTime startTime = overlapCheckStart.ToUniversalTime();
            DateTime endTime = overlapCheckEnd.ToUniversalTime();
            // Format date and time to SQL 
            string sqlFormattedStart = startTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlFormattedEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Stores row count from query
            var rows = 0;
            // Opens connection to the database
            conn.Open();

            // Creates and executes query against customer database
            MySqlCommand cmd = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE start <= '{sqlFormattedEnd}' AND end >= '{sqlFormattedStart}';", conn);
            // Checks to see if query returns any rows 
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rows++;
            }
            reader.Close();
            // If rows are returned, false
            if (rows != 0)
            {
                // Resets counter
                rows = 0;
                // Query to see if appointment matches
                MySqlCommand existingAppointment = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE appointmentId <= '{appointmentId}';", conn);
                reader = existingAppointment.ExecuteReader();
                while (reader.Read())
                {
                    rows++;
                }
                reader.Close();
                // If a match, exists allow
                if (rows > 0)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
                return false;
            }
            // If no rows are returned, true
            else
            {
                conn.Close();
                return true;
            }
        }
        /// <summary>
        /// Queries customer name
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        static public string ReminderQuery(string customerId)
        {
            // Opens connection to the database
            conn.Open();
            // Parses value to string
            string customer = "";
            // Creates and executes query against customer database
            MySqlCommand cmd = new MySqlCommand(customerId, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customer = reader.GetString(0);
            }
            // Closes connection to the database
            conn.Close();
            // Returns name
            return customer;
        }
        #endregion

        #region Report Functions
        /// <summary>
        /// Runs a query based on input and returns a Datatable
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        static public DataTable Report(string reportType)
        {
            // Stores SQL query
            string query = null;
            // Opens connection to database
            conn.Open();
            // Runs query for appointment information, if selected
            if (reportType == "appointment")
            {
                query = $"SELECT type, COUNT(*) AS 'Number' FROM appointment GROUP BY type";
            }
            // Runs query for consultant information, if selected
            else if (reportType == "consultant")
            {
                query = $"SELECT u.userName, a.appointmentId, c.customerName, a.start, a.end FROM user AS u INNER JOIN appointment AS a ON u.userId = a.userId INNER JOIN customer AS c ON a.customerId = c.customerId ORDER BY u.userName, a.appointmentId, c.customerName, a.start, a.end";
            }
            // Runs query for appointment customer and title information, if selected
            else if (reportType == "contact")
            {
                query = $"SELECT c.customerName, a.title FROM customer AS c INNER JOIN appointment AS a ON c.customerId = a.customerId ORDER BY c.customerName, a.title";
            }
            // Creates datatable to hold query results
            DataTable dt = new DataTable();
            // Reads query
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            // Fills data table
            da.Fill(dt);
            // Converts UTC to local time for the Consultant report
            if (reportType == "consultant")
            {
                for (int idx = 0; idx < dt.Rows.Count; idx++)
                {
                    dt.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
                }
            }
            // Closes the conection
            conn.Close();
            // Returns datable to caller
            return dt;
;        }
        #endregion
    }
}


