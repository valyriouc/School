using System;

//service to handle connections and queries to a databank
public class DBManager
{
	private const string connectionString = "";
	//add necessary classes as attributes to handle db connections and query
	//add attributes for project specific usage

	public DBManager()
	{

	}
	
	public Boolean saveData(object data) {
		//save your Data from passed obj to according to tables in db, if necessary create new custom object to easily handle all datatypes and data
		return false;
	}

	public Boolean connectToDB() {
		return connect(connectionString);
	}

	private Boolean connect(String pConnectionString) {
		//try to connect to databank and return if connection was successful. A Failed connection, i.e. "false" must be handled in "Data" class
		return false;
	}


}
