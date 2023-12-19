
using System.Windows.Forms;

namespace ESENP_Project
{
    /// <summary>
    /// This project takes input and creates Database schema according to provided instructions. 
    /// Also it fills the database tables with data after they have been created.
    /// I have used grids and columns to take input from the user and the data entered is always taken as string type for simplicity and ease of understanding.
    /// User can enter data either in free text format or a dropdown which can have selected few values.
    /// </summary>
    public partial class Form1 : Form

    {
        private int labelCount = 1;
        private List<Label> labels = new List<Label>();
        private List<ComboBox> dropdowns = new List<ComboBox>();
        private string TableName = null;
        private List<string> tablenamelist = new List<string>(); //list to store tablename for query condition
        private List<string> listColName_T = new List<string>(); //list of textbox
        private List<string> listColName_D = new List<string>();//list of dropdown
        private string Query;
        private string coloumnName;

        private List<TextBox> listData_T = new List<TextBox>(); //** for data in textbox
        private List<ComboBox> listData_D = new List<ComboBox>(); // for data in dropdown
        private List<string> datalist = new List<string>();    //list of data
        private List<string> coloumnNamelist = new List<string>(); //list of coloumns


        // for table

        private DataGridView dataGridView;              // Declare a DataGridView
        private bool dataGridViewExists = false;        // Flag to check if DataGridView exists
        private Label gr_label;                         //label for table  name
        string newName;
        private string gr_name = null;
        private List<string> listCol_grid = new List<string>();
        private bool is_Grid = false;
        private bool is_Form = false;
        string checkbox_name;
        string cb_name;
        private List<string> listGrid_Data = new List<string>();
        private List<bool?> list_cb = new List<bool?>();
        private List<string> listCol_cb = new List<string>();
        private List<string> Data_Gr = new List<string>();
        private List<string> Collist = new List<string>();
        private int rowCounter = 0;  /// var for rows

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {

        }
        //Method for getting new form and fields
        private void CreateForm()
        {

            string inputText = textBoxMain.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
                return;

            Form_Label.Visible = true;
            if (labelCount == 1)
            {
                Form_Label.Text = newName;
                TableName = newName;
                labelCount++;
            }
            else
            {
                buttonSave.Visible = true;

                //code for getting new label
                Label newLabel = new Label();

                //Check condition if user wants dropdown or simple field
                if (inputText.Contains(','))
                {
                    // Split the input text into individual entries
                    string[] entries = inputText.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    if (entries.Length > 0)
                    {
                        newLabel.Text = entries[0].Trim();
                        newLabel.Location = new System.Drawing.Point(80, 40 + (labelCount - 1) * 30);
                        newLabel.AutoSize = true;
                        newLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        groupBox2.Controls.Add(newLabel);

                        //** add labelname of dropdown into list 

                        listColName_D.Add(newLabel.Text);     
                        
                        // Create a new ComboBox for the remaining entries
                        ComboBox newComboBox = new ComboBox
                        {
                            // Adjust the location as needed
                            Location = new System.Drawing.Point(200, 40 + (labelCount - 1) * 30),
                            // Adjust the width as needed
                            Width = 200                                                  
                        };
                        groupBox2.Controls.Add(newComboBox);
                        ///List of dropdown
                        listData_D.Add(newComboBox);                                    

                        // Add the remaining entries as options to the ComboBox
                        foreach (string entry in entries.Skip(1))
                        {
                            newComboBox.Items.Add(entry.Trim());

                        }
                        // listData.Add(newComboBox.Text);
                        labelCount++;
                        this.textBoxMain.ResetText();
                    }

                }
                else
                {
                    newLabel.Text = textBoxMain.Text;
                    // Adjust the location as needed
                    newLabel.Location = new System.Drawing.Point(80, 40 + (labelCount - 1) * 30);
                    newLabel.AutoSize = true;
                    groupBox2.Controls.Add(newLabel);

                    //add labelname of textbox into list of textbox
                    listColName_T.Add(newLabel.Text); 

                    //code for getting new textbox
                    TextBox newTextBox = new TextBox();
                    newTextBox.Location = new System.Drawing.Point(200, 40 + (labelCount - 1) * 30);
                    groupBox2.Controls.Add(newTextBox);

                    labelCount++;
                    this.textBoxMain.ResetText();
                    listData_T.Add(newTextBox);
                }

            }
        }

