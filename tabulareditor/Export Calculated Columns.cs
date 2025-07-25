// Collecting calculated column details
string result = "No.\tType\tName\tExpression\n"; // Add a new column header for numbering, type (Calculated Column), name, and expression
int count = 1; // Initialize a counter

// Export only calculated columns (hidden and unhidden)
foreach (var table in Model.Tables)
{
    foreach (var column in table.Columns)
    {
        // Check if the column is a calculated column
        var calculatedColumn = column as CalculatedColumn; // Use casting to avoid syntax issues
        if (calculatedColumn != null) // Ensure the column is a calculated column
        {
            result += count.ToString() + "\tCalculated Column\t" + calculatedColumn.Table.Name + "[" + calculatedColumn.Name + "]\t" + calculatedColumn.Expression.Replace("\n", " ") + "\n"; // Format: Number, Type, Table[Column], Expression
            count++; // Increment the counter
        }
    }
}

// Write to .txt file
string filePath = "calculated_columns.txt"; // Change the path as needed
System.IO.File.WriteAllText(filePath, result);
