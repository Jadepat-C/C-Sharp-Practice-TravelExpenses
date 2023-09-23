namespace TravelExpenses.BackEnd.Models
{
    /// <summary>
    /// Represents an interface for Travel Expenses Data Access Object (DAO).
    /// </summary>
    public interface ITravelExpensesDAO
    {
        /// <summary>
        /// Inserts a new travel expense record.
        /// </summary>
        /// <param name="travelExpense">The travel expense to insert.</param>
        public void Insert(TravelExpensesDTO travelExpense);

        /// <summary>
        /// Updates an existing travel expense record.
        /// </summary>
        /// <param name="travelExpense">The travel expense to update.</param>
        public void Update(TravelExpensesDTO travelExpense);

        /// <summary>
        /// Deletes a travel expense record by its ID.
        /// </summary>
        /// <param name="id">The ID of the travel expense to delete.</param>
        public void Delete(int id);

        /// <summary>
        /// Retrieves all travel expenses.
        /// </summary>
        /// <returns>A list of all travel expenses.</returns>
        public List<TravelExpensesDTO> getAll();

        /// <summary>
        /// Retrieves travel expenses by name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A list of travel expenses matching the name.</returns>
        public List<TravelExpensesDTO> getByName(string name);

        /// <summary>
        /// Retrieves travel expenses by reference number.
        /// </summary>
        /// <param name="refNumber">The reference number to search for.</param>
        /// <returns>A list of travel expenses matching the reference number.</returns>
        public List<TravelExpensesDTO> getByRefNumber(string refNumber);

        /// <summary>
        /// Retrieves a travel expense by its ID.
        /// </summary>
        /// <param name="id">The ID of the travel expense to retrieve.</param>
        /// <returns>The travel expense with the specified ID.</returns>
        public TravelExpensesDTO getByID(int id);
    }
}