        //when user want to enter data in form of table
        private void CreateGrid()
        {
            dataGridView = new DataGridView();

            // Set DataGridView properties as needed
            // Adjust the location
            dataGridView.Location = new Point(10, 125);
            // Adjust the size                                           
            dataGridView.Size = new Size(1400, 300);    
            dataGridView.Dock = DockStyle.None;
            // for no scroll
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.BackgroundColor = Color.White;                                         
            groupBox1.Controls.Add(dataGridView);
        }

        //Method to add oloumns to grid
        private void AddColumnsToGrid()
        {
            string columnName = textBoxMain.Text.Trim();

            if (!string.IsNullOrEmpty(columnName))
                //Condition to check if user wants checkbox
            {
                if (textBoxMain.Text.Contains("_cb"))
                {

                    checkbox_name = textBoxMain.Text;
                    var arr_cb = checkbox_name.Split('_');
                    cb_name = arr_cb[0];
                    // Create a new checkbox column
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = cb_name;
                    checkBoxColumn.Name = cb_name;

                    // Add the checkbox column to the DataGridView
                    DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                    //checkbox col name added to list
                    listCol_cb.Add(checkBoxColumn.Name); 
                    dataGridView.Columns.Add(checkBoxColumn);

                    //data from checkbox
                    list_cb.Add((bool?)checkBoxCell.Value);      
                }
                else
                {
                    DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn
                    {
                        Name = columnName,
                        HeaderText = columnName,
                        DataPropertyName = columnName
                    };


                    dataGridView.Columns.Add(newColumn);
                    listCol_grid.Add(columnName);

                }


                // Clear the TextBox for the next column name
                textBoxMain.Clear();
            }
        }

        //Method to create label for the table Name and add button to save data to database
        private void CreateTable(string newName)
        {

            Label gr_label = new Label();
            //(dataGridView.Left, dataGridView.Top - gr_label.Height - 10);
            gr_label.Location = new Point(600, 90);

            gr_label.Text = newName;
            gr_name = gr_label.Text;
            gr_label.AutoSize = true;
            gr_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Controls.Add(gr_label);

            //for button
            Button btnSaveGrid = new Button();
            btnSaveGrid.Location = new Point(10, 90);
            btnSaveGrid.Text = "Save Data";
            btnSaveGrid.AutoSize = true;
            btnSaveGrid.Click += new EventHandler(btnSaveGridClick);
            //btnSaveGrid.BackColor = Color.BlueViolet;
            groupBox1.Controls.Add(btnSaveGrid);


            textBoxMain.Clear();
            this.CreateGrid(); 

        }



        private void buttonMain_Click(object sender, EventArgs e)
        {

            string Input = textBoxMain.Text;

            //Save your Textbox text in form of array
            var array_input = Input.Split(' ');
            newName = array_input[0];
            // Condition to check whether userr wants form or grid 
            if (array_input != null && array_input.Any() && array_input.LastOrDefault().ToUpper() == "FR")
            {
                //Call Creatform Method
                this.CreateForm();
                //Setting is_Form flag to true
                is_Form = true;
                //Seeting is_Grid flag to false
                is_Grid = false;
            }
            else if (array_input != null && array_input.Any() && array_input.LastOrDefault().ToUpper() == "GR")
            {
                //Calling create table method
                this.CreateTable(newName);
                is_Form = false;
                is_Grid = true;


            }

            else
            {
                //If form already exist then add fields to form
                if (is_Form == true)
                {

                    this.CreateForm();
                }
                //if grid already exist add coloumns to grid
                else if (is_Grid == true)
                {
                    this.AddColumnsToGrid();
                }
            }
        }


