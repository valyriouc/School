using System;

public class Data
{
	Controll controll;
	//Example database service class that exists and is only used at data layer to store data long term
	private DBManager dbManager = new DBManager();

	//Further possible examples
	//APIManager apiManager = new APIManager() for using (rest) api
	//FileWriter fW = new FileWriter() to store csv or json data in files
	
	public Data(Controll controll)
	{
		//controll object gets passed so that, at runtime, the data layer can call methods or attributes from controll back independently for example used in asynchronous data requests. Async logic needs to be implemented separately
		this.controll = controll;
	}

	//use methods like follows here to store, get and manage data. 
	public string getName() {
		return ""; //return the true data from service classes of data layer
	}
}
