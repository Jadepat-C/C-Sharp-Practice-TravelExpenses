using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TravelEx
{
    /// <summary>
    /// Represents a Data Access Object (DAO) for managing travel expenses.
    /// </summary>
    public class TravelExpensesDAO : ITravelExpensesDAO
    {
        private readonly DataSource ds;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDAO"/> class.
        /// </summary>
        public TravelExpensesDAO()
        {
            ds = DataSource.GetInstance();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {

            List<TravelExpensesDTO> dataset = ds.GetDataset();
            var deleteItem = dataset.FirstOrDefault(x => x.id == id);

            if (deleteItem != null)
            {
                dataset.Remove(deleteItem);
                ds.Commit(dataset);
            }
            else
            {
                // Handle the case where the item with the provided ID is not found.
                throw new InvalidOperationException($"Item with ID {id} not found.");
            }
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getAll()
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();

            List<TravelExpensesDTO> descDataset = new List<TravelExpensesDTO>(dataset);

            if (dataset.First().id == descDataset.First().id)
            {
                descDataset.Reverse(); // Reverse the list in-place
            }

            return descDataset;
        }

        /// <inheritdoc />
        public TravelExpensesDTO getByID(int id)
        {
            List<TravelExpensesDTO> list = ds.GetDataset();
            return list.FirstOrDefault(x => x.id == id);
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getByName(string name)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            return dataset.Where(instance =>
                instance.ref_number.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getByRefNumber(string refNumber)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            return dataset.Where(instance =>
                instance.ref_number.Equals(refNumber, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        /// <inheritdoc />
        public void Insert(TravelExpensesDTO travelExpense)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();

            // Generate a unique ID for the new record
            int newId = dataset.Any() ? dataset.Max(item => item.id) + 1 : 1;

            // Set the ID of the new record
            travelExpense.id = newId;

            // Add the new record to the dataset
            dataset.Add(travelExpense);

            // Commit the dataset
            ds.Commit(dataset);
        }

        /// <inheritdoc />
        public void Update(TravelExpensesDTO travelExpense)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            var updateItem = dataset.FirstOrDefault(x => x.id == travelExpense.id);

            if (updateItem != null)
            {
                PropertyInfo[] properties = typeof(TravelExpensesDTO).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.CanWrite)
                    {
                        object value = property.GetValue(travelExpense);

                        if (value != null && (!property.PropertyType.Equals(typeof(string)) || !string.IsNullOrEmpty((string)value)))
                        {
                            property.SetValue(updateItem, value);
                        }
                    }
                }

                ds.Commit(dataset);
            }
            else
            {
                // Handle the case where the item with the provided ID is not found.
                throw new InvalidOperationException($"Item with ID {travelExpense.id} not found.");
            }
        }
    }
}