        //Button to save data from the form into the database
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Making list empty by defining it everytime for new col                   //  listColName_T  --list of textbox
                                                                                      //  listColName_D  --list of dropdown
                                                                                      //  listData_T     --for data in textbox
                                                                                      //  listData_D     --for data in dropdown
            coloumnNamelist = new List<string>();
            datalist = new List<string>();

            //Creating obj of the connection class
            Connection conn = new Connection();

            //Checking if Table name already exist in database
            if (tablenamelist.Contains(TableName) == false)
            {
                //Query to create table 
                Query = "Create Table " + TableName + " ( " + TableName + "_Id BIGINT IDENTITY(1,1) ";
                foreach (var column in listColName_T)
                {
                    Query = Query + " , " + column + " VARCHAR (Max) ";
                }
                foreach (var column in listColName_D)
                {
                    Query = Query + " , " + column + " VARCHAR (Max) ";
                }

                Query = Query + " )";

                conn.ExecuteQuery(Query);
                //Add Table name to Tablename_List
                tablenamelist.Add(TableName);
            }


            //Combining both the coloumn name for insert query
            coloumnNamelist.AddRange(listColName_D);
            coloumnNamelist.AddRange(listColName_T);
            //Seperating them with ,
            string coloumnName = String.Join(",", coloumnNamelist);

            //Adding data from Dropdown in list
            datalist.AddRange(listData_D.Select(c => c.SelectedItem.ToString()));
            //Adding data from textbox into list
            datalist.AddRange(listData_T.Select(c => c.Text));
            //Join them with ,
            string data = String.Join(" ' ,' ", datalist);

            //Insert Query to add data into table
            Query = "Insert into " + TableName + " ( " + coloumnName + " ) Values  ( ' " + data + " ' ) ";
            conn.ExecuteQuery(Query);
            MessageBox.Show("Data added sucessfully");

        }

        //Button to save grid data into database
        private void btnSaveGridClick(object sender, EventArgs e)
        {

            //Making list empty by defining it everytime for new col
            Collist = new List<string>();    
            listGrid_Data = new List<string>();


            // Access data from cell of coloumn 
            for (int i = rowCounter; i < (dataGridView.Rows.Count) - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        cell.Value = false;

                    }
                    string cellValue = cell.Value.ToString();
                    //adding Cell data into list;
                    listGrid_Data.Add(cellValue);                



                }

            }
            rowCounter++;

            string data = String.Join(" ' ,' ", listGrid_Data);

            //list of norm col
            Collist.AddRange(listCol_grid);
            //list of checkboc col
            Collist.AddRange(listCol_cb);    

            string coloumnName = String.Join(",", Collist);


            //Obj of Connection Class
            Connection conn = new Connection();
            //Condition if table already exixt in databse
            if (tablenamelist.Contains(gr_name) == false)
            {
                //Query for Create table
                Query = "Create Table " + gr_name + " ( " + gr_name + "_Id BIGINT IDENTITY(1,1) ";
                foreach (var column in listCol_grid)
                {

                    Query = Query + " , " + column + " VARCHAR (Max) ";
                }

                foreach (var column in listCol_cb)
                {
                    Query = Query + " , " + column + " Bit ";
                }
                Query = Query + " )";

                conn.ExecuteQuery(Query);
                tablenamelist.Add(gr_name);
            }



            //Query for inserting data into sql table



            data = data.Replace("True", "1").Replace("False", "0");
            Query = "Insert into " + gr_name + " ( " + coloumnName + " ) Values  ( ' " + data + " ' ";

            Query = Query + ")";
            conn.ExecuteQuery(Query);
            MessageBox.Show("Data added successfully");

        }


    }
}


