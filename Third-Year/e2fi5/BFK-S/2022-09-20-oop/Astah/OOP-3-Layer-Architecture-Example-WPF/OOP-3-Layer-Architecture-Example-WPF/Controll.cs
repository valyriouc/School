using System;
using OOP_3_Layer_Architecture_Example_WPF;

public class Controll
{
	//here attributes are defined that represent other components (i.e. objects) at runtime
	Data data;
	MainWindow gui;

	//constructor gets a reference to the other objects
	public Controll(MainWindow gui)
	{
		this.gui = gui;
		data = new Data(this);
	}

	//Implement all program logic here. All the window should do is call methods in controll.
	//Setup must be triggered in constructor, because all further actions will get triggered by a user via the gui
	//Controll calls methods in data to retrieve data and handles it accordingly.
	//Then contoll calls methods in window that only change the way data is displayed

	//Example text form "PAP" (Programmablaufplan) sketch (NOTE: Not real UML! Only a sketch, sue me over it. See http://www.home.hs-karlsruhe.de/~krre0001/MCT_Labor/PAP_Tutorial_und_Uebung.pdf for further information)

	//Delete btn is pressed in a list of elements on the element with index 7
	//window calls controll.deleteListElement(7)   
	//controll evaluates if the delete call is valid (using own methods isUserAdmin(); isDataDeletable(); or service classes like AuthorizationManager...)  -> if not valid controll calls window.showError("Delete Action is not valid!") with explanation why the operation failed if possible for best user experience
	//controll gets and parses necessary data and calls data.deleteListElement(preparedData)  For best practice: handle occurring errors
	//data calls its service class and deletes the element  dbManager.deleteTableRow(sqlPreparedData) and gives back information for possible error handling keeping best practice in mind
	//controll receives the information that the data was deleted, from callbacks (look at the returned boolean in dbManager class), and calls window.updateListData() and window.showConfirmationMessage(messageText) 
	//window calls own methods to update the view and show a message "Data XY has been deleted"

}
